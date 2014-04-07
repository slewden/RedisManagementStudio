namespace RedisManagementStudio
{
  partial class FManagement
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

    #region Code généré par le Concepteur Windows Form

    /// <summary>
    /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
    /// le contenu de cette méthode avec l'éditeur de code.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FManagement));
      this.treeView1 = new System.Windows.Forms.TreeView();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.mnuConnect = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuNewFolder = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuNewConnection = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuEmpty1 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuDel = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuEmpty2 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuExport = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuImport = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuEmpty3 = new System.Windows.Forms.ToolStripSeparator();
      this.mnuProperty = new System.Windows.Forms.ToolStripMenuItem();
      this.lblTitre = new System.Windows.Forms.Label();
      this.lblTips = new System.Windows.Forms.Label();
      this.btQuit = new System.Windows.Forms.Button();
      this.lblDetail = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.lblDetail2 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btConnect = new System.Windows.Forms.Button();
      this.btAddConnection = new System.Windows.Forms.Button();
      this.contextMenuStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // treeView1
      // 
      this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.treeView1.FullRowSelect = true;
      this.treeView1.HideSelection = false;
      this.treeView1.ImageIndex = 0;
      this.treeView1.ImageList = this.imageList1;
      this.treeView1.Location = new System.Drawing.Point(236, 113);
      this.treeView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.treeView1.Name = "treeView1";
      this.treeView1.SelectedImageIndex = 0;
      this.treeView1.ShowNodeToolTips = true;
      this.treeView1.ShowRootLines = false;
      this.treeView1.Size = new System.Drawing.Size(391, 243);
      this.treeView1.TabIndex = 1;
      this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1AfterSelect);
      this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView1NodeMouseClick);
      this.treeView1.DoubleClick += new System.EventHandler(this.TreeView1DoubleClick);
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "Folder");
      this.imageList1.Images.SetKeyName(1, "FolderSel");
      this.imageList1.Images.SetKeyName(2, "Connection");
      this.imageList1.Images.SetKeyName(3, "ConnectionSel");
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConnect,
            this.mnuNew,
            this.mnuEmpty1,
            this.mnuDel,
            this.mnuEmpty2,
            this.mnuExport,
            this.mnuImport,
            this.mnuEmpty3,
            this.mnuProperty});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(139, 154);
      this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1Opening);
      // 
      // mnuConnect
      // 
      this.mnuConnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
      this.mnuConnect.Name = "mnuConnect";
      this.mnuConnect.Size = new System.Drawing.Size(138, 22);
      this.mnuConnect.Text = "Connection";
      this.mnuConnect.Click += new System.EventHandler(this.MnuConnectClick);
      // 
      // mnuNew
      // 
      this.mnuNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewFolder,
            this.mnuNewConnection});
      this.mnuNew.Name = "mnuNew";
      this.mnuNew.Size = new System.Drawing.Size(138, 22);
      this.mnuNew.Text = "Nouveau";
      // 
      // mnuNewFolder
      // 
      this.mnuNewFolder.Name = "mnuNewFolder";
      this.mnuNewFolder.Size = new System.Drawing.Size(140, 22);
      this.mnuNewFolder.Text = "Groupe...";
      this.mnuNewFolder.Click += new System.EventHandler(this.MnuNewFolderClick);
      // 
      // mnuNewConnection
      // 
      this.mnuNewConnection.Name = "mnuNewConnection";
      this.mnuNewConnection.Size = new System.Drawing.Size(140, 22);
      this.mnuNewConnection.Text = "Connexion...";
      this.mnuNewConnection.Click += new System.EventHandler(this.MnuNewConnectionClick);
      // 
      // mnuEmpty1
      // 
      this.mnuEmpty1.Name = "mnuEmpty1";
      this.mnuEmpty1.Size = new System.Drawing.Size(135, 6);
      // 
      // mnuDel
      // 
      this.mnuDel.Name = "mnuDel";
      this.mnuDel.Size = new System.Drawing.Size(138, 22);
      this.mnuDel.Text = "Supprimer...";
      this.mnuDel.Click += new System.EventHandler(this.MnuDelClick);
      // 
      // mnuEmpty2
      // 
      this.mnuEmpty2.Name = "mnuEmpty2";
      this.mnuEmpty2.Size = new System.Drawing.Size(135, 6);
      // 
      // mnuExport
      // 
      this.mnuExport.Name = "mnuExport";
      this.mnuExport.Size = new System.Drawing.Size(138, 22);
      this.mnuExport.Text = "Exporter...";
      this.mnuExport.Click += new System.EventHandler(this.MnuExportClick);
      // 
      // mnuImport
      // 
      this.mnuImport.Name = "mnuImport";
      this.mnuImport.Size = new System.Drawing.Size(138, 22);
      this.mnuImport.Text = "Importer...";
      this.mnuImport.Click += new System.EventHandler(this.MnuImportClick);
      // 
      // mnuEmpty3
      // 
      this.mnuEmpty3.Name = "mnuEmpty3";
      this.mnuEmpty3.Size = new System.Drawing.Size(135, 6);
      // 
      // mnuProperty
      // 
      this.mnuProperty.Name = "mnuProperty";
      this.mnuProperty.Size = new System.Drawing.Size(138, 22);
      this.mnuProperty.Text = "Propriétés...";
      this.mnuProperty.Click += new System.EventHandler(this.MnuPropertyClick);
      // 
      // lblTitre
      // 
      this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblTitre.Location = new System.Drawing.Point(10, 9);
      this.lblTitre.Name = "lblTitre";
      this.lblTitre.Size = new System.Drawing.Size(534, 30);
      this.lblTitre.TabIndex = 3;
      this.lblTitre.Text = "Redis Managment studio : Explorateur de serveurs Redis";
      // 
      // lblTips
      // 
      this.lblTips.ForeColor = System.Drawing.Color.Gray;
      this.lblTips.Location = new System.Drawing.Point(12, 93);
      this.lblTips.Name = "lblTips";
      this.lblTips.Size = new System.Drawing.Size(369, 17);
      this.lblTips.TabIndex = 4;
      this.lblTips.Text = "Sélectionnez un serveur ou définissez une nouvelle connection";
      // 
      // btQuit
      // 
      this.btQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btQuit.ForeColor = System.Drawing.SystemColors.ControlText;
      this.btQuit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btQuit.Location = new System.Drawing.Point(15, 328);
      this.btQuit.Name = "btQuit";
      this.btQuit.Size = new System.Drawing.Size(217, 28);
      this.btQuit.TabIndex = 7;
      this.btQuit.Text = "Quitter";
      this.btQuit.UseVisualStyleBackColor = true;
      this.btQuit.Click += new System.EventHandler(this.BtQuitClick);
      // 
      // lblDetail
      // 
      this.lblDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblDetail.AutoEllipsis = true;
      this.lblDetail.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblDetail.ForeColor = System.Drawing.Color.RoyalBlue;
      this.lblDetail.Location = new System.Drawing.Point(-1, 31);
      this.lblDetail.Name = "lblDetail";
      this.lblDetail.Size = new System.Drawing.Size(218, 30);
      this.lblDetail.TabIndex = 8;
      this.lblDetail.Text = "label3";
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.lblDetail2);
      this.panel1.Controls.Add(this.lblDetail);
      this.panel1.Location = new System.Drawing.Point(15, 138);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(217, 170);
      this.panel1.TabIndex = 9;
      this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1Paint);
      // 
      // lblDetail2
      // 
      this.lblDetail2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblDetail2.ForeColor = System.Drawing.Color.SteelBlue;
      this.lblDetail2.Location = new System.Drawing.Point(1, 73);
      this.lblDetail2.Name = "lblDetail2";
      this.lblDetail2.Size = new System.Drawing.Size(216, 80);
      this.lblDetail2.TabIndex = 9;
      this.lblDetail2.Text = "label3";
      // 
      // panel2
      // 
      this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel2.Controls.Add(this.lblTitre);
      this.panel2.Controls.Add(this.lblTips);
      this.panel2.Location = new System.Drawing.Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(637, 109);
      this.panel2.TabIndex = 11;
      this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel2Paint);
      // 
      // btConnect
      // 
      this.btConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btConnect.ForeColor = System.Drawing.SystemColors.ControlText;
      this.btConnect.Image = global::RedisManagementStudio.Properties.Resources.Redis16;
      this.btConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btConnect.Location = new System.Drawing.Point(15, 294);
      this.btConnect.Name = "btConnect";
      this.btConnect.Size = new System.Drawing.Size(217, 28);
      this.btConnect.TabIndex = 6;
      this.btConnect.Text = "Connexion à la base...";
      this.btConnect.UseVisualStyleBackColor = true;
      this.btConnect.Click += new System.EventHandler(this.MnuConnectClick);
      // 
      // btAddConnection
      // 
      this.btAddConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btAddConnection.ForeColor = System.Drawing.SystemColors.ControlText;
      this.btAddConnection.Image = global::RedisManagementStudio.Properties.Resources.Add;
      this.btAddConnection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btAddConnection.Location = new System.Drawing.Point(15, 113);
      this.btAddConnection.Name = "btAddConnection";
      this.btAddConnection.Size = new System.Drawing.Size(217, 28);
      this.btAddConnection.TabIndex = 5;
      this.btAddConnection.Text = "Nouvelle connexion ...";
      this.btAddConnection.UseVisualStyleBackColor = true;
      this.btAddConnection.Click += new System.EventHandler(this.MnuNewConnectionClick);
      // 
      // FManagement
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(641, 374);
      this.Controls.Add(this.btConnect);
      this.Controls.Add(this.btQuit);
      this.Controls.Add(this.btAddConnection);
      this.Controls.Add(this.treeView1);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.panel2);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(657, 649);
      this.MinimumSize = new System.Drawing.Size(566, 410);
      this.Name = "FManagement";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Redis Managment Studio";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FManagement_FormClosed);
      this.Load += new System.EventHandler(this.FManagement_Load);
      this.contextMenuStrip1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TreeView treeView1;
    private System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem mnuConnect;
    private System.Windows.Forms.ToolStripMenuItem mnuNew;
    private System.Windows.Forms.ToolStripMenuItem mnuNewFolder;
    private System.Windows.Forms.ToolStripMenuItem mnuNewConnection;
    private System.Windows.Forms.ToolStripSeparator mnuEmpty1;
    private System.Windows.Forms.ToolStripMenuItem mnuDel;
    private System.Windows.Forms.ToolStripMenuItem mnuExport;
    private System.Windows.Forms.ToolStripMenuItem mnuImport;
    private System.Windows.Forms.ToolStripSeparator mnuEmpty3;
    private System.Windows.Forms.ToolStripMenuItem mnuProperty;
    private System.Windows.Forms.ToolStripSeparator mnuEmpty2;
    private System.Windows.Forms.Label lblTitre;
    private System.Windows.Forms.Label lblTips;
    private System.Windows.Forms.Button btAddConnection;
    private System.Windows.Forms.Button btConnect;
    private System.Windows.Forms.Button btQuit;
    private System.Windows.Forms.Label lblDetail;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label lblDetail2;
    private System.Windows.Forms.Panel panel2;
  }
}

