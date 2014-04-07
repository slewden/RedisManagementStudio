using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RedisManagementStudio.BLL.Redis;

namespace RedisManagementStudio.BLL.Keys
{
  /// <summary>
  /// EDiteur de données du type LIST
  /// </summary>
  public partial class EditTypeList : UserControl
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
    /// Nombre de valeur dans la liste
    /// </summary>
    private int nombreValeur = 0;

    /// <summary>
    /// Premier index affiché
    /// </summary>
    private int firstIndex = 0;

    /// <summary>
    /// Constructeur de la classe
    /// </summary>
    public EditTypeList()
    {
      this.InitializeComponent();
    }

    #region Interface publique
    /// <summary>
    /// Notifie un changement au parent
    /// </summary>
    public event EventHandler OnChange;

    /// <summary>
    /// Les types d'edition possible
    /// </summary>
    internal enum ETypeEdition
    {
      /// <summary>
      /// Ajout d'une donnée
      /// </summary>
      Ajout = 0,

      /// <summary>
      /// Modification d'une donnée
      /// </summary>
      Modification = 1,

      /// <summary>
      /// insersion avant une ligne
      /// </summary>
      InsersionAvant = 2,

      /// <summary>
      /// Insersion après une ligne
      /// </summary>
      InsersionApres = 3
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
          if (this.Connection.Type(value) != ETypeKey.Tlist)
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
      // TODO If needed
    }

    /// <summary>
    /// Charge les propriété du composant
    /// </summary>
    public void LoadProperties()
    {
      // TODO If needed
    }
    #endregion

    #region Events
    /// <summary>
    /// Changement du type d'éditeur ==> on ajuste la taille des colonnes
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">param inutile</param>
    private void EditTypeSetSizeChanged(object sender, EventArgs e)
    {
      this.colValue.Width = this.lstValues.Width;
    }

    /// <summary>
    /// Changement d'élément sélectionné
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">param inutile</param>
    private void LstValuesSelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.lstValues.SelectedItems.Count > 0)
      {
        this.lblCurrentValue.Text = this.lstValues.SelectedItems[0].Text;
        this.txtNewValue.Text = this.lstValues.SelectedItems[0].Text;
        this.SetEditMode(ETypeEdition.Modification);
      }
      else
      {
        this.lblCurrentValue.Text = string.Empty;
        this.txtNewValue.Text = string.Empty;
        this.SetEditMode(ETypeEdition.Ajout);
      }
    }

    /// <summary>
    /// les infos de la saisie d'un nouvel élement ont changés
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">param inutile</param>
    private void NewElementChanged(object sender, EventArgs e)
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
      if (MessageBox.Show(this, "Etes vous certain de vouloir supprimer cette valeur ?\n\nL'opération est irréversible.", "Confirmez la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
      {
        int n = this.Connection.Connector.LRem(this.myKey, 1, this.lstValues.SelectedItems[0].Text);
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
      if (!this.CheckAction() || string.IsNullOrWhiteSpace(this.txtNewValue.Text))
      {
        return;
      }

      ETypeEdition te = (ETypeEdition)cbNewAction.SelectedIndex;
      switch (te)
      {
        case ETypeEdition.Ajout:
          this.Connection.Connector.LPush(this.myKey, this.txtNewValue.Text);
          break;
        case ETypeEdition.Modification:
          this.Connection.Connector.LSet(this.myKey, this.firstIndex + this.lstValues.SelectedIndices[0], this.txtNewValue.Text);
          break;
        case ETypeEdition.InsersionAvant:
          this.Connection.Connector.LInsert(this.myKey, false, this.lstValues.SelectedItems[0].Text, this.txtNewValue.Text);
          break;
        case ETypeEdition.InsersionApres:
          this.Connection.Connector.LInsert(this.myKey, true, this.lstValues.SelectedItems[0].Text, this.txtNewValue.Text);
          break;
      }

      this.txtNewValue.Text = string.Empty;
      this.GereBouton();
      this.NotifyChange();
    }

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
    /// Rafraichir la liste
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
    #endregion

    /// <summary>
    /// Remplit l'interface avec les infos sur la clé de type LIST
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
        this.nombreValeur = this.Connection.Connector.LLen(this.myKey);
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
            this.firstIndex = 0;
          }
          else
          {
            this.txtIndexMin.IntValue = 0;
            this.txtIndexMax.IntValue = this.nombreValeur - 1;
            this.firstIndex = 0;
          }
        }

        List<string> values = this.Connection.Connector.LRange(this.myKey, this.txtIndexMin.IntValue, this.txtIndexMax.IntValue);
        foreach (string s in values)
        {
          this.lstValues.Items.Add(s);
        }
      }

      this.LstValuesSelectedIndexChanged(null, null);
    }

    /// <summary>
    /// Active ou pas les boutons
    /// </summary>
    private void GereBouton()
    {
      this.btAdd.Enabled = this.CheckAction() && !string.IsNullOrWhiteSpace(this.txtNewValue.Text);
      this.btDelete.Enabled = this.lstValues.SelectedItems.Count == 1;

      this.btRefreshList.Enabled = this.CheckIndexes();
      this.btAdd.Image = this.cbNewAction.SelectedIndex == 1 ? Properties.Resources.Save : Properties.Resources.Add;
    }

    /// <summary>
    /// force le mode d'édition en cours
    /// </summary>
    /// <param name="te">Type d'édition à imposer</param>
    private void SetEditMode(ETypeEdition te)
    {
      this.cbNewAction.SelectedIndex = Convert.ToInt32(te);
      this.GereBouton();
    }

    /// <summary>
    /// Vérifie s'il y a ce qu'il faut pour éditer une valeur
    /// </summary>
    /// <returns>True si ok</returns>
    private bool CheckAction()
    {
      if (cbNewAction.SelectedItem == null)
      {
        cbNewAction.SelectedItem = cbNewAction.Items[0];
      }

      ETypeEdition te = (ETypeEdition)cbNewAction.SelectedIndex;
      switch (te)
      {
        case ETypeEdition.Ajout:  // Ajout : Pas besoin d'index ici
          return true;
        case ETypeEdition.Modification:
        case ETypeEdition.InsersionAvant:
        case ETypeEdition.InsersionApres:
          return this.lstValues.SelectedIndices.Count > 0;
      }

      return false;
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
