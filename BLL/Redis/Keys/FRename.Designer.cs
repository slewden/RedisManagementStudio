namespace RedisManagementStudio.BLL.Redis.Keys
{
  partial class FRename
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
      this.label2 = new System.Windows.Forms.Label();
      this.txtOld = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.txtNew = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // btCancel
      // 
      this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btCancel.Location = new System.Drawing.Point(292, 113);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(75, 28);
      this.btCancel.TabIndex = 13;
      this.btCancel.Text = "Annuler";
      this.btCancel.UseVisualStyleBackColor = true;
      // 
      // btOk
      // 
      this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btOk.Location = new System.Drawing.Point(211, 113);
      this.btOk.Name = "btOk";
      this.btOk.Size = new System.Drawing.Size(75, 28);
      this.btOk.TabIndex = 12;
      this.btOk.Text = "Ajouter";
      this.btOk.UseVisualStyleBackColor = true;
      this.btOk.Click += new System.EventHandler(this.BtOkClick);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 22);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(90, 13);
      this.label2.TabIndex = 14;
      this.label2.Text = "Ancienne valeur :";
      // 
      // txtOld
      // 
      this.txtOld.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtOld.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtOld.Location = new System.Drawing.Point(108, 20);
      this.txtOld.Name = "txtOld";
      this.txtOld.ReadOnly = true;
      this.txtOld.Size = new System.Drawing.Size(259, 13);
      this.txtOld.TabIndex = 15;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 50);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(87, 13);
      this.label1.TabIndex = 16;
      this.label1.Text = "Nouvelle valeur :";
      // 
      // txtNew
      // 
      this.txtNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtNew.Location = new System.Drawing.Point(108, 48);
      this.txtNew.Name = "txtNew";
      this.txtNew.Size = new System.Drawing.Size(259, 20);
      this.txtNew.TabIndex = 17;
      this.txtNew.TextChanged += new System.EventHandler(this.TxtNewTextChanged);
      // 
      // FRename
      // 
      this.AcceptButton = this.btOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btOk;
      this.ClientSize = new System.Drawing.Size(379, 153);
      this.Controls.Add(this.btCancel);
      this.Controls.Add(this.btOk);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtOld);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtNew);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(300, 165);
      this.Name = "FRename";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "FRename";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FRename_FormClosed);
      this.Load += new System.EventHandler(this.FRename_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.Button btOk;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtOld;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtNew;
  }
}