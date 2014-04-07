using System;
using System.Windows.Forms;

namespace RedisManagementStudio.BLL.Redis.Keys
{
  /// <summary>
  /// Affiche un groupe de clés
  /// </summary>
  public partial class KeyGroup : UserControl
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="KeyGroup" />
    /// </summary>
    public KeyGroup()
    {
      this.InitializeComponent();
      this.lblTitre.Text = Properties.Resources.KeyGroupTitreT;
      this.colCle.Text = Properties.Resources.KeyGroupColCle;
      this.colType.Text = Properties.Resources.KeyGroupColType;
      this.lblPoids.Text = string.Empty;
    }

    #region Interface publique
    /// <summary>
    /// Notifie un changement de sélection au parent
    /// </summary>
    public event EventHandler OnChange;

    /// <summary>
    /// L'interface de recherche de clés
    /// </summary>
    public KeySearch KeySearcher { get; set; }

    /// <summary>
    /// Défini la connexion à utiliser
    /// </summary>
    public RedisConnection Connection { get; set; }
        
    /// <summary>
    /// L'image list à utiliser
    /// </summary>
    public ImageList ImageList
    {
      get
      {
        return this.lstNodes.SmallImageList;
      }

      set
      {
        this.lstNodes.SmallImageList = value;
      }
    }
    
    /// <summary>
    /// le noeud sélectionné
    /// </summary>
    public TreeNode Selection
    {
      get
      {
        if (this.lstNodes.SelectedItems.Count == 0)
        {
          return null;
        }
        else
        {
          return this.GetTreeNode(this.lstNodes.SelectedItems[0]);
        }
      }
      
      set
      {
        this.lstNodes.BeginUpdate();
        this.lstNodes.Items.Clear();
        if (value != null)
        { // y a quelque chose
          int n = 0;
          ListViewItem itx;
          ETypeKey tk = ETypeKey.Tnone;
          string t;
          foreach (TreeNode node in value.Nodes)
          {
            itx = new ListViewItem(node.Text);
            itx.ImageKey = node.ImageKey;
            itx.Tag = node.Tag;
            t = node.ImageKey;
            if (t == "Groupe")
            {
              t = "Folder";
            }
            else if (t.StartsWith("G"))
            {
              t = t.Substring(1);
            }

            this.lstNodes.Items.Add(itx);
            
            // information suppémentaire le type
            tk = (ETypeKey)Enum.Parse(typeof(ETypeKey), t);
            itx.SubItems.Add(tk.GetLibelle());
            n++;
          }

          if (n == 0)
          {
            this.lblCount.Text = Properties.Resources.KeyGroupCountCle0; 
          }
          else if (n == 1)
          {
            this.lblCount.Text = Properties.Resources.KeyGroupCountCle1; 
          }
          else
          {
            this.lblCount.Text = string.Format(Properties.Resources.KeyGroupCountCleN, n);
          }

          this.lblDescription.Text = tk.GetLongLibelle();
        }
        else
        {
          this.lblCount.Text = string.Empty;
          this.lblDescription.Text = string.Empty;
        }
        
        this.lstNodes.EndUpdate();
        this.GereBoutons();
      }
    }

    /// <summary>
    /// Charge les paramètres le l'objet
    /// </summary>
    public void LoadProperties()
    {
      this.colCle.Width = Properties.Settings.Default.KeyGroupColCle;
      this.colType.Width = Properties.Settings.Default.KeyGroupColType;
    }

    /// <summary>
    /// Enregistre les paramètre de l'objet
    /// </summary>
    public void SaveProperties()
    {
      Properties.Settings.Default.KeyGroupColCle = this.colCle.Width;
      Properties.Settings.Default.KeyGroupColType = this.colType.Width;
    }
    #endregion

    #region Internal events
    /// <summary>
    /// Event double CLICK sur un noeud ==> notifier le parent
    /// </summary>
    /// <param name="sender">qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void LstNodesDoubleClick(object sender, EventArgs e)
    {
      if (this.OnChange != null)
      {
        this.OnChange(this, new EventArgs());
      }
    }

    /// <summary>
    /// Trie des données
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre de tri</param>
    private void LstNodesColumnClick(object sender, ColumnClickEventArgs e)
    {
      if (this.lstNodes.ListViewItemSorter == null)
      {
        this.lstNodes.ListViewItemSorter = new ListViewTextSorter(e.Column);
      }
      else
      {
        ((ListViewTextSorter)this.lstNodes.ListViewItemSorter).Change(e.Column);
      }

      this.lstNodes.Sort();
    }

    /// <summary>
    /// Changement de sélection
    /// </summary>
    /// <param name="sender">qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void LstNodesSelectedIndexChanged(object sender, EventArgs e)
    {
      this.GereBoutons();
    }

    /// <summary>
    /// Ajoute une clé
    /// </summary>
    /// <param name="sender">qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtAddKeyClick(object sender, EventArgs e)
    {
      FAddKey.ProcessAdd(this.Connection, this);
    }

    /// <summary>
    /// Calcule le poids des clés sélectionnées
    /// </summary>
    /// <param name="sender">qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtSizeOfClick(object sender, EventArgs e)
    {
      if (this.lstNodes.SelectedItems.Count == 0)
      { // pas de sélection  pas bonne pas de calcul (au cas ou)
        return;
      }

      long size = 0;
      int nombreKey = 0;
      CommandMenu menu;

      foreach (ListViewItem itx in this.lstNodes.SelectedItems)
      {
        menu = itx.Tag as CommandMenu;
        if (menu != null && menu.Key != null)
        {
          size += menu.Key.Size(this.Connection);
          nombreKey += menu.Key.Nombre;
        }
      }

      string txt, sizeTxt;

      if (size == 0)
      {
        txt = Properties.Resources.KeyExplorerBtSizeOfConfirmD0;
        sizeTxt = Properties.Resources.KeySize0;
      }
      else
      {
        sizeTxt = InformationBase.GetCounterBit(size);
        if (nombreKey > 1)
        {
          txt = string.Format(Properties.Resources.KeyExplorerBtSizeOfConfirmDNN, sizeTxt, nombreKey);
        }
        else
        {
          txt = string.Format(Properties.Resources.KeyExplorerBtSizeOfConfirmDN1, sizeTxt);
        }
      }

      this.lblPoids.Text = sizeTxt;
      MessageBox.Show(this, txt, Properties.Resources.KeyExplorerBtSizeOfConfirmT, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    /// <summary>
    /// Supprime les clés sélectionnées
    /// </summary>
    /// <param name="sender">qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtDelKeyClick(object sender, EventArgs e)
    {
      if (this.lstNodes.SelectedItems.Count == 0 || this.KeySearcher == null)
      { // pas de sélection pas de suppression, pas d'outil de recherche câblé 
        return;
      }

      // Compter les clés qui vont être supprimées
      int nombreKey = 0;
      CommandMenu menu;
      foreach (ListViewItem itx in this.lstNodes.SelectedItems)
      {
        menu = itx.Tag as CommandMenu;
        if (menu != null && menu.Key != null)
        {
          nombreKey += menu.Key.Nombre;
        }
      }

      string message = nombreKey > 1 ? string.Format(Properties.Resources.KeyGroupBtDelKeyConfirmDN, nombreKey) : Properties.Resources.KeyExplorerBtDelKeyConfirmD;
      string titre = nombreKey > 1 ? Properties.Resources.KeyGroupBtDelKeyConfirmTN : Properties.Resources.KeyExplorerBtDelKeyConfirmT;
      if (MessageBox.Show(this, message, titre, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
      { // Validé par le user
        int nombreToDel = this.lstNodes.SelectedItems.Count; // pour savoir quand on détruit la dernière clé (pour lancer l'envent de refresh)
        foreach (ListViewItem itx in this.lstNodes.SelectedItems)
        {
          menu = itx.Tag as CommandMenu;
          if (menu != null && menu.Key != null)
          {
            if (menu.Key.Del(this.Connection) > 0)
            {
              this.KeySearcher.RemoveKey(menu.Key, nombreToDel == 1);
              this.lstNodes.Items.Remove(itx);
            }
          }

          nombreToDel--; // une de moins (normalement !!)
        }

        this.GereBoutons();
      }
    }
    #endregion

    #region Privates
    /// <summary>
    /// Gestion de l'activation des boutons
    /// </summary>
    private void GereBoutons()
    {
      this.btDelKey.Enabled = this.lstNodes.SelectedItems.Count > 0;
      this.btSizeOf.Enabled = this.lstNodes.SelectedItems.Count > 0;
      this.lblPoids.Text = string.Empty;
    }

    /// <summary>
    /// Renvoie un TREENODE à partir d'un listItem
    /// </summary>
    /// <param name="itx">Le listItem de départ</param>
    /// <returns>Le TREE NODE qui correspond</returns>
    private TreeNode GetTreeNode(ListViewItem itx)
    {
      TreeNode tn = new TreeNode(itx.Text);
      tn.ImageKey = itx.ImageKey;
      tn.SelectedImageKey = tn.ImageKey;
      tn.Tag = itx.Tag;
      return tn;
    }
    #endregion
  }
}
