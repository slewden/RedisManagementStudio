using System;
using System.Windows.Forms;
using RedisManagementStudio.BLL.Connection;

namespace RedisManagementStudio.BLL.UI
{
  /// <summary>
  /// Fenêtre d'importe des chaines de connexion
  /// </summary>
  public partial class FImportExport : Form
  {
    /// <summary>
    /// On est en import ou export ?
    /// </summary>
    private bool isImport = false;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="FImportExport" />.
    /// </summary>
    public FImportExport()
    {
      this.InitializeComponent();
      this.Text = Properties.Resources.FimportExportTImport;
      this.btCancel.Text = Properties.Resources.BtCancelT;
      this.btOk.Text = Properties.Resources.BtOkT;
      this.saveFileDialog1.Filter = Properties.Resources.FimportExportOpenFileFilter;
      this.saveFileDialog1.Title = Properties.Resources.FimportExportOpenFileTImport;
    }

    /// <summary>
    /// Indique ou défini si on est en import ou export
    /// </summary>
    public bool IsImport
    {
      private get
      {
        return this.isImport;
      }

      set
      {
        this.isImport = value;

        if (this.isImport)
        { // import
          this.Text = Properties.Resources.FimportExportTImport;
          this.lblTitre.Text = Properties.Resources.FImportExportLblTitreTImport;
          this.lblGroupe.Text = Properties.Resources.FImportExportLblGroupeTImport;
          this.lblFile.Text = Properties.Resources.FimportExportOpenFileTImport;
          this.pnlFile.Dock = DockStyle.Top;
        }
        else
        { // export
          this.Text = Properties.Resources.FimportExportTExport;
          this.lblTitre.Text = Properties.Resources.FImportExportLblTitreTExport;
          this.lblGroupe.Text = Properties.Resources.FImportExportLblGroupeTExport;
          this.lblFile.Text = Properties.Resources.FimportExportOpenFileTExport;
          this.pnlFile.Dock = DockStyle.Bottom;
        }
      }
    }

    /// <summary>
    /// Défini le noeud des connexions à exporter ou sur lequel importer
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
    /// défini le PARENT FOLDER FULL PATH
    /// </summary>
    public string ParentFolderFullPath
    {
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
    private void FImportExport_Load(object sender, EventArgs e)
    {
      this.Location = Properties.Settings.Default.FImportExportPosition;
      this.Size = Properties.Settings.Default.FImportExportDimension;
      this.GereBouton();
    }

    /// <summary>
    /// Fermeture de la page
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void FImportExport_FormClosed(object sender, FormClosedEventArgs e)
    {
      Properties.Settings.Default.FImportExportPosition = this.Location;
      Properties.Settings.Default.FImportExportDimension = this.Size;
      Properties.Settings.Default.Save();
    }

    /// <summary>
    /// Sélection d'un noeud
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void TvParentAfterSelect(object sender, TreeViewEventArgs e)
    {
      this.GereBouton();
    }

    /// <summary>
    /// Choix d'un fichier
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtBrowseClick(object sender, EventArgs e)
    {
      if (this.IsImport)
      { // import de fichier == File Open
        this.openFileDialog1.FileName = this.txtFileName.Text;
        if (this.openFileDialog1.ShowDialog(this) == DialogResult.OK)
        {
          this.txtFileName.Text = this.openFileDialog1.FileName;
          this.GereBouton();
        }
      }
      else
      {  // export de fichier == File Save
        this.saveFileDialog1.FileName = this.txtFileName.Text;
        if (this.saveFileDialog1.ShowDialog(this) == DialogResult.OK)
        {
          this.txtFileName.Text = this.saveFileDialog1.FileName;
          this.GereBouton();
        }
      }
    }

    /// <summary>
    /// Changement du nom du fichier
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void TxtFileNameTextChanged(object sender, EventArgs e)
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
      if (this.tvParent.SelectedNode == null)
      { // pas d'emplacement d'ou exporter ou ou importer
        return;
      }

      if (string.IsNullOrWhiteSpace(this.txtFileName.Text))
      { // pas de nom de fichier
        return;
      }

      if (this.IsImport && !System.IO.File.Exists(this.txtFileName.Text))
      { // En import uniquement le nom du fichier doit exister 
        return;
      }

      this.Enabled = false;
      this.tvParent.Enabled = false;
      this.txtFileName.Enabled = false;
      this.btBrowse.Enabled = false;
      this.btOk.Enabled = false;
      Application.DoEvents();

      if (this.isImport)
      { // traite l'import
        ConnectionFolder fld = new ConnectionFolder();
        if (System.IO.File.Exists(this.txtFileName.Text))
        { // Phase 1 on charge le fichier dans un treeNode
          string err = fld.Load(this.txtFileName.Text);
          if (string.IsNullOrWhiteSpace(err))
          { // pas d'erreur on continue 
            TreeNode rac = fld.GetFolder(null); // on n'a pas besoin des context menu ici
            if (this.tvParent.SelectedNode.ImageKey == ConnectionFolder.IMGKEYCONNECTION)
            { // un connexion => on prend le père
              this.tvParent.SelectedNode.Parent.Nodes.Add(rac);
            }
            else
            { // un dossier 
              this.tvParent.SelectedNode.Nodes.Add(rac);
            }

            // Phase 2 on réécrit le tout dans le fichier de l'application
            err = ConnectionFolder.ConnectionsSynchroniseAndSave(ConnectionFolder.FileConfig, this.tvParent.Nodes[0]);
            if (!string.IsNullOrEmpty(err))
            {
              MessageBox.Show(this, err, Properties.Resources.FImportExportBtOkConfirmTImport, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          }
        }
        else
        { // le fichier n'existe pas
          MessageBox.Show(this, Properties.Resources.FImportExportBtOkConfirmDErrImport, Properties.Resources.FImportExportBtOkConfirmTImport, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        this.DialogResult = DialogResult.OK; // on met Ok pour force le parent à re-remplir la liste 
      }
      else
      { // traite l'export
        string err = ConnectionFolder.ConnectionsSynchroniseAndSave(this.txtFileName.Text, this.tvParent.SelectedNode);
        if (string.IsNullOrWhiteSpace(err))
        {
          MessageBox.Show(this, Properties.Resources.FImportExportBtOkConfirmDOkExport, Properties.Resources.FImportExportBtOkConfirmTExport, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        { // problème d'export
          MessageBox.Show(this, err, Properties.Resources.FImportExportBtOkConfirmTExport, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        this.DialogResult = DialogResult.Yes; // on ne met pas Ok pour eviter de re-remplir la liste qui n'a pas changée
      }
    }

    /// <summary>
    /// Duplique un noeud
    /// </summary>
    /// <param name="nod">le noeud source</param>
    /// <returns>le noeud cloné</returns>
    private TreeNode CloneNode(TreeNode nod)
    {
      TreeNode rac = new TreeNode();
      rac.Text = nod.Text;
      rac.ImageKey = nod.ImageKey;
      rac.SelectedImageKey = nod.SelectedImageKey;
      rac.ToolTipText = nod.ToolTipText;
      rac.Tag = nod.Tag;
      rac.Expand();
      foreach (TreeNode nd in nod.Nodes)
      {
        rac.Nodes.Add(this.CloneNode(nd));
      }

      return rac;
    }

    /// <summary>
    /// Sélectionne le noeud value dans la collection TREENODES
    /// </summary>
    /// <param name="treeNodes">La collection dans laquelle sélectionner</param>
    /// <param name="value">la valeur à sélectionner</param>
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
    /// Gere l'activation des boutons de l'écran
    /// </summary>
    private void GereBouton()
    {
      // il faut un emplacement d'ou exporter ou ou importer
      bool ok = this.tvParent.SelectedNode != null;

      // il faut un nom de fichier
      bool ok2 = !string.IsNullOrWhiteSpace(this.txtFileName.Text);

      bool ok3 = true;
      if (this.IsImport)
      { // En import uniquement le nom du fichier doit exister 
        ok3 = System.IO.File.Exists(this.txtFileName.Text);
      }

      this.btOk.Enabled = ok && ok2 && ok3;
    }
  }
}
