namespace RedisManagementStudio.BLL.Redis.Config
{
  partial class ConfigEditUI
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
      this.btCancel = new System.Windows.Forms.Button();
      this.btEdit = new System.Windows.Forms.Button();
      this.txtEdit = new System.Windows.Forms.TextBox();
      this.lblValue = new System.Windows.Forms.TextBox();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.SuspendLayout();
      // 
      // btSave
      // 
      this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btSave.Image = global::RedisManagementStudio.Properties.Resources.Save;
      this.btSave.Location = new System.Drawing.Point(400, 0);
      this.btSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btSave.Name = "btSave";
      this.btSave.Size = new System.Drawing.Size(25, 25);
      this.btSave.TabIndex = 10;
      this.btSave.UseVisualStyleBackColor = true;
      this.btSave.Click += new System.EventHandler(this.BtSaveClick);
      // 
      // btCancel
      // 
      this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btCancel.Image = global::RedisManagementStudio.Properties.Resources.Cancel;
      this.btCancel.Location = new System.Drawing.Point(431, 0);
      this.btCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(25, 25);
      this.btCancel.TabIndex = 11;
      this.btCancel.UseVisualStyleBackColor = true;
      this.btCancel.Click += new System.EventHandler(this.BtCancelClick);
      // 
      // btEdit
      // 
      this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btEdit.Location = new System.Drawing.Point(360, 0);
      this.btEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btEdit.Name = "btEdit";
      this.btEdit.Size = new System.Drawing.Size(96, 28);
      this.btEdit.TabIndex = 9;
      this.btEdit.Text = "Configurer";
      this.btEdit.UseVisualStyleBackColor = true;
      this.btEdit.Click += new System.EventHandler(this.BtEditClick);
      // 
      // txtEdit
      // 
      this.txtEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtEdit.Location = new System.Drawing.Point(0, 0);
      this.txtEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.txtEdit.Name = "txtEdit";
      this.txtEdit.Size = new System.Drawing.Size(394, 25);
      this.txtEdit.TabIndex = 12;
      this.txtEdit.TextChanged += new System.EventHandler(this.TxtEditTextChanged);
      // 
      // lblValue
      // 
      this.lblValue.AcceptsReturn = true;
      this.lblValue.AcceptsTab = true;
      this.lblValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblValue.BackColor = System.Drawing.SystemColors.Control;
      this.lblValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.lblValue.Location = new System.Drawing.Point(0, 0);
      this.lblValue.Multiline = true;
      this.lblValue.Name = "lblValue";
      this.lblValue.ReadOnly = true;
      this.lblValue.Size = new System.Drawing.Size(354, 32);
      this.lblValue.TabIndex = 13;
      // 
      // ConfigEditUI
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.txtEdit);
      this.Controls.Add(this.btSave);
      this.Controls.Add(this.btCancel);
      this.Controls.Add(this.btEdit);
      this.Controls.Add(this.lblValue);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "ConfigEditUI";
      this.Size = new System.Drawing.Size(456, 33);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btSave;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.Button btEdit;
    private System.Windows.Forms.TextBox txtEdit;
    private System.Windows.Forms.TextBox lblValue;
    private System.Windows.Forms.ToolTip toolTip1;
  }
}
