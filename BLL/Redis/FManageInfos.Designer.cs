namespace RedisManagementStudio.BLL.Redis
{
  partial class FManageInfos
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
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.lstRubLeft = new System.Windows.Forms.ListView();
      this.colCommand = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colTypeAlarm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colTitre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.lblCountLeft = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.btClasse = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.btNoClasse = new System.Windows.Forms.Button();
      this.cbRubrique = new System.Windows.Forms.ComboBox();
      this.cbAlarme = new System.Windows.Forms.ComboBox();
      this.btTop = new System.Windows.Forms.Button();
      this.btUp = new System.Windows.Forms.Button();
      this.btBottom = new System.Windows.Forms.Button();
      this.btDown = new System.Windows.Forms.Button();
      this.lstRubRight = new System.Windows.Forms.ListView();
      this.colCommand2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colCode2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colTypeAlarm2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colTitre2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.lblCountRight = new System.Windows.Forms.Label();
      this.lblTitreLeft = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.splitContainer1.MinimumSize = new System.Drawing.Size(550, 394);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
      this.splitContainer1.Panel1.Controls.Add(this.lstRubLeft);
      this.splitContainer1.Panel1.Controls.Add(this.lblCountLeft);
      this.splitContainer1.Panel1.Controls.Add(this.label2);
      this.splitContainer1.Panel1.Controls.Add(this.btClasse);
      this.splitContainer1.Panel1.Controls.Add(this.label1);
      this.splitContainer1.Panel1.Controls.Add(this.btNoClasse);
      this.splitContainer1.Panel1.Controls.Add(this.cbRubrique);
      this.splitContainer1.Panel1.Controls.Add(this.cbAlarme);
      this.splitContainer1.Panel1.Controls.Add(this.btTop);
      this.splitContainer1.Panel1.Controls.Add(this.btUp);
      this.splitContainer1.Panel1.Controls.Add(this.btBottom);
      this.splitContainer1.Panel1.Controls.Add(this.btDown);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
      this.splitContainer1.Panel2.Controls.Add(this.lstRubRight);
      this.splitContainer1.Panel2.Controls.Add(this.lblCountRight);
      this.splitContainer1.Panel2.Controls.Add(this.lblTitreLeft);
      this.splitContainer1.Size = new System.Drawing.Size(783, 501);
      this.splitContainer1.SplitterDistance = 592;
      this.splitContainer1.SplitterWidth = 5;
      this.splitContainer1.TabIndex = 0;
      // 
      // lstRubLeft
      // 
      this.lstRubLeft.Activation = System.Windows.Forms.ItemActivation.OneClick;
      this.lstRubLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lstRubLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lstRubLeft.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCommand,
            this.colCode,
            this.colTypeAlarm,
            this.colTitre});
      this.lstRubLeft.FullRowSelect = true;
      this.lstRubLeft.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.lstRubLeft.HideSelection = false;
      this.lstRubLeft.LabelWrap = false;
      this.lstRubLeft.Location = new System.Drawing.Point(12, 38);
      this.lstRubLeft.MultiSelect = false;
      this.lstRubLeft.Name = "lstRubLeft";
      this.lstRubLeft.ShowGroups = false;
      this.lstRubLeft.ShowItemToolTips = true;
      this.lstRubLeft.Size = new System.Drawing.Size(459, 433);
      this.lstRubLeft.TabIndex = 16;
      this.lstRubLeft.UseCompatibleStateImageBehavior = false;
      this.lstRubLeft.View = System.Windows.Forms.View.Details;
      this.lstRubLeft.SelectedIndexChanged += new System.EventHandler(this.LstRubLeftSelectedIndexChanged);
      // 
      // colCommand
      // 
      this.colCommand.Text = "Commande";
      // 
      // colCode
      // 
      this.colCode.Text = "Information";
      // 
      // colTypeAlarm
      // 
      this.colTypeAlarm.Text = "Type";
      // 
      // colTitre
      // 
      this.colTitre.Text = "Titre";
      // 
      // lblCountLeft
      // 
      this.lblCountLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblCountLeft.Location = new System.Drawing.Point(9, 475);
      this.lblCountLeft.Name = "lblCountLeft";
      this.lblCountLeft.Size = new System.Drawing.Size(578, 26);
      this.lblCountLeft.TabIndex = 13;
      this.lblCountLeft.Text = "xxx";
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(474, 217);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(116, 17);
      this.label2.TabIndex = 15;
      this.label2.Text = "Type de données :";
      // 
      // btClasse
      // 
      this.btClasse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btClasse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btClasse.Image = global::RedisManagementStudio.Properties.Resources.BtLeft;
      this.btClasse.Location = new System.Drawing.Point(476, 336);
      this.btClasse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btClasse.Name = "btClasse";
      this.btClasse.Size = new System.Drawing.Size(113, 30);
      this.btClasse.TabIndex = 12;
      this.btClasse.Text = "Unknow";
      this.btClasse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btClasse.UseVisualStyleBackColor = true;
      this.btClasse.Click += new System.EventHandler(this.BtClasseClick);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(68, 17);
      this.label1.TabIndex = 14;
      this.label1.Text = "Rubrique :";
      // 
      // btNoClasse
      // 
      this.btNoClasse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btNoClasse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btNoClasse.Image = global::RedisManagementStudio.Properties.Resources.BtRight;
      this.btNoClasse.Location = new System.Drawing.Point(476, 298);
      this.btNoClasse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btNoClasse.Name = "btNoClasse";
      this.btNoClasse.Size = new System.Drawing.Size(113, 30);
      this.btNoClasse.TabIndex = 11;
      this.btNoClasse.Text = "Non classé";
      this.btNoClasse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btNoClasse.UseVisualStyleBackColor = true;
      this.btNoClasse.Click += new System.EventHandler(this.BNoClasseClick);
      // 
      // cbRubrique
      // 
      this.cbRubrique.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cbRubrique.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbRubrique.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbRubrique.FormattingEnabled = true;
      this.cbRubrique.Location = new System.Drawing.Point(86, 6);
      this.cbRubrique.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.cbRubrique.Name = "cbRubrique";
      this.cbRubrique.Size = new System.Drawing.Size(385, 25);
      this.cbRubrique.TabIndex = 0;
      this.cbRubrique.SelectedIndexChanged += new System.EventHandler(this.CbRubriqueSelectedIndexChanged);
      // 
      // cbAlarme
      // 
      this.cbAlarme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cbAlarme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbAlarme.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbAlarme.FormattingEnabled = true;
      this.cbAlarme.Location = new System.Drawing.Point(477, 238);
      this.cbAlarme.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.cbAlarme.Name = "cbAlarme";
      this.cbAlarme.Size = new System.Drawing.Size(112, 25);
      this.cbAlarme.TabIndex = 4;
      this.cbAlarme.SelectedIndexChanged += new System.EventHandler(this.CbAlarmeSelectedIndexChanged);
      // 
      // btTop
      // 
      this.btTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btTop.Image = global::RedisManagementStudio.Properties.Resources.BtPremier;
      this.btTop.Location = new System.Drawing.Point(477, 39);
      this.btTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btTop.Name = "btTop";
      this.btTop.Size = new System.Drawing.Size(112, 30);
      this.btTop.TabIndex = 7;
      this.btTop.Text = "Premier";
      this.btTop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btTop.UseVisualStyleBackColor = true;
      this.btTop.Click += new System.EventHandler(this.BtTopClick);
      // 
      // btUp
      // 
      this.btUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btUp.Image = global::RedisManagementStudio.Properties.Resources.BtUp;
      this.btUp.Location = new System.Drawing.Point(477, 77);
      this.btUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btUp.Name = "btUp";
      this.btUp.Size = new System.Drawing.Size(112, 30);
      this.btUp.TabIndex = 8;
      this.btUp.Text = "Monter";
      this.btUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btUp.UseVisualStyleBackColor = true;
      this.btUp.Click += new System.EventHandler(this.BtUpClick);
      // 
      // btBottom
      // 
      this.btBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btBottom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btBottom.Image = global::RedisManagementStudio.Properties.Resources.BtDernier;
      this.btBottom.Location = new System.Drawing.Point(477, 153);
      this.btBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btBottom.Name = "btBottom";
      this.btBottom.Size = new System.Drawing.Size(112, 30);
      this.btBottom.TabIndex = 10;
      this.btBottom.Text = "Dernier";
      this.btBottom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btBottom.UseVisualStyleBackColor = true;
      this.btBottom.Click += new System.EventHandler(this.BtBottomClick);
      // 
      // btDown
      // 
      this.btDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btDown.Image = global::RedisManagementStudio.Properties.Resources.BtDown;
      this.btDown.Location = new System.Drawing.Point(477, 115);
      this.btDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btDown.Name = "btDown";
      this.btDown.Size = new System.Drawing.Size(112, 30);
      this.btDown.TabIndex = 9;
      this.btDown.Text = "Descendre";
      this.btDown.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btDown.UseVisualStyleBackColor = true;
      this.btDown.Click += new System.EventHandler(this.BtDownClick);
      // 
      // lstRubRight
      // 
      this.lstRubRight.Activation = System.Windows.Forms.ItemActivation.OneClick;
      this.lstRubRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lstRubRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lstRubRight.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCommand2,
            this.colCode2,
            this.colTypeAlarm2,
            this.colTitre2});
      this.lstRubRight.FullRowSelect = true;
      this.lstRubRight.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.lstRubRight.HideSelection = false;
      this.lstRubRight.LabelWrap = false;
      this.lstRubRight.Location = new System.Drawing.Point(6, 39);
      this.lstRubRight.MultiSelect = false;
      this.lstRubRight.Name = "lstRubRight";
      this.lstRubRight.ShowGroups = false;
      this.lstRubRight.ShowItemToolTips = true;
      this.lstRubRight.Size = new System.Drawing.Size(169, 428);
      this.lstRubRight.TabIndex = 17;
      this.lstRubRight.UseCompatibleStateImageBehavior = false;
      this.lstRubRight.View = System.Windows.Forms.View.Details;
      this.lstRubRight.SelectedIndexChanged += new System.EventHandler(this.LstRubRightSelectedIndexChanged);
      // 
      // colCommand2
      // 
      this.colCommand2.Text = "Commande";
      // 
      // colCode2
      // 
      this.colCode2.Text = "Information";
      // 
      // colTypeAlarm2
      // 
      this.colTypeAlarm2.Text = "Type";
      // 
      // colTitre2
      // 
      this.colTitre2.Text = "Titre";
      // 
      // lblCountRight
      // 
      this.lblCountRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lblCountRight.AutoSize = true;
      this.lblCountRight.Location = new System.Drawing.Point(3, 475);
      this.lblCountRight.Name = "lblCountRight";
      this.lblCountRight.Size = new System.Drawing.Size(26, 17);
      this.lblCountRight.TabIndex = 3;
      this.lblCountRight.Text = "xxx";
      // 
      // lblTitreLeft
      // 
      this.lblTitreLeft.AutoSize = true;
      this.lblTitreLeft.Location = new System.Drawing.Point(3, 9);
      this.lblTitreLeft.Name = "lblTitreLeft";
      this.lblTitreLeft.Size = new System.Drawing.Size(145, 17);
      this.lblTitreLeft.TabIndex = 2;
      this.lblTitreLeft.Text = "Eléments non classées :";
      // 
      // FManageInfos
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(783, 501);
      this.Controls.Add(this.splitContainer1);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FManageInfos";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Configurer les informations serveur";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FManageInfos_FormClosed);
      this.Load += new System.EventHandler(this.FManageInfos_Load);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.ComboBox cbRubrique;
    private System.Windows.Forms.ComboBox cbAlarme;
    private System.Windows.Forms.Button btBottom;
    private System.Windows.Forms.Button btDown;
    private System.Windows.Forms.Button btUp;
    private System.Windows.Forms.Button btTop;
    private System.Windows.Forms.Button btNoClasse;
    private System.Windows.Forms.Button btClasse;
    private System.Windows.Forms.Label lblCountRight;
    private System.Windows.Forms.Label lblTitreLeft;
    private System.Windows.Forms.Label lblCountLeft;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ListView lstRubLeft;
    private System.Windows.Forms.ColumnHeader colCommand;
    private System.Windows.Forms.ColumnHeader colCode;
    private System.Windows.Forms.ColumnHeader colTypeAlarm;
    private System.Windows.Forms.ColumnHeader colTitre;
    private System.Windows.Forms.ListView lstRubRight;
    private System.Windows.Forms.ColumnHeader colCommand2;
    private System.Windows.Forms.ColumnHeader colCode2;
    private System.Windows.Forms.ColumnHeader colTypeAlarm2;
    private System.Windows.Forms.ColumnHeader colTitre2;
  }
}