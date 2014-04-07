namespace RedisManagementStudio.BLL.Alarm
{
  partial class AlarmStatusUI 
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
      this.lblDescription = new System.Windows.Forms.Label();
      this.btEdit = new System.Windows.Forms.Button();
      this.imageLib1 = new RedisManagementStudio.BLL.ImageLib(this.components);
      this.alarmBoolUI1 = new RedisManagementStudio.BLL.Alarm.AlarmBoolUI();
      this.alarmCounterUI1 = new RedisManagementStudio.BLL.Alarm.AlarmCounterUI();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.btDel = new System.Windows.Forms.Button();
      this.btSave = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.btCancel = new System.Windows.Forms.Button();
      this.imgStatut = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.imgStatut)).BeginInit();
      this.SuspendLayout();
      // 
      // lblDescription
      // 
      this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblDescription.Location = new System.Drawing.Point(107, 0);
      this.lblDescription.Name = "lblDescription";
      this.lblDescription.Size = new System.Drawing.Size(208, 25);
      this.lblDescription.TabIndex = 1;
      this.lblDescription.Text = "label1";
      this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btEdit
      // 
      this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btEdit.Location = new System.Drawing.Point(390, 0);
      this.btEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btEdit.Name = "btEdit";
      this.btEdit.Size = new System.Drawing.Size(96, 28);
      this.btEdit.TabIndex = 2;
      this.btEdit.Text = "Configurer";
      this.btEdit.UseVisualStyleBackColor = true;
      this.btEdit.Click += new System.EventHandler(this.BtEditClick);
      // 
      // alarmBoolUI1
      // 
      this.alarmBoolUI1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.alarmBoolUI1.Location = new System.Drawing.Point(15, 39);
      this.alarmBoolUI1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.alarmBoolUI1.Name = "alarmBoolUI1";
      this.alarmBoolUI1.Size = new System.Drawing.Size(425, 60);
      this.alarmBoolUI1.TabIndex = 4;
      this.alarmBoolUI1.OnChange += new System.EventHandler(this.AlarmOnChange);
      // 
      // alarmCounterUI1
      // 
      this.alarmCounterUI1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.alarmCounterUI1.Location = new System.Drawing.Point(15, 39);
      this.alarmCounterUI1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.alarmCounterUI1.Name = "alarmCounterUI1";
      this.alarmCounterUI1.Size = new System.Drawing.Size(425, 60);
      this.alarmCounterUI1.TabIndex = 5;
      this.alarmCounterUI1.OnChange += new System.EventHandler(this.AlarmOnChange);
      // 
      // btDel
      // 
      this.btDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btDel.Image = global::RedisManagementStudio.Properties.Resources.Delete12;
      this.btDel.Location = new System.Drawing.Point(374, 0);
      this.btDel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btDel.Name = "btDel";
      this.btDel.Size = new System.Drawing.Size(33, 25);
      this.btDel.TabIndex = 3;
      this.btDel.UseVisualStyleBackColor = true;
      this.btDel.Click += new System.EventHandler(this.BtDelClick);
      // 
      // btSave
      // 
      this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btSave.Image = global::RedisManagementStudio.Properties.Resources.Save;
      this.btSave.Location = new System.Drawing.Point(414, 0);
      this.btSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btSave.Name = "btSave";
      this.btSave.Size = new System.Drawing.Size(33, 25);
      this.btSave.TabIndex = 6;
      this.btSave.UseVisualStyleBackColor = true;
      this.btSave.Click += new System.EventHandler(this.BtSaveClick);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::RedisManagementStudio.Properties.Resources.Warning;
      this.pictureBox1.Location = new System.Drawing.Point(3, 0);
      this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(28, 31);
      this.pictureBox1.TabIndex = 7;
      this.pictureBox1.TabStop = false;
      // 
      // btCancel
      // 
      this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btCancel.Image = global::RedisManagementStudio.Properties.Resources.Cancel;
      this.btCancel.Location = new System.Drawing.Point(453, 0);
      this.btCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(33, 25);
      this.btCancel.TabIndex = 8;
      this.btCancel.UseVisualStyleBackColor = true;
      this.btCancel.Click += new System.EventHandler(this.BtCancelClick);
      // 
      // imgStatut
      // 
      this.imgStatut.Location = new System.Drawing.Point(60, 4);
      this.imgStatut.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.imgStatut.Name = "imgStatut";
      this.imgStatut.Size = new System.Drawing.Size(19, 21);
      this.imgStatut.TabIndex = 0;
      this.imgStatut.TabStop = false;
      // 
      // AlarmStatusUI
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.btDel);
      this.Controls.Add(this.lblDescription);
      this.Controls.Add(this.imgStatut);
      this.Controls.Add(this.btSave);
      this.Controls.Add(this.btCancel);
      this.Controls.Add(this.btEdit);
      this.Controls.Add(this.alarmCounterUI1);
      this.Controls.Add(this.alarmBoolUI1);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "AlarmStatusUI";
      this.Size = new System.Drawing.Size(486, 100);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.imgStatut)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox imgStatut;
    private System.Windows.Forms.Label lblDescription;
    private System.Windows.Forms.Button btEdit;
    private System.Windows.Forms.Button btDel;
    private ImageLib imageLib1;
    private AlarmBoolUI alarmBoolUI1;
    private AlarmCounterUI alarmCounterUI1;
    private System.Windows.Forms.Button btSave;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.ToolTip toolTip1;
  }
}
