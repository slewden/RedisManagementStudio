namespace RedisManagementStudio.BLL.Redis.Command
{
  partial class RedisServerTools
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
      this.lblDetail = new System.Windows.Forms.Label();
      this.pnlTips = new System.Windows.Forms.Panel();
      this.lblTips = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.pnlTips.SuspendLayout();
      this.SuspendLayout();
      // 
      // lblDetail
      // 
      this.lblDetail.BackColor = System.Drawing.SystemColors.Control;
      this.lblDetail.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblDetail.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblDetail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.lblDetail.Location = new System.Drawing.Point(0, 0);
      this.lblDetail.Name = "lblDetail";
      this.lblDetail.Size = new System.Drawing.Size(626, 30);
      this.lblDetail.TabIndex = 31;
      this.lblDetail.Text = "Les actions serveur";
      this.lblDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // pnlTips
      // 
      this.pnlTips.BackColor = System.Drawing.SystemColors.Info;
      this.pnlTips.Controls.Add(this.lblTips);
      this.pnlTips.ForeColor = System.Drawing.SystemColors.InfoText;
      this.pnlTips.Location = new System.Drawing.Point(252, 81);
      this.pnlTips.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.pnlTips.Name = "pnlTips";
      this.pnlTips.Size = new System.Drawing.Size(357, 197);
      this.pnlTips.TabIndex = 34;
      this.pnlTips.Visible = false;
      // 
      // lblTips
      // 
      this.lblTips.Location = new System.Drawing.Point(3, 8);
      this.lblTips.Name = "lblTips";
      this.lblTips.Size = new System.Drawing.Size(345, 179);
      this.lblTips.TabIndex = 0;
      this.lblTips.Text = "xxx";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(19, 52);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(53, 17);
      this.label1.TabIndex = 35;
      this.label1.Text = "TODO...";
      // 
      // RedisServerTools
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.label1);
      this.Controls.Add(this.pnlTips);
      this.Controls.Add(this.lblDetail);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "RedisServerTools";
      this.Size = new System.Drawing.Size(626, 467);
      this.pnlTips.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblDetail;
    private System.Windows.Forms.Panel pnlTips;
    private System.Windows.Forms.Label lblTips;
    private System.Windows.Forms.Label label1;
  }
}
