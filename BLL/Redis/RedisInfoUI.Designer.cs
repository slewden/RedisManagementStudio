namespace RedisManagementStudio.BLL.Redis

{
  partial class RedisInfoUI
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
      this.lblInfoDescriptionCaption = new System.Windows.Forms.Label();
      this.lblInfoValueCaption = new System.Windows.Forms.Label();
      this.lblInfoOriginalValueCaption = new System.Windows.Forms.Label();
      this.lblInfoKeyCaption = new System.Windows.Forms.Label();
      this.lblInfoDescription = new System.Windows.Forms.Label();
      this.lblInfoKey = new System.Windows.Forms.TextBox();
      this.lblInfoOriginalValue = new System.Windows.Forms.TextBox();
      this.alarmStatus1 = new RedisManagementStudio.BLL.Alarm.AlarmStatusUI();
      this.configEditUI1 = new RedisManagementStudio.BLL.Redis.Config.ConfigEditUI();
      this.imageLib1 = new RedisManagementStudio.BLL.ImageLib(this.components);
      this.SuspendLayout();
      // 
      // lblInfoDescriptionCaption
      // 
      this.lblInfoDescriptionCaption.AutoSize = true;
      this.lblInfoDescriptionCaption.Location = new System.Drawing.Point(3, 17);
      this.lblInfoDescriptionCaption.Name = "lblInfoDescriptionCaption";
      this.lblInfoDescriptionCaption.Size = new System.Drawing.Size(81, 17);
      this.lblInfoDescriptionCaption.TabIndex = 23;
      this.lblInfoDescriptionCaption.Text = "Description :";
      // 
      // lblInfoValueCaption
      // 
      this.lblInfoValueCaption.AutoSize = true;
      this.lblInfoValueCaption.Location = new System.Drawing.Point(3, 60);
      this.lblInfoValueCaption.Name = "lblInfoValueCaption";
      this.lblInfoValueCaption.Size = new System.Drawing.Size(56, 17);
      this.lblInfoValueCaption.TabIndex = 19;
      this.lblInfoValueCaption.Text = "Valeur : ";
      // 
      // lblInfoOriginalValueCaption
      // 
      this.lblInfoOriginalValueCaption.AutoSize = true;
      this.lblInfoOriginalValueCaption.BackColor = System.Drawing.SystemColors.Control;
      this.lblInfoOriginalValueCaption.Location = new System.Drawing.Point(295, 140);
      this.lblInfoOriginalValueCaption.Name = "lblInfoOriginalValueCaption";
      this.lblInfoOriginalValueCaption.Size = new System.Drawing.Size(91, 17);
      this.lblInfoOriginalValueCaption.TabIndex = 17;
      this.lblInfoOriginalValueCaption.Text = "Valeur brute : ";
      // 
      // lblInfoKeyCaption
      // 
      this.lblInfoKeyCaption.AutoSize = true;
      this.lblInfoKeyCaption.Location = new System.Drawing.Point(3, 140);
      this.lblInfoKeyCaption.Name = "lblInfoKeyCaption";
      this.lblInfoKeyCaption.Size = new System.Drawing.Size(37, 17);
      this.lblInfoKeyCaption.TabIndex = 15;
      this.lblInfoKeyCaption.Text = "Clé : ";
      // 
      // lblInfoDescription
      // 
      this.lblInfoDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblInfoDescription.Location = new System.Drawing.Point(107, 17);
      this.lblInfoDescription.Name = "lblInfoDescription";
      this.lblInfoDescription.Size = new System.Drawing.Size(436, 34);
      this.lblInfoDescription.TabIndex = 24;
      this.lblInfoDescription.Text = "xxx";
      // 
      // lblInfoKey
      // 
      this.lblInfoKey.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.lblInfoKey.Location = new System.Drawing.Point(110, 140);
      this.lblInfoKey.Name = "lblInfoKey";
      this.lblInfoKey.ReadOnly = true;
      this.lblInfoKey.Size = new System.Drawing.Size(179, 18);
      this.lblInfoKey.TabIndex = 29;
      this.lblInfoKey.Text = "xxx";
      // 
      // lblInfoOriginalValue
      // 
      this.lblInfoOriginalValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblInfoOriginalValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.lblInfoOriginalValue.Location = new System.Drawing.Point(392, 140);
      this.lblInfoOriginalValue.Name = "lblInfoOriginalValue";
      this.lblInfoOriginalValue.ReadOnly = true;
      this.lblInfoOriginalValue.Size = new System.Drawing.Size(148, 18);
      this.lblInfoOriginalValue.TabIndex = 30;
      this.lblInfoOriginalValue.Text = "xxx";
      // 
      // alarmStatus1
      // 
      this.alarmStatus1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.alarmStatus1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.alarmStatus1.Location = new System.Drawing.Point(0, 172);
      this.alarmStatus1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
      this.alarmStatus1.Name = "alarmStatus1";
      this.alarmStatus1.Size = new System.Drawing.Size(543, 100);
      this.alarmStatus1.TabIndex = 25;
      this.alarmStatus1.OnSaved += new System.EventHandler(this.AlarmStatus1OnSaved);
      // 
      // configEditUI1
      // 
      this.configEditUI1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.configEditUI1.BackColor = System.Drawing.SystemColors.Control;
      this.configEditUI1.Connection = null;
      this.configEditUI1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.configEditUI1.Location = new System.Drawing.Point(107, 56);
      this.configEditUI1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
      this.configEditUI1.Name = "configEditUI1";
      this.configEditUI1.Size = new System.Drawing.Size(436, 79);
      this.configEditUI1.TabIndex = 27;
      this.configEditUI1.OnSaved += new System.EventHandler(this.ConfigEditUI1OnSaved);
      // 
      // RedisInfoUI
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.Controls.Add(this.lblInfoOriginalValue);
      this.Controls.Add(this.lblInfoKey);
      this.Controls.Add(this.alarmStatus1);
      this.Controls.Add(this.lblInfoDescriptionCaption);
      this.Controls.Add(this.lblInfoDescription);
      this.Controls.Add(this.configEditUI1);
      this.Controls.Add(this.lblInfoOriginalValueCaption);
      this.Controls.Add(this.lblInfoValueCaption);
      this.Controls.Add(this.lblInfoKeyCaption);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "RedisInfoUI";
      this.Size = new System.Drawing.Size(543, 272);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Alarm.AlarmStatusUI alarmStatus1;
    private System.Windows.Forms.Label lblInfoDescriptionCaption;
    private System.Windows.Forms.Label lblInfoValueCaption;
    private System.Windows.Forms.Label lblInfoOriginalValueCaption;
    private System.Windows.Forms.Label lblInfoKeyCaption;
    private System.Windows.Forms.Label lblInfoDescription;
    private ImageLib imageLib1;
    private Config.ConfigEditUI configEditUI1;
    private System.Windows.Forms.TextBox lblInfoKey;
    private System.Windows.Forms.TextBox lblInfoOriginalValue;
  }
}
