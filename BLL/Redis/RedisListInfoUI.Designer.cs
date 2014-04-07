namespace RedisManagementStudio.BLL.Redis
{
  partial class RedisListInfoUI
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
      this.listView1 = new System.Windows.Forms.ListView();
      this.colServerProperty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colServerValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.panel2 = new System.Windows.Forms.Panel();
      this.btRefresh = new System.Windows.Forms.Button();
      this.btConfigure = new System.Windows.Forms.Button();
      this.lblDetail = new System.Windows.Forms.Label();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.redisInfoUI1 = new RedisManagementStudio.BLL.Redis.RedisInfoUI();
      this.actionsReplication1 = new RedisManagementStudio.BLL.Redis.Command.ActionsReplication();
      this.actionsCommand1 = new RedisManagementStudio.BLL.Redis.Command.ActionsCommand();
      this.actionsPersistance1 = new RedisManagementStudio.BLL.Redis.Command.ActionsPersistance();
      this.actionsStatistiques1 = new RedisManagementStudio.BLL.Redis.Command.ActionsStatistiques();
      this.imageLib1 = new RedisManagementStudio.BLL.ImageLib(this.components);
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // listView1
      // 
      this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colServerProperty,
            this.colServerValue});
      this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.listView1.FullRowSelect = true;
      this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.listView1.HideSelection = false;
      this.listView1.Location = new System.Drawing.Point(0, 40);
      this.listView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.listView1.MultiSelect = false;
      this.listView1.Name = "listView1";
      this.listView1.Size = new System.Drawing.Size(906, 98);
      this.listView1.TabIndex = 2;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = System.Windows.Forms.View.Details;
      this.listView1.SelectedIndexChanged += new System.EventHandler(this.LvPropertiesSelectedIndexChanged);
      // 
      // colServerProperty
      // 
      this.colServerProperty.Text = "Propriété";
      this.colServerProperty.Width = 200;
      // 
      // colServerValue
      // 
      this.colServerValue.Text = "Valeur";
      this.colServerValue.Width = 303;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btRefresh);
      this.panel2.Controls.Add(this.btConfigure);
      this.panel2.Controls.Add(this.lblDetail);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(906, 40);
      this.panel2.TabIndex = 30;
      // 
      // btRefresh
      // 
      this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btRefresh.Image = global::RedisManagementStudio.Properties.Resources.Refresh;
      this.btRefresh.Location = new System.Drawing.Point(881, 10);
      this.btRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btRefresh.Name = "btRefresh";
      this.btRefresh.Size = new System.Drawing.Size(25, 25);
      this.btRefresh.TabIndex = 1;
      this.btRefresh.UseVisualStyleBackColor = true;
      this.btRefresh.Click += new System.EventHandler(this.BtRefreshClick);
      // 
      // btConfigure
      // 
      this.btConfigure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btConfigure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btConfigure.Image = global::RedisManagementStudio.Properties.Resources.Edit;
      this.btConfigure.Location = new System.Drawing.Point(850, 10);
      this.btConfigure.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btConfigure.Name = "btConfigure";
      this.btConfigure.Size = new System.Drawing.Size(25, 25);
      this.btConfigure.TabIndex = 29;
      this.btConfigure.UseVisualStyleBackColor = true;
      this.btConfigure.Click += new System.EventHandler(this.BtConfigureClick);
      // 
      // lblDetail
      // 
      this.lblDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblDetail.BackColor = System.Drawing.SystemColors.Control;
      this.lblDetail.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblDetail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.lblDetail.Location = new System.Drawing.Point(0, 0);
      this.lblDetail.Name = "lblDetail";
      this.lblDetail.Size = new System.Drawing.Size(861, 40);
      this.lblDetail.TabIndex = 28;
      this.lblDetail.Text = "Informations serveur";
      this.lblDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // redisInfoUI1
      // 
      this.redisInfoUI1.BackColor = System.Drawing.SystemColors.Control;
      this.redisInfoUI1.Connexion = null;
      this.redisInfoUI1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.redisInfoUI1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.redisInfoUI1.Location = new System.Drawing.Point(0, 138);
      this.redisInfoUI1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.redisInfoUI1.Name = "redisInfoUI1";
      this.redisInfoUI1.Size = new System.Drawing.Size(906, 290);
      this.redisInfoUI1.TabIndex = 0;
      this.redisInfoUI1.OnSaved += new System.EventHandler(this.RedisInfoUI1OnSaved);
      // 
      // actionsReplication1
      // 
      this.actionsReplication1.Connection = null;
      this.actionsReplication1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.actionsReplication1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.actionsReplication1.Location = new System.Drawing.Point(0, 428);
      this.actionsReplication1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.actionsReplication1.Name = "actionsReplication1";
      this.actionsReplication1.Size = new System.Drawing.Size(906, 40);
      this.actionsReplication1.TabIndex = 5;
      this.actionsReplication1.OnNotifyRefreshNeed += new System.EventHandler(this.PanelsActionOnNotifyRefreshNeed);
      // 
      // actionsCommand1
      // 
      this.actionsCommand1.Connection = null;
      this.actionsCommand1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.actionsCommand1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.actionsCommand1.Location = new System.Drawing.Point(0, 468);
      this.actionsCommand1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.actionsCommand1.Name = "actionsCommand1";
      this.actionsCommand1.Size = new System.Drawing.Size(906, 40);
      this.actionsCommand1.TabIndex = 3;
      this.actionsCommand1.OnNotifyRefreshNeed += new System.EventHandler(this.PanelsActionOnNotifyRefreshNeed);
      // 
      // actionsPersistance1
      // 
      this.actionsPersistance1.Connection = null;
      this.actionsPersistance1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.actionsPersistance1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.actionsPersistance1.Location = new System.Drawing.Point(0, 508);
      this.actionsPersistance1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.actionsPersistance1.Name = "actionsPersistance1";
      this.actionsPersistance1.Size = new System.Drawing.Size(906, 40);
      this.actionsPersistance1.TabIndex = 2;
      this.actionsPersistance1.OnNotifyRefreshNeed += new System.EventHandler(this.PanelsActionOnNotifyRefreshNeed);
      // 
      // actionsStatistiques1
      // 
      this.actionsStatistiques1.Connection = null;
      this.actionsStatistiques1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.actionsStatistiques1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.actionsStatistiques1.Location = new System.Drawing.Point(0, 548);
      this.actionsStatistiques1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.actionsStatistiques1.Name = "actionsStatistiques1";
      this.actionsStatistiques1.Size = new System.Drawing.Size(906, 40);
      this.actionsStatistiques1.TabIndex = 1;
      this.actionsStatistiques1.OnNotifyRefreshNeed += new System.EventHandler(this.PanelsActionOnNotifyRefreshNeed);
      // 
      // RedisListInfoUI
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.listView1);
      this.Controls.Add(this.redisInfoUI1);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.actionsReplication1);
      this.Controls.Add(this.actionsCommand1);
      this.Controls.Add(this.actionsPersistance1);
      this.Controls.Add(this.actionsStatistiques1);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "RedisListInfoUI";
      this.Size = new System.Drawing.Size(906, 588);
      this.Load += new System.EventHandler(this.RedisConfigUILoad);
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListView listView1;
    private System.Windows.Forms.ColumnHeader colServerProperty;
    private System.Windows.Forms.ColumnHeader colServerValue;
    private System.Windows.Forms.Button btRefresh;
    private RedisInfoUI redisInfoUI1;
    private System.Windows.Forms.Label lblDetail;
    private ImageLib imageLib1;
    private Command.ActionsStatistiques actionsStatistiques1;
    private Command.ActionsPersistance actionsPersistance1;
    private Command.ActionsCommand actionsCommand1;
    private System.Windows.Forms.Button btConfigure;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Panel panel2;
    private Command.ActionsReplication actionsReplication1;

  }
}
