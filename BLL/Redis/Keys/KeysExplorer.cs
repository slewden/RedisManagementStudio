using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RedisManagementStudio.BLL.Redis;

namespace RedisManagementStudio.BLL.Redis.Keys
{
  /// <summary>
  /// Contrôle pour l'affichage d'une liste de clé en DB
  /// </summary>
  public partial class KeysExplorer : UserControl
  {
    /// <summary>
    /// La clé couramment sélectionnée
    /// </summary>
    private KeySearchResult currentKey = null;

    /// <summary>
    /// La connexion
    /// </summary>
    private RedisConnection myConnection;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="KeysExplorer" />.
    /// </summary>
    public KeysExplorer()
    {
      this.InitializeComponent();

      this.pnlDefault.Dock = DockStyle.Fill;
      this.editTypeHash1.Dock = DockStyle.Fill;
      this.editTypeList1.Dock = DockStyle.Fill;
      this.editTypeSet1.Dock = DockStyle.Fill;
      this.editTypeText1.Dock = DockStyle.Fill;
      this.editTypeZSet1.Dock = DockStyle.Fill;

      this.label2.Text = Properties.Resources.KeyExplorerLbl2T;
      this.label3.Text = Properties.Resources.KeyExplorerLbl3T;
      this.lblTitre.Text = Properties.Resources.KeyExplorerLbl4T;
      this.txtTitre.Visible = false;
      this.label5.Text = Properties.Resources.KeyExplorerLbl5T;
      this.cbTTL.Items.AddRange(
        new object[] 
        {
            Properties.Resources.KeyExplorerTTLFormatSeconds,
            Properties.Resources.KeyExplorerTTLFormatMinutes,
            Properties.Resources.KeyExplorerTTLFormatHours
        });
      this.toolTip1.SetToolTip(this.btCancelEditTTL, Properties.Resources.KeyExplorerBtCancelD);
      this.toolTip1.SetToolTip(this.btClearTTL, Properties.Resources.KeyExplorerBtClearTTLD);
      this.toolTip1.SetToolTip(this.btSetTTL, Properties.Resources.KeyExplorerBtSetTTLD);
      this.toolTip1.SetToolTip(this.btAddKey, Properties.Resources.KeyExplorerBtAddKeyD);
      this.toolTip1.SetToolTip(this.btDelKey, Properties.Resources.KeyExplorerBtDelKeyD);
      this.toolTip1.SetToolTip(this.btSizeOf, Properties.Resources.KeyExplorerBtSizeOfD1);

      this.lblPoids.Text = string.Empty;
      this.ClearDetail();
      this.numTTL.Value = 30;
      this.cbTTL.SelectedIndex = 0;
    }

    #region Interface publique
    /// <summary>
    /// L'interface de recherche de clés
    /// </summary>
    public KeySearch KeySearcher { get; set; }

    /// <summary>
    /// Défini la connexion à utiliser
    /// </summary>
    public RedisConnection Connection
    {
      get
      {
        return this.myConnection;
      }

      set
      {
        this.myConnection = value;
        this.editTypeSet1.Connection = value;
        this.editTypeHash1.Connection = value;
        this.editTypeList1.Connection = value;
        this.editTypeText1.Connection = value;
        this.editTypeZSet1.Connection = value;
      }
    }

    /// <summary>
    /// Définition de la clé à afficher
    /// </summary>
    public KeySearchResult CurrentKey
    {
      set
      {
        this.currentKey = value;
        this.GereSelection();
      }
    }

    /// <summary>
    /// Enregistre les propriétés de mise en forme du contrôle
    /// </summary>
    public void SaveProperties()
    {
      this.editTypeHash1.SaveProperties();
      this.editTypeSet1.SaveProperties();
      this.editTypeList1.SaveProperties();
      this.editTypeText1.SaveProperties();
      this.editTypeZSet1.SaveProperties();
    }

    /// <summary>
    /// Charge les propriété du composant
    /// </summary>
    public void LoadProperties()
    {
      this.editTypeSet1.LoadProperties();
      this.editTypeHash1.LoadProperties();
      this.editTypeList1.LoadProperties();
      this.editTypeText1.LoadProperties();
      this.editTypeZSet1.LoadProperties();
    }
    #endregion

    #region Internal Events
    /// <summary>
    /// Changement dans un editeur
    /// </summary>
    /// <param name="sender">qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void EditTypeOnChange(object sender, EventArgs e)
    {
      this.GereSelection();
    }

    /// <summary>
    /// RAZ du TTL de la clé en cours d'affichage
    /// </summary>
    /// <param name="sender">qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtClearTTLClick(object sender, EventArgs e)
    {
      if (this.currentKey != null)
      {
        this.Connection.Connector.Persist(this.currentKey.Key);
        this.FillDetail();
        this.DisplayEditTTl(false);
      }
    }

    /// <summary>
    /// Définition de la clé en cours d'affichage
    /// </summary>
    /// <param name="sender">qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtSetTTLClick(object sender, EventArgs e)
    {
      if (this.currentKey != null)
      {
        int nb = Convert.ToInt32(this.numTTL.Value);
        int factor = this.cbTTL.SelectedIndex == 1 ? 60 : this.cbTTL.SelectedIndex == 2 ? 3600 : 1;
        this.Connection.Connector.Expire(this.currentKey.Key, nb * factor);
        this.FillDetail();
        this.DisplayEditTTl(false);
      }
    }

    /// <summary>
    /// Afficher l'éditeur de TTL
    /// </summary>
    /// <param name="sender">qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtEditTTLClick(object sender, EventArgs e)
    {
      this.DisplayEditTTl(true);
    }

    /// <summary>
    /// Annule l'affichage de l'éditeur de TTL
    /// </summary>
    /// <param name="sender">qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtCancelEditTTLClick(object sender, EventArgs e)
    {
      this.DisplayEditTTl(false);
    }

    /// <summary>
    /// Suppression de la clé sélectionnée
    /// </summary>
    /// <param name="sender">qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtDelKeyClick(object sender, EventArgs e)
    {
      if (this.KeySearcher != null && this.currentKey != null)
      { // y a une cle et l'outil de recherche est câblé
        if (MessageBox.Show(this, Properties.Resources.KeyExplorerBtDelKeyConfirmD, Properties.Resources.KeyExplorerBtDelKeyConfirmT, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
        { // validé par le user
          if (this.currentKey.Del(this.Connection) > 0)
          { // rafraichir la recherche + RAZ de l'interface
            this.KeySearcher.RemoveKey(this.currentKey, true);
            this.currentKey = null;
            this.GereSelection();
          }
        }
      }
    }

    /// <summary>
    /// Renommer une clé
    /// </summary>
    /// <param name="sender">qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtRenameClick(object sender, EventArgs e)
    {
      if (this.KeySearcher != null && this.currentKey != null)
      { // y a une cle et l'outil de recherche est câblé
        using (FRename frm = new FRename())
        {
          frm.KeyName = this.currentKey.Key;
          if (frm.ShowDialog(this) == DialogResult.OK)
          { // validé par le user
            string newName = frm.KeyName;
            if (this.currentKey.Rename(this.Connection, newName))
            { // rafraichir la recherche + RAZ de l'interface
              this.KeySearcher.FireSearch();
              this.GereSelection();
            }
          }
        }
      }
    }

    /// <summary>
    /// Ajouter une nouvelle clé
    /// </summary>
    /// <param name="sender">qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtAddKeyClick(object sender, EventArgs e)
    {
      FAddKey.ProcessAdd(this.Connection, this);
    }

    /// <summary>
    /// Calcule la taille de la ou les clés affichées
    /// </summary>
    /// <param name="sender">qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtSizeOfClick(object sender, EventArgs e)
    {
      if (this.currentKey == null)
      { // pas de sélection pas de calcul (au cas ou)
        return;
      }

      long size = this.currentKey.Size(this.Connection);

      string txt, sizeTxt;
      if (size == 0)
      {
        txt = Properties.Resources.KeyExplorerBtSizeOfConfirmD0;
        sizeTxt = Properties.Resources.KeySize0;
      }
      else
      {
        sizeTxt = InformationBase.GetCounterBit(size);
        txt = string.Format(Properties.Resources.KeyExplorerBtSizeOfConfirmDN1, sizeTxt);
      }

      this.lblPoids.Text = sizeTxt;
      MessageBox.Show(this, txt, Properties.Resources.KeyExplorerBtSizeOfConfirmT, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    #endregion

    #region Display Key Methods
    /// <summary>
    /// Met à jour l'interface en fonction de la clé sélectionnée
    /// </summary>
    private void GereSelection()
    {
      if (this.currentKey == null)
      { // pas de sélection pas d'affichage
        this.ClearDetail();
      }
      else 
      { // affichage de la clé sélectionnée
        this.FillDetail();
      }
    }

    /// <summary>
    /// Efface toutes les info = pas de sélection
    /// </summary>
    private void ClearDetail()
    {
      this.lblTitre.Text = string.Empty;
      this.txtTitre.Visible = false;
      this.imgType.Image = null;
      this.pnlDefineTTL.Visible = false;
      this.btEditTTL.Visible = false;
      this.pnlDetail.Visible = true;
      this.lblTypeCle.Text = string.Empty;
      this.lblValue.Text = string.Empty;
      this.FillTimeToLive(null);
      this.editTypeSet1.Visible = false;
      this.editTypeHash1.Visible = false;
      this.editTypeList1.Visible = false;
      this.editTypeText1.Visible = false;
      this.editTypeZSet1.Visible = false;
      this.pnlDefault.Visible = false;
      this.btDelKey.Enabled = false;
      this.btSizeOf.Enabled = false;
      this.toolTip1.SetToolTip(this.btSizeOf, Properties.Resources.KeyExplorerBtSizeOfD1);
      this.btAddKey.Enabled = true;
      this.lblPoids.Text = string.Empty;
    }

    /// <summary>
    /// Remplit l'interface pour la clé key
    /// </summary>
    private void FillDetail()
    {
      ////this.lblTitre.Text = string.Format(Properties.Resources.KeyExplorerlblDetailTKey, this.currentKey.Key);
      this.lblTitre.Text = Properties.Resources.KeyExplorerlblDetailTKey;
      this.txtTitre.Text = this.currentKey.Key;
      this.txtTitre.Visible = true;
      this.btDelKey.Enabled = true;
      this.btSizeOf.Enabled = true;
      this.toolTip1.SetToolTip(this.btSizeOf, Properties.Resources.KeyExplorerBtSizeOfD1);
      this.btAddKey.Enabled = true;
      this.lblPoids.Text = string.Empty;
      this.imgType.Image = this.imageList2.Images[this.currentKey.Type.ToString()];

      this.FillTimeToLive(this.currentKey);

      this.pnlDetail.Visible = true;
      this.editTypeSet1.Visible = false;
      this.editTypeHash1.Visible = false;
      this.editTypeList1.Visible = false;
      this.editTypeText1.Visible = false;
      this.editTypeZSet1.Visible = false;
      this.pnlDefault.Visible = false;
      switch (this.currentKey.Type)
      {
        case ETypeKey.Tstring:
          this.editTypeText1.Key = this.currentKey.Key;
          this.editTypeText1.Visible = true;
          this.lblTypeCle.Text = this.currentKey.Type.GetLibelle();
          break;
        case ETypeKey.Tlist:
          this.editTypeList1.Key = this.currentKey.Key;
          this.editTypeList1.Visible = true;
          this.lblTypeCle.Text = this.GetCountList(ETypeKey.Tlist.GetLibelle(), EditTypeSet.SEUIL, this.editTypeList1.Count);
          break;
        case ETypeKey.Tset:
          this.editTypeSet1.Key = this.currentKey.Key;
          this.editTypeSet1.Visible = true;
          this.lblTypeCle.Text = this.GetCountList(ETypeKey.Tset.GetLibelle(), EditTypeSet.SEUIL, this.editTypeSet1.Count);
          break;
        case ETypeKey.Tzset:
          this.editTypeZSet1.Key = this.currentKey.Key;
          this.editTypeZSet1.Visible = true;
          this.lblTypeCle.Text = this.GetCountList(ETypeKey.Tzset.GetLibelle(), EditTypeSet.SEUIL, this.editTypeSet1.Count);
          break;
        case ETypeKey.Thash:
          this.editTypeHash1.Key = this.currentKey.Key;
          this.editTypeHash1.Visible = true;
          this.lblTypeCle.Text = this.GetCountList(ETypeKey.Thash.GetLibelle(), EditTypeHash.SEUIL, this.editTypeHash1.Count);
          break;
        default:
          this.pnlDefault.Visible = true;
          this.lblTypeCle.Text = this.currentKey.Type.GetLibelle();
          this.lblValue.Text = string.Empty;
          break;
      }
    }

    /// <summary>
    /// Affiche le Time to Live
    /// </summary>
    /// <param name="key">La clé a afficher</param>
    private void FillTimeToLive(KeySearchResult key)
    {
      if (key == null)
      {
        this.lblTTL.Text = string.Empty;
        this.pnlDefineTTL.Visible = false;
        this.btEditTTL.Visible = false;
      }
      else if (key.Type != ETypeKey.Tnone)
      {
        TimeSpan ts = this.Connection.Connector.TTL(key.Key);
        if (ts.TotalSeconds > 0)
        {
          this.lblTTL.Text = ts.ToFormatted();
          this.DisplayEditTTl(false);
          this.btClearTTL.Visible = true;
        }
        else if (ts.TotalSeconds == 0)
        {
          this.lblTTL.Text = Properties.Resources.KeyExplorerLblTTLTExpired;
          this.DisplayEditTTl(false);
          this.btEditTTL.Visible = false;
          this.btClearTTL.Visible = false;
        }
        else
        {
          this.lblTTL.Text = Properties.Resources.KeyExplorerLblTTLTInfinite;
          this.DisplayEditTTl(false);
          this.btClearTTL.Visible = false;
        }
      }
      else
      {
        this.lblTTL.Text = Properties.Resources.KeyExplorerLblTTLTExpired;
        this.DisplayEditTTl(false);
        this.btEditTTL.Visible = false;
        this.btClearTTL.Visible = false;
      }
    }

    /// <summary>
    /// Affiche ou masque l'éditeur de TTL
    /// </summary>
    /// <param name="display">TRUE si affiche</param>
    private void DisplayEditTTl(bool display)
    {
      this.pnlDefineTTL.Visible = display;
      this.btEditTTL.Visible = !display;
    }

    /// <summary>
    /// renvoie le nombre d'éléments dans la valeur d'une clé de type enuméré
    /// </summary>
    /// <param name="titre">Le type à afficher</param>
    /// <param name="seuil">La seuil au delà duquel l'affichage est partiel</param>
    /// <param name="n">Le nombre d'éléments à afficher</param>
    /// <returns>Le texte formaté</returns>
    private string GetCountList(string titre, int seuil, int n)
    {
      if (n < 0)
      {
        return titre + " " + Properties.Resources.KeyExplorerCountListWithoutValue;
      }
      else if (n == 1)
      {
        return titre + " " + Properties.Resources.KeyExplorerCountListWith1Value;
      }
      else
      {
        string s = titre + " " + string.Format(Properties.Resources.KeyExplorerCountListWithNValue, n);
        if (seuil > 1 && n > seuil)
        {
          s += " " + string.Format(Properties.Resources.KeyExplorerCountListTrim, seuil);
        }

        return s;
      }
    }
    #endregion
  }
}
