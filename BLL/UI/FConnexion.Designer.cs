namespace RedisManagementStudio.BLL.UI
{
  partial class FConnexion
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
			this.btCancel = new System.Windows.Forms.Button();
			this.btOk = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtUrl = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cbBaseId = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.btChooseColor = new System.Windows.Forms.Button();
			this.pnlColor = new System.Windows.Forms.Panel();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.btClearColor = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btCancel
			// 
			this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btCancel.Location = new System.Drawing.Point(374, 470);
			this.btCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(87, 30);
			this.btCancel.TabIndex = 0;
			this.btCancel.Text = "Annuler";
			this.btCancel.UseVisualStyleBackColor = true;
			// 
			// btOk
			// 
			this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btOk.Location = new System.Drawing.Point(280, 470);
			this.btOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btOk.Name = "btOk";
			this.btOk.Size = new System.Drawing.Size(87, 30);
			this.btOk.TabIndex = 1;
			this.btOk.Text = "Enregistrer";
			this.btOk.UseVisualStyleBackColor = true;
			this.btOk.Click += new System.EventHandler(this.BtOkClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Location = new System.Drawing.Point(10, 60);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox1.Size = new System.Drawing.Size(451, 4);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(55, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(407, 33);
			this.label1.TabIndex = 5;
			this.label1.Text = "Connexion à une base d\'un serveur Redis.";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::RedisManagementStudio.Properties.Resources.Redis32;
			this.pictureBox1.Location = new System.Drawing.Point(10, 12);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(44, 44);
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(15, 90);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(140, 17);
			this.label2.TabIndex = 8;
			this.label2.Text = "Nom de la connexion :";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 134);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 17);
			this.label3.TabIndex = 9;
			this.label3.Text = "Adresse du serveur :";
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtName.Location = new System.Drawing.Point(154, 87);
			this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(308, 25);
			this.txtName.TabIndex = 10;
			this.txtName.TextChanged += new System.EventHandler(this.TxtTextChanged);
			// 
			// txtUrl
			// 
			this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtUrl.Location = new System.Drawing.Point(154, 131);
			this.txtUrl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtUrl.Name = "txtUrl";
			this.txtUrl.Size = new System.Drawing.Size(308, 25);
			this.txtUrl.TabIndex = 11;
			this.txtUrl.TextChanged += new System.EventHandler(this.TxtTextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(15, 178);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(39, 17);
			this.label4.TabIndex = 12;
			this.label4.Text = "Port :";
			// 
			// txtPort
			// 
			this.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPort.Location = new System.Drawing.Point(154, 175);
			this.txtPort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtPort.MaxLength = 5;
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(77, 25);
			this.txtPort.TabIndex = 13;
			this.txtPort.TextChanged += new System.EventHandler(this.TxtTextChanged);
			this.txtPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPortKeyPress);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(15, 218);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(137, 17);
			this.label5.TabIndex = 14;
			this.label5.Text = "Identifiant de la base :";
			// 
			// cbBaseId
			// 
			this.cbBaseId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbBaseId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cbBaseId.FormattingEnabled = true;
			this.cbBaseId.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
			this.cbBaseId.Location = new System.Drawing.Point(154, 215);
			this.cbBaseId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.cbBaseId.Name = "cbBaseId";
			this.cbBaseId.Size = new System.Drawing.Size(77, 25);
			this.cbBaseId.TabIndex = 15;
			this.cbBaseId.SelectedIndexChanged += new System.EventHandler(this.TxtTextChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(15, 262);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(96, 17);
			this.label6.TabIndex = 16;
			this.label6.Text = "Mot de passe :";
			// 
			// txtPassword
			// 
			this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPassword.Location = new System.Drawing.Point(154, 259);
			this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(308, 25);
			this.txtPassword.TabIndex = 17;
			this.txtPassword.TextChanged += new System.EventHandler(this.TxtTextChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(15, 306);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 17);
			this.label7.TabIndex = 18;
			this.label7.Text = "Couleur  :";
			// 
			// btChooseColor
			// 
			this.btChooseColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btChooseColor.Location = new System.Drawing.Point(237, 302);
			this.btChooseColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btChooseColor.Name = "btChooseColor";
			this.btChooseColor.Size = new System.Drawing.Size(30, 25);
			this.btChooseColor.TabIndex = 19;
			this.btChooseColor.Text = "...";
			this.btChooseColor.UseVisualStyleBackColor = true;
			this.btChooseColor.Click += new System.EventHandler(this.BtChooseColorClick);
			// 
			// pnlColor
			// 
			this.pnlColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlColor.Location = new System.Drawing.Point(154, 302);
			this.pnlColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.pnlColor.Name = "pnlColor";
			this.pnlColor.Size = new System.Drawing.Size(77, 25);
			this.pnlColor.TabIndex = 20;
			// 
			// txtDescription
			// 
			this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDescription.Location = new System.Drawing.Point(154, 340);
			this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(308, 110);
			this.txtDescription.TabIndex = 22;
			this.txtDescription.TextChanged += new System.EventHandler(this.TxtTextChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(15, 343);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(81, 17);
			this.label8.TabIndex = 21;
			this.label8.Text = "Description :";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Location = new System.Drawing.Point(10, 458);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.groupBox2.Size = new System.Drawing.Size(450, 7);
			this.groupBox2.TabIndex = 23;
			this.groupBox2.TabStop = false;
			// 
			// btClearColor
			// 
			this.btClearColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btClearColor.Image = global::RedisManagementStudio.Properties.Resources.Delete12;
			this.btClearColor.Location = new System.Drawing.Point(273, 302);
			this.btClearColor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btClearColor.Name = "btClearColor";
			this.btClearColor.Size = new System.Drawing.Size(30, 25);
			this.btClearColor.TabIndex = 24;
			this.btClearColor.UseVisualStyleBackColor = true;
			this.btClearColor.Click += new System.EventHandler(this.BtClearColorClick);
			// 
			// FConnexion
			// 
			this.AcceptButton = this.btOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btCancel;
			this.ClientSize = new System.Drawing.Size(476, 515);
			this.Controls.Add(this.btClearColor);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.pnlColor);
			this.Controls.Add(this.btChooseColor);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.cbBaseId);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtUrl);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btOk);
			this.Controls.Add(this.btCancel);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(447, 500);
			this.Name = "FConnexion";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Connexion";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FConnexionFormClosed);
			this.Load += new System.EventHandler(this.FConnexionLoad);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.Button btOk;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.TextBox txtUrl;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtPort;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox cbBaseId;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Button btChooseColor;
    private System.Windows.Forms.Panel pnlColor;
    private System.Windows.Forms.TextBox txtDescription;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.ColorDialog colorDialog1;
    private System.Windows.Forms.Button btClearColor;
  }
}