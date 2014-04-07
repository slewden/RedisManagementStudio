using System;
using System.Windows.Forms;
using RedisManagementStudio.BLL.Redis;

namespace RedisManagementStudio.BLL.Keys
{
  /// <summary>
  /// Editeur de données de type String
  /// </summary>
  public partial class EditTypeText : UserControl
  {
    /// <summary>
    /// La clé en cours d'affichage
    /// </summary>
    private string myKey = string.Empty;

    /// <summary>
    /// La valeur manipulée
    /// </summary>
    private string myValue = string.Empty;

    /// <summary>
    /// Indique si la valeur est un nombre (entier ou décimal)
    /// </summary>
    private bool myValueIsNumeric = false;

    /// <summary>
    /// Constructeur de la classe
    /// </summary>
    public EditTypeText()
    {
      this.InitializeComponent();
    }

    #region Interface publique
    /// <summary>
    /// Notifie un changement au parent
    /// </summary>
    public event EventHandler OnChange;

    /// <summary>
    /// Différent format d'affichage de la chaine 
    /// (Ces formats sont listés au Design dans la combox cbTypeAffichage)
    /// </summary>
    internal enum ETypeEdition
    {
      /// <summary>
      /// Affichage simple du texte
      /// </summary>
      Brut = 0,

      /// <summary>
      /// Affichage comme des nombre
      /// </summary>
      Numerique = 1,

      /// <summary>
      /// Affichache en champ de bit
      /// </summary>
      Bit = 2,

      /// <summary>
      /// Objet JSON
      /// </summary>
      JSon = 3
    }

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
          if (this.Connection.Type(value) != ETypeKey.Tstring)
          { // invalid key
            return;
          }
        }

        this.myKey = value;
        this.FillDisplay(true);
      }
    }

    /// <summary>
    /// Enregistre les proppriétés de mise en forme du controle
    /// </summary>
    public void SaveProperties()
    {
      Properties.Settings.Default.ColWidthEditTextKey = this.colKey.Width;
      Properties.Settings.Default.ColWidthEditTextValue = this.colValue.Width;
    }

    /// <summary>
    /// Charge les propriétés du composant
    /// </summary>
    public void LoadProperties()
    {
      this.colKey.Width = Properties.Settings.Default.ColWidthEditTextKey;
      this.colValue.Width = Properties.Settings.Default.ColWidthEditTextValue;
    }
    #endregion

    #region Events
    /// <summary>
    /// Changement du type d'affichage
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">parametre inutile</param>
    private void TypeAffichageSelectedIndexChanged(object sender, EventArgs e)
    {
      this.FillDisplay(false);
    }

    /// <summary>
    /// Bouton incrémentation
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">parametre inutile</param>
    private void BtIncrClick(object sender, EventArgs e)
    {
      this.Connection.Connector.IncrBy(this.myKey, this.txtIncremValue.IntValue);
      this.NotifyChange();
    }

    /// <summary>
    /// bouton decrementation
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">parametre inutile</param>
    private void BtDecrClick(object sender, EventArgs e)
    {
      this.Connection.Connector.DecrBy(this.myKey, this.txtIncremValue.IntValue);
      this.NotifyChange();
    }

    /// <summary>
    /// Bouton mise à jour du texte
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">parametre inutile</param>
    private void BtUpdateClick(object sender, EventArgs e)
    {
      this.Connection.Connector.Set(this.myKey, this.txtNewValue.Text);
      this.NotifyChange();
    }

    /// <summary>
    /// Le nouveau texte à edité a changé
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">parametre inutile</param>
    private void TxtNewValueTextChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }

    /// <summary>
    /// Bouton de définition d'un bit
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">parametre inutile</param>
    private void BtSetBitClick(object sender, EventArgs e)
    {
      if (this.txtSetBitOffset.IntValue >= 0)
      {
        this.Connection.Connector.SetBit(this.myKey, this.txtSetBitOffset.IntValue, this.chkSetBit.Checked);
        this.NotifyChange();
      }
    }

    /// <summary>
    /// Selection d'une case dans le tabelau des bits
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">parametre inutile</param>
    private void BitDisplay1Click(object sender, EventArgs e)
    {
      this.txtSetBitOffset.IntValue = this.bitDisplay1.Offset;
      this.GereBouton();
    }

    /// <summary>
    /// Changement de l'offset pour l'édition par bit
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">parametre inutile</param>
    private void SetBitOffsetTextChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }
    #endregion

    /// <summary>
    /// Remplit l'affichage en fonction du choix d'écran
    /// </summary>
    /// <param name="forceLoad">Force ou pas le chargement des données</param>
    private void FillDisplay(bool forceLoad)
    {
      if (forceLoad && this.Connection != null && !string.IsNullOrWhiteSpace(this.myKey))
      { // récupère la valeur
        this.myValue = this.Connection.Connector.Get(this.myKey);
        double nb;
        this.myValueIsNumeric = double.TryParse(this.myValue, out nb);
      }

      if (this.cbTypeAffichage.SelectedIndex == -1)
      { // pas de sélection d'affichage on en positionne un (le premier !)
        this.cbTypeAffichage.SelectedIndex = 0;
      }

      ETypeEdition te = (ETypeEdition)this.cbTypeAffichage.SelectedIndex;
      this.lblWrongFormat.Text = string.Empty;
      this.lstValues.Visible = false;
      this.lblDetail.Visible = true;
      this.bitDisplay1.Visible = false;
      switch (te)
      {
        case ETypeEdition.Brut:
          this.lblDetail.Text = this.myValue;
          break;
        case ETypeEdition.Bit:
          this.bitDisplay1.Connection = this.Connection;
          this.bitDisplay1.Key = this.myKey;
          this.bitDisplay1.Text = this.myValue;
          this.bitDisplay1.Visible = true;
          this.lblDetail.Visible = false;
          break;
        case ETypeEdition.Numerique:
          this.lblDetail.Text = this.myValue; // TODO améliorer cela

          if (!this.myValueIsNumeric)
          { // c'est pas un nombre !!
            this.lblWrongFormat.Text = "Le texte ne semble pas être un nombre";
          }

          break;
        case ETypeEdition.JSon:
          if (this.FillJson(this.myValue))
          {
            this.lstValues.Visible = true;
            this.lblDetail.Visible = false;
          }
          else
          { // c'est pas du json on ne fait rien
            this.lblDetail.Text = this.myValue;
            this.lblWrongFormat.Text = "Le texte ne semble pas représenter un objet JSon Sérialisé";
          }

          break;
      }

      this.txtNewValue.Text = this.myValue;
      this.GereBouton();
    }

    /// <summary>
    /// Remplissage pour l'affichage JSON
    /// </summary>
    /// <param name="txt">Texte à afficher</param>
    /// <returns>True si on a un JSON valide</returns>
    private bool FillJson(string txt)
    {
      this.lstValues.Items.Clear();
      if (txt.StartsWith("{") && txt.EndsWith("}"))
      {
        txt = txt.Substring(1, txt.Length - 2);
        if (txt.IndexOf(',') != -1)
        {
          string[] keyValues = txt.Split(',');
          bool ok = true;
          foreach (string s in keyValues)
          {
            if (!this.SplitKeyValue(s))
            {
              ok = false;
              break;
            }
          }

          return ok;
        }
        else
        {
          return this.SplitKeyValue(txt);
        }
      }

      this.lstValues.Items.Clear();
      return false;
    }

    /// <summary>
    /// Affiche la partie Clé valeur d'un JSON
    /// </summary>
    /// <param name="txt">Texte clé valeur à décoder</param>
    /// <returns>Trus si c'est valide</returns>
    private bool SplitKeyValue(string txt)
    {
      if (txt.IndexOf(':') != -1)
      {
        string[] nfos = txt.Split(':');
        ListViewItem itx = new ListViewItem();
        itx.Text = nfos[0].Replace("\"", string.Empty);
        itx.SubItems.Add(nfos[1].Replace("\"", string.Empty));
        this.lstValues.Items.Add(itx);
        return true;
      }

      return false;
    }

    /// <summary>
    /// Gere l'activation des boutons
    /// </summary>
    private void GereBouton()
    {
      if (this.cbTypeAffichage.SelectedIndex == -1)
      { // on choisi un affichage par défaut
        this.cbTypeAffichage.SelectedIndex = 0;
      }

      ETypeEdition te = (ETypeEdition)this.cbTypeAffichage.SelectedIndex;
      this.pnlToolNumerique.Visible = te == ETypeEdition.Numerique && this.myValueIsNumeric;
      this.pnlSetBit.Visible = te == ETypeEdition.Bit;

      bool ok = this.txtIncremValue.IntValue != 0;
      this.btIncr.Enabled = ok;
      this.btDecr.Enabled = ok;

      this.btUpdate.Enabled = !string.IsNullOrWhiteSpace(this.txtNewValue.Text);
      this.btSetBit.Enabled = this.txtSetBitOffset.IntValue >= 0;
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
