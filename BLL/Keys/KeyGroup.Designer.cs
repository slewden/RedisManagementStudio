namespace RedisManagementStudio.BLL.Keys
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
      this.lstNodes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.lstNodes.HideSelection = false;
      this.lstNodes.LabelWrap = false;
      this.lstNodes.Location = new System.Drawing.Point(0, 48);
      this.lstNodes.Name = "lstNodes";
      this.lstNodes.ShowItemToolTips = true;
      this.lstNodes.Size = new System.Drawing.Size(411, 122);
      this.lstNodes.TabIndex = 1;
      this.lstNodes.UseCompatibleStateImageBehavior = false;
      this.lstNodes.View = System.Windows.Forms.View.Details;
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
      this.lblDescription.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblDescription.Location = new System.Drawing.Point(0, 0);
      this.lblDescription.Name = "lblDescription";
      this.lblDescription.Size = new System.Drawing.Size(411, 48);
      this.lblDescription.TabIndex = 2;
      // 
      // KeyGroup
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lstNodes);
      this.Controls.Add(this.lblDescription);
      this.Controls.Add(this.lblCount);
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
  }
}
