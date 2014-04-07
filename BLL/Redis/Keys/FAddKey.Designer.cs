namespace RedisManagementStudio.BLL.Redis.Keys
{
  partial class FAddKey
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAddKey));
      this.btOk = new System.Windows.Forms.Button();
      this.btCancel = new System.Windows.Forms.Button();
      this.cbType = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.lblValue1 = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.lblValue2 = new System.Windows.Forms.Label();
      this.txtValeur1 = new System.Windows.Forms.TextBox();
      this.txtValeur2 = new System.Windows.Forms.TextBox();
      this.txtCle = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      this.chkPlayAgain = new System.Windows.Forms.CheckBox();
      this.lblCounter = new System.Windows.Forms.Label();
      this.numericTextBox1 = new RedisManagementStudio.BLL.UI.NumericTextBox();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      this.SuspendLayout();
      // 
      // btOk
      // 
      this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btOk.Location = new System.Drawing.Point(223, 175);
      this.btOk.Name = "btOk";
      this.btOk.Size = new System.Drawing.Size(75, 28);
      this.btOk.TabIndex = 10;
      this.btOk.Text = "Ajouter";
      this.btOk.UseVisualStyleBackColor = true;
      this.btOk.Click += new System.EventHandler(this.BtOkClick);
      // 
      // btCancel
      // 
      this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btCancel.Location = new System.Drawing.Point(304, 175);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(75, 28);
      this.btCancel.TabIndex = 11;
      this.btCancel.Text = "Annuler";
      this.btCancel.UseVisualStyleBackColor = true;
      // 
      // cbType
      // 
      this.cbType.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cbType.FormattingEnabled = true;
      this.cbType.Location = new System.Drawing.Point(0, 0);
      this.cbType.Name = "cbType";
      this.cbType.Size = new System.Drawing.Size(279, 25);
      this.cbType.TabIndex = 4;
      this.cbType.SelectedIndexChanged += new System.EventHandler(this.CbTypeSelectedIndexChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 47);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(43, 17);
      this.label1.TabIndex = 2;
      this.label1.Text = "Type :";
      // 
      // lblValue1
      // 
      this.lblValue1.AutoSize = true;
      this.lblValue1.Location = new System.Drawing.Point(12, 92);
      this.lblValue1.Name = "lblValue1";
      this.lblValue1.Size = new System.Drawing.Size(52, 17);
      this.lblValue1.TabIndex = 5;
      this.lblValue1.Text = "Valeur :";
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.cbType);
      this.panel1.Location = new System.Drawing.Point(81, 43);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(281, 25);
      this.panel1.TabIndex = 3;
      // 
      // lblValue2
      // 
      this.lblValue2.AutoSize = true;
      this.lblValue2.Location = new System.Drawing.Point(13, 123);
      this.lblValue2.Name = "lblValue2";
      this.lblValue2.Size = new System.Drawing.Size(48, 17);
      this.lblValue2.TabIndex = 7;
      this.lblValue2.Text = "Score :";
      // 
      // txtValeur1
      // 
      this.txtValeur1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtValeur1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtValeur1.Location = new System.Drawing.Point(81, 90);
      this.txtValeur1.Name = "txtValeur1";
      this.txtValeur1.Size = new System.Drawing.Size(281, 25);
      this.txtValeur1.TabIndex = 6;
      this.txtValeur1.TextChanged += new System.EventHandler(this.TxtValeurTextChanged);
      // 
      // txtValeur2
      // 
      this.txtValeur2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtValeur2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtValeur2.Location = new System.Drawing.Point(81, 121);
      this.txtValeur2.Name = "txtValeur2";
      this.txtValeur2.Size = new System.Drawing.Size(281, 25);
      this.txtValeur2.TabIndex = 8;
      this.txtValeur2.TextChanged += new System.EventHandler(this.TxtValeurTextChanged);
      // 
      // txtCle
      // 
      this.txtCle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtCle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtCle.Location = new System.Drawing.Point(81, 12);
      this.txtCle.Name = "txtCle";
      this.txtCle.Size = new System.Drawing.Size(281, 25);
      this.txtCle.TabIndex = 1;
      this.txtCle.TextChanged += new System.EventHandler(this.TxtValeurTextChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(13, 14);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(33, 17);
      this.label2.TabIndex = 0;
      this.label2.Text = "Clé :";
      // 
      // errorProvider1
      // 
      this.errorProvider1.ContainerControl = this;
      // 
      // chkPlayAgain
      // 
      this.chkPlayAgain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.chkPlayAgain.AutoSize = true;
      this.chkPlayAgain.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.chkPlayAgain.Location = new System.Drawing.Point(16, 195);
      this.chkPlayAgain.Name = "chkPlayAgain";
      this.chkPlayAgain.Size = new System.Drawing.Size(131, 17);
      this.chkPlayAgain.TabIndex = 12;
      this.chkPlayAgain.Text = "Ajouter d\'autres clés";
      this.chkPlayAgain.UseVisualStyleBackColor = true;
      // 
      // lblCounter
      // 
      this.lblCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.lblCounter.AutoSize = true;
      this.lblCounter.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblCounter.Location = new System.Drawing.Point(13, 179);
      this.lblCounter.Name = "lblCounter";
      this.lblCounter.Size = new System.Drawing.Size(22, 13);
      this.lblCounter.TabIndex = 13;
      this.lblCounter.Text = "xxx";
      // 
      // numericTextBox1
      // 
      this.numericTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.numericTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.numericTextBox1.DefaultDoubleValue = 0D;
      this.numericTextBox1.DoubleValue = 0D;
      this.numericTextBox1.IntegerOnly = false;
      this.numericTextBox1.Location = new System.Drawing.Point(81, 121);
      this.numericTextBox1.Name = "numericTextBox1";
      this.numericTextBox1.Size = new System.Drawing.Size(281, 25);
      this.numericTextBox1.TabIndex = 9;
      this.numericTextBox1.TextChanged += new System.EventHandler(this.TxtValeurTextChanged);
      // 
      // FAddKey
      // 
      this.AcceptButton = this.btOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btCancel;
      this.ClientSize = new System.Drawing.Size(391, 215);
      this.Controls.Add(this.lblCounter);
      this.Controls.Add(this.chkPlayAgain);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtCle);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.lblValue1);
      this.Controls.Add(this.txtValeur1);
      this.Controls.Add(this.lblValue2);
      this.Controls.Add(this.txtValeur2);
      this.Controls.Add(this.numericTextBox1);
      this.Controls.Add(this.btCancel);
      this.Controls.Add(this.btOk);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(300, 236);
      this.Name = "FAddKey";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "FAddKey";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FAddKey_FormClosed);
      this.Load += new System.EventHandler(this.FAddKey_Load);
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btOk;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.ComboBox cbType;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lblValue1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label lblValue2;
    private System.Windows.Forms.TextBox txtValeur1;
    private System.Windows.Forms.TextBox txtValeur2;
    private System.Windows.Forms.TextBox txtCle;
    private System.Windows.Forms.Label label2;
    private UI.NumericTextBox numericTextBox1;
    private System.Windows.Forms.ErrorProvider errorProvider1;
    private System.Windows.Forms.CheckBox chkPlayAgain;
    private System.Windows.Forms.Label lblCounter;
  }
}