using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ClientRedisLib.RedisClass;

namespace RedisManagementStudio.BLL.Redis.Monitor
{
  /// <summary>
  /// Gestion des Publications et abonnement à des CHANELS
  /// </summary>
  public partial class PubSubConsole : UserControl
  {
    /// <summary>
    /// Séparateur des colonnes dans le fichier de sauvegarde
    /// </summary>
    private const string FILESEPARATOR = ";";

    /// <summary>
    /// Format des dates : utilisé pour l'affichage
    /// </summary>
    private string dateFormat = Properties.Resources.MonitorConsoleTraceDateFormat;

    /// <summary>
    /// il faut une connexion spécifique à cet outil pour ne pas tout planter
    /// </summary>
    private RedisConnection myConnexion = null;

    /// <summary>
    /// Indique si l'on est abonné ou pas à un canal
    /// </summary>
    private bool abonne = false;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="PubSubConsole" />.
    /// </summary>
    public PubSubConsole()
    {
      this.InitializeComponent();

      this.toolTip1.SetToolTip(this.btSave, Properties.Resources.PubSubConsoleBtSaveD);
      this.toolTip1.SetToolTip(this.btSaveSelection, Properties.Resources.PubSubConsoleBtSaveSelD);
      this.saveFileDialog1.Filter = Properties.Resources.PubSubConsoleSaveFileFilter;
      this.saveFileDialog1.Title = Properties.Resources.PubSubConsoleSaveFileT;

      this.Mode = CommandMenuAction.PubSub;
    }

    #region Interface publique
    /// <summary>
    /// Notifie au parent le besoin de change d'affichage
    /// </summary>
    public event EventHandler OnChange;

    /// <summary>
    /// indique au parent si une trace est active
    /// </summary>
    public bool TraceIsActive
    {
      get
      {
        return this.abonne;
      }
    }

    /// <summary>
    /// Les infos de la connexion à surveiller : une nouvelle connexion va être crée
    /// </summary>
    public RedisConnection Connection { get; set; }

    /// <summary>
    /// Défini le mode d'affichage
    /// PUBSUB            : Décrit ce que cela fait
    /// PUBSUBPUBLICATION : Publication de message uniquement
    /// PUBSUBABONNEMENT  : Console d'abonnement
    /// </summary>
    public CommandMenuAction Mode
    {
      set
      {
        switch (value)
        {
          case CommandMenuAction.PubSubAbonnement:
            this.pnlInfos.Visible = false;
            this.pnlToolAbonnement.Visible = true;
            this.lstMessage.Visible = true;
            this.lstMessage.Dock = DockStyle.Fill;
            this.lblTitre.Text = Properties.Resources.PubSubConsoleLblTitreAbonnement;
            this.toolTip1.SetToolTip(this.btClear, Properties.Resources.PubSubConsoleBtClearD);
            this.toolTip1.SetToolTip(this.txtSubChanel, Properties.Resources.PubSubConsoleTxtSubChanelD);
            this.colAction.Text = Properties.Resources.PubSubConsoleColActionT;
            this.colChanel.Text = Properties.Resources.PubSubConsoleColChanelT;
            this.colDate.Text = Properties.Resources.PubSubConsoleColDateT;
            this.colMessage.Text = Properties.Resources.PubSubConsoleColMessageT;
            this.colPattern.Text = Properties.Resources.PubSubConsoleColPatternT;
            break;
          default: // autre valeur = mode par défaut 
            this.lblTitre.Text = Properties.Resources.PubSubConsoleLblTitreT;
            this.label3.Text = string.Concat(Properties.Resources.PubSubConsoleLbl3T1, " : ", Properties.Resources.PubSubConsoleLbl3T2);
            this.label3.LinkArea = new LinkArea(0, Properties.Resources.PubSubConsoleLbl3T1.Length);
            this.pnlToolAbonnement.Visible = false;
            this.lstMessage.Visible = false;
            this.pnlInfos.Visible = true;
            this.pnlInfos.Dock = DockStyle.Fill;
            this.label1.Text = Properties.Resources.PubSubConsoleLbl1T;
            this.lblPubChanel.Text = Properties.Resources.PubSubConsoleLblPubChanel;
            this.lblPubMessage.Text = Properties.Resources.PubSubConsoleLblPubMessage;
            this.toolTip1.SetToolTip(this.txtPubChanel, Properties.Resources.PubSubConsoleTxtPubChanelD);
            this.toolTip1.SetToolTip(this.txtPubMessage, Properties.Resources.PubSubConsoleTxtPubMessageD);
            this.btPublish.Text = Properties.Resources.PubSubConsoleBtPublishT;
            this.lblPublishStatut.Text = string.Empty;
            break;
        }

        this.GereBouton();
      }
    }

    /// <summary>
    /// Charge les données
    /// </summary>
    public void LoadProperties()
    {
      this.colAction.Width = Properties.Settings.Default.ColWidthPubSubAction;
      this.colChanel.Width = Properties.Settings.Default.ColWidthPubSubChanel;
      this.colDate.Width = Properties.Settings.Default.ColWidthPubSubDate;
      this.colMessage.Width = Properties.Settings.Default.ColWidthPubSubMessage;
      this.colPattern.Width = Properties.Settings.Default.ColWidthPubSubPattern;
    }

    /// <summary>
    /// Sauve les données et nettoie les connexions
    /// </summary>
    public void SaveProperties()
    {
      Properties.Settings.Default.ColWidthPubSubAction = this.colAction.Width;
      Properties.Settings.Default.ColWidthPubSubChanel = this.colChanel.Width;
      Properties.Settings.Default.ColWidthPubSubDate = this.colDate.Width;
      Properties.Settings.Default.ColWidthPubSubMessage = this.colMessage.Width;
      Properties.Settings.Default.ColWidthPubSubPattern = this.colPattern.Width;
      
      if (this.myConnexion != null)
      {
        this.myConnexion.Dispose();
        this.myConnexion = null;
      }
    }

    /// <summary>
    /// Arrête le monitoring
    /// </summary>
    public void Stop()
    {
      this.btStop.PerformClick();
    }
    #endregion

    #region Events
    /// <summary>
    /// Les informations de publication ont changé
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void TxtPubTextChanged(object sender, EventArgs e)
    {
      this.lblPublishStatut.Text = string.Empty;
      this.GereBouton();
    }

    /// <summary>
    /// Gestion du ENTER
    /// </summary>
    /// <param name="sender">inutile qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void TxtPubMessageKeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == '\n' || e.KeyChar == '\r')
      {
        this.btPublish.PerformClick();
      }
    }

    /// <summary>
    /// Publication d'un message
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtPublishClick(object sender, EventArgs e)
    {
      if (this.Connection != null)
      {
        int n = this.Connection.Connector.Publish(this.txtPubChanel.Text, this.txtPubMessage.Text);
        this.txtPubMessage.Text = string.Empty;
        string message;
        if (n == 0)
        {
          message = Properties.Resources.PubSubConsoleBtPublishConfirmD0;
        }
        else if (n == 1)
        { 
          message = Properties.Resources.PubSubConsoleBtPublishConfirmD1; 
        }
        else
        {
          message = string.Format(Properties.Resources.PubSubConsoleBtPublishConfirmDN, n);
        }

        this.lblPublishStatut.Text = message;
        this.GereBouton();
        this.txtPubMessage.Focus();
      }
    }

    /// <summary>
    /// Demande de passer en mode abonnement
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void Label3LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (this.OnChange != null)
      {
        this.OnChange(this, new EventArgs());
      }
    }

    /// <summary>
    /// Effacement de la liste des informations
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtClearClick(object sender, EventArgs e)
    {
      this.lstMessage.Items.Clear();
      this.GereBouton();
    }

    /// <summary>
    /// Gestion du changement du canal
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void TxtSubChanelTextChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }
    
    /// <summary>
    /// Démarre un abonnement
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtStartClick(object sender, EventArgs e)
    {
      if (!this.abonne && !string.IsNullOrWhiteSpace(this.txtSubChanel.Text))
      {
        this.btClear.PerformClick();
        this.EnsureConnexionExists();
        this.abonne = true;
        this.myConnexion.Connector.PSubscribe(new EventSubscribeHandeler(this.PublishReceiveInformation), this.txtSubChanel.Text);
        this.GereBouton();
      }
    }

    /// <summary>
    /// Stoppe un abonnement
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtStopClick(object sender, EventArgs e)
    {
      if (this.abonne && !string.IsNullOrWhiteSpace(this.txtSubChanel.Text))
      {
        this.myConnexion.Connector.PUnSubscribe(this.txtSubChanel.Text);
        this.abonne = false;
        this.GereBouton();
      }
    }

    /// <summary>
    /// Sauve toutes les infos dans un fichier
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtSaveClick(object sender, EventArgs e)
    {
      this.SaveData(true);
      this.GereBouton();
    }

    /// <summary>
    /// Sauve les lignes sélectionnées dans un fichier
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtSaveSelectionClick(object sender, EventArgs e)
    {
      if (this.lstMessage.SelectedItems.Count > 1)
      {
        this.SaveData(false);
        this.GereBouton();
      }
    }

    /// <summary>
    /// Changement de la sélection des messages affichés
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void LstMessageSelectedIndexChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }
    #endregion

    /// <summary>
    /// Gestion de l'activation des boutons
    /// </summary>
    private void GereBouton()
    {
      if (this.txtSubChanel.Text.IndexOf("*") != -1)
      { // s'il y a une étoile ==> on est multi-cannaux
        this.toolTip1.SetToolTip(this.btStart, string.Format(Properties.Resources.PubSubConsoleBtStartD2, this.txtSubChanel.Text));
        this.toolTip1.SetToolTip(this.btStop, string.Format(Properties.Resources.PubSubConsoleBtStopD2, this.txtSubChanel.Text));
      }
      else
      {
        this.toolTip1.SetToolTip(this.btStart, string.Format(Properties.Resources.PubSubConsoleBtStartD, this.txtSubChanel.Text));
        this.toolTip1.SetToolTip(this.btStop, string.Format(Properties.Resources.PubSubConsoleBtStopD, this.txtSubChanel.Text));
      }

      this.btStart.Enabled = !string.IsNullOrWhiteSpace(this.txtSubChanel.Text) && !this.abonne;
      this.btStop.Enabled = this.abonne;
      this.txtSubChanel.Enabled = !this.abonne;
      this.btSaveSelection.Enabled = this.lstMessage.SelectedItems.Count > 0;
      this.btSave.Enabled = this.lstMessage.Items.Count > 0;
    
      this.btPublish.Enabled = !string.IsNullOrWhiteSpace(this.txtPubChanel.Text) && !string.IsNullOrWhiteSpace(this.txtPubMessage.Text);
    }

    /// <summary>
    /// S'assure que la connexion existe avant de lancer une commande !
    /// </summary>
    private void EnsureConnexionExists()
    {
      if (this.Connection == null || this.Connection.Param == null)
      {
        throw new Exception(Properties.Resources.ErrorEditorsWithoutConnection);
      }

      if (this.myConnexion == null)
      {
        this.myConnexion = new RedisConnection(this.Connection.Param);
      }
    }

    /// <summary>
    /// SUBSCRIBE / PSBUSCRIBE Méthodes de CALLBACK : quand un message est dispo sur le serveur
    /// </summary>
    /// <param name="e">Contient les nouvelles informations du serveur</param>
    private void PublishReceiveInformation(EventSubscribeArgs e)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new EventSubscribeHandeler(this.ReceiveData), new object[] { e });
      }
      else
      {
        this.ReceiveData(e);
      }
    }

    /// <summary>
    /// SUBSCRIBE / PSBUSCRIBE Méthode de CALLBACK : quand un message est disponible sur le serveur
    /// </summary>
    /// <param name="e">Contient les nouvelles informations du serveur</param>
    private void ReceiveData(EventSubscribeArgs e)
    {
      if (e.CanQuit)
      {
        this.abonne = false;
        this.GereBouton();
      }
      else
      {
        DateTime dt = DateTime.Now;
        ListViewItem itx = new ListViewItem(dt.ToString(this.dateFormat));
        itx.SubItems.Add(e.MessageType);
        itx.SubItems.Add(e.Pattern);
        itx.SubItems.Add(e.Chanel);
        itx.SubItems.Add(e.Message);
        this.lstMessage.Items.Add(itx);
        itx.Tag = string.Format(
              Properties.Resources.PubSubConsoleTraceFileRow,
              PubSubConsole.FILESEPARATOR,
              dt.ToString(this.dateFormat),
              e.MessageType,
              e.Pattern,
              e.Chanel,
              e.Message);
        itx.EnsureVisible();
      }
    }

    /// <summary>
    /// Enregistre sur disque les données
    /// </summary>
    /// <param name="allDatas">Si TRUE toutes les données, sinon seulement les sélectionnée</param>
    private void SaveData(bool allDatas)
    {
      if (this.saveFileDialog1.ShowDialog(this) == DialogResult.OK)
      {
        using (StreamWriter tw = new StreamWriter(this.saveFileDialog1.FileName))
        {
          tw.WriteLine(string.Format(Properties.Resources.PubSubConsoleTraceFileEntete, PubSubConsole.FILESEPARATOR));
          if (allDatas)
          { // on veut tout
            foreach (ListViewItem itx in this.lstMessage.Items)
            {
              tw.WriteLine(itx.Tag.ToString());
            }
          }
          else
          {  // que les sélectionnés
            foreach (ListViewItem itx in this.lstMessage.SelectedItems)
            {
              tw.WriteLine(itx.Tag.ToString());
            }
          }
        }

        System.Diagnostics.Process.Start(this.saveFileDialog1.FileName);
      }
    }
  }
}
