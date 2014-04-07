namespace RedisManagementStudio
{
  partial class FRedisUtil
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRedisUtil));
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.tvMenu = new System.Windows.Forms.TreeView();
      this.panel1 = new System.Windows.Forms.Panel();
      this.sentinelServersUI1 = new RedisManagementStudio.BLL.Redis.Sentinel.SentinelServersUI();
      this.keysExplorer1 = new RedisManagementStudio.BLL.Redis.Keys.KeysExplorer();
      this.keyGroup1 = new RedisManagementStudio.BLL.Redis.Keys.KeyGroup();
      this.keySearch1 = new RedisManagementStudio.BLL.Redis.Keys.KeySearch();
      this.redisClientUI1 = new RedisManagementStudio.BLL.Redis.Client.RedisClientUI();
      this.pubSubConsole1 = new RedisManagementStudio.BLL.Redis.Monitor.PubSubConsole();
      this.serverResume1 = new RedisManagementStudio.BLL.Redis.ServerResume();
      this.monitorConsole1 = new RedisManagementStudio.BLL.Redis.Monitor.MonitorConsole();
      this.redisListInfoUI1 = new RedisManagementStudio.BLL.Redis.RedisListInfoUI();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblConnexionName = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblConnexionUrl = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblConnexionPort = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblConnexionBase = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblConnexionDescription = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
      this.lblConnexionVersion = new System.Windows.Forms.ToolStripStatusLabel();
      this.timSave = new System.Windows.Forms.Timer(this.components);
      this.imageLib1 = new RedisManagementStudio.BLL.ImageLib(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.tvMenu);
      this.splitContainer1.Panel1.Controls.Add(this.panel1);
      this.splitContainer1.Panel1MinSize = 150;
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.pubSubConsole1);
      this.splitContainer1.Panel2.Controls.Add(this.sentinelServersUI1);
      this.splitContainer1.Panel2.Controls.Add(this.keysExplorer1);
      this.splitContainer1.Panel2.Controls.Add(this.keyGroup1);
      this.splitContainer1.Panel2.Controls.Add(this.keySearch1);
      this.splitContainer1.Panel2.Controls.Add(this.redisClientUI1);
      this.splitContainer1.Panel2.Controls.Add(this.serverResume1);
      this.splitContainer1.Panel2.Controls.Add(this.monitorConsole1);
      this.splitContainer1.Panel2.Controls.Add(this.redisListInfoUI1);
      this.splitContainer1.Size = new System.Drawing.Size(1141, 532);
      this.splitContainer1.SplitterDistance = 174;
      this.splitContainer1.SplitterWidth = 5;
      this.splitContainer1.TabIndex = 0;
      // 
      // tvMenu
      // 
      this.tvMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tvMenu.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tvMenu.HideSelection = false;
      this.tvMenu.Location = new System.Drawing.Point(0, 40);
      this.tvMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.tvMenu.Name = "tvMenu";
      this.tvMenu.ShowNodeToolTips = true;
      this.tvMenu.Size = new System.Drawing.Size(174, 492);
      this.tvMenu.TabIndex = 0;
      this.tvMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MenuItemSelected);
      // 
      // panel1
      // 
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(174, 40);
      this.panel1.TabIndex = 1;
      // 
      // sentinelServersUI1
      // 
      this.sentinelServersUI1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.sentinelServersUI1.Location = new System.Drawing.Point(69, 319);
      this.sentinelServersUI1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.sentinelServersUI1.Name = "sentinelServersUI1";
      this.sentinelServersUI1.Serveur = null;
      this.sentinelServersUI1.Size = new System.Drawing.Size(297, 209);
      this.sentinelServersUI1.TabIndex = 14;
      this.sentinelServersUI1.OnChange += new System.EventHandler(this.SentinelServersUI1OnChange);
      this.sentinelServersUI1.OnRefresh += new System.EventHandler(this.SentinelServersUI1OnRefresh);
      // 
      // keysExplorer1
      // 
      this.keysExplorer1.Connection = null;
      this.keysExplorer1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.keysExplorer1.KeySearcher = null;
      this.keysExplorer1.Location = new System.Drawing.Point(240, 258);
      this.keysExplorer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.keysExplorer1.Name = "keysExplorer1";
      this.keysExplorer1.Size = new System.Drawing.Size(246, 195);
      this.keysExplorer1.TabIndex = 7;
      // 
      // keyGroup1
      // 
      this.keyGroup1.Connection = null;
      this.keyGroup1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.keyGroup1.ImageList = null;
      this.keyGroup1.KeySearcher = null;
      this.keyGroup1.Location = new System.Drawing.Point(35, 299);
      this.keyGroup1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.keyGroup1.Name = "keyGroup1";
      this.keyGroup1.Selection = null;
      this.keyGroup1.Size = new System.Drawing.Size(199, 196);
      this.keyGroup1.TabIndex = 13;
      this.keyGroup1.OnChange += new System.EventHandler(this.KeyGroup1OnChange);
      // 
      // keySearch1
      // 
      this.keySearch1.Connection = null;
      this.keySearch1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.keySearch1.Location = new System.Drawing.Point(59, 97);
      this.keySearch1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.keySearch1.Name = "keySearch1";
      this.keySearch1.SearchText = "";
      this.keySearch1.Size = new System.Drawing.Size(408, 194);
      this.keySearch1.TabIndex = 12;
      this.keySearch1.OnSearch += new System.EventHandler(this.KeySearch1OnSearch);
      // 
      // redisClientUI1
      // 
      this.redisClientUI1.Client = null;
      this.redisClientUI1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.redisClientUI1.Location = new System.Drawing.Point(473, 97);
      this.redisClientUI1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.redisClientUI1.Name = "redisClientUI1";
      this.redisClientUI1.Size = new System.Drawing.Size(348, 271);
      this.redisClientUI1.TabIndex = 11;
      this.redisClientUI1.OnChange += new System.EventHandler(this.RedisClientUI1OnChange);
      this.redisClientUI1.OnRefresh += new System.EventHandler(this.RedisClientUI1OnRefresh);
      // 
      // pubSubConsole1
      // 
      this.pubSubConsole1.Connection = null;
      this.pubSubConsole1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.pubSubConsole1.Location = new System.Drawing.Point(35, 78);
      this.pubSubConsole1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.pubSubConsole1.Name = "pubSubConsole1";
      this.pubSubConsole1.Size = new System.Drawing.Size(546, 348);
      this.pubSubConsole1.TabIndex = 10;
      this.pubSubConsole1.OnChange += new System.EventHandler(this.PubSubConsole1OnChange);
      // 
      // serverResume1
      // 
      this.serverResume1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.serverResume1.Location = new System.Drawing.Point(101, 143);
      this.serverResume1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.serverResume1.Name = "serverResume1";
      this.serverResume1.Size = new System.Drawing.Size(638, 361);
      this.serverResume1.TabIndex = 9;
      // 
      // monitorConsole1
      // 
      this.monitorConsole1.ConnectionParam = null;
      this.monitorConsole1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.monitorConsole1.Location = new System.Drawing.Point(122, 13);
      this.monitorConsole1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.monitorConsole1.MinimumSize = new System.Drawing.Size(470, 150);
      this.monitorConsole1.Name = "monitorConsole1";
      this.monitorConsole1.Size = new System.Drawing.Size(719, 278);
      this.monitorConsole1.TabIndex = 8;
      // 
      // redisListInfoUI1
      // 
      this.redisListInfoUI1.Connection = null;
      this.redisListInfoUI1.Current = null;
      this.redisListInfoUI1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.redisListInfoUI1.Location = new System.Drawing.Point(287, 185);
      this.redisListInfoUI1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.redisListInfoUI1.Name = "redisListInfoUI1";
      this.redisListInfoUI1.Size = new System.Drawing.Size(566, 282);
      this.redisListInfoUI1.TabIndex = 5;
      this.redisListInfoUI1.OnRefreshList += new System.EventHandler(this.RedisListInfoUI1OnRefreshList);
      // 
      // statusStrip1
      // 
      this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblConnexionName,
            this.toolStripStatusLabel2,
            this.lblConnexionUrl,
            this.toolStripStatusLabel3,
            this.lblConnexionPort,
            this.toolStripStatusLabel4,
            this.lblConnexionBase,
            this.toolStripStatusLabel5,
            this.lblConnexionDescription,
            this.toolStripStatusLabel6,
            this.lblConnexionVersion});
      this.statusStrip1.Location = new System.Drawing.Point(0, 532);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
      this.statusStrip1.Size = new System.Drawing.Size(1141, 22);
      this.statusStrip1.TabIndex = 0;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(70, 17);
      this.toolStripStatusLabel1.Text = "Connexion :";
      // 
      // lblConnexionName
      // 
      this.lblConnexionName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblConnexionName.Name = "lblConnexionName";
      this.lblConnexionName.Size = new System.Drawing.Size(170, 17);
      this.lblConnexionName.Text = "toolStrip hjk hkj StatusLabel1";
      // 
      // toolStripStatusLabel2
      // 
      this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
      this.toolStripStatusLabel2.Size = new System.Drawing.Size(54, 17);
      this.toolStripStatusLabel2.Text = "Adresse :";
      // 
      // lblConnexionUrl
      // 
      this.lblConnexionUrl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblConnexionUrl.Name = "lblConnexionUrl";
      this.lblConnexionUrl.Size = new System.Drawing.Size(127, 17);
      this.lblConnexionUrl.Text = "toolStripStatusLabel3";
      // 
      // toolStripStatusLabel3
      // 
      this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
      this.toolStripStatusLabel3.Size = new System.Drawing.Size(35, 17);
      this.toolStripStatusLabel3.Text = "Port :";
      // 
      // lblConnexionPort
      // 
      this.lblConnexionPort.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblConnexionPort.Name = "lblConnexionPort";
      this.lblConnexionPort.Size = new System.Drawing.Size(127, 17);
      this.lblConnexionPort.Text = "toolStripStatusLabel4";
      // 
      // toolStripStatusLabel4
      // 
      this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
      this.toolStripStatusLabel4.Size = new System.Drawing.Size(37, 17);
      this.toolStripStatusLabel4.Text = "Base :";
      // 
      // lblConnexionBase
      // 
      this.lblConnexionBase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblConnexionBase.Name = "lblConnexionBase";
      this.lblConnexionBase.Size = new System.Drawing.Size(127, 17);
      this.lblConnexionBase.Text = "toolStripStatusLabel5";
      // 
      // toolStripStatusLabel5
      // 
      this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
      this.toolStripStatusLabel5.Size = new System.Drawing.Size(73, 17);
      this.toolStripStatusLabel5.Text = "Description :";
      // 
      // lblConnexionDescription
      // 
      this.lblConnexionDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblConnexionDescription.Name = "lblConnexionDescription";
      this.lblConnexionDescription.Size = new System.Drawing.Size(127, 17);
      this.lblConnexionDescription.Text = "toolStripStatusLabel6";
      // 
      // toolStripStatusLabel6
      // 
      this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
      this.toolStripStatusLabel6.Size = new System.Drawing.Size(52, 17);
      this.toolStripStatusLabel6.Text = "Version :";
      // 
      // lblConnexionVersion
      // 
      this.lblConnexionVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblConnexionVersion.Name = "lblConnexionVersion";
      this.lblConnexionVersion.Size = new System.Drawing.Size(120, 17);
      this.lblConnexionVersion.Text = "lblConnexionVersion";
      // 
      // timSave
      // 
      this.timSave.Interval = 3000;
      // 
      // FRedisUtil
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1141, 554);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.statusStrip1);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "FRedisUtil";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Connexion";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRedisUtil_FormClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FRedisUtil_FormClosed);
      this.Load += new System.EventHandler(this.FRedisUtil_Load);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.TreeView tvMenu;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.Timer timSave;
    private BLL.ImageLib imageLib1;
    private BLL.Redis.RedisListInfoUI redisListInfoUI1;
    private BLL.Redis.Keys.KeysExplorer keysExplorer1;
    private System.Windows.Forms.ToolStripStatusLabel lblConnexionName;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    private System.Windows.Forms.ToolStripStatusLabel lblConnexionUrl;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
    private System.Windows.Forms.ToolStripStatusLabel lblConnexionPort;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
    private System.Windows.Forms.ToolStripStatusLabel lblConnexionBase;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
    private System.Windows.Forms.ToolStripStatusLabel lblConnexionDescription;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
    private System.Windows.Forms.ToolStripStatusLabel lblConnexionVersion;
    private BLL.Redis.Monitor.MonitorConsole monitorConsole1;
    private BLL.Redis.ServerResume serverResume1;
    private BLL.Redis.Monitor.PubSubConsole pubSubConsole1;
		private BLL.Redis.Client.RedisClientUI redisClientUI1;
    private BLL.Redis.Keys.KeySearch keySearch1;
    private BLL.Redis.Keys.KeyGroup keyGroup1;
    private BLL.Redis.Sentinel.SentinelServersUI sentinelServersUI1;
  }
}