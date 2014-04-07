namespace RedisManagementStudio.BLL.Redis.Keys
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
      this.panel2 = new System.Windows.Forms.Panel();
      this.txtTitre = new System.Windows.Forms.TextBox();
      this.btRename = new System.Windows.Forms.Button();
      this.lblPoids = new System.Windows.Forms.Label();
      this.lblTitre = new System.Windows.Forms.Label();
      this.btSizeOf = new System.Windows.Forms.Button();
      this.btAddKey = new System.Windows.Forms.Button();
      this.btDelKey = new System.Windows.Forms.Button();
      this.pnlDefault = new System.Windows.Forms.Panel();
      this.lblValue = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.pnlDetail = new System.Windows.Forms.Panel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.pnlDefineTTL = new System.Windows.Forms.Panel();
      this.btCancelEditTTL = new System.Windows.Forms.Button();
      this.panel5 = new System.Windows.Forms.Panel();
      this.numTTL = new System.Windows.Forms.NumericUpDown();
      this.cbTTL = new System.Windows.Forms.ComboBox();
      this.btClearTTL = new System.Windows.Forms.Button();
      this.btSetTTL = new System.Windows.Forms.Button();
      this.btEditTTL = new System.Windows.Forms.Button();
      this.label5 = new System.Windows.Forms.Label();
      this.lblTTL = new System.Windows.Forms.Label();
      this.imgType = new System.Windows.Forms.PictureBox();
      this.lblTypeCle = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.panel3 = new System.Windows.Forms.Panel();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.imageList2 = new System.Windows.Forms.ImageList(this.components);
      this.editTypeText1 = new RedisManagementStudio.BLL.Redis.Keys.EditTypeText();
      this.editTypeZSet1 = new RedisManagementStudio.BLL.Redis.Keys.EditTypeZSet();
      this.editTypeHash1 = new RedisManagementStudio.BLL.Redis.Keys.EditTypeHash();
      this.editTypeSet1 = new RedisManagementStudio.BLL.Redis.Keys.EditTypeSet();
      this.editTypeList1 = new RedisManagementStudio.BLL.Redis.Keys.EditTypeList();
      this.panel2.SuspendLayout();
      this.pnlDefault.SuspendLayout();
      this.pnlDetail.SuspendLayout();
      this.panel1.SuspendLayout();
      this.pnlDefineTTL.SuspendLayout();
      this.panel5.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numTTL)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.imgType)).BeginInit();
      this.SuspendLayout();
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btRename);
      this.panel2.Controls.Add(this.lblPoids);
      this.panel2.Controls.Add(this.btSizeOf);
      this.panel2.Controls.Add(this.btAddKey);
      this.panel2.Controls.Add(this.btDelKey);
      this.panel2.Controls.Add(this.txtTitre);
      this.panel2.Controls.Add(this.lblTitre);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(0, 0);
      this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(879, 40);
      this.panel2.TabIndex = 5;
      // 
      // txtTitre
      // 
      this.txtTitre.BackColor = System.Drawing.SystemColors.Control;
      this.txtTitre.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtTitre.Font = new System.Drawing.Font("Segoe UI", 14.25F);
      this.txtTitre.Location = new System.Drawing.Point(176, 8);
      this.txtTitre.Name = "txtTitre";
      this.txtTitre.ReadOnly = true;
      this.txtTitre.Size = new System.Drawing.Size(363, 26);
      this.txtTitre.TabIndex = 43;
      // 
      // btRename
      // 
      this.btRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btRename.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btRename.Image = global::RedisManagementStudio.Properties.Resources.Rename;
      this.btRename.Location = new System.Drawing.Point(793, 8);
      this.btRename.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btRename.Name = "btRename";
      this.btRename.Size = new System.Drawing.Size(25, 25);
      this.btRename.TabIndex = 42;
      this.toolTip1.SetToolTip(this.btRename, "Renommer la clé");
      this.btRename.UseVisualStyleBackColor = true;
      this.btRename.Click += new System.EventHandler(this.BtRenameClick);
      // 
      // lblPoids
      // 
      this.lblPoids.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblPoids.Location = new System.Drawing.Point(662, 10);
      this.lblPoids.Name = "lblPoids";
      this.lblPoids.Size = new System.Drawing.Size(94, 25);
      this.lblPoids.TabIndex = 41;
      this.lblPoids.Text = "xxx";
      this.lblPoids.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // lblTitre
      // 
      this.lblTitre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblTitre.BackColor = System.Drawing.SystemColors.Control;
      this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 14.25F);
      this.lblTitre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.lblTitre.Location = new System.Drawing.Point(0, 0);
      this.lblTitre.Name = "lblTitre";
      this.lblTitre.Size = new System.Drawing.Size(179, 40);
      this.lblTitre.TabIndex = 29;
      this.lblTitre.Text = "Explorateur de clés";
      this.lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btSizeOf
      // 
      this.btSizeOf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btSizeOf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btSizeOf.Image = global::RedisManagementStudio.Properties.Resources.weight16;
      this.btSizeOf.Location = new System.Drawing.Point(762, 8);
      this.btSizeOf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btSizeOf.Name = "btSizeOf";
      this.btSizeOf.Size = new System.Drawing.Size(25, 25);
      this.btSizeOf.TabIndex = 36;
      this.btSizeOf.UseVisualStyleBackColor = true;
      this.btSizeOf.Click += new System.EventHandler(this.BtSizeOfClick);
      // 
      // btAddKey
      // 
      this.btAddKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btAddKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btAddKey.Image = global::RedisManagementStudio.Properties.Resources.Add;
      this.btAddKey.Location = new System.Drawing.Point(854, 8);
      this.btAddKey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btAddKey.Name = "btAddKey";
      this.btAddKey.Size = new System.Drawing.Size(25, 25);
      this.btAddKey.TabIndex = 35;
      this.btAddKey.UseVisualStyleBackColor = true;
      this.btAddKey.Click += new System.EventHandler(this.BtAddKeyClick);
      // 
      // btDelKey
      // 
      this.btDelKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btDelKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btDelKey.Image = global::RedisManagementStudio.Properties.Resources.Delete12;
      this.btDelKey.Location = new System.Drawing.Point(824, 8);
      this.btDelKey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btDelKey.Name = "btDelKey";
      this.btDelKey.Size = new System.Drawing.Size(25, 25);
      this.btDelKey.TabIndex = 34;
      this.btDelKey.UseVisualStyleBackColor = true;
      this.btDelKey.Click += new System.EventHandler(this.BtDelKeyClick);
      // 
      // pnlDefault
      // 
      this.pnlDefault.Controls.Add(this.lblValue);
      this.pnlDefault.Controls.Add(this.label3);
      this.pnlDefault.Location = new System.Drawing.Point(19, 298);
      this.pnlDefault.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.pnlDefault.Name = "pnlDefault";
      this.pnlDefault.Size = new System.Drawing.Size(160, 76);
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
      // pnlDetail
      // 
      this.pnlDetail.Controls.Add(this.panel1);
      this.pnlDetail.Controls.Add(this.imgType);
      this.pnlDetail.Controls.Add(this.lblTypeCle);
      this.pnlDetail.Controls.Add(this.label2);
      this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlDetail.Location = new System.Drawing.Point(0, 40);
      this.pnlDetail.Name = "pnlDetail";
      this.pnlDetail.Size = new System.Drawing.Size(879, 46);
      this.pnlDetail.TabIndex = 41;
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.BackColor = System.Drawing.Color.White;
      this.panel1.Controls.Add(this.pnlDefineTTL);
      this.panel1.Controls.Add(this.btEditTTL);
      this.panel1.Controls.Add(this.label5);
      this.panel1.Controls.Add(this.lblTTL);
      this.panel1.Location = new System.Drawing.Point(434, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(445, 35);
      this.panel1.TabIndex = 35;
      // 
      // pnlDefineTTL
      // 
      this.pnlDefineTTL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.pnlDefineTTL.BackColor = System.Drawing.Color.White;
      this.pnlDefineTTL.Controls.Add(this.btCancelEditTTL);
      this.pnlDefineTTL.Controls.Add(this.panel5);
      this.pnlDefineTTL.Controls.Add(this.btClearTTL);
      this.pnlDefineTTL.Controls.Add(this.btSetTTL);
      this.pnlDefineTTL.Location = new System.Drawing.Point(217, 0);
      this.pnlDefineTTL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.pnlDefineTTL.Name = "pnlDefineTTL";
      this.pnlDefineTTL.Size = new System.Drawing.Size(228, 35);
      this.pnlDefineTTL.TabIndex = 32;
      this.pnlDefineTTL.Visible = false;
      // 
      // btCancelEditTTL
      // 
      this.btCancelEditTTL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btCancelEditTTL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btCancelEditTTL.Image = global::RedisManagementStudio.Properties.Resources.Cancel;
      this.btCancelEditTTL.Location = new System.Drawing.Point(203, 4);
      this.btCancelEditTTL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btCancelEditTTL.Name = "btCancelEditTTL";
      this.btCancelEditTTL.Size = new System.Drawing.Size(25, 25);
      this.btCancelEditTTL.TabIndex = 35;
      this.btCancelEditTTL.UseVisualStyleBackColor = true;
      this.btCancelEditTTL.Click += new System.EventHandler(this.BtCancelEditTTLClick);
      // 
      // panel5
      // 
      this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel5.Controls.Add(this.numTTL);
      this.panel5.Controls.Add(this.cbTTL);
      this.panel5.Location = new System.Drawing.Point(0, 4);
      this.panel5.Name = "panel5";
      this.panel5.Size = new System.Drawing.Size(137, 25);
      this.panel5.TabIndex = 34;
      // 
      // numTTL
      // 
      this.numTTL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.numTTL.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.numTTL.Location = new System.Drawing.Point(2, 2);
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
      // cbTTL
      // 
      this.cbTTL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cbTTL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbTTL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cbTTL.FormattingEnabled = true;
      this.cbTTL.Location = new System.Drawing.Point(47, 0);
      this.cbTTL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.cbTTL.Name = "cbTTL";
      this.cbTTL.Size = new System.Drawing.Size(89, 25);
      this.cbTTL.TabIndex = 31;
      // 
      // btClearTTL
      // 
      this.btClearTTL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btClearTTL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btClearTTL.Image = global::RedisManagementStudio.Properties.Resources.Delete12;
      this.btClearTTL.Location = new System.Drawing.Point(143, 4);
      this.btClearTTL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btClearTTL.Name = "btClearTTL";
      this.btClearTTL.Size = new System.Drawing.Size(25, 25);
      this.btClearTTL.TabIndex = 33;
      this.btClearTTL.UseVisualStyleBackColor = true;
      this.btClearTTL.Click += new System.EventHandler(this.BtClearTTLClick);
      // 
      // btSetTTL
      // 
      this.btSetTTL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btSetTTL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btSetTTL.Image = global::RedisManagementStudio.Properties.Resources.Save;
      this.btSetTTL.Location = new System.Drawing.Point(173, 4);
      this.btSetTTL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btSetTTL.Name = "btSetTTL";
      this.btSetTTL.Size = new System.Drawing.Size(25, 25);
      this.btSetTTL.TabIndex = 29;
      this.btSetTTL.UseVisualStyleBackColor = true;
      this.btSetTTL.Click += new System.EventHandler(this.BtSetTTLClick);
      // 
      // btEditTTL
      // 
      this.btEditTTL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btEditTTL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btEditTTL.Image = global::RedisManagementStudio.Properties.Resources.Edit;
      this.btEditTTL.Location = new System.Drawing.Point(420, 4);
      this.btEditTTL.Name = "btEditTTL";
      this.btEditTTL.Size = new System.Drawing.Size(25, 25);
      this.btEditTTL.TabIndex = 33;
      this.btEditTTL.UseVisualStyleBackColor = true;
      this.btEditTTL.Click += new System.EventHandler(this.BtEditTTLClick);
      // 
      // label5
      // 
      this.label5.Location = new System.Drawing.Point(3, -1);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(89, 35);
      this.label5.TabIndex = 4;
      this.label5.Text = "Durée de vie :";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lblTTL
      // 
      this.lblTTL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblTTL.AutoEllipsis = true;
      this.lblTTL.Location = new System.Drawing.Point(98, -1);
      this.lblTTL.Name = "lblTTL";
      this.lblTTL.Size = new System.Drawing.Size(316, 35);
      this.lblTTL.TabIndex = 5;
      this.lblTTL.Text = "xxx";
      this.lblTTL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // imgType
      // 
      this.imgType.BackColor = System.Drawing.SystemColors.Control;
      this.imgType.Location = new System.Drawing.Point(104, 3);
      this.imgType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.imgType.Name = "imgType";
      this.imgType.Size = new System.Drawing.Size(32, 32);
      this.imgType.TabIndex = 34;
      this.imgType.TabStop = false;
      // 
      // lblTypeCle
      // 
      this.lblTypeCle.AutoSize = true;
      this.lblTypeCle.Location = new System.Drawing.Point(142, 18);
      this.lblTypeCle.Name = "lblTypeCle";
      this.lblTypeCle.Size = new System.Drawing.Size(26, 17);
      this.lblTypeCle.TabIndex = 1;
      this.lblTypeCle.Text = "???";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(16, 18);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(82, 17);
      this.label2.TabIndex = 0;
      this.label2.Text = "Type de clé :";
      // 
      // panel3
      // 
      this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
      this.panel3.Location = new System.Drawing.Point(879, 0);
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
      // editTypeText1
      // 
      this.editTypeText1.Connection = null;
      this.editTypeText1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.editTypeText1.Key = "";
      this.editTypeText1.Location = new System.Drawing.Point(239, 238);
      this.editTypeText1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.editTypeText1.Name = "editTypeText1";
      this.editTypeText1.Size = new System.Drawing.Size(161, 125);
      this.editTypeText1.TabIndex = 39;
      this.editTypeText1.OnChange += new System.EventHandler(this.EditTypeOnChange);
      // 
      // editTypeZSet1
      // 
      this.editTypeZSet1.Connection = null;
      this.editTypeZSet1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.editTypeZSet1.Key = "";
      this.editTypeZSet1.Location = new System.Drawing.Point(319, 298);
      this.editTypeZSet1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.editTypeZSet1.Name = "editTypeZSet1";
      this.editTypeZSet1.Size = new System.Drawing.Size(182, 99);
      this.editTypeZSet1.TabIndex = 40;
      this.editTypeZSet1.OnChange += new System.EventHandler(this.EditTypeOnChange);
      // 
      // editTypeHash1
      // 
      this.editTypeHash1.Connection = null;
      this.editTypeHash1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.editTypeHash1.Key = "";
      this.editTypeHash1.Location = new System.Drawing.Point(26, 197);
      this.editTypeHash1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.editTypeHash1.Name = "editTypeHash1";
      this.editTypeHash1.Size = new System.Drawing.Size(287, 173);
      this.editTypeHash1.TabIndex = 37;
      this.editTypeHash1.OnChange += new System.EventHandler(this.EditTypeOnChange);
      // 
      // editTypeSet1
      // 
      this.editTypeSet1.Connection = null;
      this.editTypeSet1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.editTypeSet1.Key = "";
      this.editTypeSet1.Location = new System.Drawing.Point(392, 204);
      this.editTypeSet1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.editTypeSet1.Name = "editTypeSet1";
      this.editTypeSet1.Size = new System.Drawing.Size(124, 86);
      this.editTypeSet1.TabIndex = 35;
      this.editTypeSet1.OnChange += new System.EventHandler(this.EditTypeOnChange);
      // 
      // editTypeList1
      // 
      this.editTypeList1.Connection = null;
      this.editTypeList1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.editTypeList1.Key = "";
      this.editTypeList1.Location = new System.Drawing.Point(557, 209);
      this.editTypeList1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.editTypeList1.Name = "editTypeList1";
      this.editTypeList1.Size = new System.Drawing.Size(193, 138);
      this.editTypeList1.TabIndex = 38;
      this.editTypeList1.OnChange += new System.EventHandler(this.EditTypeOnChange);
      // 
      // KeysExplorer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.pnlDefault);
      this.Controls.Add(this.editTypeText1);
      this.Controls.Add(this.editTypeZSet1);
      this.Controls.Add(this.editTypeHash1);
      this.Controls.Add(this.editTypeSet1);
      this.Controls.Add(this.editTypeList1);
      this.Controls.Add(this.pnlDetail);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel3);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "KeysExplorer";
      this.Size = new System.Drawing.Size(889, 391);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.pnlDefault.ResumeLayout(false);
      this.pnlDefault.PerformLayout();
      this.pnlDetail.ResumeLayout(false);
      this.pnlDetail.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.pnlDefineTTL.ResumeLayout(false);
      this.panel5.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.numTTL)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.imgType)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblValue;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label lblTypeCle;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label lblTTL;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Button btClearTTL;
    private System.Windows.Forms.Panel pnlDefineTTL;
    private System.Windows.Forms.Button btSetTTL;
    private System.Windows.Forms.ComboBox cbTTL;
    private System.Windows.Forms.NumericUpDown numTTL;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.ImageList imageList1;
    private EditTypeSet editTypeSet1;
    private System.Windows.Forms.Panel pnlDefault;
    private System.Windows.Forms.Label lblTitre;
    private EditTypeHash editTypeHash1;
    private EditTypeList editTypeList1;
    private EditTypeText editTypeText1;
    private System.Windows.Forms.ImageList imageList2;
    private System.Windows.Forms.PictureBox imgType;
    private EditTypeZSet editTypeZSet1;
    private System.Windows.Forms.Panel pnlDetail;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Button btEditTTL;
    private System.Windows.Forms.Panel panel5;
    private System.Windows.Forms.Button btCancelEditTTL;
    private System.Windows.Forms.Button btAddKey;
    private System.Windows.Forms.Button btDelKey;
    private System.Windows.Forms.Button btSizeOf;
    private System.Windows.Forms.Label lblPoids;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btRename;
    private System.Windows.Forms.TextBox txtTitre;
  }
}
