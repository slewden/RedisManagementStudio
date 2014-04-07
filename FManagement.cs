using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using RedisManagementStudio.BLL.Connection;
using RedisManagementStudio.BLL.Redis;
using RedisManagementStudio.BLL.UI;

namespace RedisManagementStudio
{
  /// <summary>
  /// Fenêtre de lancement des connexions
  /// </summary>
  public partial class FManagement : Form
  {
    /// <summary>
    /// Indicateur du flag de sauvegarde
    /// </summary>
    private bool fileConnexionIsDirty = false;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="FManagement" />.
    /// </summary>
    public FManagement()
    {
      this.InitializeComponent();
      this.Text = Properties.Resources.FManagementT; 
      this.mnuConnect.Text = Properties.Resources.FManagementMnuConnectT;
      this.mnuNew.Text = Properties.Resources.FManagementMnuNewT;
      this.mnuNewConnection.Text = Properties.Resources.FManagementMnuConnectionT;
      this.mnuDel.Text = Properties.Resources.FManagementMnuDelT;
      this.mnuExport.Text = Properties.Resources.FManagementMnuExportT;
      this.mnuImport.Text = Properties.Resources.FManagementMnuImportT;
      this.mnuProperty.Text = Properties.Resources.FManagementMnuPropertyT;
      this.lblTitre.Text = Properties.Resources.FManagementLblTitreT;
      this.lblTips.Text = Properties.Resources.FManagementLblTipsT;
      this.btQuit.Text = Properties.Resources.FManagementBtQuitT;
      this.btConnect.Text = Properties.Resources.FManagementBtConnectT;
      this.btAddConnection.Text = Properties.Resources.FManagementBtAddConnectionT;
    }

    #region Events
    /// <summary>
    /// Chargement de la fenêtre
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void FManagement_Load(object sender, EventArgs e)
    {
      this.Location = Properties.Settings.Default.FManagementPosition;
      this.Size = Properties.Settings.Default.FManagementDimension;

      this.lblDetail.BackColor = Color.Transparent;
      this.lblDetail2.BackColor = Color.Transparent;

      this.lblTitre.BackColor = Color.Transparent;
      this.lblTips.BackColor = Color.Transparent;

      this.ConnectionsLoadAndFill();
      this.GereBoutons();
    }

    /// <summary>
    /// Fin de l'application
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void FManagement_FormClosed(object sender, FormClosedEventArgs e)
    {
      this.ConnectionsSynchroniseAndSave();
      if (this.WindowState == FormWindowState.Normal)
      {
        Properties.Settings.Default.FManagementPosition = this.Location;
        Properties.Settings.Default.FManagementDimension = this.Size;
      }
      else
      {
        Properties.Settings.Default.FManagementPosition = this.RestoreBounds.Location;
        Properties.Settings.Default.FManagementDimension = this.RestoreBounds.Size;
      }

      Properties.Settings.Default.Save();
    }

    /// <summary>
    /// Trace l'image de fond
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">paramètres de dessin</param>
    private void Panel1Paint(object sender, PaintEventArgs e)
    {
      Image image = Properties.Resources.ServerLight;
      Rectangle r = new Rectangle(0, 0, this.panel1.Width, this.panel1.Height);
      e.Graphics.DrawImage(image, r);
    }

    /// <summary>
    /// Trace l'image de fond
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">paramètres de dessin</param>
    private void Panel2Paint(object sender, PaintEventArgs e)
    {
      Image image = Properties.Resources.Version;
      Rectangle r = new Rectangle(this.panel2.Width - image.Width, (this.panel2.Height - image.Height) / 2, image.Width, image.Height);
      e.Graphics.DrawImage(image, r);
    }

    /// <summary>
    /// Quitter l'application
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtQuitClick(object sender, EventArgs e)
    {
      this.Close();
    }

    #region TreeView
    /// <summary>
    /// Changement de Sélection
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void TreeView1AfterSelect(object sender, TreeViewEventArgs e)
    {
      this.GereBoutons();
    }

    /// <summary>
    /// Double CLICK ==> connexion directe
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void TreeView1DoubleClick(object sender, EventArgs e)
    {
      if (this.treeView1.SelectedNode != null)
      {
        this.MnuConnectClick(sender, e);
      }
    }

    /// <summary>
    /// CLICK sur un noeud du TREEVIEW des connexions : On s'assure que le noeud est sélectionné
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void TreeView1NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
      if (e.Button == System.Windows.Forms.MouseButtons.Right)
      {
        this.treeView1.SelectedNode = e.Node;
      }
    }
    #endregion

    #region Menu
    /// <summary>
    /// Apparition du menu contextuel des connexions
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void ContextMenuStrip1Opening(object sender, CancelEventArgs e)
    {
      TreeNode nod = this.treeView1.SelectedNode;
      if (nod != null)
      { // y a bien un node de sélectionné
        bool isConnection = nod.ImageKey == ConnectionFolder.IMGKEYCONNECTION;
        bool isNotRacine = nod.Parent != null;
        this.mnuConnect.Visible = isConnection;
        this.mnuDel.Enabled = isNotRacine;
        this.mnuEmpty3.Visible = isNotRacine;
        this.mnuProperty.Visible = isNotRacine;
      }
      else
      { // annuler l'apparition du menu
        e.Cancel = true;
      }
    }

    /// <summary>
    /// Activation de la connexion 
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void MnuConnectClick(object sender, EventArgs e)
    {
      if (this.treeView1.SelectedNode == null)
      { // pas de sélection ==> on sort
        return;
      }

      if (this.treeView1.SelectedNode.ImageKey != ConnectionFolder.IMGKEYCONNECTION)
      { // on n'est pas sur une connexion ==> on sort
        return;
      }

      RedisConnectionParam cnnParam = this.treeView1.SelectedNode.Tag as RedisConnectionParam;
      if (cnnParam == null)
      { // pour une raison inconnu pas l'info ==> on sort
        return;
      }

      Cursor cur = this.Cursor;
      this.Cursor = Cursors.WaitCursor;
      Application.DoEvents();
      try
      {
        using (RedisConnection cnn = new RedisConnection(cnnParam))
        {
          if (cnn.Connector.Ping())
          { // Le serveur répond
            if (cnn.Connector.ServerVersionIsHigherThan240)
            { // la version est supérieure à 2.4
              this.Cursor = cur;
              using (FRedisUtil frm = new FRedisUtil())
              {
                frm.Connection = cnn;
                this.Hide();
                frm.ShowDialog(this);
                this.Show();
              }
            }
            else
            { // problème de version
              this.Cursor = cur;
              MessageBox.Show(this, string.Format(Properties.Resources.FManagementBtConnectErrVersionD, cnn.Connector.ServerVersionTxt), Properties.Resources.FManagementBtConnectErrVersionT, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          }
          else
          { // le serveur ne répond pas
            this.Cursor = cur;
            MessageBox.Show(this, Properties.Resources.FManagementBtConnectErrD, Properties.Resources.FManagementBtConnectErrT, MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
      }
      finally
      {
        this.Cursor = cur;
      }
    }

    /// <summary>
    /// Nouveau dossier
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void MnuNewFolderClick(object sender, EventArgs e)
    {
      using (FFolder frm = new FFolder())
      {
        ConnectionFolder fld = new ConnectionFolder();
        frm.Tree = this.treeView1.Nodes;
        frm.ParentFolderFullPath = this.GetFullPath(this.treeView1.SelectedNode);
        frm.Folder = fld;
        if (frm.ShowDialog(this) == DialogResult.OK)
        {
          TreeNode parent = this.FindFolder(frm.ParentFolderFullPath);
          TreeNode nod = frm.Folder.GetFolder(this.contextMenuStrip1);
          if (parent != null)
          {
            parent.Nodes.Add(nod);
          }
          else
          {
            this.treeView1.Nodes.Add(nod);
          }

          this.fileConnexionIsDirty = true;
          this.treeView1.SelectedNode = nod;
          this.treeView1.SelectedNode.EnsureVisible();
          this.ConnectionsSynchroniseAndSave();
        }
      }
    }

    /// <summary>
    /// Nouvelle connexion
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void MnuNewConnectionClick(object sender, EventArgs e)
    {
      using (FConnexion frm = new FConnexion())
      {
        RedisConnectionParam cnn = new RedisConnectionParam();
        frm.Connexion = cnn;
        if (frm.ShowDialog(this) == DialogResult.OK)
        {
          TreeNode parent = this.FindFolder(this.treeView1.SelectedNode.FullPath);
          TreeNode nod = frm.Connexion.GetConnection(this.contextMenuStrip1);
          if (parent != null)
          {
            parent.Nodes.Add(nod);
          }
          else
          {
            this.treeView1.Nodes.Add(nod);
          }

          this.fileConnexionIsDirty = true;
          this.treeView1.SelectedNode = nod;
          this.treeView1.SelectedNode.EnsureVisible();
          this.ConnectionsSynchroniseAndSave();
        }
      }
    }

    /// <summary>
    /// Suppression d'un élément
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void MnuDelClick(object sender, EventArgs e)
    {
      if (this.treeView1.SelectedNode == null)
      {
        return;
      }

      TreeNode parent = this.treeView1.SelectedNode.Parent;
      if (parent != null)
      { // on ne supprimer jamais la racine
        string message;
        if (this.treeView1.SelectedNode.ImageKey == ConnectionFolder.IMGKEYFOLDER)
        { // supression d'un dossier
          message = string.Format(Properties.Resources.FManagementBtDelConfirmDGroupe, this.treeView1.SelectedNode.Text);
          if (MessageBox.Show(this, message, Properties.Resources.FManagementBtDelConfirmT, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
          { // c'est confirmé
            this.fileConnexionIsDirty = true;
            this.treeView1.SelectedNode.Remove();
            this.treeView1.SelectedNode = parent;
            this.treeView1.SelectedNode.EnsureVisible();
            this.ConnectionsSynchroniseAndSave();
          }
        }
        else if (this.treeView1.SelectedNode.ImageKey == ConnectionFolder.IMGKEYCONNECTION)
        { // supression d'une connexion
          message = string.Format(Properties.Resources.FManagementBtDelConfirmDConnexion, this.treeView1.SelectedNode.Text);
          if (MessageBox.Show(this, message, Properties.Resources.FManagementBtDelConfirmT, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
          { // c'est confirmé
            this.fileConnexionIsDirty = true;
            this.treeView1.SelectedNode.Remove();
            this.treeView1.SelectedNode = parent;
            this.treeView1.SelectedNode.EnsureVisible();
            this.ConnectionsSynchroniseAndSave();
          }
        }
      }
    }

    /// <summary>
    /// Export des connexions
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void MnuExportClick(object sender, EventArgs e)
    {
      this.ProcessImportExport(false, this.treeView1.SelectedNode);
    }

    /// <summary>
    /// Import des connexions
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void MnuImportClick(object sender, EventArgs e)
    {
      this.ProcessImportExport(true, this.treeView1.SelectedNode);
    }

    /// <summary>
    /// Détail de l'élément sélectionné
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void MnuPropertyClick(object sender, EventArgs e)
    {
      if (this.treeView1.SelectedNode == null)
      {
        return;
      }

      if (this.treeView1.SelectedNode.ImageKey == ConnectionFolder.IMGKEYFOLDER)
      {
        this.DisplayPropertyFolder(this.treeView1.SelectedNode);
      }
      else if (this.treeView1.SelectedNode.ImageKey == ConnectionFolder.IMGKEYCONNECTION)
      {
        this.DisplayPropertyConnection(this.treeView1.SelectedNode);
      }
    }
    #endregion
    #endregion

    /// <summary>
    /// Gère l'activation des boutons
    /// </summary>
    private void GereBoutons()
    {
      if (this.treeView1.SelectedNode != null && this.treeView1.SelectedNode.ImageKey == ConnectionFolder.IMGKEYCONNECTION)
      {
        this.btConnect.Enabled = true;
        this.lblDetail.Text = this.treeView1.SelectedNode.Text + " :";
        this.lblDetail2.Text = this.treeView1.SelectedNode.ToolTipText;
      }
      else
      {
        this.btConnect.Enabled = false;
        this.lblDetail.Text = string.Empty;
        this.lblDetail2.Text = string.Empty;
      }
    }

    #region Gestion de la liste des connexion de dossiers
    /// <summary>
    /// Charge le fichier des connexion et l'affiche
    /// </summary>
    private void ConnectionsLoadAndFill()
    {
      this.treeView1.Nodes.Clear();

      ConnectionFolder fld = new ConnectionFolder();
      if (System.IO.File.Exists(ConnectionFolder.FileConfig))
      {
        string err = fld.Load(ConnectionFolder.FileConfig);
        if (!string.IsNullOrWhiteSpace(err))
        { // erreur au reload des infos ==> RAZ
          MessageBox.Show(err, Properties.Resources.FManagementImportErrT, MessageBoxButtons.OK, MessageBoxIcon.Error);
          this.MakeFolderRacine();
        }
        else
        {
          TreeNode rac = fld.GetFolder(this.contextMenuStrip1);
          this.treeView1.Nodes.Add(rac);
          this.fileConnexionIsDirty = false;
        }
      }
      else
      { // Créer le père 
        this.MakeFolderRacine();
      }
    }

    /// <summary>
    /// Cree un dossier vide lorsqu'il n'y a pas de fichier de connexion
    /// </summary>
    private void MakeFolderRacine()
    {
      this.treeView1.Nodes.Clear();
      ConnectionFolder fld = new ConnectionFolder();
      fld.Name = Properties.Resources.FManagemenFolderRacineT;
      TreeNode rac = fld.GetFolder(this.contextMenuStrip1);
      this.treeView1.Nodes.Add(rac);
      this.fileConnexionIsDirty = true;
    }

    /// <summary>
    /// Retrouve le TREENODE dont le FULLPATH est celui passé en paramètre
    /// </summary>
    /// <param name="fullPath">Chemin complet</param>
    /// <returns>Le TREENODE</returns>
    private TreeNode FindFolder(string fullPath)
    {
      return this.FindFolder(this.treeView1.Nodes, fullPath);
    }

    /// <summary>
    /// Retrouve le TREENODE dans la collection TREENODECOLLECTION dont le FULLPATH est celui passé en paramètre
    /// </summary>
    /// <param name="treeNodeCollection">La collection dans laquelle chercher</param>
    /// <param name="fullPath">Chemin complet</param>
    /// <returns>Le TREENODE</returns>
    private TreeNode FindFolder(TreeNodeCollection treeNodeCollection, string fullPath)
    {
      foreach (TreeNode nod in treeNodeCollection)
      {
        if (nod.FullPath == fullPath)
        {
          return nod;
        }

        TreeNode nx = this.FindFolder(nod.Nodes, fullPath);
        if (nx != null)
        { // trouvé dans les fils on sort
          return nx;
        }
      }

      return null;
    }

    /// <summary>
    /// Sauvegarde la liste des connexion et groupe (SSI elle a changé)
    /// </summary>
    private void ConnectionsSynchroniseAndSave()
    {
      if (this.fileConnexionIsDirty)
      { // on ne sauve que si le fichie a été modifié
        ConnectionFolder.ConnectionsSynchroniseAndSave(ConnectionFolder.FileConfig, this.treeView1.Nodes[0]);
        this.fileConnexionIsDirty = false;
      }
    }

    /// <summary>
    /// Renvoie le FULLPATH du TREENODE Courant =
    /// le sélectionné si c'est un dossier
    /// le parent du sélectionné si c'est une connexion
    /// le 1er TREENODE sinon
    /// NULL si y a rien !
    /// </summary>
    /// <param name="nod">Le noeud de départ</param>
    /// <returns>Le FULLPATH du noeud</returns>
    private string GetFullPath(TreeNode nod)
    {
      if (this.treeView1.Nodes.Count == 0)
      { // pas de bras... pas de chocolat
        return string.Empty;
      }

      if (nod == null)
      { // le premier
        return this.treeView1.Nodes[0].FullPath;
      }
      else if (nod.ImageKey == ConnectionFolder.IMGKEYCONNECTION)
      { // pour les connections on prend le parent
        if (nod.Parent == null)
        { // au cas ou ??
          return this.treeView1.Nodes[0].FullPath;
        }
        else
        { // la connexion à bien un parent
          return nod.Parent.FullPath;
        }
      }
      else
      { // on est sur un dossier
        return nod.FullPath;
      }
    }

    /// <summary>
    /// Affiche les propriétés d'un groupe
    /// </summary>
    /// <param name="nod">Le noeud a afficher</param>
    private void DisplayPropertyFolder(TreeNode nod)
    {
      using (FFolder frm = new FFolder())
      {
        frm.Tree = this.treeView1.Nodes;
        frm.ParentFolderFullPath = this.GetFullPath(nod.Parent);
        frm.Folder = nod.Tag as ConnectionFolder;
        if (frm.ShowDialog(this) == DialogResult.OK)
        {
          ConnectionFolder fld = frm.Folder;
          nod.Text = fld.Name;
          nod.ToolTipText = fld.Description;
          nod.Tag = fld;

          TreeNode parent = this.FindFolder(frm.ParentFolderFullPath);
          if (parent != null)
          { // changement de père
            nod.Remove();
            parent.Nodes.Add(nod);
          }

          this.fileConnexionIsDirty = true;
          this.treeView1.SelectedNode = nod;
          this.treeView1.SelectedNode.EnsureVisible();
        }
      }
    }

    /// <summary>
    /// Affiche les propriété d'une connexion
    /// </summary>
    /// <param name="nod">le noeud à afficher</param>
    private void DisplayPropertyConnection(TreeNode nod)
    {
      using (FConnexion frm = new FConnexion())
      {
        frm.Connexion = nod.Tag as RedisConnectionParam;
        if (frm.ShowDialog(this) == DialogResult.OK)
        {
          RedisConnectionParam cnn = frm.Connexion;
          nod.Text = cnn.Name;
          nod.ToolTipText = cnn.Description;
          nod.Tag = cnn;
          this.fileConnexionIsDirty = true;
          this.treeView1.SelectedNode = nod;
          this.treeView1.SelectedNode.EnsureVisible();
        }
      }
    }

    /// <summary>
    /// Action du menu Import Export
    /// </summary>
    /// <param name="isImport">Si TRUE on est en import sinon export</param>
    /// <param name="nod">Le noeud à traiter</param>
    private void ProcessImportExport(bool isImport, TreeNode nod)
    {
      using (FImportExport frm = new FImportExport())
      {
        frm.IsImport = isImport;  // doit être mis avant remplissage des folders
        frm.Tree = this.treeView1.Nodes;
        frm.ParentFolderFullPath = this.GetFullPath(nod);
        if (frm.ShowDialog(this) == DialogResult.OK)
        { // recharger le configuration
          this.ConnectionsLoadAndFill();
        }
      }
    }
    #endregion
  }
}