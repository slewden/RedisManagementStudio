using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RedisManagementStudio.BLL.Redis.Client
{
  /// <summary>
  /// Affiche le détail d'un client
  /// </summary>
  public partial class RedisClientUI : UserControl
  {
    /// <summary>
    /// Le client affiché
    /// </summary>
    private RedisClientListTranslator myClient = null;

    /// <summary>
    /// La liste des clients trouvés
    /// </summary>
    private List<RedisClientListTranslator> myList = null;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="RedisClientUI" />.
    /// </summary>
    public RedisClientUI()
    {
      this.InitializeComponent();

      this.lblDetail.Text = Properties.Resources.RedisClientUIlblDetailT0;
      this.lblInfoDescriptionCaption.Text = Properties.Resources.RedisClientUIlblInfoDescriptionCaptionT;
      this.lblInfoBrute.Text = string.Empty;
      this.colPropertie.Text = Properties.Resources.RedisClientUIColPropertieT;
      this.colValue.Text = Properties.Resources.RedisClientUIColValueT;
      this.toolTip1.SetToolTip(this.btKillConnection, Properties.Resources.RedisClientUIBtKillD);
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
    /// Définition du client
    /// </summary>
    public RedisClientListTranslator Client
    {
      get
      {
        return this.myClient;
      }

      set
      {
        this.myClient = value;
        this.RefreshDisplay();
      }
    }

    /// <summary>
    /// La liste des clients actifs
    /// </summary>
    public List<RedisClientListTranslator> Clients
    {
      get
      {
        if (this.Connection != null)
        {
          this.myList = this.Connection.GetClients();
          return this.myList;
        }
        else
        {
          return null;
        }
      }
    }

    /// <summary>
    /// Renvoie le client sélectionné
    /// </summary>
    public RedisClientListTranslator SelectedClient
    {
      get
      {
        return this.lstClients.SelectedItem as RedisClientListTranslator;
      }
    }

    /// <summary>
    /// Mémorise la mis en forme de l'objet
    /// </summary>
    public void SaveProperties()
    {
      Properties.Settings.Default.RedisClientListUIColProperty = this.colPropertie.Width;
      Properties.Settings.Default.RedisClientListUIColValue = this.colValue.Width;
    }

    /// <summary>
    /// Chargement des infos
    /// </summary>
    public void LoadProperties()
    {
      this.colPropertie.Width = Properties.Settings.Default.RedisClientListUIColProperty;
      this.colValue.Width = Properties.Settings.Default.RedisClientListUIColValue;
    }
    #endregion

    #region Internal Events
    /// <summary>
    /// Sélection d'une propriété
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">paramètre inutile</param>
    private void LvPropertiesSelectedIndexChanged(object sender, EventArgs e)
    {
      this.UpdateSelection();
    }

    /// <summary>
    /// Sélection d'un client
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">paramètre inutile</param>
    private void LstClientsDoubleClick(object sender, EventArgs e)
    {
      if (this.lstClients.SelectedItem != null)
      {
        if (this.OnChange != null)
        {
          this.OnChange(this, new EventArgs());
        }
      }
    }

    /// <summary>
    /// Demande le Rafraichissement au parent
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">paramètre inutile</param>
    private void BtRefreshClick(object sender, EventArgs e)
    {
      if (this.OnRefresh != null)
      {
        this.OnRefresh(this, new EventArgs());
      }
    }

    /// <summary>
    /// Stoppe la connexion du client
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">paramètre inutile</param>
    private void BtKillConnectionClick(object sender, EventArgs e)
    {
      if (this.myClient != null)
      {
        if (MessageBox.Show(
          this,
          Properties.Resources.RedisClientUIStopConnexionConfirmD,
          Properties.Resources.RedisClientUIStopConnexionConfirmT,
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Exclamation,
          MessageBoxDefaultButton.Button2) == DialogResult.Yes)
        {
          string err = this.Connection.ClientKill(this.myClient.AdressIp);
          if (!string.IsNullOrWhiteSpace(err))
          {
            MessageBox.Show(
              this,
              err,
              Properties.Resources.RedisClientUIStopConnexionError,
              MessageBoxButtons.OK,
              MessageBoxIcon.Error);
          }
          else
          { // c'est ok on rafraichit la liste
            this.Client = null;
          }
        }
      }
    }
    #endregion

    /// <summary>
    /// Affiche les propriétés du client
    /// </summary>
    private void RefreshDisplay()
    {
      this.lvProperties.Items.Clear();
      this.lblInfoDescription.Text = string.Empty;
      if (this.myClient != null)
      {
        this.lblDetail.Text = string.Format(Properties.Resources.RedisClientUILblDetailTx, this.myClient.Index);
        this.lstClients.Visible = false;
        this.panel2.Visible = true;
        this.lvProperties.Visible = true;

        ListViewItem itx;
        foreach (var prop in this.myClient.Properties.OrderBy(x => x.Position))
        {
          itx = new ListViewItem(prop.Titre);
          itx.SubItems.Add(prop.Value);
          itx.Tag = prop;
          this.lvProperties.Items.Add(itx);
        }

        this.btKillConnection.Enabled = true;
        if (this.lvProperties.Items.Count > 0)
        {
          this.lvProperties.Items[0].Selected = true;
        }
      }
      else
      { // pas de client sélectionné on affiche la liste
        this.lblDetail.Text = Properties.Resources.RedisClientUIlblDetailT0;
        this.btKillConnection.Enabled = false;
        this.lstClients.Visible = true;
        this.lstClients.DataSource = this.myList;
        this.panel2.Visible = false;
        this.lvProperties.Visible = false;
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
        RedisClientListInfo nfo = this.lvProperties.SelectedItems[0].Tag as RedisClientListInfo;
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
  }
}