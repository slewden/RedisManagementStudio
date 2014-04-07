using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RedisManagementStudio.BLL.Redis;

namespace RedisManagementStudio.BLL.Redis.Keys
{
  /// <summary>
  /// éditeur de données du type LIST
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
    /// Initialise une nouvelle instance de la classe <see cref="EditTypeList" />.
    /// </summary>
    public EditTypeList()
    {
      this.InitializeComponent();
      this.colValue.Text = Properties.Resources.EditTypeListColValueT;
      this.cbNewAction.Items.AddRange(
        new object[] 
        {
            Properties.Resources.EditTypeListCbNewActionAdd,
            Properties.Resources.EditTypeListCbNewActionEdit,
            Properties.Resources.EditTypeListCbNewActionInsertBefore,
            Properties.Resources.EditTypeListCbNewActionInsertAfter
        });
      this.toolTip1.SetToolTip(this.txtIndexMax, Properties.Resources.EditTypeListTxtIndexMaxD);
      this.toolTip1.SetToolTip(this.txtIndexMin, Properties.Resources.EditTypeListTxtIndexMinD);
      this.toolTip1.SetToolTip(this.btDelete, Properties.Resources.EditTypeListBtDeleteD);
      this.toolTip1.SetToolTip(this.btRefreshList, Properties.Resources.EditTypeListBtRefresh);
      this.label2.Text = Properties.Resources.EditTypeListLbl2T;
      this.label3.Text = Properties.Resources.EditTypeListLbl3T;
      this.label4.Text = Properties.Resources.EditTypeListLbl4T;
    }

    #region Interface publique
    /// <summary>
    /// Notifie un changement au parent
    /// </summary>
    public event EventHandler OnChange;

    /// <summary>
    /// Les types d'édition possible
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
      /// insertion avant une ligne
      /// </summary>
      InsersionAvant = 2,

      /// <summary>
      /// Insertion après une ligne
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
          throw new ArgumentException(Properties.Resources.ErrorEditorsWithoutConnection);
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
    /// Enregistre les propriétés de mise en forme du contrôle
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
    /// <param name="e">Paramètre inutile</param>
    private void EditTypeSetSizeChanged(object sender, EventArgs e)
    {
      this.colValue.Width = this.lstValues.Width;
    }

    /// <summary>
    /// Changement d'élément sélectionné
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
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
    /// les infos de la saisie d'un nouvel élément ont changés
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void NewElementChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }

    /// <summary>
    /// Suppression de la valeur en cours
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtDeleteClick(object sender, EventArgs e)
    {
      if (MessageBox.Show(
        this, 
        Properties.Resources.EditTypeListBtDeleteConfirmD, 
        Properties.Resources.EditTypeListBtDeleteConfirmT, 
        MessageBoxButtons.YesNo, 
        MessageBoxIcon.Question, 
        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
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
    /// <param name="e">Paramètre inutile</param>
    private void BtAddClick(object sender, EventArgs e)
    {
      if (!this.CheckAction() || string.IsNullOrWhiteSpace(this.txtNewValue.Text))
      {
        return;
      }

      ETypeEdition te = (ETypeEdition)this.cbNewAction.SelectedIndex;
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
    /// <param name="e">Paramètre inutile</param>
    private void TxtIndexTextChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }

    /// <summary>
    /// Rafraichir la liste
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
    /// <returns>TRUE si ok</returns>
    private bool CheckAction()
    {
      if (this.cbNewAction.SelectedItem == null)
      {
        this.cbNewAction.SelectedItem = this.cbNewAction.Items[0];
      }

      ETypeEdition te = (ETypeEdition)this.cbNewAction.SelectedIndex;
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
