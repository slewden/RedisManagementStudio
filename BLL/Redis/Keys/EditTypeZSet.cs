using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClientRedisLib.RedisClass;
using RedisManagementStudio.BLL.Redis;

namespace RedisManagementStudio.BLL.Redis.Keys
{
  /// <summary>
  /// Editeur de données du type ZSet
  /// </summary>
  public partial class EditTypeZSet : UserControl
  {
    /// <summary>
    /// Nombre de valeurs max affichées
    /// </summary>
    public const int SEUIL = 2000;

    /// <summary>
    /// La clé en cours d'affichage
    /// </summary>
    private string myKey = string.Empty;

    /// <summary>
    /// Nombre de valeurs dans le ZSet
    /// </summary>
    private int nombreValeur = 0;

    /// <summary>
    /// Pour ne gérer cela qu'une fois (le chargement des infos quand l'objet s'affiche)
    /// </summary>
    private bool firstTime = true;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="EditTypeZSet" />.
    /// </summary>
    public EditTypeZSet()
    {
      this.InitializeComponent();

      this.toolTip1.SetToolTip(this.txtIndexMax, Properties.Resources.EditTypeZSetTxtIndexMaxD);
      this.toolTip1.SetToolTip(this.txtIndexMin, Properties.Resources.EditTypeZSetTxtIndexMinD);
      this.toolTip1.SetToolTip(this.btDelete, Properties.Resources.EditTypeZSetBtDeleteD);
      this.toolTip1.SetToolTip(this.btRefreshList, Properties.Resources.EditTypeZSetBtRefresh);
      this.toolTip1.SetToolTip(this.lblCurrentMember, Properties.Resources.EditTypeZSetColMembre);
      this.toolTip1.SetToolTip(this.txtNewMember, Properties.Resources.EditTypeZSetColMembre);
      this.toolTip1.SetToolTip(this.btDecr, Properties.Resources.EditTypeZSetBtDecrD);
      this.toolTip1.SetToolTip(this.btIncr, Properties.Resources.EditTypeZSetBtIncrD);
      this.toolTip1.SetToolTip(this.lblCurrentScore, Properties.Resources.EditTypeZSetColScore);
      this.toolTip1.SetToolTip(this.txtNewScore, Properties.Resources.EditTypeZSetColScore);
      this.toolTip1.SetToolTip(this.btAdd, Properties.Resources.EditTypeZSetBtAdd);

      this.label2.Text = Properties.Resources.EditTypeZSetLbl2T;
      this.label3.Text = Properties.Resources.EditTypeZSetLbl3T;
      this.label4.Text = Properties.Resources.EditTypeZSetLbl4T;
      this.lblEdition.Text = Properties.Resources.EditTypeZSetLblEditionTAdd;
      this.colMember.Text = Properties.Resources.EditTypeZSetColMembre;
      this.colScore.Text = Properties.Resources.EditTypeZSetColScore;
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
          throw new ArgumentException(Properties.Resources.ErrorEditorsWithoutConnection);
        }

        if (!string.IsNullOrWhiteSpace(value))
        {
          if (this.Connection.Type(value) != ETypeKey.Tzset)
          { // invalid key
            return;
          }
        }

        this.myKey = value;
        this.FillDisplay(true);
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
    /// Enregistre les propriétés de mise en forme du contrôle
    /// </summary>
    public void SaveProperties()
    {
      Properties.Settings.Default.ColWidthEditZSetMembre = this.colMember.Width;
      Properties.Settings.Default.ColWidthEditZSetScore = this.colScore.Width;
      Properties.Settings.Default.ColWidthEditZSetNew = this.splitContainer1.SplitterDistance;
    }

    /// <summary>
    /// Charge les propriété du composant
    /// </summary>
    public void LoadProperties()
    {
      this.colMember.Width = Properties.Settings.Default.ColWidthEditZSetMembre;
      this.colScore.Width = Properties.Settings.Default.ColWidthEditZSetScore;
      this.splitContainer1.SplitterDistance = Properties.Settings.Default.ColWidthEditZSetNew;
    }
    #endregion

    #region Events
    /// <summary>
    /// Au premier affichage on charge les donnée de positionnement
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void EditTypeZSetVisibleChanged(object sender, EventArgs e)
    {
      if (this.Visible && this.firstTime)
      {
        this.LoadProperties();
        this.firstTime = false;
      }
    }
    
    /// <summary>
    /// Un index d'affichage à changé
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void TxtIndexTextChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }

    /// <summary>
    /// Rafraichir la liste des éléments
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtRefreshListClick(object sender, EventArgs e)
    {
      if (this.CheckIndexes())
      {
        this.FillDisplay(false);
      }
    }

    /// <summary>
    /// Changement d'élément sélectionné
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void LstValuesSelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.lstValues.SelectedItems.Count > 0 && this.lstValues.SelectedItems[0].SubItems.Count > 1)
      {
        this.lblCurrentMember.Text = this.lstValues.SelectedItems[0].Text;
        this.lblCurrentScore.Text = this.lstValues.SelectedItems[0].SubItems[1].Text;
        this.txtNewMember.Text = this.lstValues.SelectedItems[0].Text;
        this.txtNewScore.DoubleValue = Convert.ToDouble(this.lstValues.SelectedItems[0].SubItems[1].Text);
        this.SetEditMode(true);
      }
      else
      {
        this.lblCurrentMember.Text = string.Empty;
        this.lblCurrentScore.Text = string.Empty;
        this.txtNewMember.Text = string.Empty;
        this.txtNewScore.Text = string.Empty;
        this.SetEditMode(false);
      }

      this.GereBouton();
    }

    /// <summary>
    /// Trie des données
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre de tri</param>
    private void LstValuesColumnClick(object sender, ColumnClickEventArgs e)
    {
      if (this.lstValues.ListViewItemSorter == null)
      {
        this.lstValues.ListViewItemSorter = new ListViewTextSorter(e.Column);
      }
      else
      {
        ((ListViewTextSorter)this.lstValues.ListViewItemSorter).Change(e.Column);
      }

      this.lstValues.Sort();
    }

    /// <summary>
    /// Demande de suppression d'un membre
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtDeleteClick(object sender, EventArgs e)
    {
      if (MessageBox.Show(
        this, 
        Properties.Resources.EditTypeZSetBtDeleteConfirmD,
        Properties.Resources.EditTypeZSetBtDeleteConfirmT, 
        MessageBoxButtons.YesNo, 
        MessageBoxIcon.Question, 
        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
      {
        int n = this.Connection.Connector.ZRem(this.myKey, this.lstValues.SelectedItems[0].Text);
        if (n == 1)
        {
          this.NotifyChange();
        }
      }
    }

    /// <summary>
    /// Ajout d'un membre ou sauvegarde score
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtAddClick(object sender, EventArgs e)
    {
      if (string.IsNullOrWhiteSpace(this.txtNewMember.Text))
      {
        return;
      }

      SortedSet st = new SortedSet(this.txtNewScore.DoubleValue, this.txtNewMember.Text);
      this.Connection.Connector.ZAdd(this.myKey, st);
      if (this.lstValues.SelectedItems.Count > 0)
      {
        this.lstValues.SelectedItems[0].Selected = false;
      }

      this.txtNewMember.Text = string.Empty;
      this.txtNewScore.IntValue = -1;
      this.GereBouton();
      this.NotifyChange();
    }

    /// <summary>
    /// Baisse le score de 1
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtDecrClick(object sender, EventArgs e)
    {
      this.Incremente(-1);
    }

    /// <summary>
    /// Monter le score de 1
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtIncrClick(object sender, EventArgs e)
    {
      this.Incremente(1);
    }

    /// <summary>
    /// Changement du score
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void TxtNewValueTextChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }

    /// <summary>
    /// Changement du membre
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void TxtNewMemberTextChanged(object sender, EventArgs e)
    {
      this.SetEditMode(false);
      this.GereBouton();
    }
    #endregion

    /// <summary>
    /// Remplit l'interface avec les infos sur la clé de type ZSet
    /// </summary>
    /// <param name="canChangeIndexex">Indique si l'on peut ou pas actualiser les indexes</param>
    private void FillDisplay(bool canChangeIndexex)
    {
      if (string.IsNullOrWhiteSpace(this.myKey))
      {
        this.nombreValeur = 0;
      }
      else
      {
        this.nombreValeur = this.Connection.Connector.ZCard(this.myKey);
      }

      this.lstValues.Items.Clear();
      if (this.nombreValeur > 0)
      {
        if (canChangeIndexex)
        {
          if (this.nombreValeur > EditTypeList.SEUIL)
          { // Trop de données on affiche un échantillon
            this.txtIndexMin.IntValue = 0;
            this.txtIndexMax.IntValue = EditTypeList.SEUIL - 1;
          }
          else
          {
            this.txtIndexMin.IntValue = 0;
            this.txtIndexMax.IntValue = this.nombreValeur - 1;
          }
        }

        List<SortedSet> values = this.Connection.Connector.ZRange(this.myKey, this.txtIndexMin.IntValue, this.txtIndexMax.IntValue, true);
        ListViewItem itx;
        foreach (SortedSet s in values)
        {
          itx = new ListViewItem(s.Member);
          itx.SubItems.Add(s.Score.ToString("N3"));
          this.lstValues.Items.Add(itx);
        }
      }

      this.LstValuesSelectedIndexChanged(null, null);
    }

    /// <summary>
    /// Active ou pas les boutons
    /// </summary>
    private void GereBouton()
    {
      this.btAdd.Enabled = !string.IsNullOrWhiteSpace(this.txtNewMember.Text) && !string.IsNullOrWhiteSpace(this.txtNewScore.Text);
      this.btDelete.Enabled = this.lstValues.SelectedItems.Count == 1;

      this.btRefreshList.Enabled = this.CheckIndexes();
    }

    /// <summary>
    /// Vérifie les borne min et max d'affichage
    /// </summary>
    /// <returns>TRUE si ok</returns>
    private bool CheckIndexes()
    {
      this.lblCount.Text = string.Empty;

      int min = this.txtIndexMin.IntValue;
      if (min < 0)
      {
        this.errorProvider1.SetError(this.txtIndexMin, Properties.Resources.EditTypeCheckIndexMinError);
        return false;
      }

      if (min >= this.Count)
      {
        this.errorProvider1.SetError(this.txtIndexMin, string.Format(Properties.Resources.EditTypeCheckIndexMaxError, this.nombreValeur - 1));
        return false;
      }

      int max = this.txtIndexMax.IntValue;
      if (max < 0)
      {
        this.errorProvider1.SetError(this.txtIndexMax, Properties.Resources.EditTypeCheckIndexMinError);
        return false;
      }

      if (max >= this.Count)
      {
        this.errorProvider1.SetError(this.txtIndexMax, string.Format(Properties.Resources.EditTypeCheckIndexMaxError, this.nombreValeur - 1));
        return false;
      }

      if (min > max)
      { // ordre pas bon
        this.errorProvider1.SetError(this.txtIndexMin, Properties.Resources.EditTypeCheckIndexOrderMin);
        this.errorProvider1.SetError(this.txtIndexMax, Properties.Resources.EditTypeCheckIndexOrderMax);
        return false;
      }

      int nb = max - min + 1;
      if (nb > EditTypeList.SEUIL)
      {
        this.errorProvider1.SetError(this.txtIndexMin, string.Format(Properties.Resources.EditTypeCheckIndexInterval, EditTypeList.SEUIL));
        this.errorProvider1.SetError(this.txtIndexMax, string.Format(Properties.Resources.EditTypeCheckIndexInterval, EditTypeList.SEUIL));
        return false;
      }

      this.errorProvider1.SetError(this.txtIndexMin, string.Empty);
      this.errorProvider1.SetError(this.txtIndexMax, string.Empty);
      if (nb == 1)
      {
        this.lblCount.Text = string.Format(Properties.Resources.EditTypeCount1, this.nombreValeur);
      }
      else
      {
        this.lblCount.Text = string.Format(Properties.Resources.EditTypeCountN, nb, this.nombreValeur);
      }

      return true;
    }

    /// <summary>
    /// Met le champ nouveau en edition ou insertion
    /// </summary>
    /// <param name="isEdit">TRUE pour édition / False pour insertion</param>
    private void SetEditMode(bool isEdit)
    {
      if (isEdit)
      {
        this.lblEdition.Text = Properties.Resources.EditTypeZSetLblEditionTEdit;
        this.btAdd.Image = Properties.Resources.Save;
        this.toolTip1.SetToolTip(this.btAdd, Properties.Resources.EditTypeZSetLblEditionDEdit);
      }
      else
      {
        this.lblEdition.Text = Properties.Resources.EditTypeZSetLblEditionTAdd;
        this.btAdd.Image = Properties.Resources.Add;
        this.toolTip1.SetToolTip(this.btAdd, Properties.Resources.EditTypeZSetLblEditionDAdd);
      }
    }

    /// <summary>
    /// Incrémente le score de la valeur en cour de delta
    /// </summary>
    /// <param name="delta">Valeur de l'incrémentation</param>
    private void Incremente(double delta)
    {
      if (string.IsNullOrWhiteSpace(this.txtNewMember.Text))
      {
        return;
      }

      this.Connection.Connector.ZIncrBy(this.myKey, delta, this.txtNewMember.Text);
      this.NotifyChange();
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
