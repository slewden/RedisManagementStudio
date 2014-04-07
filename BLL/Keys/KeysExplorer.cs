using System;
using System.Windows.Forms;
using RedisManagementStudio.BLL.Redis;

namespace RedisManagementStudio.BLL.Keys
{
  /// <summary>
  /// Controle pour l'affichage d'une liste de clé en DB
  /// </summary>
  public partial class KeysExplorer : UserControl
  {
    /// <summary>
    /// La clé couramment sélectionnée
    /// </summary>
    private string currentKey = string.Empty;

    /// <summary>
    /// La connexion
    /// </summary>
    private RedisConnection myConnection;

    /// <summary>
    /// Constructeur de la classe
    /// </summary>
    public KeysExplorer()
    {
      this.InitializeComponent();

      this.ClearDetail();
      this.numTTL.Value = 30;
      this.cbTTL.SelectedIndex = 0;
      this.keyGroup1.ImageList = this.keySearch1.imageList1;
    }

    #region Interface publique
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
        this.keySearch1.Connection = value;
        this.editTypeSet1.Connection = value;
        this.editTypeHash1.Connection = value;
        this.editTypeList1.Connection = value;
        this.editTypeText1.Connection = value;
        this.editTypeZSet1.Connection = value;
      }
    }

    /// <summary>
    /// Enregistre les proppriétés de mise en forme du controle
    /// </summary>
    public void SaveProperties()
    {
      Properties.Settings.Default.KeyExplorerSplitter = this.splitContainer1.SplitterDistance;
      this.keySearch1.SaveProperties();
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
      this.splitContainer1.SplitterDistance = Properties.Settings.Default.KeyExplorerSplitter;
      this.keySearch1.LoadProperties();
      this.editTypeSet1.LoadProperties();
      this.editTypeHash1.LoadProperties();
      this.editTypeList1.LoadProperties();
      this.editTypeText1.LoadProperties();
      this.editTypeZSet1.LoadProperties();
    }
    #endregion

    #region Events
    /// <summary>
    /// Lancement d'une recherche de clés
    /// </summary>
    /// <param name="sender">qui appalle</param>
    /// <param name="e">param inutile</param>
    private void KeySearchOnSearch(object sender, EventArgs e)
    {
      this.GereSelection();
    }

    /// <summary>
    /// Changement de la clé courament sélectionnée
    /// </summary>
    /// <param name="sender">qui appalle</param>
    /// <param name="e">param inutile</param>
    private void KeySearchOnChange(object sender, EventArgs e)
    {
      this.GereSelection();
    }

    /// <summary>
    /// Choix d'un élément depuis un groupe : mettre à jour la sélection dans la recherche
    /// </summary>
    /// <param name="sender">qui appalle</param>
    /// <param name="e">param inutile</param>
    private void KeyGroup1OnChange(object sender, EventArgs e)
    {
      TreeNode nod = this.keyGroup1.Selection;
      this.keySearch1.SelectedNode = nod;
    }

    /// <summary>
    /// Changement dans un editeur
    /// </summary>
    /// <param name="sender">qui appalle</param>
    /// <param name="e">param inutile</param>
    private void EditTypeOnChange(object sender, EventArgs e)
    {
      this.GereSelection();
    }

    /// <summary>
    /// RAZ du TTL de la clé en cours d'affichage
    /// </summary>
    /// <param name="sender">qui appalle</param>
    /// <param name="e">param inutile</param>
    private void BtClearTTLClick(object sender, EventArgs e)
    {
      if (!string.IsNullOrWhiteSpace(this.currentKey))
      {
        this.Connection.Connector.Persist(this.currentKey);
        this.FillDetail(this.currentKey);
      }
    }

    /// <summary>
    /// Définition de la clé en cours d'affichage
    /// </summary>
    /// <param name="sender">qui appalle</param>
    /// <param name="e">param inutile</param>
    private void BtSetTTLClick(object sender, EventArgs e)
    {
      if (!string.IsNullOrWhiteSpace(this.currentKey))
      {
        int nb = Convert.ToInt32(this.numTTL.Value);
        int factor = this.cbTTL.SelectedIndex == 1 ? 60 : this.cbTTL.SelectedIndex == 2 ? 3600 : 1;
        this.Connection.Connector.Expire(this.currentKey, nb * factor);
        this.FillDetail(this.currentKey);
      }
    }
    #endregion

    #region Display Key Methods
    /// <summary>
    /// Met à jour l'interface en fonction de la clé sélectionnée
    /// </summary>
    private void GereSelection()
    {
      string sel = this.keySearch1.SelectedText;
      if (string.IsNullOrWhiteSpace(sel))
      { // pas de sélection pas d'affichage
        this.ClearDetail();
      }
      else if (this.keySearch1.SelectedIsGroup)
      { // affichage du groupe des clé sélectionnées
        this.DisplayGroup(this.keySearch1.SelectedType, sel);
      }
      else
      { // affichage de la clé sélectionnée
        this.FillDetail(sel);
      }
    }

    /// <summary>
    /// Efface toutes les info = pas de sélection
    /// </summary>
    private void ClearDetail()
    {
      this.currentKey = string.Empty;
      this.lblDetail.Text = string.Empty;
      this.imgType.Image = null;

      this.pnlDetail.Visible = true;
      this.lblTypeCle.Text = string.Empty;
      this.lblValue.Text = string.Empty;
      this.FillTimeToLive(ETypeKey.UnKnow, string.Empty);
      this.editTypeSet1.Visible = false;
      this.editTypeHash1.Visible = false;
      this.editTypeList1.Visible = false;
      this.editTypeText1.Visible = false;
      this.editTypeZSet1.Visible = false;
      this.pnlDefault.Visible = false;
      this.keyGroup1.Visible = false;
    }

    /// <summary>
    /// Affiche le détail d'un groupe de clé
    /// </summary>
    /// <param name="tk">Type de clé a fficher</param>
    /// <param name="txt">Texte du groupe de clés</param>
    private void DisplayGroup(ETypeKey tk, string txt)
    {
      this.pnlDetail.Visible = false;
      this.editTypeSet1.Visible = false;
      this.editTypeHash1.Visible = false;
      this.editTypeList1.Visible = false;
      this.editTypeText1.Visible = false;
      this.editTypeZSet1.Visible = false;
      this.pnlDefault.Visible = false;

      this.currentKey = string.Empty;
      this.lblDetail.Text = string.Format("Groupe de clés du type {0} commencant par {1}", tk, txt);
      this.imgType.Image = this.imageList2.Images[tk.ToString()];
      this.keyGroup1.Visible = true;
      this.keyGroup1.Selection = this.keySearch1.SelectedNode;
    }

    /// <summary>
    /// Remplit l'interface pour la clé key
    /// </summary>
    /// <param name="key">La clé a afficher</param>
    private void FillDetail(string key)
    {
      this.currentKey = key;
      this.lblDetail.Text = string.Format("Détail de la clé : " + key);

      ETypeKey t = this.Connection.Type(key);
      this.imgType.Image = this.imageList2.Images[t.ToString()];

      this.FillTimeToLive(t, key);

      this.pnlDetail.Visible = true;
      this.editTypeSet1.Visible = false;
      this.editTypeHash1.Visible = false;
      this.editTypeList1.Visible = false;
      this.editTypeText1.Visible = false;
      this.editTypeZSet1.Visible = false;
      this.pnlDefault.Visible = false;
      this.keyGroup1.Visible = false;
      switch (t)
      {
        case ETypeKey.Tstring:
          this.editTypeText1.Key = key;
          this.editTypeText1.Visible = true;
          this.lblTypeCle.Text = t.GetLibelle();
          break;
        case ETypeKey.Tlist:
          this.editTypeList1.Key = key;
          this.editTypeList1.Visible = true;
          this.lblTypeCle.Text = this.GetCountList(ETypeKey.Tlist.GetLibelle(), EditTypeSet.SEUIL, this.editTypeList1.Count);
          break;
        case ETypeKey.Tset:
          this.editTypeSet1.Key = key;
          this.editTypeSet1.Visible = true;
          this.lblTypeCle.Text = this.GetCountList(ETypeKey.Tset.GetLibelle(), EditTypeSet.SEUIL, this.editTypeSet1.Count);
          break;
        case ETypeKey.Tzset:
          this.editTypeZSet1.Key = key;
          this.editTypeZSet1.Visible = true;
          this.lblTypeCle.Text = this.GetCountList(ETypeKey.Tzset.GetLibelle(), EditTypeSet.SEUIL, this.editTypeSet1.Count);
          break;
        case ETypeKey.Thash:
          this.editTypeHash1.Key = key;
          this.editTypeHash1.Visible = true;
          this.lblTypeCle.Text = this.GetCountList(ETypeKey.Thash.GetLibelle(), EditTypeHash.SEUIL, this.editTypeHash1.Count);
          break;
        default:
          this.pnlDefault.Visible = true;
          this.lblTypeCle.Text = t.GetLibelle();
          this.lblValue.Text = string.Empty;
          break;
      }
    }

    /// <summary>
    /// Affiche le Time to Live
    /// </summary>
    /// <param name="t">Type de donnée affichée</param>
    /// <param name="key">La clé a afficher</param>
    private void FillTimeToLive(ETypeKey t, string key)
    {
      if (string.IsNullOrWhiteSpace(key))
      {
        this.lblTTL.Text = string.Empty;
        this.pnlDefineTTL.Visible = false;
      }
      else if (t != ETypeKey.Tnone)
      {
        TimeSpan ts = this.Connection.Connector.TTL(key);
        if (ts.TotalSeconds > 0)
        {
          this.lblTTL.Text = ts.ToFormatted();
          this.pnlDefineTTL.Visible = true;
          this.btClearTTL.Visible = true;
        }
        else if (ts.TotalSeconds == 0)
        {
          this.lblTTL.Text = "Clé expirée";
          this.pnlDefineTTL.Visible = false;
        }
        else
        {
          this.lblTTL.Text = "Infinie";
          this.pnlDefineTTL.Visible = true;
          this.btClearTTL.Visible = false;
        }
      }
      else
      {
        this.lblTTL.Text = "Clé expirée";
      }
    }

    /// <summary>
    /// renvoie le nombre d'éléments dans la valeur d'une clé de type enuméré
    /// </summary>
    /// <param name="titre">Le type à afficher</param>
    /// <param name="seuil">La seui au dela duquel l'affichage est partiel</param>
    /// <param name="n">Le nombre d'éléments à afficher</param>
    /// <returns>Le texte formatté</returns>
    private string GetCountList(string titre, int seuil, int n)
    {
      if (n < 0)
      {
        return titre + " sans aucune valeur";
      }
      else if (n == 1)
      {
        return titre + " avec une seule valeur";
      }
      else
      {
        string s = string.Format("{0} avec {1} valeurs", titre, n);
        if (seuil > 1 && n > seuil)
        {
          s += string.Format(" (seules {0} valeurs affichées)", seuil);
        }

        return s;
      }
    }
    #endregion
  }
}
