namespace RedisManagementStudio.BLL.UI
{
  partial class FImportExport
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FImportExport));
      this.btCancel = new System.Windows.Forms.Button();
      this.btOk = new System.Windows.Forms.Button();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.lblTitre = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.pnlFolder = new System.Windows.Forms.Panel();
      this.tvParent = new System.Windows.Forms.TreeView();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.lblGroupe = new System.Windows.Forms.Label();
      this.pnlFile = new System.Windows.Forms.Panel();
      this.btBrowse = new System.Windows.Forms.Button();
      this.txtFileName = new System.Windows.Forms.TextBox();
      this.lblFile = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.pnlFolder.SuspendLayout();
      this.pnlFile.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // btCancel
      // 
      this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btCancel.Location = new System.Drawing.Point(471, 456);
      this.btCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(87, 30);
      this.btCancel.TabIndex = 0;
      this.btCancel.Text = "Annuler";
      this.btCancel.UseVisualStyleBackColor = true;
      // 
      // btOk
      // 
      this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btOk.Location = new System.Drawing.Point(377, 456);
      this.btOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btOk.Name = "btOk";
      this.btOk.Size = new System.Drawing.Size(87, 30);
      this.btOk.TabIndex = 1;
      this.btOk.Text = "&Ok";
      this.btOk.UseVisualStyleBackColor = true;
      this.btOk.Click += new System.EventHandler(this.BtOkClick);
      // 
      // groupBox2
      // 
      this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox2.Location = new System.Drawing.Point(14, 442);
      this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBox2.Size = new System.Drawing.Size(540, 7);
      this.groupBox2.TabIndex = 15;
      this.groupBox2.TabStop = false;
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Location = new System.Drawing.Point(14, 76);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBox1.Size = new System.Drawing.Size(540, 7);
      this.groupBox1.TabIndex = 14;
      this.groupBox1.TabStop = false;
      // 
      // lblTitre
      // 
      this.lblTitre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblTitre.Location = new System.Drawing.Point(58, 12);
      this.lblTitre.Name = "lblTitre";
      this.lblTitre.Size = new System.Drawing.Size(496, 60);
      this.lblTitre.TabIndex = 12;
      this.lblTitre.Text = "Importer ou exporter la configuration";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::RedisManagementStudio.Properties.Resources.Export_Import32;
      this.pictureBox1.Location = new System.Drawing.Point(14, 12);
      this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(44, 44);
      this.pictureBox1.TabIndex = 13;
      this.pictureBox1.TabStop = false;
      // 
      // pnlFolder
      // 
      this.pnlFolder.Controls.Add(this.tvParent);
      this.pnlFolder.Controls.Add(this.lblGroupe);
      this.pnlFolder.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlFolder.Location = new System.Drawing.Point(0, 0);
      this.pnlFolder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.pnlFolder.Name = "pnlFolder";
      this.pnlFolder.Size = new System.Drawing.Size(540, 261);
      this.pnlFolder.TabIndex = 18;
      // 
      // tvParent
      // 
      this.tvParent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tvParent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tvParent.HideSelection = false;
      this.tvParent.ImageIndex = 0;
      this.tvParent.ImageList = this.imageList1;
      this.tvParent.Location = new System.Drawing.Point(0, 42);
      this.tvParent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.tvParent.Name = "tvParent";
      this.tvParent.SelectedImageIndex = 0;
      this.tvParent.Size = new System.Drawing.Size(539, 210);
      this.tvParent.TabIndex = 19;
      this.tvParent.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvParentAfterSelect);
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
      // lblGroupe
      // 
      this.lblGroupe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblGroupe.Location = new System.Drawing.Point(-3, 0);
      this.lblGroupe.Name = "lblGroupe";
      this.lblGroupe.Size = new System.Drawing.Size(544, 38);
      this.lblGroupe.TabIndex = 18;
      this.lblGroupe.Text = "Sélectionnez l\'emplacement\r\nSur 2 lignes\r\n";
      // 
      // pnlFile
      // 
      this.pnlFile.Controls.Add(this.btBrowse);
      this.pnlFile.Controls.Add(this.txtFileName);
      this.pnlFile.Controls.Add(this.lblFile);
      this.pnlFile.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnlFile.Location = new System.Drawing.Point(0, 261);
      this.pnlFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.pnlFile.Name = "pnlFile";
      this.pnlFile.Size = new System.Drawing.Size(540, 80);
      this.pnlFile.TabIndex = 19;
      // 
      // btBrowse
      // 
      this.btBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btBrowse.Location = new System.Drawing.Point(503, 26);
      this.btBrowse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btBrowse.Name = "btBrowse";
      this.btBrowse.Size = new System.Drawing.Size(34, 25);
      this.btBrowse.TabIndex = 2;
      this.btBrowse.Text = "...";
      this.btBrowse.UseVisualStyleBackColor = true;
      this.btBrowse.Click += new System.EventHandler(this.BtBrowseClick);
      // 
      // txtFileName
      // 
      this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtFileName.Location = new System.Drawing.Point(0, 26);
      this.txtFileName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.txtFileName.Name = "txtFileName";
      this.txtFileName.Size = new System.Drawing.Size(495, 25);
      this.txtFileName.TabIndex = 1;
      this.txtFileName.TextChanged += new System.EventHandler(this.TxtFileNameTextChanged);
      // 
      // lblFile
      // 
      this.lblFile.AutoSize = true;
      this.lblFile.Location = new System.Drawing.Point(-3, 5);
      this.lblFile.Name = "lblFile";
      this.lblFile.Size = new System.Drawing.Size(52, 17);
      this.lblFile.TabIndex = 0;
      this.lblFile.Text = "Fichier :";
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.Controls.Add(this.pnlFolder);
      this.panel1.Controls.Add(this.pnlFile);
      this.panel1.Location = new System.Drawing.Point(14, 101);
      this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(540, 341);
      this.panel1.TabIndex = 20;
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.DefaultExt = "xml";
      this.openFileDialog1.Filter = "Fichiers XML|*.xml|Tous Fichiers|*.*";
      this.openFileDialog1.Title = "Fichier  d\'import";
      // 
      // saveFileDialog1
      // 
      this.saveFileDialog1.DefaultExt = "xml";
      this.saveFileDialog1.Filter = "Fichiers XML|*.xml|Tous fichiers|*.*";
      this.saveFileDialog1.Title = "Fichier d\'export";
      // 
      // FImportExport
      // 
      this.AcceptButton = this.btOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btCancel;
      this.ClientSize = new System.Drawing.Size(573, 502);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.lblTitre);
      this.Controls.Add(this.btOk);
      this.Controls.Add(this.btCancel);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(518, 474);
      this.Name = "FImportExport";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Export Import";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FImportExport_FormClosed);
      this.Load += new System.EventHandler(this.FImportExport_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.pnlFolder.ResumeLayout(false);
      this.pnlFile.ResumeLayout(false);
      this.pnlFile.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.Button btOk;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label lblTitre;
    private System.Windows.Forms.Panel pnlFolder;
    private System.Windows.Forms.TreeView tvParent;
    private System.Windows.Forms.Label lblGroupe;
    private System.Windows.Forms.Panel pnlFile;
    private System.Windows.Forms.Button btBrowse;
    private System.Windows.Forms.TextBox txtFileName;
    private System.Windows.Forms.Label lblFile;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
  }
}