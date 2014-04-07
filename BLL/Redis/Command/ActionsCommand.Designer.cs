namespace RedisManagementStudio.BLL.Redis.Command
{
  partial class ActionsCommand
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
      this.lblInfo = new System.Windows.Forms.Label();
      this.btShow = new System.Windows.Forms.Button();
      this.btReset = new System.Windows.Forms.Button();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.SuspendLayout();
      // 
      // lblInfo
      // 
      this.lblInfo.AutoSize = true;
      this.lblInfo.Location = new System.Drawing.Point(3, 12);
      this.lblInfo.Name = "lblInfo";
      this.lblInfo.Size = new System.Drawing.Size(316, 17);
      this.lblInfo.TabIndex = 0;
      this.lblInfo.Text = "Il y a actuellement XXX commandes lentes identifiées";
      // 
      // btShow
      // 
      this.btShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btShow.Location = new System.Drawing.Point(346, 5);
      this.btShow.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
      this.btShow.Name = "btShow";
      this.btShow.Size = new System.Drawing.Size(110, 30);
      this.btShow.TabIndex = 35;
      this.btShow.Text = "Voir en détail...";
      this.btShow.UseVisualStyleBackColor = true;
      this.btShow.Click += new System.EventHandler(this.BtShowClick);
      // 
      // btReset
      // 
      this.btReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btReset.Location = new System.Drawing.Point(462, 5);
      this.btReset.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
      this.btReset.Name = "btReset";
      this.btReset.Size = new System.Drawing.Size(110, 30);
      this.btReset.TabIndex = 36;
      this.btReset.Text = "Vider la liste...";
      this.btReset.UseVisualStyleBackColor = true;
      this.btReset.Click += new System.EventHandler(this.BtResetClick);
      // 
      // ActionsCommand
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.btReset);
      this.Controls.Add(this.btShow);
      this.Controls.Add(this.lblInfo);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "ActionsCommand";
      this.Size = new System.Drawing.Size(572, 40);
      this.VisibleChanged += new System.EventHandler(this.ActionsCommand_VisibleChanged);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblInfo;
    private System.Windows.Forms.Button btShow;
    private System.Windows.Forms.Button btReset;
    private System.Windows.Forms.ToolTip toolTip1;
  }
}
