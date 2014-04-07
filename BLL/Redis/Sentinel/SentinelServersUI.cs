using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RedisManagementStudio.BLL.Redis.Sentinel
{
  /// <summary>
  /// Gère l'affichages informations des serveurs suivis par sentinel
  /// </summary>
  public partial class SentinelServersUI : UserControl
  {
    /// <summary>
    /// Le serveur affiché
    /// </summary>
    private SentinelServer myServeur = null;

    /// <summary>
    /// La liste des serveurs suivis
    /// </summary>
    private List<SentinelServer> myList = null;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="SentinelServersUI" />.
    /// </summary>
    public SentinelServersUI()
    {
      this.InitializeComponent();

      this.lblTitre.Text = Properties.Resources.SentinelServersTitre;
      this.lblInfoDescriptionCaption.Text = Properties.Resources.SentinelServersDescriptionCaptionT;
      this.lblInfoBrute.Text = string.Empty;
      this.colPropertie.Text = Properties.Resources.SentinelServersColPropertyT;
      this.colValue.Text = Properties.Resources.SentinelServersColValueT;
    }

    #region Interface publique
    /// <summary>
    /// Notifie un changement de sélection au parent
    /// </summary>
    public event EventHandler OnChange;
    
    /// <summary>
    /// Notifie un Rafraichissement à faire au parent
    /// </summary>
    public event EventHandler OnRefresh;
   
    /// <summary>
    /// Défini la connexion à utiliser
    /// </summary>
    public RedisConnection Connection { private get; set; }

    /// <summary>
    /// Obtient ou défini le serveur a afficher
    /// </summary>
    public SentinelServer Serveur
    {
      get
      {
        return this.myServeur;
      }

      set
      {
        this.myServeur = value;
        this.RefreshDisplay();
      }
    }

    /// <summary>
    /// Calcule la liste des serveurs
    /// </summary>
    public List<SentinelServer> Serveurs
    {
      get
      {
        if (this.Connection != null)
        {
          this.myList = this.Connection.GetSentinelServers();
          foreach (SentinelServer srv in this.myList)
          {
            if (!string.IsNullOrWhiteSpace(srv.Name))
            {
              srv.SlavesAdd(this.Connection.GetSentinelSlaves(srv.Name));
            }
          }

          return this.myList;
        }
        else
        {
          return null;
        }
      }
    }

    /// <summary>
    /// Renvoie l'esclave sélectionné
    /// </summary>
    public SentinelServer SelectedSlave
    {
      get
      {
        return this.lstSlaves.SelectedItem as SentinelServer;
      }
    }

    /// <summary>
    /// Mémorise la mis en forme de l'objet
    /// </summary>
    public void SaveProperties()
    {
      Properties.Settings.Default.ColWidthSentinelServersProperty = this.colPropertie.Width;
      Properties.Settings.Default.ColWidthSentinelServersValue = this.colValue.Width;
      Properties.Settings.Default.SentinelServersSplitter = this.splitContainer1.SplitterDistance;
    }

    /// <summary>
    /// Chargement des infos
    /// </summary>
    public void LoadProperties()
    {
      this.colPropertie.Width = Properties.Settings.Default.ColWidthSentinelServersProperty;
      this.colValue.Width = Properties.Settings.Default.ColWidthSentinelServersValue;
      this.splitContainer1.SplitterDistance = Properties.Settings.Default.SentinelServersSplitter;
    }
    #endregion

    #region Internal Events
    /// <summary>
    /// Sélection d'une propriété
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void LvPropertiesSelectedIndexChanged(object sender, EventArgs e)
    {
      this.UpdateSelection();
    }
    
    /// <summary>
    /// On veut voir un serveur slave
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void LstSlavesDoubleClick(object sender, EventArgs e)
    {
      if (this.lstSlaves.SelectedItem != null)
      {
        if (this.OnChange != null)
        {
          this.OnChange(this, new EventArgs());
        }
      }
    }

    /// <summary>
    /// Force le rafraichissement de l'objet
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtRefreshClick(object sender, EventArgs e)
    {
      if (this.OnRefresh != null)
      {
        this.OnRefresh(this, new EventArgs());
      }
    }
    #endregion

    /// <summary>
    /// Affiche les propriétés du serveur
    /// </summary>
    private void RefreshDisplay()
    {
      this.lvProperties.Items.Clear();
      this.lstSlaves.DataSource = null;

      this.lblInfoDescription.Text = string.Empty;
      if (this.myServeur != null)
      {
        this.lblTitre.Text = string.Format(Properties.Resources.SentinelServersTitrex, this.myServeur.Index);
        ListViewItem itx;
        foreach (SentinelServerSuivisInfo prop in this.myServeur.Properties.OrderBy(x => x.Position))
        {
          itx = new ListViewItem(prop.Titre);
          itx.SubItems.Add(prop.Value);
          itx.Tag = prop;
          this.lvProperties.Items.Add(itx);
        }

        if (this.lvProperties.Items.Count > 0)
        {
          this.lvProperties.Items[0].Selected = true;
        }

        this.splitContainer1.Panel1Collapsed = false; 
        this.splitContainer1.Panel2Collapsed = !this.myServeur.IsMaster; 
        if (this.myServeur.IsMaster)
        { // on remplit la liste des slaves s'il y a lieu
          this.lstSlaves.DataSource = this.myServeur.Slaves;
        }
      }
      else
      { // mode liste des serveurs
        this.lblTitre.Text = Properties.Resources.SentinelServersTitre;
        this.splitContainer1.Panel1Collapsed = true;
        this.lstSlaves.DataSource = this.myList;
      }

      this.UpdateSelection();
    }

    /// <summary>
    /// Met à jour les infos de l'élément sélectionné
    /// </summary>
    private void UpdateSelection()
    {
      if (this.lvProperties.SelectedItems.Count == 0)
      {
        this.lblInfoDescription.Text = string.Empty;
        this.lblInfoBrute.Text = string.Empty;
      }
      else
      {
        SentinelServerSuivisInfo nfo = this.lvProperties.SelectedItems[0].Tag as SentinelServerSuivisInfo;
        if (nfo != null)
        {
          this.lblInfoDescription.Text = nfo.Description;
          this.lblInfoBrute.Text = nfo.OriginalValue;
        }
        else
        {
          this.lblInfoDescription.Text = string.Empty;
          this.lblInfoBrute.Text = string.Empty;
        }
      }
    }

    /// <summary>
    /// Lance la notification de changement au parent
    /// </summary>
    private void FireOnChange()
    {
    }
  }
}