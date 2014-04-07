namespace RedisManagementStudio.BLL.Keys
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
      this.lstKeys = new System.Windows.Forms.TreeView();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.btDisplayMode = new System.Windows.Forms.Button();
      this.panel1.SuspendLayout();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.White;
      this.panel1.Controls.Add(this.panel3);
      this.panel1.Controls.Add(this.btSearch);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
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
      this.panel3.Size = new System.Drawing.Size(484, 25);
      this.panel3.TabIndex = 4;
      // 
      // txtSearch
      // 
      this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtSearch.Location = new System.Drawing.Point(3, 3);
      this.txtSearch.Name = "txtSearch";
      this.txtSearch.Size = new System.Drawing.Size(353, 18);
      this.txtSearch.TabIndex = 1;
      this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearchTextChanged);
      // 
      // cbFiltreType
      // 
      this.cbFiltreType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cbFiltreType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbFiltreType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbFiltreType.FormattingEnabled = true;
      this.cbFiltreType.Items.AddRange(new object[] {
            "[Tous]",
            "Chaînes",
            "Listes",
            "Sets",
            "ZSets",
            "Hash"});
      this.cbFiltreType.Location = new System.Drawing.Point(362, -1);
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
      this.btSearch.Location = new System.Drawing.Point(574, 4);
      this.btSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btSearch.Name = "btSearch";
      this.btSearch.Size = new System.Drawing.Size(30, 25);
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
      this.lblCountCle.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.lblCountCle.Location = new System.Drawing.Point(0, 497);
      this.lblCountCle.Name = "lblCountCle";
      this.lblCountCle.Size = new System.Drawing.Size(607, 26);
      this.lblCountCle.TabIndex = 0;
      this.lblCountCle.Text = "xxx";
      this.lblCountCle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lstKeys
      // 
      this.lstKeys.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lstKeys.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lstKeys.FullRowSelect = true;
      this.lstKeys.HideSelection = false;
      this.lstKeys.ImageIndex = 0;
      this.lstKeys.ImageList = this.imageList1;
      this.lstKeys.Location = new System.Drawing.Point(0, 48);
      this.lstKeys.Name = "lstKeys";
      this.lstKeys.PathSeparator = "/";
      this.lstKeys.SelectedImageIndex = 0;
      this.lstKeys.ShowNodeToolTips = true;
      this.lstKeys.Size = new System.Drawing.Size(607, 449);
      this.lstKeys.TabIndex = 2;
      this.lstKeys.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.LstKeysAfterSelect);
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
      // btDisplayMode
      // 
      this.btDisplayMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btDisplayMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btDisplayMode.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btDisplayMode.Location = new System.Drawing.Point(585, 500);
      this.btDisplayMode.Name = "btDisplayMode";
      this.btDisplayMode.Size = new System.Drawing.Size(22, 22);
      this.btDisplayMode.TabIndex = 5;
      this.btDisplayMode.Text = "x";
      this.btDisplayMode.UseVisualStyleBackColor = true;
      this.btDisplayMode.Click += new System.EventHandler(this.BtDisplayModeClick);
      // 
      // KeySearch
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.btDisplayMode);
      this.Controls.Add(this.lstKeys);
      this.Controls.Add(this.lblCountCle);
      this.Controls.Add(this.panel1);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "KeySearch";
      this.Size = new System.Drawing.Size(607, 523);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TextBox txtSearch;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TreeView lstKeys;
    private System.Windows.Forms.Button btSearch;
    private System.Windows.Forms.ComboBox cbFiltreType;
    private System.Windows.Forms.Label lblCountCle;
    private System.Windows.Forms.Panel panel3;
    public System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Button btDisplayMode;
  }
}
