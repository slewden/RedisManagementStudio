namespace RedisManagementStudio.BLL.Keys
{
  partial class KeysExplorer
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeysExplorer));
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.keySearch1 = new RedisManagementStudio.BLL.Keys.KeySearch();
      this.panel2 = new System.Windows.Forms.Panel();
      this.label4 = new System.Windows.Forms.Label();
      this.pnlDefault = new System.Windows.Forms.Panel();
      this.lblValue = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.editTypeHash1 = new RedisManagementStudio.BLL.Keys.EditTypeHash();
      this.editTypeZSet1 = new RedisManagementStudio.BLL.Keys.EditTypeZSet();
      this.editTypeSet1 = new RedisManagementStudio.BLL.Keys.EditTypeSet();
      this.editTypeList1 = new RedisManagementStudio.BLL.Keys.EditTypeList();
      this.editTypeText1 = new RedisManagementStudio.BLL.Keys.EditTypeText();
      this.pnlDetail = new System.Windows.Forms.Panel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.pnlDefineTTL = new System.Windows.Forms.Panel();
      this.btClearTTL = new System.Windows.Forms.Button();
      this.btSetTTL = new System.Windows.Forms.Button();
      this.cbTTL = new System.Windows.Forms.ComboBox();
      this.numTTL = new System.Windows.Forms.NumericUpDown();
      this.label5 = new System.Windows.Forms.Label();
      this.lblTTL = new System.Windows.Forms.Label();
      this.lblTypeCle = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.keyGroup1 = new RedisManagementStudio.BLL.Keys.KeyGroup();
      this.panel4 = new System.Windows.Forms.Panel();
      this.imgType = new System.Windows.Forms.PictureBox();
      this.lblDetail = new System.Windows.Forms.Label();
      this.panel3 = new System.Windows.Forms.Panel();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.imageList2 = new System.Windows.Forms.ImageList(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.pnlDefault.SuspendLayout();
      this.pnlDetail.SuspendLayout();
      this.panel1.SuspendLayout();
      this.pnlDefineTTL.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numTTL)).BeginInit();
      this.panel4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.imgType)).BeginInit();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.keySearch1);
      this.splitContainer1.Panel1.Controls.Add(this.panel2);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.pnlDefault);
      this.splitContainer1.Panel2.Controls.Add(this.editTypeHash1);
      this.splitContainer1.Panel2.Controls.Add(this.editTypeZSet1);
      this.splitContainer1.Panel2.Controls.Add(this.editTypeSet1);
      this.splitContainer1.Panel2.Controls.Add(this.editTypeList1);
      this.splitContainer1.Panel2.Controls.Add(this.editTypeText1);
      this.splitContainer1.Panel2.Controls.Add(this.pnlDetail);
      this.splitContainer1.Panel2.Controls.Add(this.keyGroup1);
      this.splitContainer1.Panel2.Controls.Add(this.panel4);
      this.splitContainer1.Panel2.Controls.Add(this.panel3);
      this.splitContainer1.Size = new System.Drawing.Size(889, 391);
      this.splitContainer1.SplitterDistance = 417;
      this.splitContainer1.SplitterWidth = 5;
      this.splitContainer1.TabIndex = 4;
      // 
      // keySearch1
      // 
      this.keySearch1.Connection = null;
      this.keySearch1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.keySearch1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.keySearch1.Location = new System.Drawing.Point(0, 40);
      this.keySearch1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.keySearch1.Name = "keySearch1";
      this.keySearch1.SelectedNode = null;
      this.keySearch1.Size = new System.Drawing.Size(417, 351);
      this.keySearch1.TabIndex = 6;
      this.keySearch1.OnSearch += new System.EventHandler(this.KeySearchOnSearch);
      this.keySearch1.OnChange += new System.EventHandler(this.KeySearchOnChange);
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.label4);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(0, 0);
      this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(417, 40);
      this.panel2.TabIndex = 5;
      // 
      // label4
      // 
      this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label4.BackColor = System.Drawing.SystemColors.Control;
      this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F);
      this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.label4.Location = new System.Drawing.Point(3, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(256, 40);
      this.label4.TabIndex = 29;
      this.label4.Text = "Explorateur de clés";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // pnlDefault
      // 
      this.pnlDefault.Controls.Add(this.lblValue);
      this.pnlDefault.Controls.Add(this.label3);
      this.pnlDefault.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlDefault.Location = new System.Drawing.Point(0, 110);
      this.pnlDefault.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.pnlDefault.Name = "pnlDefault";
      this.pnlDefault.Size = new System.Drawing.Size(457, 281);
      this.pnlDefault.TabIndex = 36;
      // 
      // lblValue
      // 
      this.lblValue.AutoSize = true;
      this.lblValue.Location = new System.Drawing.Point(105, 0);
      this.lblValue.Name = "lblValue";
      this.lblValue.Size = new System.Drawing.Size(26, 17);
      this.lblValue.TabIndex = 3;
      this.lblValue.Text = "xxx";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(16, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(52, 17);
      this.label3.TabIndex = 2;
      this.label3.Text = "Valeur :";
      // 
      // editTypeHash1
      // 
      this.editTypeHash1.Connection = null;
      this.editTypeHash1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.editTypeHash1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.editTypeHash1.Key = "";
      this.editTypeHash1.Location = new System.Drawing.Point(0, 110);
      this.editTypeHash1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.editTypeHash1.Name = "editTypeHash1";
      this.editTypeHash1.Size = new System.Drawing.Size(457, 281);
      this.editTypeHash1.TabIndex = 37;
      this.editTypeHash1.OnChange += new System.EventHandler(this.EditTypeOnChange);
      // 
      // editTypeZSet1
      // 
      this.editTypeZSet1.Connection = null;
      this.editTypeZSet1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.editTypeZSet1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.editTypeZSet1.Key = "";
      this.editTypeZSet1.Location = new System.Drawing.Point(0, 110);
      this.editTypeZSet1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.editTypeZSet1.Name = "editTypeZSet1";
      this.editTypeZSet1.Size = new System.Drawing.Size(457, 281);
      this.editTypeZSet1.TabIndex = 40;
      this.editTypeZSet1.OnChange += new System.EventHandler(this.EditTypeOnChange);
      // 
      // editTypeSet1
      // 
      this.editTypeSet1.Connection = null;
      this.editTypeSet1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.editTypeSet1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.editTypeSet1.Key = "";
      this.editTypeSet1.Location = new System.Drawing.Point(0, 110);
      this.editTypeSet1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.editTypeSet1.Name = "editTypeSet1";
      this.editTypeSet1.Size = new System.Drawing.Size(457, 281);
      this.editTypeSet1.TabIndex = 35;
      this.editTypeSet1.OnChange += new System.EventHandler(this.EditTypeOnChange);
      // 
      // editTypeList1
      // 
      this.editTypeList1.Connection = null;
      this.editTypeList1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.editTypeList1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.editTypeList1.Key = "";
      this.editTypeList1.Location = new System.Drawing.Point(0, 110);
      this.editTypeList1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.editTypeList1.Name = "editTypeList1";
      this.editTypeList1.Size = new System.Drawing.Size(457, 281);
      this.editTypeList1.TabIndex = 38;
      this.editTypeList1.OnChange += new System.EventHandler(this.EditTypeOnChange);
      // 
      // editTypeText1
      // 
      this.editTypeText1.Connection = null;
      this.editTypeText1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.editTypeText1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.editTypeText1.Key = "";
      this.editTypeText1.Location = new System.Drawing.Point(0, 110);
      this.editTypeText1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.editTypeText1.Name = "editTypeText1";
      this.editTypeText1.Size = new System.Drawing.Size(457, 281);
      this.editTypeText1.TabIndex = 39;
      this.editTypeText1.OnChange += new System.EventHandler(this.EditTypeOnChange);
      // 
      // pnlDetail
      // 
      this.pnlDetail.Controls.Add(this.panel1);
      this.pnlDetail.Controls.Add(this.lblTypeCle);
      this.pnlDetail.Controls.Add(this.label2);
      this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlDetail.Location = new System.Drawing.Point(0, 40);
      this.pnlDetail.Name = "pnlDetail";
      this.pnlDetail.Size = new System.Drawing.Size(457, 70);
      this.pnlDetail.TabIndex = 41;
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.BackColor = System.Drawing.Color.White;
      this.panel1.Controls.Add(this.pnlDefineTTL);
      this.panel1.Controls.Add(this.label5);
      this.panel1.Controls.Add(this.lblTTL);
      this.panel1.Location = new System.Drawing.Point(0, 24);
      this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(457, 35);
      this.panel1.TabIndex = 33;
      // 
      // pnlDefineTTL
      // 
      this.pnlDefineTTL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.pnlDefineTTL.BackColor = System.Drawing.Color.White;
      this.pnlDefineTTL.Controls.Add(this.btClearTTL);
      this.pnlDefineTTL.Controls.Add(this.btSetTTL);
      this.pnlDefineTTL.Controls.Add(this.cbTTL);
      this.pnlDefineTTL.Controls.Add(this.numTTL);
      this.pnlDefineTTL.Location = new System.Drawing.Point(214, 0);
      this.pnlDefineTTL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.pnlDefineTTL.Name = "pnlDefineTTL";
      this.pnlDefineTTL.Size = new System.Drawing.Size(243, 35);
      this.pnlDefineTTL.TabIndex = 32;
      // 
      // btClearTTL
      // 
      this.btClearTTL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btClearTTL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btClearTTL.Image = global::RedisManagementStudio.Properties.Resources.Delete12;
      this.btClearTTL.Location = new System.Drawing.Point(216, 4);
      this.btClearTTL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btClearTTL.Name = "btClearTTL";
      this.btClearTTL.Size = new System.Drawing.Size(27, 27);
      this.btClearTTL.TabIndex = 33;
      this.toolTip1.SetToolTip(this.btClearTTL, "Durée de vie infinie");
      this.btClearTTL.UseVisualStyleBackColor = true;
      this.btClearTTL.Click += new System.EventHandler(this.BtClearTTLClick);
      // 
      // btSetTTL
      // 
      this.btSetTTL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btSetTTL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btSetTTL.Location = new System.Drawing.Point(156, 4);
      this.btSetTTL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btSetTTL.Name = "btSetTTL";
      this.btSetTTL.Size = new System.Drawing.Size(56, 27);
      this.btSetTTL.TabIndex = 29;
      this.btSetTTL.Text = "Définir";
      this.btSetTTL.UseVisualStyleBackColor = true;
      this.btSetTTL.Click += new System.EventHandler(this.BtSetTTLClick);
      // 
      // cbTTL
      // 
      this.cbTTL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cbTTL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbTTL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cbTTL.FormattingEnabled = true;
      this.cbTTL.Items.AddRange(new object[] {
            "Secondes",
            "Minutes",
            "Heures"});
      this.cbTTL.Location = new System.Drawing.Point(62, 4);
      this.cbTTL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.cbTTL.Name = "cbTTL";
      this.cbTTL.Size = new System.Drawing.Size(89, 25);
      this.cbTTL.TabIndex = 31;
      // 
      // numTTL
      // 
      this.numTTL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.numTTL.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.numTTL.Location = new System.Drawing.Point(16, 8);
      this.numTTL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.numTTL.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
      this.numTTL.Name = "numTTL";
      this.numTTL.Size = new System.Drawing.Size(45, 21);
      this.numTTL.TabIndex = 30;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(16, 9);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(89, 17);
      this.label5.TabIndex = 4;
      this.label5.Text = "Durée de vie :";
      // 
      // lblTTL
      // 
      this.lblTTL.AutoSize = true;
      this.lblTTL.Location = new System.Drawing.Point(105, 8);
      this.lblTTL.Name = "lblTTL";
      this.lblTTL.Size = new System.Drawing.Size(26, 17);
      this.lblTTL.TabIndex = 5;
      this.lblTTL.Text = "xxx";
      // 
      // lblTypeCle
      // 
      this.lblTypeCle.AutoSize = true;
      this.lblTypeCle.Location = new System.Drawing.Point(105, 3);
      this.lblTypeCle.Name = "lblTypeCle";
      this.lblTypeCle.Size = new System.Drawing.Size(26, 17);
      this.lblTypeCle.TabIndex = 1;
      this.lblTypeCle.Text = "???";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(16, 3);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(82, 17);
      this.label2.TabIndex = 0;
      this.label2.Text = "Type de clé :";
      // 
      // keyGroup1
      // 
      this.keyGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.keyGroup1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.keyGroup1.ImageList = null;
      this.keyGroup1.Location = new System.Drawing.Point(0, 40);
      this.keyGroup1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.keyGroup1.Name = "keyGroup1";
      this.keyGroup1.Selection = null;
      this.keyGroup1.Size = new System.Drawing.Size(457, 351);
      this.keyGroup1.TabIndex = 4;
      this.keyGroup1.OnChange += new System.EventHandler(this.KeyGroup1OnChange);
      // 
      // panel4
      // 
      this.panel4.Controls.Add(this.imgType);
      this.panel4.Controls.Add(this.lblDetail);
      this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel4.Location = new System.Drawing.Point(0, 0);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(457, 40);
      this.panel4.TabIndex = 35;
      // 
      // imgType
      // 
      this.imgType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.imgType.BackColor = System.Drawing.SystemColors.Control;
      this.imgType.Location = new System.Drawing.Point(425, 5);
      this.imgType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.imgType.Name = "imgType";
      this.imgType.Size = new System.Drawing.Size(32, 32);
      this.imgType.TabIndex = 34;
      this.imgType.TabStop = false;
      // 
      // lblDetail
      // 
      this.lblDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblDetail.BackColor = System.Drawing.SystemColors.Control;
      this.lblDetail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblDetail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.lblDetail.Location = new System.Drawing.Point(0, 0);
      this.lblDetail.Name = "lblDetail";
      this.lblDetail.Size = new System.Drawing.Size(413, 40);
      this.lblDetail.TabIndex = 28;
      this.lblDetail.Text = "Détail de l\'information";
      this.lblDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // panel3
      // 
      this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
      this.panel3.Location = new System.Drawing.Point(457, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(10, 391);
      this.panel3.TabIndex = 4;
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "Tnone");
      this.imageList1.Images.SetKeyName(1, "UnKnow");
      this.imageList1.Images.SetKeyName(2, "Thash");
      this.imageList1.Images.SetKeyName(3, "Tstring");
      this.imageList1.Images.SetKeyName(4, "Tlist");
      this.imageList1.Images.SetKeyName(5, "Tzset");
      this.imageList1.Images.SetKeyName(6, "Tset");
      // 
      // imageList2
      // 
      this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
      this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList2.Images.SetKeyName(0, "Thash");
      this.imageList2.Images.SetKeyName(1, "Tstring");
      this.imageList2.Images.SetKeyName(2, "Tlist");
      this.imageList2.Images.SetKeyName(3, "Tzset");
      this.imageList2.Images.SetKeyName(4, "Tset");
      this.imageList2.Images.SetKeyName(5, "Tnone");
      this.imageList2.Images.SetKeyName(6, "UnKnow");
      // 
      // KeysExplorer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.splitContainer1);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "KeysExplorer";
      this.Size = new System.Drawing.Size(889, 391);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.pnlDefault.ResumeLayout(false);
      this.pnlDefault.PerformLayout();
      this.pnlDetail.ResumeLayout(false);
      this.pnlDetail.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.pnlDefineTTL.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.numTTL)).EndInit();
      this.panel4.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.imgType)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.Label lblValue;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label lblTypeCle;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label lblTTL;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label lblDetail;
    private System.Windows.Forms.Button btClearTTL;
    private System.Windows.Forms.Panel pnlDefineTTL;
    private System.Windows.Forms.Button btSetTTL;
    private System.Windows.Forms.ComboBox cbTTL;
    private System.Windows.Forms.NumericUpDown numTTL;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.ImageList imageList1;
    private EditTypeSet editTypeSet1;
    private System.Windows.Forms.Panel pnlDefault;
    private System.Windows.Forms.Label label4;
    private EditTypeHash editTypeHash1;
    private EditTypeList editTypeList1;
    private EditTypeText editTypeText1;
    private System.Windows.Forms.ImageList imageList2;
    private System.Windows.Forms.PictureBox imgType;
    private EditTypeZSet editTypeZSet1;
    private KeySearch keySearch1;
    private System.Windows.Forms.Panel pnlDetail;
    private System.Windows.Forms.Panel panel4;
    private KeyGroup keyGroup1;
    private System.Windows.Forms.Panel panel3;
  }
}
