namespace RedisManagementStudio.BLL.Alarm
{
  partial class AlarmBoolUI
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
      this.lblTrueOption = new System.Windows.Forms.Label();
      this.cbTrueOption = new System.Windows.Forms.ComboBox();
      this.lblFalseOption = new System.Windows.Forms.Label();
      this.cbFalseOption = new System.Windows.Forms.ComboBox();
      this.imageLib1 = new RedisManagementStudio.BLL.ImageLib(this.components);
      this.SuspendLayout();
      // 
      // lblTrueOption
      // 
      this.lblTrueOption.AutoSize = true;
      this.lblTrueOption.Location = new System.Drawing.Point(3, 3);
      this.lblTrueOption.Name = "lblTrueOption";
      this.lblTrueOption.Size = new System.Drawing.Size(210, 17);
      this.lblTrueOption.TabIndex = 1;
      this.lblTrueOption.Text = "Quand la valeur est à Oui afficher :";
      // 
      // cbTrueOption
      // 
      this.cbTrueOption.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
      this.cbTrueOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbTrueOption.FormattingEnabled = true;
      this.cbTrueOption.ItemHeight = 16;
      this.cbTrueOption.Items.AddRange(new object[] {
            "AlarmRed",
            "AlarmOrange",
            "AlarmGreen",
            "AlarmNone"});
      this.cbTrueOption.Location = new System.Drawing.Point(219, 0);
      this.cbTrueOption.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.cbTrueOption.Name = "cbTrueOption";
      this.cbTrueOption.Size = new System.Drawing.Size(47, 22);
      this.cbTrueOption.TabIndex = 2;
      this.cbTrueOption.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBoxDrawItem);
      this.cbTrueOption.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectedIndexChanged);
      // 
      // lblFalseOption
      // 
      this.lblFalseOption.AutoSize = true;
      this.lblFalseOption.Location = new System.Drawing.Point(3, 37);
      this.lblFalseOption.Name = "lblFalseOption";
      this.lblFalseOption.Size = new System.Drawing.Size(215, 17);
      this.lblFalseOption.TabIndex = 3;
      this.lblFalseOption.Text = "Quand la valeur est à Non afficher :";
      // 
      // cbFalseOption
      // 
      this.cbFalseOption.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
      this.cbFalseOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbFalseOption.FormattingEnabled = true;
      this.cbFalseOption.Items.AddRange(new object[] {
            "AlarmRed",
            "AlarmOrange",
            "AlarmGreen",
            "AlarmNone"});
      this.cbFalseOption.Location = new System.Drawing.Point(219, 34);
      this.cbFalseOption.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.cbFalseOption.Name = "cbFalseOption";
      this.cbFalseOption.Size = new System.Drawing.Size(47, 26);
      this.cbFalseOption.TabIndex = 4;
      this.cbFalseOption.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBoxDrawItem);
      this.cbFalseOption.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectedIndexChanged);
      // 
      // AlarmBoolUI
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.cbFalseOption);
      this.Controls.Add(this.lblFalseOption);
      this.Controls.Add(this.cbTrueOption);
      this.Controls.Add(this.lblTrueOption);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "AlarmBoolUI";
      this.Size = new System.Drawing.Size(425, 60);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblTrueOption;
    private System.Windows.Forms.ComboBox cbTrueOption;
    private System.Windows.Forms.Label lblFalseOption;
    private System.Windows.Forms.ComboBox cbFalseOption;
    private ImageLib imageLib1;
  }
}
