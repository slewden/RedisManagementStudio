namespace RedisManagementStudio.BLL.Redis.Sentinel
{
  partial class SentinelServersUI
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
      this.lvProperties = new System.Windows.Forms.ListView();
      this.colPropertie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.panel2 = new System.Windows.Forms.Panel();
      this.lblInfoBrute = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.lblInfoDescriptionCaption = new System.Windows.Forms.Label();
      this.lblInfoDescription = new System.Windows.Forms.Label();
      this.lblTitre = new System.Windows.Forms.Label();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.lstSlaves = new System.Windows.Forms.ListBox();
      this.btRefresh = new System.Windows.Forms.Button();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.SuspendLayout();
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
      this.lvProperties.Location = new System.Drawing.Point(0, 0);
      this.lvProperties.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.lvProperties.MultiSelect = false;
      this.lvProperties.Name = "lvProperties";
      this.lvProperties.Size = new System.Drawing.Size(625, 299);
      this.lvProperties.TabIndex = 30;
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
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.SystemColors.Control;
      this.panel2.Controls.Add(this.lblInfoBrute);
      this.panel2.Controls.Add(this.label1);
      this.panel2.Controls.Add(this.lblInfoDescriptionCaption);
      this.panel2.Controls.Add(this.lblInfoDescription);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 299);
      this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(625, 111);
      this.panel2.TabIndex = 32;
      // 
      // lblInfoBrute
      // 
      this.lblInfoBrute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblInfoBrute.Location = new System.Drawing.Point(110, 81);
      this.lblInfoBrute.Name = "lblInfoBrute";
      this.lblInfoBrute.Size = new System.Drawing.Size(511, 24);
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
      this.lblInfoDescription.Size = new System.Drawing.Size(514, 34);
      this.lblInfoDescription.TabIndex = 24;
      this.lblInfoDescription.Text = "xxx";
      // 
      // lblTitre
      // 
      this.lblTitre.BackColor = System.Drawing.SystemColors.Control;
      this.lblTitre.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblTitre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.lblTitre.Location = new System.Drawing.Point(0, 0);
      this.lblTitre.Name = "lblTitre";
      this.lblTitre.Size = new System.Drawing.Size(625, 40);
      this.lblTitre.TabIndex = 31;
      this.lblTitre.Text = "Détail du serveur sélectionné";
      this.lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.splitContainer1.Location = new System.Drawing.Point(0, 40);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.lvProperties);
      this.splitContainer1.Panel1.Controls.Add(this.panel2);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.lstSlaves);
      this.splitContainer1.Size = new System.Drawing.Size(625, 520);
      this.splitContainer1.SplitterDistance = 410;
      this.splitContainer1.TabIndex = 33;
      // 
      // lstSlaves
      // 
      this.lstSlaves.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lstSlaves.FormattingEnabled = true;
      this.lstSlaves.IntegralHeight = false;
      this.lstSlaves.ItemHeight = 17;
      this.lstSlaves.Location = new System.Drawing.Point(0, 0);
      this.lstSlaves.Name = "lstSlaves";
      this.lstSlaves.Size = new System.Drawing.Size(625, 106);
      this.lstSlaves.TabIndex = 0;
      this.lstSlaves.DoubleClick += new System.EventHandler(this.LstSlavesDoubleClick);
      // 
      // btRefresh
      // 
      this.btRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btRefresh.Image = global::RedisManagementStudio.Properties.Resources.Refresh;
      this.btRefresh.Location = new System.Drawing.Point(600, 10);
      this.btRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btRefresh.Name = "btRefresh";
      this.btRefresh.Size = new System.Drawing.Size(25, 25);
      this.btRefresh.TabIndex = 34;
      this.btRefresh.UseVisualStyleBackColor = true;
      this.btRefresh.Click += new System.EventHandler(this.BtRefreshClick);
      // 
      // SentinelServersUI
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.btRefresh);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.lblTitre);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "SentinelServersUI";
      this.Size = new System.Drawing.Size(625, 560);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListView lvProperties;
    private System.Windows.Forms.ColumnHeader colPropertie;
    private System.Windows.Forms.ColumnHeader colValue;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label lblInfoBrute;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lblInfoDescriptionCaption;
    private System.Windows.Forms.Label lblInfoDescription;
    private System.Windows.Forms.Label lblTitre;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.ListBox lstSlaves;
    private System.Windows.Forms.Button btRefresh;
  }
}
