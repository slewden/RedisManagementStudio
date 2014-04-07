namespace RedisManagementStudio.BLL.Redis.Client
{
  partial class RedisClientUI
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
      this.lblDetail = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btKillConnection = new System.Windows.Forms.Button();
      this.lblInfoBrute = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.lblInfoDescriptionCaption = new System.Windows.Forms.Label();
      this.lblInfoDescription = new System.Windows.Forms.Label();
      this.lvProperties = new System.Windows.Forms.ListView();
      this.colPropertie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.btRefresh = new System.Windows.Forms.Button();
      this.lstClients = new System.Windows.Forms.ListBox();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblDetail
      // 
      this.lblDetail.BackColor = System.Drawing.SystemColors.Control;
      this.lblDetail.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblDetail.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblDetail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.lblDetail.Location = new System.Drawing.Point(0, 0);
      this.lblDetail.Name = "lblDetail";
      this.lblDetail.Size = new System.Drawing.Size(477, 40);
      this.lblDetail.TabIndex = 28;
      this.lblDetail.Text = "Détail du client sélectionné";
      this.lblDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.SystemColors.Control;
      this.panel2.Controls.Add(this.btKillConnection);
      this.panel2.Controls.Add(this.lblInfoBrute);
      this.panel2.Controls.Add(this.label1);
      this.panel2.Controls.Add(this.lblInfoDescriptionCaption);
      this.panel2.Controls.Add(this.lblInfoDescription);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 428);
      this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(477, 111);
      this.panel2.TabIndex = 29;
      // 
      // btKillConnection
      // 
      this.btKillConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btKillConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btKillConnection.Image = global::RedisManagementStudio.Properties.Resources.ClientKill;
      this.btKillConnection.Location = new System.Drawing.Point(445, 81);
      this.btKillConnection.Name = "btKillConnection";
      this.btKillConnection.Size = new System.Drawing.Size(32, 23);
      this.btKillConnection.TabIndex = 27;
      this.btKillConnection.UseVisualStyleBackColor = true;
      this.btKillConnection.Click += new System.EventHandler(this.BtKillConnectionClick);
      // 
      // lblInfoBrute
      // 
      this.lblInfoBrute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblInfoBrute.Location = new System.Drawing.Point(110, 81);
      this.lblInfoBrute.Name = "lblInfoBrute";
      this.lblInfoBrute.Size = new System.Drawing.Size(329, 24);
      this.lblInfoBrute.TabIndex = 26;
      this.lblInfoBrute.Text = "xxx";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 81);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(87, 17);
      this.label1.TabIndex = 25;
      this.label1.Text = "Valeur brute :";
      // 
      // lblInfoDescriptionCaption
      // 
      this.lblInfoDescriptionCaption.AutoSize = true;
      this.lblInfoDescriptionCaption.Location = new System.Drawing.Point(3, 17);
      this.lblInfoDescriptionCaption.Name = "lblInfoDescriptionCaption";
      this.lblInfoDescriptionCaption.Size = new System.Drawing.Size(81, 17);
      this.lblInfoDescriptionCaption.TabIndex = 23;
      this.lblInfoDescriptionCaption.Text = "Description :";
      // 
      // lblInfoDescription
      // 
      this.lblInfoDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblInfoDescription.Location = new System.Drawing.Point(107, 17);
      this.lblInfoDescription.Name = "lblInfoDescription";
      this.lblInfoDescription.Size = new System.Drawing.Size(366, 34);
      this.lblInfoDescription.TabIndex = 24;
      this.lblInfoDescription.Text = "xxx";
      // 
      // lvProperties
      // 
      this.lvProperties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lvProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPropertie,
            this.colValue});
      this.lvProperties.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lvProperties.FullRowSelect = true;
      this.lvProperties.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.lvProperties.HideSelection = false;
      this.lvProperties.Location = new System.Drawing.Point(0, 40);
      this.lvProperties.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.lvProperties.MultiSelect = false;
      this.lvProperties.Name = "lvProperties";
      this.lvProperties.Size = new System.Drawing.Size(477, 388);
      this.lvProperties.TabIndex = 27;
      this.lvProperties.UseCompatibleStateImageBehavior = false;
      this.lvProperties.View = System.Windows.Forms.View.Details;
      this.lvProperties.SelectedIndexChanged += new System.EventHandler(this.LvPropertiesSelectedIndexChanged);
      // 
      // colPropertie
      // 
      this.colPropertie.Text = "Propriété";
      this.colPropertie.Width = 200;
      // 
      // colValue
      // 
      this.colValue.Text = "Valeur";
      this.colValue.Width = 200;
      // 
      // btRefresh
      // 
      this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btRefresh.Image = global::RedisManagementStudio.Properties.Resources.Refresh;
      this.btRefresh.Location = new System.Drawing.Point(452, 10);
      this.btRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btRefresh.Name = "btRefresh";
      this.btRefresh.Size = new System.Drawing.Size(25, 25);
      this.btRefresh.TabIndex = 35;
      this.btRefresh.UseVisualStyleBackColor = true;
      this.btRefresh.Click += new System.EventHandler(this.BtRefreshClick);
      // 
      // lstClients
      // 
      this.lstClients.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lstClients.FormattingEnabled = true;
      this.lstClients.IntegralHeight = false;
      this.lstClients.ItemHeight = 17;
      this.lstClients.Location = new System.Drawing.Point(0, 40);
      this.lstClients.Name = "lstClients";
      this.lstClients.Size = new System.Drawing.Size(477, 388);
      this.lstClients.TabIndex = 28;
      this.lstClients.DoubleClick += new System.EventHandler(this.LstClientsDoubleClick);
      // 
      // RedisClientUI
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lstClients);
      this.Controls.Add(this.btRefresh);
      this.Controls.Add(this.lvProperties);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.lblDetail);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "RedisClientUI";
      this.Size = new System.Drawing.Size(477, 539);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblDetail;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.ListView lvProperties;
    private System.Windows.Forms.ColumnHeader colPropertie;
    private System.Windows.Forms.ColumnHeader colValue;
    private System.Windows.Forms.Label lblInfoDescriptionCaption;
    private System.Windows.Forms.Label lblInfoDescription;
    private System.Windows.Forms.Label lblInfoBrute;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btKillConnection;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Button btRefresh;
    private System.Windows.Forms.ListBox lstClients;
  }
}
