namespace RedisManagementStudio.BLL.Alarm
{
  partial class AlarmCounterUI
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
      this.txtSeuil2 = new System.Windows.Forms.TextBox();
      this.lblSeuil2Caption = new System.Windows.Forms.Label();
      this.picSeuil2 = new System.Windows.Forms.PictureBox();
      this.txtSeuil1 = new System.Windows.Forms.TextBox();
      this.lblSeuil1Caption = new System.Windows.Forms.Label();
      this.picSeuil1 = new System.Windows.Forms.PictureBox();
      this.lblSeuil1Caption2 = new System.Windows.Forms.Label();
      this.lblSeuil2Caption2 = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.picSeuil2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.picSeuil1)).BeginInit();
      this.SuspendLayout();
      // 
      // txtSeuil2
      // 
      this.txtSeuil2.Location = new System.Drawing.Point(250, 34);
      this.txtSeuil2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.txtSeuil2.Name = "txtSeuil2";
      this.txtSeuil2.Size = new System.Drawing.Size(93, 25);
      this.txtSeuil2.TabIndex = 6;
      this.txtSeuil2.TextChanged += new System.EventHandler(this.TxtTextChanged);
      this.txtSeuil2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtKeyPress);
      // 
      // lblSeuil2Caption
      // 
      this.lblSeuil2Caption.AutoSize = true;
      this.lblSeuil2Caption.Location = new System.Drawing.Point(3, 37);
      this.lblSeuil2Caption.Name = "lblSeuil2Caption";
      this.lblSeuil2Caption.Size = new System.Drawing.Size(242, 17);
      this.lblSeuil2Caption.TabIndex = 5;
      this.lblSeuil2Caption.Text = "Puis quand la valeur est en dessous de :";
      // 
      // picSeuil2
      // 
      this.picSeuil2.Image = global::RedisManagementStudio.Properties.Resources.AlarmRed;
      this.picSeuil2.Location = new System.Drawing.Point(406, 38);
      this.picSeuil2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.picSeuil2.Name = "picSeuil2";
      this.picSeuil2.Size = new System.Drawing.Size(19, 21);
      this.picSeuil2.TabIndex = 4;
      this.picSeuil2.TabStop = false;
      // 
      // txtSeuil1
      // 
      this.txtSeuil1.Location = new System.Drawing.Point(251, 0);
      this.txtSeuil1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.txtSeuil1.Name = "txtSeuil1";
      this.txtSeuil1.Size = new System.Drawing.Size(91, 25);
      this.txtSeuil1.TabIndex = 3;
      this.txtSeuil1.TextChanged += new System.EventHandler(this.TxtTextChanged);
      this.txtSeuil1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtKeyPress);
      // 
      // lblSeuil1Caption
      // 
      this.lblSeuil1Caption.AutoSize = true;
      this.lblSeuil1Caption.Location = new System.Drawing.Point(3, 3);
      this.lblSeuil1Caption.Name = "lblSeuil1Caption";
      this.lblSeuil1Caption.Size = new System.Drawing.Size(217, 17);
      this.lblSeuil1Caption.TabIndex = 2;
      this.lblSeuil1Caption.Text = "Quand la valeur est en dessous de :";
      // 
      // picSeuil1
      // 
      this.picSeuil1.Image = global::RedisManagementStudio.Properties.Resources.AlarmOrange;
      this.picSeuil1.Location = new System.Drawing.Point(406, 4);
      this.picSeuil1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.picSeuil1.Name = "picSeuil1";
      this.picSeuil1.Size = new System.Drawing.Size(19, 21);
      this.picSeuil1.TabIndex = 1;
      this.picSeuil1.TabStop = false;
      // 
      // lblSeuil1Caption2
      // 
      this.lblSeuil1Caption2.AutoSize = true;
      this.lblSeuil1Caption2.Location = new System.Drawing.Point(350, 3);
      this.lblSeuil1Caption2.Name = "lblSeuil1Caption2";
      this.lblSeuil1Caption2.Size = new System.Drawing.Size(51, 17);
      this.lblSeuil1Caption2.TabIndex = 8;
      this.lblSeuil1Caption2.Text = "afficher";
      // 
      // lblSeuil2Caption2
      // 
      this.lblSeuil2Caption2.AutoSize = true;
      this.lblSeuil2Caption2.Location = new System.Drawing.Point(349, 37);
      this.lblSeuil2Caption2.Name = "lblSeuil2Caption2";
      this.lblSeuil2Caption2.Size = new System.Drawing.Size(51, 17);
      this.lblSeuil2Caption2.TabIndex = 9;
      this.lblSeuil2Caption2.Text = "afficher";
      // 
      // AlarmCounterUI
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lblSeuil2Caption2);
      this.Controls.Add(this.lblSeuil1Caption2);
      this.Controls.Add(this.txtSeuil2);
      this.Controls.Add(this.lblSeuil2Caption);
      this.Controls.Add(this.picSeuil2);
      this.Controls.Add(this.txtSeuil1);
      this.Controls.Add(this.lblSeuil1Caption);
      this.Controls.Add(this.picSeuil1);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "AlarmCounterUI";
      this.Size = new System.Drawing.Size(425, 60);
      ((System.ComponentModel.ISupportInitialize)(this.picSeuil2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.picSeuil1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txtSeuil2;
    private System.Windows.Forms.Label lblSeuil2Caption;
    private System.Windows.Forms.PictureBox picSeuil2;
    private System.Windows.Forms.TextBox txtSeuil1;
    private System.Windows.Forms.Label lblSeuil1Caption;
    private System.Windows.Forms.PictureBox picSeuil1;
    private System.Windows.Forms.Label lblSeuil1Caption2;
    private System.Windows.Forms.Label lblSeuil2Caption2;
  }
}
