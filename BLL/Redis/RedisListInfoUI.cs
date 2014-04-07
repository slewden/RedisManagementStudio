using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RedisManagementStudio.BLL.Redis
{
  /// <summary>
  /// Affiche le détail des configurations + Infos du serveur
  /// </summary>
  public partial class RedisListInfoUI : UserControl
  {
    /// <summary>
    /// L'élément couramment sélectionné
    /// </summary>
    private InformationBase myCurrentSel = null;

    /// <summary>
    /// Filtre su une seule rubrique
    /// </summary>
    private CmdInfoRubrique onlyRub = CmdInfoRubrique.AllRubrique;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="RedisListInfoUI" />.
    /// </summary>
    public RedisListInfoUI()
    {
      this.InitializeComponent();
      this.colServerProperty.Text = Properties.Resources.RedisListInfoUIColPropertyT;
      this.colServerValue.Text = Properties.Resources.RedisListInfoUIColValueT;
      this.toolTip1.SetToolTip(this.btRefresh, Properties.Resources.RedisListInfoUIBtRefreshD);
      this.toolTip1.SetToolTip(this.btConfigure, Properties.Resources.RedisListInfoUIBtConfigD); 
      this.listView1.SmallImageList = this.imageLib1.Alarms;
    }

    /// <summary>
    /// Notifie les changements de sélection au parent
    /// </summary>
    public event EventHandler OnSelectedItemChanged;

    /// <summary>
    /// Notifie après un nouveau remplissage
    /// </summary>
    public event EventHandler OnRefreshList;

    /// <summary>
    /// Défini la connexion à utiliser
    /// </summary>
    public RedisConnection Connection
    {
      get
      {
        return this.redisInfoUI1.Connexion;
      }

      set
      {
        this.redisInfoUI1.Connexion = value;
        this.actionsStatistiques1.Connection = value;
        this.actionsPersistance1.Connection = value;
        this.actionsCommand1.Connection = value;
        this.actionsReplication1.Connection = value;
       }
    }

    /// <summary>
    /// Renvoie ou défini l'élément couramment sélectionné
    /// </summary>
    public InformationBase Current
    {
      get
      {
        return this.myCurrentSel;
      }

      set
      {
        this.myCurrentSel = value;
        if (value != null)
        {
          InformationBase nfo;
          foreach (ListViewItem itx in this.listView1.Items)
          {
            nfo = itx.Tag as InformationBase;
            if (nfo != null && nfo.Code.Equals(value.Code))
            {
              itx.Selected = true;
            }
          }
        }
        else
        {
          this.listView1.SelectedItems.Clear();
        }
      }
    }
    
    /// <summary>
    /// Liste des groupes affichés
    /// </summary>
    public IEnumerable<CmdInfoRubrique> Groupes { get; private set; }

    /// <summary>
    /// Enregistre les propriétés de mise en forme du contrôle
    /// </summary>
    public void SaveProperties()
    {
      Properties.Settings.Default.RedisListInfoUIColProperty = this.colServerProperty.Width;
      Properties.Settings.Default.RedisListInfoUIColValue = this.colServerValue.Width;
    }

    /// <summary>
    /// Charge les propriété du composant
    /// </summary>
    public void LoadProperties()
    {
      this.colServerProperty.Width = Properties.Settings.Default.RedisListInfoUIColProperty;
      this.colServerValue.Width = Properties.Settings.Default.RedisListInfoUIColValue;
    }

    /// <summary>
    /// Force le remplissage de la liste pour une rubrique
    /// </summary>
    /// <param name="rub">pour une rubrique donnée</param>
    public void PerformFill(CmdInfoRubrique rub)
    {
      this.onlyRub = rub;
      this.RefreshDisplay();
    }

    /// <summary>
    /// Chargement de la page
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void RedisConfigUILoad(object sender, EventArgs e)
    {
      this.Groupes = null;
      this.LoadProperties();
    }

    /// <summary>
    /// Rafraichissement des données
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void BtRefreshClick(object sender, EventArgs e)
    {
      this.RefreshDisplay();
      this.FireRefresh();
    }

    /// <summary>
    /// Appel à la fenêtre de configuration
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void BtConfigureClick(object sender, EventArgs e)
    {
      using (FManageInfos frm = new FManageInfos())
      {
        frm.Connection = this.Connection;
        frm.Rubrique = this.myCurrentSel != null ? this.myCurrentSel.Rubrique : this.onlyRub;
        frm.ShowDialog();
      }

      this.btRefresh.PerformClick();
    }

    /// <summary>
    /// un des panneaux d'action demande un rafraichissement
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void PanelsActionOnNotifyRefreshNeed(object sender, EventArgs e)
    {
      this.RefreshDisplay();
      this.FireRefresh();
    }

    /// <summary>
    /// Changement de sélection
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void LvPropertiesSelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.listView1.SelectedItems.Count == 0)
      {
        this.myCurrentSel = null;
      }
      else
      {
        this.myCurrentSel = this.listView1.SelectedItems[0].Tag as InformationBase;
      }

      this.redisInfoUI1.Info = this.myCurrentSel;
      if (this.onlyRub == CmdInfoRubrique.AllRubrique)
      {
        this.actionsStatistiques1.Visible = this.myCurrentSel != null && this.myCurrentSel.Rubrique == CmdInfoRubrique.Statistics;
        this.actionsPersistance1.Visible = this.myCurrentSel != null && this.myCurrentSel.Rubrique == CmdInfoRubrique.Persistance;
        this.actionsCommand1.Visible = this.myCurrentSel != null && this.myCurrentSel.Rubrique == CmdInfoRubrique.Command;
        this.actionsReplication1.Visible = this.myCurrentSel != null && this.myCurrentSel.Rubrique == CmdInfoRubrique.Replication;
      }

      this.FireChanged();
    }

    /// <summary>
    /// une alarme vient de changer (ou être supprimée) : forcer le remplissage
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void RedisInfoUI1OnSaved(object sender, EventArgs e)
    {
      if (this.myCurrentSel == null)
      { // c'est pas normal à ce stade on ignore juste
        return;
      }

      this.RefreshDisplay();
    }

    /// <summary>
    /// Force le remplissage des informations
    /// </summary>
    private void RefreshDisplay()
    {
      this.listView1.BeginUpdate();
      this.listView1.Items.Clear();
      this.listView1.Groups.Clear();
      if (this.Connection != null)
      {
        IEnumerable<InformationBase> nfos = this.Connection.GetInfoAndConfig();

        if (nfos != null)
        {
          this.Groupes = nfos.Select(x => x.Rubrique).Distinct().OrderBy(x => Convert.ToInt32(x));
        }
        else
        {
          this.Groupes = new List<CmdInfoRubrique>();
        }

        IEnumerable<InformationBase> qq;
        if (nfos != null)
        {
          if (this.onlyRub == CmdInfoRubrique.AllRubrique)
          { // on active les rubriques
            foreach (CmdInfoRubrique grp in this.Groupes)
            {
              this.listView1.Groups.Add(new ListViewGroup(grp.ToString(), Rubrique.GetLibelle(grp)));
            }

            qq = nfos.OrderBy(x => x.Position);
          }
          else
          {
            qq = nfos.Where(x => x.Rubrique == this.onlyRub).OrderBy(x => x.Position);
            this.actionsStatistiques1.Visible = this.onlyRub == CmdInfoRubrique.Statistics;
            this.actionsPersistance1.Visible = this.onlyRub == CmdInfoRubrique.Persistance;
            this.actionsCommand1.Visible = this.onlyRub == CmdInfoRubrique.Command;
            this.actionsReplication1.Visible = this.onlyRub == CmdInfoRubrique.Replication;
          }
        }
        else
        {
          qq = new List<InformationBase>();
          this.actionsStatistiques1.Visible = false;
          this.actionsPersistance1.Visible = false;
          this.actionsCommand1.Visible = false;
          this.actionsReplication1.Visible = false;
        }

        ListViewItem itx;
        foreach (InformationBase nfo in qq)
        {
          itx = new ListViewItem();
          if (this.onlyRub == CmdInfoRubrique.AllRubrique)
          {
            itx.Group = this.listView1.Groups[nfo.Rubrique.ToString()];
          }

          itx.Tag = nfo;
          itx.Text = nfo.Titre;
          itx.SubItems.Add(nfo.Value);

          nfo.LoadAlarm();
          itx.ImageKey = nfo.GetAlarmStatut().ToString();

          if (nfo.CompareKey(this.myCurrentSel))
          { // resélection du dernier élément affiché
            itx.Selected = true;
            this.redisInfoUI1.Info = nfo;
          }

          this.listView1.Items.Add(itx);
        }
      }

      this.listView1.EndUpdate();
      if (this.listView1.SelectedItems.Count == 0)
      {
        if (this.listView1.Items.Count > 0)
        {
          if (this.listView1.Groups.Count > 0)
          { // y a plusieurs groupe on prend le premier element du premier groupe
            this.myCurrentSel = this.listView1.Groups[0].Items[0].Tag as InformationBase;
            this.listView1.Groups[0].Items[0].Selected = true;
          }
          else
          { // y a pas de groupe on prend le premier de la liste
            this.myCurrentSel = this.listView1.Items[0].Tag as InformationBase;
            this.listView1.Items[0].Selected = true;
          }

          this.redisInfoUI1.Info = this.myCurrentSel;
        }
        else
        {
          this.myCurrentSel = null;
          this.redisInfoUI1.Info = null;
        }
      }
      else
      {
        this.listView1.SelectedItems[0].EnsureVisible();
      }

      this.FireChanged();
    }

    /// <summary>
    /// Actualise l'affichage
    /// </summary>
    private void FireRefresh()
    {
      if (this.OnRefreshList != null)
      {
        this.OnRefreshList(this, new EventArgs());
      }
    }

    /// <summary>
    /// Notifie le parent s'il y a lieu
    /// </summary>
    private void FireChanged()
    {
      if (this.OnSelectedItemChanged != null)
      {
        this.OnSelectedItemChanged(this, new EventArgs());
      }
    }
  }
}
