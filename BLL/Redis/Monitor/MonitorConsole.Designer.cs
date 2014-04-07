namespace RedisManagementStudio.BLL.Redis.Monitor
{
  partial class MonitorConsole
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorConsole));
      this.label1 = new System.Windows.Forms.Label();
      this.lstCommands = new System.Windows.Forms.ListView();
      this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colBaseId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colIp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colPort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colCommand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.panel1 = new System.Windows.Forms.Panel();
      this.btSave = new System.Windows.Forms.Button();
      this.btSaveSelection = new System.Windows.Forms.Button();
      this.chkScroll = new System.Windows.Forms.CheckBox();
      this.btClear = new System.Windows.Forms.Button();
      this.btStop = new System.Windows.Forms.Button();
      this.btPause = new System.Windows.Forms.Button();
      this.btStart = new System.Windows.Forms.Button();
      this.lblCount = new System.Windows.Forms.Label();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F);
      this.label1.Location = new System.Drawing.Point(0, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(317, 40);
      this.label1.TabIndex = 0;
      this.label1.Text = "Trace des commandes sur le serveur";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lstCommands
      // 
      this.lstCommands.Activation = System.Windows.Forms.ItemActivation.OneClick;
      this.lstCommands.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lstCommands.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colBaseId,
            this.colIp,
            this.colPort,
            this.colCommand});
      this.lstCommands.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lstCommands.FullRowSelect = true;
      this.lstCommands.GridLines = true;
      this.lstCommands.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.lstCommands.HideSelection = false;
      this.lstCommands.LabelWrap = false;
      this.lstCommands.Location = new System.Drawing.Point(0, 40);
      this.lstCommands.Name = "lstCommands";
      this.lstCommands.Size = new System.Drawing.Size(580, 267);
      this.lstCommands.TabIndex = 1;
      this.lstCommands.UseCompatibleStateImageBehavior = false;
      this.lstCommands.View = System.Windows.Forms.View.Details;
      this.lstCommands.SelectedIndexChanged += new System.EventHandler(this.LstCommandsSelectedIndexChanged);
      // 
      // colDate
      // 
      this.colDate.Text = "Date";
      this.colDate.Width = 180;
      // 
      // colBaseId
      // 
      this.colBaseId.Text = "Base";
      this.colBaseId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.colBaseId.Width = 123;
      // 
      // colIp
      // 
      this.colIp.Text = "Adresse";
      this.colIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.colIp.Width = 100;
      // 
      // colPort
      // 
      this.colPort.Text = "Port";
      this.colPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // colCommand
      // 
      this.colCommand.Text = "Commande";
      this.colCommand.Width = 269;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btSave);
      this.panel1.Controls.Add(this.btSaveSelection);
      this.panel1.Controls.Add(this.chkScroll);
      this.panel1.Controls.Add(this.btClear);
      this.panel1.Controls.Add(this.btStop);
      this.panel1.Controls.Add(this.btPause);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Controls.Add(this.btStart);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(580, 40);
      this.panel1.TabIndex = 4;
      // 
      // btSave
      // 
      this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btSave.Image = global::RedisManagementStudio.Properties.Resources.Save;
      this.btSave.Location = new System.Drawing.Point(348, 3);
      this.btSave.Name = "btSave";
      this.btSave.Size = new System.Drawing.Size(25, 25);
      this.btSave.TabIndex = 8;
      this.btSave.UseVisualStyleBackColor = true;
      this.btSave.Click += new System.EventHandler(this.BtSaveClick);
      // 
      // btSaveSelection
      // 
      this.btSaveSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btSaveSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btSaveSelection.Image = global::RedisManagementStudio.Properties.Resources.saveSelection;
      this.btSaveSelection.Location = new System.Drawing.Point(379, 3);
      this.btSaveSelection.Name = "btSaveSelection";
      this.btSaveSelection.Size = new System.Drawing.Size(25, 25);
      this.btSaveSelection.TabIndex = 7;
      this.btSaveSelection.UseVisualStyleBackColor = true;
      this.btSaveSelection.Click += new System.EventHandler(this.BtSaveSelectionClick);
      // 
      // chkScroll
      // 
      this.chkScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.chkScroll.Appearance = System.Windows.Forms.Appearance.Button;
      this.chkScroll.Checked = true;
      this.chkScroll.CheckState = System.Windows.Forms.CheckState.Checked;
      this.chkScroll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.chkScroll.Image = global::RedisManagementStudio.Properties.Resources.Defillement;
      this.chkScroll.Location = new System.Drawing.Point(410, 3);
      this.chkScroll.Name = "chkScroll";
      this.chkScroll.Size = new System.Drawing.Size(25, 25);
      this.chkScroll.TabIndex = 6;
      this.chkScroll.UseVisualStyleBackColor = true;
      this.chkScroll.CheckedChanged += new System.EventHandler(this.ChkScrollCheckedChanged);
      // 
      // btClear
      // 
      this.btClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btClear.Image = ((System.Drawing.Image)(resources.GetObject("btClear.Image")));
      this.btClear.Location = new System.Drawing.Point(441, 3);
      this.btClear.Name = "btClear";
      this.btClear.Size = new System.Drawing.Size(25, 25);
      this.btClear.TabIndex = 5;
      this.btClear.UseVisualStyleBackColor = true;
      this.btClear.Click += new System.EventHandler(this.BtClearClick);
      // 
      // btStop
      // 
      this.btStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btStop.Image = ((System.Drawing.Image)(resources.GetObject("btStop.Image")));
      this.btStop.Location = new System.Drawing.Point(551, 3);
      this.btStop.Name = "btStop";
      this.btStop.Size = new System.Drawing.Size(25, 25);
      this.btStop.TabIndex = 4;
      this.btStop.UseVisualStyleBackColor = true;
      this.btStop.Click += new System.EventHandler(this.BtStopClick);
      // 
      // btPause
      // 
      this.btPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btPause.Image = global::RedisManagementStudio.Properties.Resources.Pause;
      this.btPause.Location = new System.Drawing.Point(520, 3);
      this.btPause.Name = "btPause";
      this.btPause.Size = new System.Drawing.Size(25, 25);
      this.btPause.TabIndex = 3;
      this.btPause.UseVisualStyleBackColor = true;
      this.btPause.Click += new System.EventHandler(this.BtPauseClick);
      // 
      // btStart
      // 
      this.btStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btStart.Image = ((System.Drawing.Image)(resources.GetObject("btStart.Image")));
      this.btStart.Location = new System.Drawing.Point(489, 3);
      this.btStart.Name = "btStart";
      this.btStart.Size = new System.Drawing.Size(25, 25);
      this.btStart.TabIndex = 2;
      this.btStart.UseVisualStyleBackColor = true;
      this.btStart.Click += new System.EventHandler(this.BtStartClick);
      // 
      // lblCount
      // 
      this.lblCount.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.lblCount.Location = new System.Drawing.Point(0, 307);
      this.lblCount.Name = "lblCount";
      this.lblCount.Size = new System.Drawing.Size(580, 30);
      this.lblCount.TabIndex = 5;
      this.lblCount.Text = "xxx";
      this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // saveFileDialog1
      // 
      this.saveFileDialog1.DefaultExt = "csv";
      this.saveFileDialog1.Filter = "Fichier Trace (*.csv)|*.csv|Tous fichiers|*.*";
      this.saveFileDialog1.Title = "Enregistrer la trace";
      // 
      // MonitorConsole
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lstCommands);
      this.Controls.Add(this.lblCount);
      this.Controls.Add(this.panel1);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.MinimumSize = new System.Drawing.Size(470, 150);
      this.Name = "MonitorConsole";
      this.Size = new System.Drawing.Size(580, 337);
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ListView lstCommands;
    private System.Windows.Forms.Button btStart;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.ColumnHeader colDate;
    private System.Windows.Forms.ColumnHeader colIp;
    private System.Windows.Forms.ColumnHeader colCommand;
    private System.Windows.Forms.Button btStop;
    private System.Windows.Forms.Button btPause;
    private System.Windows.Forms.Button btClear;
    private System.Windows.Forms.Button btSaveSelection;
    private System.Windows.Forms.CheckBox chkScroll;
    private System.Windows.Forms.Button btSave;
    private System.Windows.Forms.Label lblCount;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    private System.Windows.Forms.ColumnHeader colBaseId;
    private System.Windows.Forms.ColumnHeader colPort;
  }
}
