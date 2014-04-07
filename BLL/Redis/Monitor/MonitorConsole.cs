using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ClientRedisLib.RedisClass;
using RedisManagementStudio.BLL.Connection;

namespace RedisManagementStudio.BLL.Redis.Monitor
{
  /// <summary>
  /// Contrôle pour la gestion d'une trace sur le serveur (Commande REDIS : Monitor)
  /// </summary>
  public partial class MonitorConsole : UserControl
  {
    #region Membres privés

    /// <summary>
    /// Séparateur des colonnes dans le fichier de trace
    /// </summary>
    private const string FILESEPARATOR = ";";
    
    /// <summary>
    /// Format des dates : utilisé pour l'affichage
    /// </summary>
    private string dateFormat = Properties.Resources.MonitorConsoleTraceDateFormat;
    
    /// <summary>
    /// Nom du fichier trace par défaut
    /// </summary>
    private string defaultFileTrace = Properties.Resources.MonitorConsoleTraceDefaultFile;

    /// <summary>
    /// Etat du moniteur PLAY/PAUSE/STOP
    /// </summary>
    private EMonitorMode monitorMode = EMonitorMode.Stop;

    /// <summary>
    /// il faut une connexion spécifique à cet outil pour ne pas tout planter
    /// </summary>
    private RedisConnection myConnexion = null;

    /// <summary>
    /// Les données de la Trace
    /// </summary>
    private List<EventMonitorArgs> dataPaused = null;
    #endregion

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="MonitorConsole" />.
    /// </summary>
    public MonitorConsole()
    {
      this.InitializeComponent();
      this.label1.Text = Properties.Resources.MonitorConsoleLbl1T;
      this.colDate.Text = Properties.Resources.MonitorConsoleColDate;
      this.colBaseId.Text = Properties.Resources.MonitorConsoleColBaseId;
      this.colIp.Text = Properties.Resources.MonitorConsoleColAdresse;
      this.colPort.Text = Properties.Resources.MonitorConsoleColPort;
      this.colCommand.Text = Properties.Resources.MonitorConsoleColCommand;
      this.saveFileDialog1.Filter = Properties.Resources.MonitorConsoleSaveFileFilter;
      this.saveFileDialog1.Title = Properties.Resources.MonitorConsoleSaveFileT;
      this.toolTip1.SetToolTip(this.btSave, Properties.Resources.MonitorConsoleBtSaveD);
      this.toolTip1.SetToolTip(this.btSaveSelection, Properties.Resources.MonitorConsoleBtSaveSelD);
      this.toolTip1.SetToolTip(this.chkScroll, Properties.Resources.MonitorConsoleChkScrollOn);
      this.toolTip1.SetToolTip(this.btClear, Properties.Resources.MonitorConsoleBtClearD);
      this.toolTip1.SetToolTip(this.btStop, Properties.Resources.MonitorConsoleBtStopD);
      this.toolTip1.SetToolTip(this.btPause, Properties.Resources.MonitorConsoleBtPauseD);
      this.toolTip1.SetToolTip(this.btStart, Properties.Resources.MonitorConsoleBtStartD);

      this.GereBouton();
    }

    /// <summary>
    /// Les modes du moniteur
    /// </summary>
    internal enum EMonitorMode
    {
      /// <summary>
      /// Mode arrêt
      /// </summary>
      Stop,

      /// <summary>
      /// En cours d'enregistrement
      /// </summary>
      Play,

      /// <summary>
      /// En pause = enregistre, mais n'affiche pas
      /// </summary>
      Pause,

      /// <summary>
      /// En cours d'arrêt : attend le dernier retour du serveur
      /// </summary>
      Stopping,
    }

    #region Interface publique
    /// <summary>
    /// Les infos de la connexion à surveiller : une nouvelle connexion va être crée
    /// </summary>
    public RedisConnectionParam ConnectionParam { get; set; }

    /// <summary>
    /// indique au parent si une trace est active
    /// </summary>
    public bool TraceIsActive
    {
      get
      {
        return this.monitorMode != EMonitorMode.Stop;
      }
    }

    /// <summary>
    /// Chargement de l'état du moniteur
    /// </summary>
    public void LoadProperties()
    {
      this.chkScroll.Checked = Properties.Settings.Default.MonitorConsoleScroll;
      this.colDate.Width = Properties.Settings.Default.ColWidthMonitorDate;
      this.colIp.Width = Properties.Settings.Default.ColWidthMonitorIp;
      this.colCommand.Width = Properties.Settings.Default.ColWidthMonitorCommand;
      this.colBaseId.Width = Properties.Settings.Default.ColWidthMonitorBase;
      this.colPort.Width = Properties.Settings.Default.ColWidthMonitorPort;

      string fileName = Properties.Settings.Default.MonitorConsoleSaveFileName;
      if (string.IsNullOrWhiteSpace(fileName))
      {
        FileInfo fix = new FileInfo(Application.ExecutablePath);
        fileName = Path.Combine(fix.DirectoryName, this.defaultFileTrace);
      }

      FileInfo fi = new FileInfo(fileName);
      this.saveFileDialog1.InitialDirectory = fi.DirectoryName;
      this.saveFileDialog1.FileName = fileName;
    }

    /// <summary>
    /// Sauvegarde et libération de la connexion
    /// </summary>
    public void SaveProperties()
    {
      Properties.Settings.Default.MonitorConsoleScroll = this.chkScroll.Checked; 
      Properties.Settings.Default.ColWidthMonitorDate = this.colDate.Width;
      Properties.Settings.Default.ColWidthMonitorIp = this.colIp.Width;
      Properties.Settings.Default.ColWidthMonitorCommand = this.colCommand.Width;
      Properties.Settings.Default.MonitorConsoleSaveFileName = this.saveFileDialog1.FileName;
      Properties.Settings.Default.ColWidthMonitorBase = this.colBaseId.Width;
      Properties.Settings.Default.ColWidthMonitorPort = this.colPort.Width;

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

    #region Les Events
    /// <summary>
    /// Démarrage du monitoring
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void BtStartClick(object sender, EventArgs e)
    {
      if (this.monitorMode == EMonitorMode.Stop || this.monitorMode == EMonitorMode.Pause)
      { // on est dans un état valide pour démarrer (Stop ou Pause)
        if (this.monitorMode == EMonitorMode.Stop)
        { // demmarre une nouvelle trace
          this.btClear.PerformClick();
          this.monitorMode = EMonitorMode.Play;
          this.ReceiveData(EventMonitorArgs.Trace(Properties.Resources.MonitorConsoleTRACESTART));
          this.EnsureConnexionExists();
          this.myConnexion.Connector.Monitor(new EventMonitorHandler(this.MonitorReceiveInformation));
        }
        else
        { // reprend la trace en cours
          this.ReceiveData(EventMonitorArgs.Trace(Properties.Resources.MonitorConsoleTRACERESUME));
          this.DisplayPausedDatas();
          this.monitorMode = EMonitorMode.Play; 
        }
        
        this.GereBouton();
      }
    }

    /// <summary>
    /// Demande d'arrêt du monitoring
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void BtStopClick(object sender, EventArgs e)
    {
      if (this.monitorMode == EMonitorMode.Play || this.monitorMode == EMonitorMode.Pause)
      {
        this.monitorMode = EMonitorMode.Stopping;
        this.GereBouton();
      }
    }

    /// <summary>
    /// Mise en pause du monitoring = stop d'afficher
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void BtPauseClick(object sender, EventArgs e)
    {
      if (this.monitorMode == EMonitorMode.Play)
      {
        this.ReceiveData(EventMonitorArgs.Trace(Properties.Resources.MonitorConsoleTRACEPAUSE));
        this.dataPaused = new List<EventMonitorArgs>();
        this.monitorMode = EMonitorMode.Pause;
        this.GereBouton();
      }
    }

    /// <summary>
    /// Effacer l'affichage et les données
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void BtClearClick(object sender, EventArgs e)
    {
      this.lstCommands.Items.Clear();
      this.GereBouton();
    }

    /// <summary>
    /// Enregistre les lignes sélectionnées
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void BtSaveSelectionClick(object sender, EventArgs e)
    {
      if (this.lstCommands.SelectedItems.Count > 1)
      {
        this.SaveData(false);
        this.GereBouton();
      }
    }

    /// <summary>
    /// Enregistre Toutes les lignes
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void BtSaveClick(object sender, EventArgs e)
    {
      this.SaveData(true);
      this.GereBouton();
    }

    /// <summary>
    /// Changement des lignes sélectionnées
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void LstCommandsSelectedIndexChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }

    /// <summary>
    /// Active ou pas le défilement
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void ChkScrollCheckedChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }
    #endregion

    /// <summary>
    /// Event de réception d'une information
    /// </summary>
    /// <param name="e">Tout le détail de la commande passée</param>
    private void MonitorReceiveInformation(EventMonitorArgs e)
    {
      if (this.InvokeRequired)
      {
        this.Invoke(new EventMonitorHandler(this.ReceiveData), new object[] { e });
      }
      else
      {
        this.ReceiveData(e);
      }
    }

    /// <summary>
    /// récupère les données 
    /// </summary>
    /// <param name="e">La super info</param>
    private void ReceiveData(EventMonitorArgs e)
    {
      switch (this.monitorMode)
      {
        case EMonitorMode.Stopping:
          // en cours d'arrêt
          e.CancelLoop = true;
          this.DisplayPausedDatas();
          this.monitorMode = EMonitorMode.Stop;
          this.ReceiveData(EventMonitorArgs.Trace(Properties.Resources.MonitorConsoleTRACESTOP));
          this.GereBouton();
          break;
        case EMonitorMode.Pause:
          if (this.dataPaused == null)
          {
            this.dataPaused = new List<EventMonitorArgs>();
          }

          this.dataPaused.Add(e);
          break;
        case EMonitorMode.Play:
        case EMonitorMode.Stop:
          this.AddInfo(e);
          break;
      }
    }

    /// <summary>
    /// Ajoute une information dans la liste
    /// </summary>
    /// <param name="e">Event Monitor Args = info à afficher</param>
    private void AddInfo(EventMonitorArgs e)
    {
      string txt = e.Date.ToString(this.dateFormat);
      if (e.Date == DateTime.MinValue || e.Date == DateTime.MaxValue)
      {
        txt = string.Empty;
      }

      this.lstCommands.BeginUpdate();
      ListViewItem itx = new ListViewItem(txt);
      if (e.BaseId >= 0)
      {
        itx.SubItems.Add(e.BaseId.ToString());
      }
      else
      {
        itx.SubItems.Add(string.Empty);
      }

      itx.SubItems.Add(e.IPAdress);
      itx.SubItems.Add(e.Port);
      itx.SubItems.Add(e.Command.Replace("\"", string.Empty));
      itx.Tag = e;
      this.lstCommands.Items.Add(itx);
      if (this.chkScroll.Checked)
      {
        foreach (ListViewItem x in this.lstCommands.SelectedItems)
        {
          x.Selected = false;
        }

        itx.Selected = true;
        itx.EnsureVisible();
      }

      this.lstCommands.EndUpdate();
    }

    /// <summary>
    /// S'assure que la connexion existe avant de lancer une commande !
    /// </summary>
    private void EnsureConnexionExists()
    {
      if (this.ConnectionParam == null)
      {
        throw new Exception(Properties.Resources.ErrorEditorsWithoutConnection);
      }

      if (this.myConnexion == null)
      {
        this.myConnexion = new RedisConnection(this.ConnectionParam);
      }
    }

    /// <summary>
    /// Affiche toutes les informations bufférisées
    /// </summary>
    private void DisplayPausedDatas()
    {
      if (this.dataPaused != null)
      {
        foreach (EventMonitorArgs e in this.dataPaused)
        {
          this.AddInfo(e);
        }

        this.dataPaused.Clear();
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
        IEnumerable<EventMonitorArgs> lst;

        if (allDatas)
        { // on veut tout
          if (this.dataPaused != null && this.dataPaused.Count > 0)
          {
            lst = (from ListViewItem itx in this.lstCommands.Items
                   select (EventMonitorArgs)itx.Tag).Union(this.dataPaused);
          }
          else
          {
            lst = from ListViewItem itx in this.lstCommands.Items
                  select (EventMonitorArgs)itx.Tag;
          }
        }
        else
        {
          lst = from ListViewItem itx in this.lstCommands.SelectedItems
                select (EventMonitorArgs)itx.Tag;
        }
        
        using (StreamWriter tw = new StreamWriter(this.saveFileDialog1.FileName))
        {
          tw.WriteLine(string.Format(Properties.Resources.MonitorConsoleTraceFileEntete, MonitorConsole.FILESEPARATOR));
          foreach (EventMonitorArgs e in lst)
          {
            tw.WriteLine(string.Format(
              Properties.Resources.MonitorConsoleTraceFileRow, 
              MonitorConsole.FILESEPARATOR,
              e.Date != DateTime.MinValue ? e.Date.ToString(this.dateFormat) : string.Empty, 
              e.IPAdress, 
              e.Command));
          }
        }

        System.Diagnostics.Process.Start(this.saveFileDialog1.FileName);
      }
    }

    /// <summary>
    /// Gère l'activation ou pas des boutons de l'interface
    /// </summary>
    private void GereBouton()
    {
      this.btStart.Enabled = this.monitorMode == EMonitorMode.Stop || this.monitorMode == EMonitorMode.Pause;
      this.btPause.Enabled = this.monitorMode == EMonitorMode.Play;
      this.btStop.Enabled = this.monitorMode == EMonitorMode.Play || this.monitorMode == EMonitorMode.Pause;
      this.btClear.Enabled = this.lstCommands.Items.Count > 0;
      this.btSaveSelection.Enabled = this.lstCommands.SelectedItems.Count > 1;
      this.btSave.Enabled = this.lstCommands.Items.Count > 0 || (this.dataPaused != null && this.dataPaused.Count > 0);
      this.toolTip1.SetToolTip(this.chkScroll, this.chkScroll.Checked ? Properties.Resources.MonitorConsoleChkScrollOn : Properties.Resources.MonitorConsoleChkScrollOff);

      int n = this.lstCommands.Items.Count;
      this.lblCount.Text = n == 0 ? string.Empty : (n == 1 ? Properties.Resources.MonitorConsoleCount1 : string.Format(Properties.Resources.MonitorConsoleCountN, n));
    }
  }
}
