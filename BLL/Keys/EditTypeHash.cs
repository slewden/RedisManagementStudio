using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RedisManagementStudio.BLL.Redis;

namespace RedisManagementStudio.BLL.Keys
{
  /// <summary>
  /// Editeur de données du type Hash
  /// </summary>
  public partial class EditTypeHash : UserControl
  {
    /// <summary>
    /// Nombre de valeur max affichées
    /// </summary>
    public const int SEUIL = 2000;

    /// <summary>
    /// La clé en cours d'affichage
    /// </summary>
    private string myKey = string.Empty;

    /// <summary>
    /// Nombre de fields dans le hash
    /// </summary>
    private int nombreValeur = 0;

    /// <summary>
    /// Constructeur de la classe
    /// </summary>
    public EditTypeHash()
    {
      this.InitializeComponent();
    }

    #region Interface publique
    /// <summary>
    /// Notifie un changement au parent
    /// </summary>
    public event EventHandler OnChange;

    /// <summary>
    /// Défini la connexion à utiliser
    /// </summary>
    public RedisConnection Connection { get; set; }

    /// <summary>
    /// Renvoie ou défini la clé en cours d'édition
    /// </summary>
    public string Key
    {
      get
      {
        return this.myKey;
      }

      set
      {
        if (this.Connection == null && !string.IsNullOrWhiteSpace(value))
        {
          throw new ArgumentException("Connection not set");
        }

        if (!string.IsNullOrWhiteSpace(value))
        {
          if (this.Connection.Type(value) != ETypeKey.Thash)
          { // invalid key
            return;
          }
        }

        this.myKey = value;
        this.FillDisplay();
      }
    }

    /// <summary>
    /// Renvoie le nombre de valeurs
    /// </summary>
    public int Count
    {
      get
      {
        return this.nombreValeur;
      }
    }

    /// <summary>
    /// Enregistre les proppriétés de mise en forme du controle
    /// </summary>
    public void SaveProperties()
    {
      Properties.Settings.Default.ColWidthEditHashKey = this.colKey.Width;
      Properties.Settings.Default.ColWidthEditHashValue = this.colValue.Width;
      Properties.Settings.Default.ColWidthEditHashNew = this.splitContainer1.SplitterDistance;
    }

    /// <summary>
    /// Charge les propriété du composant
    /// </summary>
    public void LoadProperties()
    {
      this.colKey.Width = Properties.Settings.Default.ColWidthEditHashKey;
      this.colValue.Width = Properties.Settings.Default.ColWidthEditHashValue;
      this.splitContainer1.SplitterDistance = Properties.Settings.Default.ColWidthEditHashNew;
    }
    #endregion

    #region Events
    /// <summary>
    /// Changement d'élément sélectionné
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">param inutile</param>
    private void LstValuesSelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.lstValues.SelectedItems.Count > 0 && this.lstValues.SelectedItems[0].SubItems.Count > 1)
      {
        this.lblCurrentKey.Text = this.lstValues.SelectedItems[0].Text;
        this.lblCurrentValue.Text = this.lstValues.SelectedItems[0].SubItems[1].Text;
        this.txtNewKey.Text = this.lstValues.SelectedItems[0].Text;
        this.txtNewValue.Text = this.lstValues.SelectedItems[0].SubItems[1].Text;
        this.SetEditMode(true);
      }
      else
      {
        this.lblCurrentKey.Text = string.Empty;
        this.lblCurrentValue.Text = string.Empty;
        this.txtNewKey.Text = string.Empty;
        this.txtNewValue.Text = string.Empty;
        this.SetEditMode(false);
      }

      this.GereBouton();
    }

    /// <summary>
    /// Changement du texte pour une nouvelle valeur
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">param inutile</param>
    private void TxtNewValueTextChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }

    /// <summary>
    /// Suppression de la valeur en cours
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">param inutile</param>
    private void BtDeleteClick(object sender, EventArgs e)
    {
      if (MessageBox.Show(this, "Etes vous certain de vouloir supprimer cette paire clé valeur ?\n\nL'opération est irréversible.", "Confirmez la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
      {
        int n = this.Connection.Connector.HDel(this.myKey, this.lstValues.SelectedItems[0].Text);
        if (n == 1)
        {
          this.NotifyChange();
        }
      }
    }

    /// <summary>
    /// Ajoute une valeur au set
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">param inutile</param>
    private void BtAddClick(object sender, EventArgs e)
    {
      if (string.IsNullOrWhiteSpace(this.txtNewValue.Text))
      {
        return;
      }

      this.Connection.Connector.HSet(this.myKey, this.txtNewKey.Text, this.txtNewValue.Text);
      this.txtNewKey.Text = string.Empty;
      this.txtNewValue.Text = string.Empty;
      this.GereBouton();
      this.NotifyChange();
    }

    /// <summary>
    /// changement du texte de recherche
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">param inutile</param>
    private void TxtSearchTextChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }

    /// <summary>
    /// Changement du texte de la clé
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">param inutile</param>
    private void TxtNewKeyTextChanged(object sender, EventArgs e)
    {
      this.SetEditMode(this.lstValues.SelectedItems.Count > 0 && this.txtNewKey.Text == this.lstValues.SelectedItems[0].Text);
      this.GereBouton();
    }

    /// <summary>
    /// recherche d'une clé
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">param inutile</param>
    private void BtSearchClick(object sender, EventArgs e)
    {
      if (string.IsNullOrWhiteSpace(this.txtSearch.Text))
      {
        return;
      }

      if (this.Connection.Connector.HExists(this.myKey, this.txtSearch.Text))
      {
        MessageBox.Show(string.Format("{0} fait partie des données de la clé {1}", this.txtSearch.Text, this.myKey), "Trouvé", MessageBoxButtons.OK, MessageBoxIcon.Information);
        ListViewItem itx = new ListViewItem(this.txtSearch.Text);
        string value = this.Connection.Connector.HGet(this.myKey, this.txtSearch.Text);
        itx.SubItems.Add(value);

        this.lstValues.Items.Add(itx);
        itx.Selected = true;
        this.txtSearch.Text = string.Empty;
        this.GereBouton();
        this.NotifyChange();
      }
      else
      {
        MessageBox.Show(string.Format("{0} non trouvé dans les données de la clé {1}", this.txtSearch.Text, this.myKey), "Non trouvé", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
    #endregion

    /// <summary>
    /// Remplit l'interface avec les infos sur la clé de type Hash
    /// </summary>
    private void FillDisplay()
    {
      if (string.IsNullOrWhiteSpace(this.myKey))
      {
        this.nombreValeur = 0;
      }
      else
      {
        this.nombreValeur = this.Connection.Connector.HLen(this.myKey);
      }

      this.lstValues.Items.Clear();
      if (this.nombreValeur > 0)
      {
        ListViewItem itx;
        if (this.nombreValeur > EditTypeHash.SEUIL)
        { // Trop de données on affiche un échantillon
          List<string> keys = this.Connection.Connector.HKeys(this.myKey);
          for (int i = 0; i < EditTypeHash.SEUIL; i++)
          {
            itx = new ListViewItem(keys[i]);
            itx.SubItems.Add(this.Connection.Connector.HGet(this.myKey, keys[i]));
            this.lstValues.Items.Add(itx);
          }

          itx = new ListViewItem("...");
          itx.ToolTipText = "Il y a d'autres valeurs";
          this.lstValues.Items.Add(itx);

          this.pnlSearch.Visible = true;
          this.lstValues.Height = this.pnlSearch.Top > 5 ? this.pnlSearch.Top - this.lstValues.Top - 5 : 0;
        }
        else
        { // on affiche toutes les valeurs 
          List<Tuple<string, string>> values = this.Connection.Connector.HGetAll(this.myKey);
          foreach (Tuple<string, string> value in values)
          {
            itx = new ListViewItem(value.Item1);
            itx.SubItems.Add(value.Item2);
            this.lstValues.Items.Add(itx);
          }

          this.pnlSearch.Visible = false;
          this.lstValues.Height = this.pnlSearch.Bottom - this.lstValues.Top;
        }
      }

      this.LstValuesSelectedIndexChanged(null, null);
    }

    /// <summary>
    /// Active o pas les boutons
    /// </summary>
    private void GereBouton()
    {
      this.btAdd.Enabled = !string.IsNullOrWhiteSpace(this.txtNewKey.Text) && !string.IsNullOrWhiteSpace(this.txtNewValue.Text);
      this.btSearch.Enabled = !string.IsNullOrWhiteSpace(this.txtSearch.Text);
      this.btDelete.Enabled = this.lstValues.SelectedItems.Count == 1;
    }

    /// <summary>
    /// Met le champ nouveau en edition ou insertion
    /// </summary>
    /// <param name="isEdit">True pour edition / False pour insertion</param>
    private void SetEditMode(bool isEdit)
    {
      if (isEdit)
      {
        this.lblEdition.Text = "Modifier :";
        this.btAdd.Image = Properties.Resources.Save;
      }
      else
      {
        this.lblEdition.Text = "Ajouter :";
        this.btAdd.Image = Properties.Resources.Add;
      }
    }

    /// <summary>
    /// Notifie les parent d'un changement
    /// </summary>
    private void NotifyChange()
    {
      if (this.OnChange != null)
      {
        this.OnChange(this, new EventArgs());
      }
    }
  }
}
