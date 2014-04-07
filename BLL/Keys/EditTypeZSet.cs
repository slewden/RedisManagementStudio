using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClientRedisLib.RedisClass;
using RedisManagementStudio.BLL.Redis;

namespace RedisManagementStudio.BLL.Keys
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
    /// Constructeur de la classe
    /// </summary>
    public EditTypeZSet()
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
    /// Enregistre les proppriétés de mise en forme du controle
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
    /// Un index d'affichage à changé
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">param inutile</param>
    private void TxtIndexTextChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }

    /// <summary>
    /// Rafaichir laliste des éléments
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">param inutile</param>
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
    /// <param name="e">param inutile</param>
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
    /// Demande de suppression d'un membre
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">param inutile</param>
    private void BtDeleteClick(object sender, EventArgs e)
    {
      if (MessageBox.Show(this, "Etes vous certain de vouloir supprimer ce membre ?\n\nL'opération est irréversible.", "Confirmez la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
    /// <param name="e">param inutile</param>
    private void BtAddClick(object sender, EventArgs e)
    {
      if (string.IsNullOrWhiteSpace(this.txtNewMember.Text))
      {
        return;
      }

      SortedSet st = new SortedSet(this.txtNewScore.DoubleValue, this.txtNewMember.Text);
      this.Connection.Connector.ZAdd(this.myKey, st);
      this.lstValues.SelectedItems[0].Selected = false;
      this.txtNewMember.Text = string.Empty;
      this.txtNewScore.IntValue = -1;
      this.GereBouton();
      this.NotifyChange();
    }

    /// <summary>
    /// Baisse le score de 1
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">param inutile</param>
    private void BtDecrClick(object sender, EventArgs e)
    {
      this.Incremente(-1);
    }

    /// <summary>
    /// Monter le score de 1
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">param inutile</param>
    private void BtIncrClick(object sender, EventArgs e)
    {
      this.Incremente(1);
    }

    /// <summary>
    /// Changement du score
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">param inutile</param>
    private void TxtNewValueTextChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }

    /// <summary>
    /// Changement du membre
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">param inutile</param>
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
    /// Vérifie les borne min et max d'affichag
    /// </summary>
    /// <returns>true si ok</returns>
    private bool CheckIndexes()
    {
      this.lblCount.Text = string.Empty;

      int min = this.txtIndexMin.IntValue;
      if (min < 0)
      {
        errorProvider1.SetError(this.txtIndexMin, "Valeur invalide");
        return false;
      }

      if (min >= this.Count)
      {
        errorProvider1.SetError(this.txtIndexMin, string.Format("Valeur trop grande (maximum = {0})", this.nombreValeur - 1));
        return false;
      }

      int max = this.txtIndexMax.IntValue;
      if (max < 0)
      {
        errorProvider1.SetError(this.txtIndexMax, "Valeur invalide");
        return false;
      }

      if (max >= this.Count)
      {
        errorProvider1.SetError(this.txtIndexMax, string.Format("Valeur trop grande (maximum = {0})", this.nombreValeur - 1));
        return false;
      }

      if (min > max)
      { // ordre pas bon
        errorProvider1.SetError(this.txtIndexMin, "La valeur doit être inférieure au max");
        errorProvider1.SetError(this.txtIndexMax, "La valeur doit être supérieur au min");
        return false;
      }

      int nb = max - min + 1;
      if (nb > EditTypeList.SEUIL)
      {
        errorProvider1.SetError(this.txtIndexMin, string.Format("L'interval est trop large ({0} valeurs maximum)", EditTypeList.SEUIL));
        errorProvider1.SetError(this.txtIndexMax, string.Format("L'interval est trop large ({0} valeurs maximum)", EditTypeList.SEUIL));
        return false;
      }

      errorProvider1.SetError(this.txtIndexMin, string.Empty);
      errorProvider1.SetError(this.txtIndexMax, string.Empty);
      this.lblCount.Text = string.Format("{0} valeur{1} affichée{1} sur {2}", nb, nb > 1 ? "s" : string.Empty, this.nombreValeur);
      return true;
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
