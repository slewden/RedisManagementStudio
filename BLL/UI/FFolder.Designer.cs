namespace RedisManagementStudio.BLL.UI
{
  partial class FFolder
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FFolder));
      this.btOk = new System.Windows.Forms.Button();
      this.btCancel = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.txtDescription = new System.Windows.Forms.TextBox();
      this.tvParent = new System.Windows.Forms.TreeView();
      this.imageList1 = new System.Windows.Forms.ImageList(this.components);
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // btOk
      // 
      this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btOk.Location = new System.Drawing.Point(263, 420);
      this.btOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btOk.Name = "btOk";
      this.btOk.Size = new System.Drawing.Size(87, 30);
      this.btOk.TabIndex = 0;
      this.btOk.Text = "Enregistrer";
      this.btOk.UseVisualStyleBackColor = true;
      this.btOk.Click += new System.EventHandler(this.BtOkClick);
      // 
      // btCancel
      // 
      this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btCancel.Location = new System.Drawing.Point(357, 420);
      this.btCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btCancel.Name = "btCancel";
      this.btCancel.Size = new System.Drawing.Size(87, 30);
      this.btCancel.TabIndex = 1;
      this.btCancel.Text = "Annuler";
      this.btCancel.UseVisualStyleBackColor = true;
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.Location = new System.Drawing.Point(58, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(386, 60);
      this.label1.TabIndex = 2;
      this.label1.Text = "Spécifier le nom et la description du groupe de connexions. Le groupe de connexio" +
    "n peut être stocké à la racine ou en tant que sous-groupe d\'un autre groupe de c" +
    "onnexions.";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::RedisManagementStudio.Properties.Resources.Folder32;
      this.pictureBox1.Location = new System.Drawing.Point(14, 16);
      this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(44, 44);
      this.pictureBox1.TabIndex = 3;
      this.pictureBox1.TabStop = false;
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Location = new System.Drawing.Point(14, 80);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBox1.Size = new System.Drawing.Size(427, 4);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(16, 108);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(110, 17);
      this.label2.TabIndex = 5;
      this.label2.Text = "Nom du groupe :";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(16, 155);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(81, 17);
      this.label3.TabIndex = 6;
      this.label3.Text = "Description :";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(16, 226);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(229, 17);
      this.label4.TabIndex = 7;
      this.label4.Text = "Sélectionnez un emplacement parent :";
      // 
      // txtName
      // 
      this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtName.Location = new System.Drawing.Point(122, 105);
      this.txtName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.txtName.Name = "txtName";
      this.txtName.Size = new System.Drawing.Size(318, 25);
      this.txtName.TabIndex = 8;
      this.txtName.TextChanged += new System.EventHandler(this.TxtTextChanged);
      // 
      // txtDescription
      // 
      this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtDescription.Location = new System.Drawing.Point(122, 152);
      this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.txtDescription.Multiline = true;
      this.txtDescription.Name = "txtDescription";
      this.txtDescription.Size = new System.Drawing.Size(318, 56);
      this.txtDescription.TabIndex = 9;
      this.txtDescription.TextChanged += new System.EventHandler(this.TxtTextChanged);
      // 
      // tvParent
      // 
      this.tvParent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tvParent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tvParent.FullRowSelect = true;
      this.tvParent.HideSelection = false;
      this.tvParent.ImageIndex = 0;
      this.tvParent.ImageList = this.imageList1;
      this.tvParent.Location = new System.Drawing.Point(19, 247);
      this.tvParent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.tvParent.Name = "tvParent";
      this.tvParent.SelectedImageIndex = 0;
      this.tvParent.Size = new System.Drawing.Size(422, 147);
      this.tvParent.TabIndex = 10;
      this.tvParent.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvParentAfterSelect);
      // 
      // imageList1
      // 
      this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
      this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList1.Images.SetKeyName(0, "Folder");
      this.imageList1.Images.SetKeyName(1, "FolderSel");
      this.imageList1.Images.SetKeyName(2, "Connection");
      this.imageList1.Images.SetKeyName(3, "ConnectionSel");
      // 
      // groupBox2
      // 
      this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox2.Location = new System.Drawing.Point(14, 408);
      this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupBox2.Size = new System.Drawing.Size(427, 4);
      this.groupBox2.TabIndex = 11;
      this.groupBox2.TabStop = false;
      // 
      // FFolder
      // 
      this.AcceptButton = this.btOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btCancel;
      this.ClientSize = new System.Drawing.Size(459, 466);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.tvParent);
      this.Controls.Add(this.txtDescription);
      this.Controls.Add(this.txtName);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btCancel);
      this.Controls.Add(this.btOk);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(563, 600);
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(447, 427);
      this.Name = "FFolder";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Groupe de connexions";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FFolder_FormClosed);
      this.Load += new System.EventHandler(this.FFolder_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btOk;
    private System.Windows.Forms.Button btCancel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.TextBox txtDescription;
    private System.Windows.Forms.TreeView tvParent;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.ImageList imageList1;
  }
}