using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RedisManagementStudio.BLL.Connection;

namespace RedisManagementStudio.BLL.UI
{
  /// <summary>
  /// interface de propriété d'un dossier de connexions
  /// </summary>
  public partial class FFolder : Form
  {
    /// <summary>
    /// L'objet métier
    /// </summary>
    private ConnectionFolder myFld = null;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="FFolder" />.
    /// </summary>
    public FFolder()
    {
      this.InitializeComponent();
      this.Text = Properties.Resources.FFolderT;
      this.btOk.Text = Properties.Resources.BtSaveT;
      this.btCancel.Text = Properties.Resources.BtCancelT;
      this.label1.Text = Properties.Resources.FFolderLbl1T;
      this.label2.Text = Properties.Resources.FFolderLbl2T;
      this.label3.Text = Properties.Resources.FFolderLbl3T;
      this.label4.Text = Properties.Resources.FFolderLbl4T;
    }

    /// <summary>
    /// Défini ou renvoie l'objet métier
    /// </summary>
    public ConnectionFolder Folder
    {
      get
      {
        if (this.myFld == null)
        {
          this.myFld = new ConnectionFolder();
        }

        this.myFld.Name = this.txtName.Text;
        this.myFld.Description = this.txtDescription.Text;
        return this.myFld;
      }

      set
      {
        this.myFld = value;
        this.txtName.Text = this.myFld.Name;
        this.txtDescription.Text = this.myFld.Description;
        this.GereBouton();
      }
    }

    /// <summary>
    /// Défini la liste des dossiers pour ce dossier
    /// </summary>
    public TreeNodeCollection Tree
    {
      set
      {
        this.tvParent.Nodes.Clear();
        foreach (TreeNode nod in value)
        {
          this.tvParent.Nodes.Add(this.CloneNode(nod));
        }
      }
    }

    /// <summary>
    /// Renvoie le PARENT FOLDER FULL PATH
    /// </summary>
    public string ParentFolderFullPath
    {
      get
      {
        if (this.tvParent.SelectedNode == null)
        {
          return string.Empty;
        }
        else
        {
          return this.tvParent.SelectedNode.FullPath;
        }
      }

      set
      {
        foreach (TreeNode nod in this.tvParent.Nodes)
        {
          if (nod.FullPath == value)
          {
            this.tvParent.SelectedNode = nod;
            this.tvParent.SelectedNode.EnsureVisible();
            return;
          }

          if (this.Selectionne(nod.Nodes, value))
          {
            return;
          }
        }
      }
    }

    /// <summary>
    /// Chargement de la page
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void FFolder_Load(object sender, EventArgs e)
    {
      this.Location = Properties.Settings.Default.FFolderPosition;
      this.Size = Properties.Settings.Default.FFolderDimension;
      this.GereBouton();
    }

    /// <summary>
    /// Fermeture de la fenêtre
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void FFolder_FormClosed(object sender, FormClosedEventArgs e)
    {
      Properties.Settings.Default.FFolderPosition = this.Location;
      Properties.Settings.Default.FFolderDimension = this.Size;
      Properties.Settings.Default.Save();
    }

    /// <summary>
    /// Changement des textes
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void TxtTextChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }

    /// <summary>
    /// Changement dans le choix du dossier racine
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void TvParentAfterSelect(object sender, TreeViewEventArgs e)
    {
      this.GereBouton();
    }

    /// <summary>
    /// Validation de l'interface
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtOkClick(object sender, EventArgs e)
    {
      if (string.IsNullOrWhiteSpace(this.txtName.Text))
      {
        return;
      }

      this.DialogResult = DialogResult.OK;
    }

    /// <summary>
    /// Copie du noeud
    /// </summary>
    /// <param name="nod">noeud d'origine</param>
    /// <returns>le noeud cloné</returns>
    private TreeNode CloneNode(TreeNode nod)
    {
      TreeNode rac = new TreeNode();
      rac.Text = nod.Text;
      rac.ImageKey = nod.ImageKey;
      rac.SelectedImageKey = nod.SelectedImageKey;
      rac.ToolTipText = nod.ToolTipText;
      rac.Expand();
      foreach (TreeNode nd in nod.Nodes)
      {
        if (nd.ImageKey == ConnectionFolder.IMGKEYFOLDER)
        {
          rac.Nodes.Add(this.CloneNode(nd));
        }
      }

      return rac;
    }

    /// <summary>
    /// Sélectionne un noeud dans une collection de TREENODES
    /// </summary>
    /// <param name="treeNodes">La collection</param>
    /// <param name="value">LA valeur à sélectionner</param>
    /// <returns>TRUE si trouvé</returns>
    private bool Selectionne(TreeNodeCollection treeNodes, string value)
    {
      foreach (TreeNode nod in treeNodes)
      {
        if (nod.FullPath == value)
        {
          this.tvParent.SelectedNode = nod;
          this.tvParent.SelectedNode.EnsureVisible();
          return true;
        }

        bool ok = this.Selectionne(nod.Nodes, value);
        if (ok)
        {
          return ok;
        }
      }

      return false;
    }

    /// <summary>
    /// Gère l'activation des boutons
    /// </summary>
    private void GereBouton()
    {
      this.btOk.Enabled = !string.IsNullOrWhiteSpace(this.txtName.Text);
    }
  }
}
