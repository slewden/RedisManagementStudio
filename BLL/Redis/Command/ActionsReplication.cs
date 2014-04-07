using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RedisManagementStudio.BLL.Redis.Command
{
  /// <summary>
  /// Gères les actions dédiées réplication
  /// </summary>
  public partial class ActionsReplication : UserControl
  {
    /// <summary>
    /// La connexion
    /// </summary>
    private RedisConnection myCnn;
    
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="ActionsReplication" />.
    /// </summary>
    public ActionsReplication()
    {
      this.InitializeComponent();
      this.Height = 40;

      this.btSlaveOfNone.Text = Properties.Resources.ActionsReplicationBtSlaveOfNoneT;
      this.label1.Text = Properties.Resources.ActionsReplicationLbl1T;
      this.label2.Text = Properties.Resources.ActionsReplicationLbl2T;
      this.label3.Text = Properties.Resources.ActionsReplicationLbl3T;
      this.label4.Text = Properties.Resources.ActionsReplicationLbl4T;
      this.label5.Text = Properties.Resources.ActionsReplicationLbl5T;
      this.label6.Text = Properties.Resources.ActionsReplicationLbl6T;
      this.label7.Text = Properties.Resources.ActionsReplicationLbl7T;
      this.lblCountSlaves.Text = string.Empty;
      this.btSlaveOf.Text = Properties.Resources.ActionsReplicationBtSlaveOfT;
      this.toolTip1.SetToolTip(this.txtAdresse, Properties.Resources.ActionsReplicationTxtAdresseD);
      this.toolTip1.SetToolTip(this.txtPort, Properties.Resources.ActionsReplicationTxtPortD);
      this.lblMasterDetail.Text = Properties.Resources.ActionsReplicationLblMasterDetailT0;
      this.txtPort.Text = Properties.Resources.ActionsReplicationTxtPortT0;
    }

    /// <summary>
    /// Notifie le parent qu'un rafraichissement est nécessaire
    /// </summary>
    public event EventHandler OnNotifyRefreshNeed;

    /// <summary>
    /// La connexion
    /// </summary>
    public RedisConnection Connection
    {
      get
      {
        return this.myCnn;
      }

      set
      {
        this.myCnn = value;
      }
    }

    /// <summary>
    /// Activation du panneau : on met à jour les infos
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void ActionsReplication_VisibleChanged(object sender, EventArgs e)
    {
      if (this.Visible)
      {
        this.LoadReplicationsInfos();
      }
    }

    /// <summary>
    /// Abonnement à un serveur Maitre
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtSlaveOfClick(object sender, EventArgs e)
    {
      if (this.Connection != null)
      {
        this.Connection.Connector.SlaveOf(this.txtAdresse.Text, this.txtPort.IntValue);
        this.FireNotifyRefresh();
      }
    }

    /// <summary>
    /// DESABONNEMENT d'un serveur Maitre
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtSlaveOfNoneClick(object sender, EventArgs e)
    {
      if (this.Connection != null)
      {
        this.Connection.Connector.SlaveOfNoOne();
        this.FireNotifyRefresh();
      }
    }

    /// <summary>
    /// Changement des infos du serveur
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void TxtMasterTextChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }

    /// <summary>
    /// Gère l'affichage du bouton SlaveOf
    /// </summary>
    private void GereBouton()
    {
      this.btSlaveOf.Enabled = !string.IsNullOrWhiteSpace(this.txtAdresse.Text) && this.txtPort.IntValue > 0 && this.txtPort.IntValue < 9999;
    }

    /// <summary>
    /// Charge les infos
    /// </summary>
    private void LoadReplicationsInfos()
    {
      if (this.Connection != null)
      {
        Dictionary<string, string> nfos = this.Connection.Connector.Info();

        if (nfos.ContainsKey("role"))
        {
          bool estMaitre = nfos["role"].ToLower() == "master";
          if (!estMaitre)
          { // c'est un esclave
            this.pnlSlave.Visible = true;
            this.pnlMaster.Visible = false;
            this.pnlStandAlone.Visible = false;
            string masterAdresse = nfos.ContainsKey("master_host") ? nfos["master_host"] : Properties.Resources.ActionsReplicationLblMasterAdresseNone;
            string masterPort = nfos.ContainsKey("master_port") ? nfos["master_port"] : Properties.Resources.ActionsReplicationLblMasterPortNone;
            this.lblMasterDetail.Text = string.Format(Properties.Resources.ActionsReplicationLblMasterDetailTx, masterAdresse, masterPort);
          }
          else
          { // c'est un maitre ou stand alone
            this.pnlSlave.Visible = false;

            int nb = 0;
            if (nfos.ContainsKey("connected_slaves"))
            {
              int v;
              if (int.TryParse(nfos["connected_slaves"], out v))
              {
                nb = v;
              }
            }

            if (nb == 0)
            { // stand alone
              this.pnlMaster.Visible = false;
              this.pnlStandAlone.Visible = true;
            }
            else
            { // master with slaves
              this.pnlMaster.Visible = true;
              this.pnlStandAlone.Visible = false;
              this.lblCountSlaves.Text = nb == 1 ? Properties.Resources.ActionsReplicationLblCountSlaves1 : string.Format(Properties.Resources.ActionsReplicationLblCountSlavesN, nb);
            }
          }
        }
      }
      else
      { // pas de connexion pas d'affichage
        this.pnlSlave.Visible = false;
        this.pnlMaster.Visible = false;
        this.pnlStandAlone.Visible = false;
      }

      this.GereBouton();
    }

    /// <summary>
    /// Notifie le parent qu'il faut Rafraichir
    /// </summary>
    private void FireNotifyRefresh()
    {
      this.LoadReplicationsInfos();
      if (this.OnNotifyRefreshNeed != null)
      {
        this.OnNotifyRefreshNeed(this, new EventArgs());
      }
    }
  }
}
