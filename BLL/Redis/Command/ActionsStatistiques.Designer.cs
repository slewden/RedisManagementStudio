namespace RedisManagementStudio.BLL.Redis.Command
{
  partial class ActionsStatistiques
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
      this.btConfigResetStat = new System.Windows.Forms.Button();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.SuspendLayout();
      // 
      // btConfigResetStat
      // 
      this.btConfigResetStat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btConfigResetStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btConfigResetStat.Location = new System.Drawing.Point(14, 5);
      this.btConfigResetStat.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
      this.btConfigResetStat.Name = "btConfigResetStat";
      this.btConfigResetStat.Size = new System.Drawing.Size(227, 30);
      this.btConfigResetStat.TabIndex = 33;
      this.btConfigResetStat.Text = "Reinitialiser les statistiques...";
      this.btConfigResetStat.UseVisualStyleBackColor = true;
      this.btConfigResetStat.Click += new System.EventHandler(this.BtConfigResetStatClick);
      // 
      // ActionsStatistiques
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.btConfigResetStat);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "ActionsStatistiques";
      this.Size = new System.Drawing.Size(241, 40);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btConfigResetStat;
    private System.Windows.Forms.ToolTip toolTip1;
  }
}
