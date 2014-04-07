namespace RedisManagementStudio.BLL.Redis.Monitor
{
  partial class PubSubConsole
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PubSubConsole));
      this.pnlToolAbonnement = new System.Windows.Forms.Panel();
      this.btSave = new System.Windows.Forms.Button();
      this.btSaveSelection = new System.Windows.Forms.Button();
      this.txtSubChanel = new System.Windows.Forms.TextBox();
      this.btClear = new System.Windows.Forms.Button();
      this.btStop = new System.Windows.Forms.Button();
      this.btStart = new System.Windows.Forms.Button();
      this.lblTitre = new System.Windows.Forms.Label();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.lstMessage = new System.Windows.Forms.ListView();
      this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colAction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colPattern = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colChanel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.lblPublishStatut = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.btPublish = new System.Windows.Forms.Button();
      this.txtPubMessage = new System.Windows.Forms.TextBox();
      this.txtPubChanel = new System.Windows.Forms.TextBox();
      this.lblPubMessage = new System.Windows.Forms.Label();
      this.lblPubChanel = new System.Windows.Forms.Label();
      this.pnlInfos = new System.Windows.Forms.Panel();
      this.label3 = new System.Windows.Forms.LinkLabel();
      this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
      this.pnlToolAbonnement.SuspendLayout();
      this.pnlInfos.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlToolAbonnement
      // 
      this.pnlToolAbonnement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.pnlToolAbonnement.Controls.Add(this.btSave);
      this.pnlToolAbonnement.Controls.Add(this.btSaveSelection);
      this.pnlToolAbonnement.Controls.Add(this.txtSubChanel);
      this.pnlToolAbonnement.Controls.Add(this.btClear);
      this.pnlToolAbonnement.Controls.Add(this.btStop);
      this.pnlToolAbonnement.Controls.Add(this.btStart);
      this.pnlToolAbonnement.Location = new System.Drawing.Point(360, 0);
      this.pnlToolAbonnement.Name = "pnlToolAbonnement";
      this.pnlToolAbonnement.Size = new System.Drawing.Size(262, 40);
      this.pnlToolAbonnement.TabIndex = 0;
      // 
      // btSave
      // 
      this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btSave.Image = global::RedisManagementStudio.Properties.Resources.Save;
      this.btSave.Location = new System.Drawing.Point(4, 9);
      this.btSave.Name = "btSave";
      this.btSave.Size = new System.Drawing.Size(25, 25);
      this.btSave.TabIndex = 11;
      this.btSave.UseVisualStyleBackColor = true;
      this.btSave.Click += new System.EventHandler(this.BtSaveClick);
      // 
      // btSaveSelection
      // 
      this.btSaveSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btSaveSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btSaveSelection.Image = global::RedisManagementStudio.Properties.Resources.saveSelection;
      this.btSaveSelection.Location = new System.Drawing.Point(35, 9);
      this.btSaveSelection.Name = "btSaveSelection";
      this.btSaveSelection.Size = new System.Drawing.Size(25, 25);
      this.btSaveSelection.TabIndex = 10;
      this.btSaveSelection.UseVisualStyleBackColor = true;
      this.btSaveSelection.Click += new System.EventHandler(this.BtSaveSelectionClick);
      // 
      // txtSubChanel
      // 
      this.txtSubChanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.txtSubChanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtSubChanel.Location = new System.Drawing.Point(97, 9);
      this.txtSubChanel.Name = "txtSubChanel";
      this.txtSubChanel.Size = new System.Drawing.Size(100, 25);
      this.txtSubChanel.TabIndex = 9;
      this.txtSubChanel.TextChanged += new System.EventHandler(this.TxtSubChanelTextChanged);
      // 
      // btClear
      // 
      this.btClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btClear.Image = ((System.Drawing.Image)(resources.GetObject("btClear.Image")));
      this.btClear.Location = new System.Drawing.Point(66, 9);
      this.btClear.Name = "btClear";
      this.btClear.Size = new System.Drawing.Size(25, 25);
      this.btClear.TabIndex = 8;
      this.btClear.UseVisualStyleBackColor = true;
      this.btClear.Click += new System.EventHandler(this.BtClearClick);
      // 
      // btStop
      // 
      this.btStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btStop.Image = ((System.Drawing.Image)(resources.GetObject("btStop.Image")));
      this.btStop.Location = new System.Drawing.Point(234, 9);
      this.btStop.Name = "btStop";
      this.btStop.Size = new System.Drawing.Size(25, 25);
      this.btStop.TabIndex = 7;
      this.btStop.UseVisualStyleBackColor = true;
      this.btStop.Click += new System.EventHandler(this.BtStopClick);
      // 
      // btStart
      // 
      this.btStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btStart.Image = ((System.Drawing.Image)(resources.GetObject("btStart.Image")));
      this.btStart.Location = new System.Drawing.Point(203, 9);
      this.btStart.Name = "btStart";
      this.btStart.Size = new System.Drawing.Size(25, 25);
      this.btStart.TabIndex = 6;
      this.btStart.UseVisualStyleBackColor = true;
      this.btStart.Click += new System.EventHandler(this.BtStartClick);
      // 
      // lblTitre
      // 
      this.lblTitre.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 14.25F);
      this.lblTitre.Location = new System.Drawing.Point(0, 0);
      this.lblTitre.Name = "lblTitre";
      this.lblTitre.Size = new System.Drawing.Size(622, 40);
      this.lblTitre.TabIndex = 1;
      this.lblTitre.Text = "Publication de message / Inscriptions";
      this.lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lstMessage
      // 
      this.lstMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lstMessage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colAction,
            this.colPattern,
            this.colChanel,
            this.colMessage});
      this.lstMessage.FullRowSelect = true;
      this.lstMessage.GridLines = true;
      this.lstMessage.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.lstMessage.HideSelection = false;
      this.lstMessage.LabelWrap = false;
      this.lstMessage.Location = new System.Drawing.Point(172, 60);
      this.lstMessage.Name = "lstMessage";
      this.lstMessage.Size = new System.Drawing.Size(416, 230);
      this.lstMessage.TabIndex = 2;
      this.lstMessage.UseCompatibleStateImageBehavior = false;
      this.lstMessage.View = System.Windows.Forms.View.Details;
      this.lstMessage.SelectedIndexChanged += new System.EventHandler(this.LstMessageSelectedIndexChanged);
      // 
      // colDate
      // 
      this.colDate.Text = "Date";
      this.colDate.Width = 120;
      // 
      // colAction
      // 
      this.colAction.Text = "Action";
      this.colAction.Width = 100;
      // 
      // colPattern
      // 
      this.colPattern.Text = "Pattern";
      this.colPattern.Width = 100;
      // 
      // colChanel
      // 
      this.colChanel.Text = "Canal";
      this.colChanel.Width = 100;
      // 
      // colMessage
      // 
      this.colMessage.Text = "Message";
      this.colMessage.Width = 300;
      // 
      // lblPublishStatut
      // 
      this.lblPublishStatut.Location = new System.Drawing.Point(127, 181);
      this.lblPublishStatut.Name = "lblPublishStatut";
      this.lblPublishStatut.Size = new System.Drawing.Size(399, 71);
      this.lblPublishStatut.TabIndex = 9;
      this.lblPublishStatut.Text = "xx";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(254, 17);
      this.label1.TabIndex = 8;
      this.label1.Text = "Diffusion d\'un message sur un canal Redis";
      // 
      // btPublish
      // 
      this.btPublish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btPublish.Location = new System.Drawing.Point(130, 144);
      this.btPublish.Name = "btPublish";
      this.btPublish.Size = new System.Drawing.Size(89, 25);
      this.btPublish.TabIndex = 7;
      this.btPublish.Text = "Diffuser";
      this.btPublish.UseVisualStyleBackColor = true;
      this.btPublish.Click += new System.EventHandler(this.BtPublishClick);
      // 
      // txtPubMessage
      // 
      this.txtPubMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtPubMessage.Location = new System.Drawing.Point(130, 97);
      this.txtPubMessage.Name = "txtPubMessage";
      this.txtPubMessage.Size = new System.Drawing.Size(396, 25);
      this.txtPubMessage.TabIndex = 3;
      this.txtPubMessage.TextChanged += new System.EventHandler(this.TxtPubTextChanged);
      this.txtPubMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPubMessageKeyPress);
      // 
      // txtPubChanel
      // 
      this.txtPubChanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtPubChanel.Location = new System.Drawing.Point(130, 51);
      this.txtPubChanel.Name = "txtPubChanel";
      this.txtPubChanel.Size = new System.Drawing.Size(396, 25);
      this.txtPubChanel.TabIndex = 2;
      this.txtPubChanel.TextChanged += new System.EventHandler(this.TxtPubTextChanged);
      // 
      // lblPubMessage
      // 
      this.lblPubMessage.AutoSize = true;
      this.lblPubMessage.Location = new System.Drawing.Point(48, 99);
      this.lblPubMessage.Name = "lblPubMessage";
      this.lblPubMessage.Size = new System.Drawing.Size(68, 17);
      this.lblPubMessage.TabIndex = 1;
      this.lblPubMessage.Text = "Message :";
      // 
      // lblPubChanel
      // 
      this.lblPubChanel.AutoSize = true;
      this.lblPubChanel.Location = new System.Drawing.Point(48, 53);
      this.lblPubChanel.Name = "lblPubChanel";
      this.lblPubChanel.Size = new System.Drawing.Size(47, 17);
      this.lblPubChanel.TabIndex = 0;
      this.lblPubChanel.Text = "Canal :";
      // 
      // pnlInfos
      // 
      this.pnlInfos.Controls.Add(this.label3);
      this.pnlInfos.Controls.Add(this.lblPublishStatut);
      this.pnlInfos.Controls.Add(this.label1);
      this.pnlInfos.Controls.Add(this.btPublish);
      this.pnlInfos.Controls.Add(this.txtPubMessage);
      this.pnlInfos.Controls.Add(this.lblPubChanel);
      this.pnlInfos.Controls.Add(this.txtPubChanel);
      this.pnlInfos.Controls.Add(this.lblPubMessage);
      this.pnlInfos.Location = new System.Drawing.Point(21, 57);
      this.pnlInfos.Name = "pnlInfos";
      this.pnlInfos.Size = new System.Drawing.Size(567, 327);
      this.pnlInfos.TabIndex = 8;
      // 
      // label3
      // 
      this.label3.LinkArea = new System.Windows.Forms.LinkArea(0, 5);
      this.label3.Location = new System.Drawing.Point(13, 253);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(513, 65);
      this.label3.TabIndex = 10;
      this.label3.TabStop = true;
      this.label3.Text = "xxx jkdfqd jklja klja jfkl";
      this.label3.UseCompatibleTextRendering = true;
      this.label3.VisitedLinkColor = System.Drawing.Color.Blue;
      this.label3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Label3LinkClicked);
      // 
      // saveFileDialog1
      // 
      this.saveFileDialog1.DefaultExt = "csv";
      this.saveFileDialog1.Filter = "Fichier Trace (*.csv)|*.csv|Tous fichiers|*.*";
      this.saveFileDialog1.Title = "Enregistrer la trace";
      // 
      // PubSubConsole
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.pnlInfos);
      this.Controls.Add(this.lstMessage);
      this.Controls.Add(this.pnlToolAbonnement);
      this.Controls.Add(this.lblTitre);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "PubSubConsole";
      this.Size = new System.Drawing.Size(622, 384);
      this.pnlToolAbonnement.ResumeLayout(false);
      this.pnlToolAbonnement.PerformLayout();
      this.pnlInfos.ResumeLayout(false);
      this.pnlInfos.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlToolAbonnement;
    private System.Windows.Forms.Label lblTitre;
    private System.Windows.Forms.Button btClear;
    private System.Windows.Forms.Button btStop;
    private System.Windows.Forms.Button btStart;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.ListView lstMessage;
    private System.Windows.Forms.ColumnHeader colDate;
    private System.Windows.Forms.ColumnHeader colAction;
    private System.Windows.Forms.ColumnHeader colPattern;
    private System.Windows.Forms.Button btPublish;
    private System.Windows.Forms.TextBox txtPubMessage;
    private System.Windows.Forms.TextBox txtPubChanel;
    private System.Windows.Forms.Label lblPubMessage;
    private System.Windows.Forms.Label lblPubChanel;
    private System.Windows.Forms.TextBox txtSubChanel;
    private System.Windows.Forms.ColumnHeader colChanel;
    private System.Windows.Forms.ColumnHeader colMessage;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lblPublishStatut;
    private System.Windows.Forms.Panel pnlInfos;
    private System.Windows.Forms.Button btSave;
    private System.Windows.Forms.Button btSaveSelection;
    private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    private System.Windows.Forms.LinkLabel label3;
  }
}
