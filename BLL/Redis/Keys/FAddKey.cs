using System;
using System.Windows.Forms;

namespace RedisManagementStudio.BLL.Redis.Keys
{
  /// <summary>
  /// Edition d'une nouvelle clé
  /// </summary>
  public partial class FAddKey : Form
  {
    /// <summary>
    /// Le type de clé sélectionné
    /// </summary>
    private ETypeKey selectedType = ETypeKey.Tnone;

    /// <summary>
    /// Nombre de clés ajoutées
    /// </summary>
    private int myNombreCleAjoute;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="FAddKey" />.
    /// </summary>
    public FAddKey()
    {
      this.InitializeComponent();

      this.Text = Properties.Resources.FAddKeyT;
      this.label1.Text = Properties.Resources.FAddKeyLbl1T;
      this.label2.Text = Properties.Resources.EditTypeTextColCle + " :";
      this.btOk.Text = Properties.Resources.BtAddT;
      this.btCancel.Text = Properties.Resources.BtCancelT;
      this.chkPlayAgain.Text = Properties.Resources.FAddKeyChkPlayAgainT;

      this.cbType.Items.Add(ETypeKey.Thash.GetLibelle());
      this.cbType.Items.Add(ETypeKey.Tlist.GetLibelle());
      this.cbType.Items.Add(ETypeKey.Tset.GetLibelle());
      this.cbType.Items.Add(ETypeKey.Tstring.GetLibelle());
      this.cbType.Items.Add(ETypeKey.Tzset.GetLibelle());

      this.myNombreCleAjoute = 0;
      this.GereBouton();
    }

    /// <summary>
    /// La connexion à utiliser
    /// </summary>
    public RedisConnection Connection { get; set; }

    /// <summary>
    /// Renvoie le nombre de clés ajoutées
    /// </summary>
    public string NombreCleAjoute
    {
      get
      {
        return this.lblCounter.Text;
      }
    }

    /// <summary>
    /// Appel à l'ajout d'une clé
    /// </summary>
    /// <param name="connection">La connexion à la DB</param>
    /// <param name="owner">Le possesseur de la fenêtre</param>
    /// <returns>TRUE si quelque chose a été ajouté</returns>
    public static bool ProcessAdd(RedisConnection connection, IWin32Window owner)
    {
      using (FAddKey f = new FAddKey())
      {
        f.Connection = connection;
        if (f.ShowDialog(owner) == DialogResult.OK)
        {
          MessageBox.Show(owner, f.NombreCleAjoute, Properties.Resources.KeyExplorerBtAddKeyConfirmT, MessageBoxButtons.OK, MessageBoxIcon.Information);
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    #region Internal events
    /// <summary>
    /// Event de chargement de la feuille
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void FAddKey_Load(object sender, EventArgs e)
    {
      this.Location = Properties.Settings.Default.FAddKeyLocation;
      this.Size = Properties.Settings.Default.FAddKeyDimension;
    }

    /// <summary>
    /// Fermeture de la fenêtre
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void FAddKey_FormClosed(object sender, FormClosedEventArgs e)
    {
      Properties.Settings.Default.FAddKeyLocation = this.Location;
      Properties.Settings.Default.FAddKeyDimension = this.Size;
      Properties.Settings.Default.Save();
    }

    /// <summary>
    /// Validation de l'action
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void BtOkClick(object sender, EventArgs e)
    {
      if (this.Connection == null)
      { // pas de connexion on ne fait rien !!
        return;
      }

      if (string.IsNullOrWhiteSpace(this.txtCle.Text))
      { // pas de nom de clé on sort
        return;
      }

      if (this.selectedType == ETypeKey.Tnone || this.selectedType == ETypeKey.UnKnow)
      { // pas de type on sort
        return;
      }

      if (string.IsNullOrWhiteSpace(this.txtValeur1.Text))
      { // pas de valeur 1 on sort
        return;
      }

      if (this.selectedType == ETypeKey.Thash && string.IsNullOrWhiteSpace(this.txtValeur2.Text))
      { // pas de valeur 2 (quand c'est nécessaire) on sort
        return;
      }
      else if (this.selectedType == ETypeKey.Tzset && this.numericTextBox1.DoubleValue.Equals(double.NaN))
      {
        return;
      }

      bool ok = false;
      switch (this.selectedType)
      {
        case ETypeKey.Thash:
          ok = this.Connection.Connector.HSet(this.txtCle.Text, this.txtValeur1.Text, this.txtValeur2.Text);
          break;
        case ETypeKey.Tlist:
          this.Connection.Connector.LPush(this.txtCle.Text, this.txtValeur1.Text);
          ok = string.IsNullOrWhiteSpace(this.Connection.Connector.LastErrorText);
          break;
        case ETypeKey.Tset:
          this.Connection.Connector.SAdd(this.txtCle.Text, this.txtValeur1.Text);
          ok = string.IsNullOrWhiteSpace(this.Connection.Connector.LastErrorText);
          break;
        case ETypeKey.Tstring:
          ok = this.Connection.Connector.Set(this.txtCle.Text, this.txtValeur1.Text);
          break;
        case ETypeKey.Tzset:
          this.Connection.Connector.ZAdd(this.txtCle.Text, new ClientRedisLib.RedisClass.SortedSet(this.numericTextBox1.DoubleValue, this.txtValeur1.Text));
          ok = string.IsNullOrWhiteSpace(this.Connection.Connector.LastErrorText);
          break;
      }

      if (ok)
      {
        this.myNombreCleAjoute++;
        if (this.chkPlayAgain.Checked)
        { // mode multiple
          this.Clear();
          this.btCancel.Text = Properties.Resources.BtCloseT;
          this.btCancel.DialogResult = DialogResult.OK;
          this.GereBouton();
        }
        else
        { // on a fini l'édition
          this.GereBouton();
          this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
      }
      else
      { // problème
        MessageBox.Show(this, this.Connection.Connector.LastErrorText, Properties.Resources.FAddKeyBtOkErrorT, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    /// <summary>
    /// Changement de type de données
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void CbTypeSelectedIndexChanged(object sender, EventArgs e)
    {
      switch (this.cbType.SelectedIndex)
      {
        case 0:
          this.selectedType = ETypeKey.Thash;
          break;
        case 1:
          this.selectedType = ETypeKey.Tlist;
          break;
        case 2:
          this.selectedType = ETypeKey.Tset;
          break;
        case 3:
          this.selectedType = ETypeKey.Tstring;
          break;
        case 4:
          this.selectedType = ETypeKey.Tzset;
          break;
      }

      this.GereBouton();
    }

    /// <summary>
    /// Changement d'une des 2 valeurs
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void TxtValeurTextChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }
    #endregion

    /// <summary>
    /// Adaptation de l'interface aux choix
    /// </summary>
    private void GereBouton()
    {
      if (string.IsNullOrWhiteSpace(this.txtCle.Text))
      {
        this.errorProvider1.SetError(this.txtCle, Properties.Resources.FAddKeyErrorKey);
      }
      else
      {
        this.errorProvider1.SetError(this.txtCle, string.Empty);
      }

      if (this.cbType.SelectedIndex == -1 || this.selectedType == ETypeKey.Tnone || this.selectedType == ETypeKey.UnKnow)
      { // la cbType est dans le panel1 pour le look d'ou l'affectation ci dessous
        this.errorProvider1.SetError(this.panel1, Properties.Resources.FAddKeyErrorType);
      }
      else
      {
        this.errorProvider1.SetError(this.panel1, string.Empty);
      }

      if (string.IsNullOrWhiteSpace(this.txtValeur1.Text))
      {
        this.errorProvider1.SetError(this.txtValeur1, Properties.Resources.FAddKeyErrorValue1);
      }
      else
      {
        this.errorProvider1.SetError(this.txtValeur1, string.Empty);
      }

      if (this.selectedType == ETypeKey.Thash)
      {
        if (string.IsNullOrWhiteSpace(this.txtValeur2.Text))
        {
          this.errorProvider1.SetError(this.txtValeur2, Properties.Resources.FAddKeyErrorValue2);
        }
        else
        {
          this.errorProvider1.SetError(this.txtValeur2, string.Empty);
        }
      }
      else if (this.selectedType == ETypeKey.Tzset)
      {
        if (this.numericTextBox1.DoubleValue.Equals(double.NaN))
        {
          this.errorProvider1.SetError(this.numericTextBox1, Properties.Resources.FAddKeyErrorValue3);
        }
        else
        {
          this.errorProvider1.SetError(this.numericTextBox1, string.Empty);
        }
      }

      this.btOk.Enabled = this.selectedType != ETypeKey.Tnone && !string.IsNullOrWhiteSpace(this.txtValeur1.Text) && !string.IsNullOrWhiteSpace(this.txtCle.Text);
      this.txtValeur2.Visible = this.selectedType == ETypeKey.Thash;
      this.numericTextBox1.Visible = this.selectedType == ETypeKey.Tzset;
      this.lblValue2.Visible = false;

      switch (this.selectedType)
      {
        case ETypeKey.Thash:
          this.lblValue1.Text = Properties.Resources.EditTypeHashColKeyT + " :";
          this.lblValue2.Text = Properties.Resources.EditTypeHashColValueT + " :";
          this.lblValue2.Visible = true;
          if (string.IsNullOrWhiteSpace(this.txtValeur2.Text))
          {
            this.btOk.Enabled = false;
          }

          break;
        case ETypeKey.Tlist:
          this.lblValue1.Text = Properties.Resources.EditTypeListColValueT + " :";
          break;
        case ETypeKey.Tset:
          this.lblValue1.Text = Properties.Resources.EditTypeSetColValue + " :";
          break;
        case ETypeKey.Tstring:
          this.lblValue1.Text = Properties.Resources.EditTypeTextColValue + " :";
          break;
        case ETypeKey.Tzset:
          this.lblValue1.Text = Properties.Resources.EditTypeZSetColMembre + " :";
          this.lblValue2.Text = Properties.Resources.EditTypeZSetColScore + " :";
          this.lblValue2.Visible = true;
          if (this.numericTextBox1.DoubleValue.Equals(double.NaN))
          {
            this.btOk.Enabled = false;
          }

          break;
      }

      if (this.myNombreCleAjoute <= 0)
      {
        this.lblCounter.Text = string.Empty;
      }
      else if (this.myNombreCleAjoute == 1)
      {
        this.lblCounter.Text = Properties.Resources.FAddKeyCountAdd1;
      }
      else
      {
        this.lblCounter.Text = string.Format(Properties.Resources.FAddKeyCountAddN, this.myNombreCleAjoute);
      }
    }
    
    /// <summary>
    /// Efface le formulaire (on garde le type sélectionné
    /// </summary>
    private void Clear()
    {
      this.txtCle.Text = string.Empty;
      this.txtValeur1.Text = string.Empty;
      this.txtValeur2.Text = string.Empty;
      this.numericTextBox1.DoubleValue = double.NaN;
    }
  }
}
