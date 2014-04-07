namespace RedisManagementStudio.BLL.Redis.Keys
{
  partial class KeyGroup
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
      this.lblCount = new System.Windows.Forms.Label();
      this.lstNodes = new System.Windows.Forms.ListView();
      this.colCle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.lblDescription = new System.Windows.Forms.Label();
      this.lblTitre = new System.Windows.Forms.Label();
      this.btSizeOf = new System.Windows.Forms.Button();
      this.btAddKey = new System.Windows.Forms.Button();
      this.btDelKey = new System.Windows.Forms.Button();
      this.lblPoids = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // lblCount
      // 
      this.lblCount.BackColor = System.Drawing.SystemColors.Control;
      this.lblCount.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.lblCount.Location = new System.Drawing.Point(0, 170);
      this.lblCount.Name = "lblCount";
      this.lblCount.Size = new System.Drawing.Size(411, 26);
      this.lblCount.TabIndex = 0;
      this.lblCount.Text = "label1";
      this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // lstNodes
      // 
      this.lstNodes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lstNodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCle,
            this.colType});
      this.lstNodes.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lstNodes.FullRowSelect = true;
      this.lstNodes.HideSelection = false;
      this.lstNodes.LabelWrap = false;
      this.lstNodes.Location = new System.Drawing.Point(0, 40);
      this.lstNodes.Name = "lstNodes";
      this.lstNodes.ShowItemToolTips = true;
      this.lstNodes.Size = new System.Drawing.Size(411, 82);
      this.lstNodes.TabIndex = 1;
      this.lstNodes.UseCompatibleStateImageBehavior = false;
      this.lstNodes.View = System.Windows.Forms.View.Details;
      this.lstNodes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LstNodesColumnClick);
      this.lstNodes.SelectedIndexChanged += new System.EventHandler(this.LstNodesSelectedIndexChanged);
      this.lstNodes.DoubleClick += new System.EventHandler(this.LstNodesDoubleClick);
      // 
      // colCle
      // 
      this.colCle.Text = "Clé";
      this.colCle.Width = 300;
      // 
      // colType
      // 
      this.colType.Text = "Type";
      this.colType.Width = 150;
      // 
      // lblDescription
      // 
      this.lblDescription.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.lblDescription.Location = new System.Drawing.Point(0, 122);
      this.lblDescription.Name = "lblDescription";
      this.lblDescription.Size = new System.Drawing.Size(411, 48);
      this.lblDescription.TabIndex = 2;
      // 
      // lblTitre
      // 
      this.lblTitre.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblTitre.Location = new System.Drawing.Point(0, 0);
      this.lblTitre.Name = "lblTitre";
      this.lblTitre.Size = new System.Drawing.Size(411, 40);
      this.lblTitre.TabIndex = 3;
      this.lblTitre.Text = "xxx";
      this.lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btSizeOf
      // 
      this.btSizeOf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btSizeOf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btSizeOf.Image = global::RedisManagementStudio.Properties.Resources.weight16;
      this.btSizeOf.Location = new System.Drawing.Point(324, 8);
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
      this.btAddKey.Location = new System.Drawing.Point(386, 8);
      this.btAddKey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btAddKey.Name = "btAddKey";
      this.btAddKey.Size = new System.Drawing.Size(25, 25);
      this.btAddKey.TabIndex = 38;
      this.btAddKey.UseVisualStyleBackColor = true;
      this.btAddKey.Click += new System.EventHandler(this.BtAddKeyClick);
      // 
      // btDelKey
      // 
      this.btDelKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btDelKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btDelKey.Image = global::RedisManagementStudio.Properties.Resources.Delete12;
      this.btDelKey.Location = new System.Drawing.Point(355, 8);
      this.btDelKey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btDelKey.Name = "btDelKey";
      this.btDelKey.Size = new System.Drawing.Size(25, 25);
      this.btDelKey.TabIndex = 37;
      this.btDelKey.UseVisualStyleBackColor = true;
      this.btDelKey.Click += new System.EventHandler(this.BtDelKeyClick);
      // 
      // lblPoids
      // 
      this.lblPoids.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblPoids.Location = new System.Drawing.Point(224, 8);
      this.lblPoids.Name = "lblPoids";
      this.lblPoids.Size = new System.Drawing.Size(94, 25);
      this.lblPoids.TabIndex = 40;
      this.lblPoids.Text = "xxx";
      this.lblPoids.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // KeyGroup
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lblPoids);
      this.Controls.Add(this.btSizeOf);
      this.Controls.Add(this.btAddKey);
      this.Controls.Add(this.btDelKey);
      this.Controls.Add(this.lstNodes);
      this.Controls.Add(this.lblDescription);
      this.Controls.Add(this.lblCount);
      this.Controls.Add(this.lblTitre);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "KeyGroup";
      this.Size = new System.Drawing.Size(411, 196);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblCount;
    private System.Windows.Forms.ListView lstNodes;
    private System.Windows.Forms.ColumnHeader colCle;
    private System.Windows.Forms.ColumnHeader colType;
    private System.Windows.Forms.Label lblDescription;
    private System.Windows.Forms.Label lblTitre;
    private System.Windows.Forms.Button btSizeOf;
    private System.Windows.Forms.Button btAddKey;
    private System.Windows.Forms.Button btDelKey;
    private System.Windows.Forms.Label lblPoids;
  }
}
