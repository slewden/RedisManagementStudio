namespace RedisManagementStudio.BLL.Redis.Keys
{
  partial class KeySearch
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeySearch));
      this.panel1 = new System.Windows.Forms.Panel();
      this.panel3 = new System.Windows.Forms.Panel();
      this.txtSearch = new System.Windows.Forms.TextBox();
      this.cbFiltreType = new System.Windows.Forms.ComboBox();
      this.btSearch = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.lblCountCle = new System.Windows.Forms.Label();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.chkMelangeType = new System.Windows.Forms.CheckBox();
      this.label2 = new System.Windows.Forms.Label();
      this.rdDisplayMode0 = new System.Windows.Forms.RadioButton();
      this.rdDisplayMode1 = new System.Windows.Forms.RadioButton();
      this.rdDisplayMode2 = new System.Windows.Forms.RadioButton();
      this.rdDisplayMode3 = new System.Windows.Forms.RadioButton();
      this.lblDetail = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.pnlResult = new System.Windows.Forms.Panel();
      this.label4 = new System.Windows.Forms.Label();
      this.btSizeOf = new System.Windows.Forms.Button();
      this.btAddKey = new System.Windows.Forms.Button();
      this.lblPoids = new System.Windows.Forms.Label();
      this.txtMinChar = new RedisManagementStudio.BLL.UI.NumericTextBox();
      this.panel1.SuspendLayout();
      this.panel3.SuspendLayout();
      this.pnlResult.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.White;
      this.panel1.Controls.Add(this.panel3);
      this.panel1.Controls.Add(this.btSearch);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Location = new System.Drawing.Point(0, 44);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(607, 48);
      this.panel1.TabIndex = 0;
      // 
      // panel3
      // 
      this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel3.Controls.Add(this.txtSearch);
      this.panel3.Controls.Add(this.cbFiltreType);
      this.panel3.Location = new System.Drawing.Point(84, 4);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(492, 25);
      this.panel3.TabIndex = 4;
      // 
      // txtSearch
      // 
      this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtSearch.Location = new System.Drawing.Point(3, 3);
      this.txtSearch.Name = "txtSearch";
      this.txtSearch.Size = new System.Drawing.Size(361, 18);
      this.txtSearch.TabIndex = 1;
      this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearchTextChanged);
      this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSearchKeyPress);
      // 
      // cbFiltreType
      // 
      this.cbFiltreType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cbFiltreType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbFiltreType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbFiltreType.FormattingEnabled = true;
      this.cbFiltreType.Location = new System.Drawing.Point(370, -1);
      this.cbFiltreType.Name = "cbFiltreType";
      this.cbFiltreType.Size = new System.Drawing.Size(121, 25);
      this.cbFiltreType.TabIndex = 3;
      this.cbFiltreType.SelectedIndexChanged += new System.EventHandler(this.TxtSearchTextChanged);
      // 
      // btSearch
      // 
      this.btSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btSearch.Image = global::RedisManagementStudio.Properties.Resources.Search;
      this.btSearch.Location = new System.Drawing.Point(582, 4);
      this.btSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btSearch.Name = "btSearch";
      this.btSearch.Size = new System.Drawing.Size(25, 25);
      this.btSearch.TabIndex = 2;
      this.btSearch.UseVisualStyleBackColor = true;
      this.btSearch.Click += new System.EventHandler(this.BtSearchClick);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 8);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(75, 17);
      this.label1.TabIndex = 0;
      this.label1.Text = "Recherche :";
      // 
      // lblCountCle
      // 
      this.lblCountCle.AutoEllipsis = true;
      this.lblCountCle.Location = new System.Drawing.Point(29, 27);
      this.lblCountCle.Name = "lblCountCle";
      this.lblCountCle.Size = new System.Drawing.Size(408, 30);
      this.lblCountCle.TabIndex = 0;
      this.lblCountCle.Text = "xxx";
      this.lblCountCle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
      this.imageList1.Images.SetKeyName(7, "GTnone");
      this.imageList1.Images.SetKeyName(8, "GUnKnow");
      this.imageList1.Images.SetKeyName(9, "GThash");
      this.imageList1.Images.SetKeyName(10, "GTstring");
      this.imageList1.Images.SetKeyName(11, "GTlist");
      this.imageList1.Images.SetKeyName(12, "GTzset");
      this.imageList1.Images.SetKeyName(13, "GTset");
      this.imageList1.Images.SetKeyName(14, "warning");
      // 
      // chkMelangeType
      // 
      this.chkMelangeType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.chkMelangeType.Location = new System.Drawing.Point(47, 332);
      this.chkMelangeType.Name = "chkMelangeType";
      this.chkMelangeType.Size = new System.Drawing.Size(340, 25);
      this.chkMelangeType.TabIndex = 6;
      this.chkMelangeType.Text = "Autoriser le regroupement de clé de types différents";
      this.chkMelangeType.UseVisualStyleBackColor = true;
      this.chkMelangeType.CheckedChanged += new System.EventHandler(this.ChkMelangeTypeCheckedChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(3, 118);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(127, 17);
      this.label2.TabIndex = 7;
      this.label2.Text = "Options du résultat :";
      // 
      // rdDisplayMode0
      // 
      this.rdDisplayMode0.Location = new System.Drawing.Point(47, 148);
      this.rdDisplayMode0.Name = "rdDisplayMode0";
      this.rdDisplayMode0.Size = new System.Drawing.Size(557, 24);
      this.rdDisplayMode0.TabIndex = 8;
      this.rdDisplayMode0.TabStop = true;
      this.rdDisplayMode0.Tag = "0";
      this.rdDisplayMode0.Text = "Aucun regroupement";
      this.rdDisplayMode0.UseVisualStyleBackColor = true;
      this.rdDisplayMode0.CheckedChanged += new System.EventHandler(this.BtDisplayModeClick);
      // 
      // rdDisplayMode1
      // 
      this.rdDisplayMode1.Location = new System.Drawing.Point(47, 178);
      this.rdDisplayMode1.Name = "rdDisplayMode1";
      this.rdDisplayMode1.Size = new System.Drawing.Size(557, 47);
      this.rdDisplayMode1.TabIndex = 9;
      this.rdDisplayMode1.TabStop = true;
      this.rdDisplayMode1.Tag = "1";
      this.rdDisplayMode1.Text = "Aucun regroupement";
      this.rdDisplayMode1.UseVisualStyleBackColor = true;
      this.rdDisplayMode1.CheckedChanged += new System.EventHandler(this.BtDisplayModeClick);
      // 
      // rdDisplayMode2
      // 
      this.rdDisplayMode2.Location = new System.Drawing.Point(47, 231);
      this.rdDisplayMode2.Name = "rdDisplayMode2";
      this.rdDisplayMode2.Size = new System.Drawing.Size(557, 43);
      this.rdDisplayMode2.TabIndex = 10;
      this.rdDisplayMode2.TabStop = true;
      this.rdDisplayMode2.Tag = "2";
      this.rdDisplayMode2.Text = "Aucun regroupement";
      this.rdDisplayMode2.UseVisualStyleBackColor = true;
      this.rdDisplayMode2.CheckedChanged += new System.EventHandler(this.BtDisplayModeClick);
      // 
      // rdDisplayMode3
      // 
      this.rdDisplayMode3.Location = new System.Drawing.Point(47, 280);
      this.rdDisplayMode3.Name = "rdDisplayMode3";
      this.rdDisplayMode3.Size = new System.Drawing.Size(557, 34);
      this.rdDisplayMode3.TabIndex = 11;
      this.rdDisplayMode3.TabStop = true;
      this.rdDisplayMode3.Tag = "3";
      this.rdDisplayMode3.Text = "Aucun regroupement";
      this.rdDisplayMode3.UseVisualStyleBackColor = true;
      this.rdDisplayMode3.CheckedChanged += new System.EventHandler(this.BtDisplayModeClick);
      // 
      // lblDetail
      // 
      this.lblDetail.BackColor = System.Drawing.SystemColors.Control;
      this.lblDetail.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblDetail.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblDetail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.lblDetail.Location = new System.Drawing.Point(0, 0);
      this.lblDetail.Name = "lblDetail";
      this.lblDetail.Size = new System.Drawing.Size(607, 40);
      this.lblDetail.TabIndex = 29;
      this.lblDetail.Text = "Recherche de clé sur le serveur";
      this.lblDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(3, 10);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(61, 17);
      this.label3.TabIndex = 30;
      this.label3.Text = "Résultat :";
      // 
      // pnlResult
      // 
      this.pnlResult.BackColor = System.Drawing.Color.White;
      this.pnlResult.Controls.Add(this.label3);
      this.pnlResult.Controls.Add(this.lblCountCle);
      this.pnlResult.Location = new System.Drawing.Point(0, 405);
      this.pnlResult.Name = "pnlResult";
      this.pnlResult.Size = new System.Drawing.Size(607, 74);
      this.pnlResult.TabIndex = 31;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(47, 377);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(276, 17);
      this.label4.TabIndex = 32;
      this.label4.Text = "Nombre de caractères en commun minimum :";
      // 
      // btSizeOf
      // 
      this.btSizeOf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btSizeOf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btSizeOf.Image = global::RedisManagementStudio.Properties.Resources.weight16;
      this.btSizeOf.Location = new System.Drawing.Point(549, 8);
      this.btSizeOf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btSizeOf.Name = "btSizeOf";
      this.btSizeOf.Size = new System.Drawing.Size(25, 25);
      this.btSizeOf.TabIndex = 39;
      this.btSizeOf.UseVisualStyleBackColor = true;
      this.btSizeOf.Click += new System.EventHandler(this.BtSizeOfClick);
      // 
      // btAddKey
      // 
      this.btAddKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btAddKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btAddKey.Image = global::RedisManagementStudio.Properties.Resources.Add;
      this.btAddKey.Location = new System.Drawing.Point(579, 8);
      this.btAddKey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btAddKey.Name = "btAddKey";
      this.btAddKey.Size = new System.Drawing.Size(25, 25);
      this.btAddKey.TabIndex = 38;
      this.btAddKey.UseVisualStyleBackColor = true;
      this.btAddKey.Click += new System.EventHandler(this.BtAddKeyClick);
      // 
      // lblPoids
      // 
      this.lblPoids.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblPoids.BackColor = System.Drawing.SystemColors.Control;
      this.lblPoids.Location = new System.Drawing.Point(449, 8);
      this.lblPoids.Name = "lblPoids";
      this.lblPoids.Size = new System.Drawing.Size(94, 25);
      this.lblPoids.TabIndex = 42;
      this.lblPoids.Text = "xxx";
      this.lblPoids.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // txtMinChar
      // 
      this.txtMinChar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtMinChar.DoubleValue = double.NaN;
      this.txtMinChar.Location = new System.Drawing.Point(337, 374);
      this.txtMinChar.Name = "txtMinChar";
      this.txtMinChar.Size = new System.Drawing.Size(100, 25);
      this.txtMinChar.TabIndex = 33;
      this.txtMinChar.Text = "Non numérique";
      this.txtMinChar.TextChanged += new System.EventHandler(this.ChkMelangeTypeCheckedChanged);
      // 
      // KeySearch
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lblPoids);
      this.Controls.Add(this.btSizeOf);
      this.Controls.Add(this.btAddKey);
      this.Controls.Add(this.txtMinChar);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.pnlResult);
      this.Controls.Add(this.lblDetail);
      this.Controls.Add(this.rdDisplayMode3);
      this.Controls.Add(this.rdDisplayMode2);
      this.Controls.Add(this.rdDisplayMode1);
      this.Controls.Add(this.rdDisplayMode0);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.chkMelangeType);
      this.Controls.Add(this.panel1);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "KeySearch";
      this.Size = new System.Drawing.Size(607, 523);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.pnlResult.ResumeLayout(false);
      this.pnlResult.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TextBox txtSearch;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btSearch;
    private System.Windows.Forms.ComboBox cbFiltreType;
    private System.Windows.Forms.Label lblCountCle;
    private System.Windows.Forms.Panel panel3;
    public System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.CheckBox chkMelangeType;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.RadioButton rdDisplayMode0;
    private System.Windows.Forms.RadioButton rdDisplayMode1;
    private System.Windows.Forms.RadioButton rdDisplayMode2;
    private System.Windows.Forms.RadioButton rdDisplayMode3;
    private System.Windows.Forms.Label lblDetail;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Panel pnlResult;
    private System.Windows.Forms.Label label4;
    private UI.NumericTextBox txtMinChar;
    private System.Windows.Forms.Button btSizeOf;
    private System.Windows.Forms.Button btAddKey;
    private System.Windows.Forms.Label lblPoids;
  }
}
