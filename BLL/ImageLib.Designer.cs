namespace RedisManagementStudio.BLL
{
  partial class ImageLib
  {
    /// <summary>
    /// Variable nécessaire au concepteur.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Nettoyage des ressources utilisées.
    /// </summary>
    /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Code généré par le Concepteur de composants

    /// <summary>
    /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
    /// le contenu de cette méthode avec l'éditeur de code.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageLib));
      this.Actions = new System.Windows.Forms.ImageList(this.components);
      this.Alarms = new System.Windows.Forms.ImageList(this.components);
      // 
      // Actions
      // 
      this.Actions.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Actions.ImageStream")));
      this.Actions.TransparentColor = System.Drawing.Color.Transparent;
      this.Actions.Images.SetKeyName(0, "ConfigurationRubrique");
      this.Actions.Images.SetKeyName(1, "Server");
      this.Actions.Images.SetKeyName(2, "Client");
      this.Actions.Images.SetKeyName(3, "Command");
      this.Actions.Images.SetKeyName(4, "Configuration");
      this.Actions.Images.SetKeyName(5, "Persistance");
      this.Actions.Images.SetKeyName(6, "Statistics");
      this.Actions.Images.SetKeyName(7, "MemoryCPU");
      this.Actions.Images.SetKeyName(8, "Replication");
      this.Actions.Images.SetKeyName(9, "Tools");
      this.Actions.Images.SetKeyName(10, "Clients");
      this.Actions.Images.SetKeyName(11, "Keys");
      this.Actions.Images.SetKeyName(12, "Monitor");
      this.Actions.Images.SetKeyName(13, "PubSub");
      this.Actions.Images.SetKeyName(14, "Tnone");
      this.Actions.Images.SetKeyName(15, "UnKnow");
      this.Actions.Images.SetKeyName(16, "warning");
      this.Actions.Images.SetKeyName(17, "GTnone");
      this.Actions.Images.SetKeyName(18, "GUnKnow");
      this.Actions.Images.SetKeyName(19, "Groupe");
      this.Actions.Images.SetKeyName(20, "GThash");
      this.Actions.Images.SetKeyName(21, "GTstring");
      this.Actions.Images.SetKeyName(22, "GTlist");
      this.Actions.Images.SetKeyName(23, "GTzset");
      this.Actions.Images.SetKeyName(24, "GTset");
      this.Actions.Images.SetKeyName(25, "Thash");
      this.Actions.Images.SetKeyName(26, "Tstring");
      this.Actions.Images.SetKeyName(27, "Tlist");
      this.Actions.Images.SetKeyName(28, "Tzset");
      this.Actions.Images.SetKeyName(29, "Tset");
      this.Actions.Images.SetKeyName(30, "PubSubPublication");
      this.Actions.Images.SetKeyName(31, "PubSubAbonnement");
      this.Actions.Images.SetKeyName(32, "None");
      this.Actions.Images.SetKeyName(33, "Sentinel");
      this.Actions.Images.SetKeyName(34, "SentinelServers");
      this.Actions.Images.SetKeyName(35, "ServeurSuiviMaster");
      this.Actions.Images.SetKeyName(36, "ServeurSuiviSlave");
      // 
      // Alarms
      // 
      this.Alarms.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Alarms.ImageStream")));
      this.Alarms.TransparentColor = System.Drawing.Color.Transparent;
      this.Alarms.Images.SetKeyName(0, "AlarmRed");
      this.Alarms.Images.SetKeyName(1, "AlarmOrange");
      this.Alarms.Images.SetKeyName(2, "AlarmGreen");
      this.Alarms.Images.SetKeyName(3, "AlarmNone");

    }

    #endregion

    public System.Windows.Forms.ImageList Actions;
    public System.Windows.Forms.ImageList Alarms;
  }
}
