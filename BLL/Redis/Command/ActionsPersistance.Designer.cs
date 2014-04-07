namespace RedisManagementStudio.BLL.Redis.Command
{
  partial class ActionsPersistance
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
      this.btSave = new System.Windows.Forms.Button();
      this.btBgSave = new System.Windows.Forms.Button();
      this.btBgRewriteAOF = new System.Windows.Forms.Button();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.SuspendLayout();
      // 
      // btSave
      // 
      this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btSave.Location = new System.Drawing.Point(17, 5);
      this.btSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
      this.btSave.Name = "btSave";
      this.btSave.Size = new System.Drawing.Size(110, 30);
      this.btSave.TabIndex = 34;
      this.btSave.Text = "Sauvegarder";
      this.btSave.UseVisualStyleBackColor = true;
      this.btSave.Click += new System.EventHandler(this.BtSaveClick);
      // 
      // btBgSave
      // 
      this.btBgSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btBgSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btBgSave.Location = new System.Drawing.Point(133, 5);
      this.btBgSave.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
      this.btBgSave.Name = "btBgSave";
      this.btBgSave.Size = new System.Drawing.Size(169, 30);
      this.btBgSave.TabIndex = 35;
      this.btBgSave.Text = "Sauvegarde asynchrone";
      this.btBgSave.UseVisualStyleBackColor = true;
      this.btBgSave.Click += new System.EventHandler(this.BtBgSaveClick);
      // 
      // btBgRewriteAOF
      // 
      this.btBgRewriteAOF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btBgRewriteAOF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btBgRewriteAOF.Location = new System.Drawing.Point(308, 5);
      this.btBgRewriteAOF.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
      this.btBgRewriteAOF.Name = "btBgRewriteAOF";
      this.btBgRewriteAOF.Size = new System.Drawing.Size(178, 30);
      this.btBgRewriteAOF.TabIndex = 36;
      this.btBgRewriteAOF.Text = "Sauvegarde des évolutions";
      this.btBgRewriteAOF.UseVisualStyleBackColor = true;
      this.btBgRewriteAOF.Click += new System.EventHandler(this.BtBgRewriteAOFClick);
      // 
      // ActionsPersistance
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.btBgRewriteAOF);
      this.Controls.Add(this.btBgSave);
      this.Controls.Add(this.btSave);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "ActionsPersistance";
      this.Size = new System.Drawing.Size(486, 40);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btSave;
    private System.Windows.Forms.Button btBgSave;
    private System.Windows.Forms.Button btBgRewriteAOF;
    private System.Windows.Forms.ToolTip toolTip1;
  }
}
