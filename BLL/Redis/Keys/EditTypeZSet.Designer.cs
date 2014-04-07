namespace RedisManagementStudio.BLL.Redis.Keys
{
  partial class EditTypeZSet
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.lblCount = new System.Windows.Forms.Label();
      this.txtIndexMax = new RedisManagementStudio.BLL.UI.NumericTextBox();
      this.txtIndexMin = new RedisManagementStudio.BLL.UI.NumericTextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.btRefreshList = new System.Windows.Forms.Button();
      this.lstValues = new System.Windows.Forms.ListView();
      this.colMember = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.panel2 = new System.Windows.Forms.Panel();
      this.label3 = new System.Windows.Forms.Label();
      this.lblEdition = new System.Windows.Forms.Label();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.lblCurrentMember = new System.Windows.Forms.TextBox();
      this.txtNewMember = new System.Windows.Forms.TextBox();
      this.btDecr = new System.Windows.Forms.Button();
      this.lblCurrentScore = new System.Windows.Forms.TextBox();
      this.btIncr = new System.Windows.Forms.Button();
      this.txtNewScore = new RedisManagementStudio.BLL.UI.NumericTextBox();
      this.btAdd = new System.Windows.Forms.Button();
      this.btDelete = new System.Windows.Forms.Button();
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.White;
      this.panel1.Controls.Add(this.lblCount);
      this.panel1.Controls.Add(this.txtIndexMax);
      this.panel1.Controls.Add(this.txtIndexMin);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.btRefreshList);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(502, 38);
      this.panel1.TabIndex = 8;
      // 
      // lblCount
      // 
      this.lblCount.AutoSize = true;
      this.lblCount.Location = new System.Drawing.Point(355, 8);
      this.lblCount.Name = "lblCount";
      this.lblCount.Size = new System.Drawing.Size(20, 17);
      this.lblCount.TabIndex = 12;
      this.lblCount.Text = "xx";
      // 
      // txtIndexMax
      // 
      this.txtIndexMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtIndexMax.DefaultIntValue = -1;
      this.txtIndexMax.DoubleValue = double.NaN;
      this.txtIndexMax.IntValue = -1;
      this.txtIndexMax.Location = new System.Drawing.Point(289, 4);
      this.txtIndexMax.Name = "txtIndexMax";
      this.txtIndexMax.Size = new System.Drawing.Size(60, 25);
      this.txtIndexMax.TabIndex = 11;
      this.txtIndexMax.TextChanged += new System.EventHandler(this.TxtIndexTextChanged);
      // 
      // txtIndexMin
      // 
      this.txtIndexMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtIndexMin.DefaultIntValue = -1;
      this.txtIndexMin.DoubleValue = double.NaN;
      this.txtIndexMin.IntValue = -1;
      this.txtIndexMin.Location = new System.Drawing.Point(132, 4);
      this.txtIndexMin.Name = "txtIndexMin";
      this.txtIndexMin.Size = new System.Drawing.Size(60, 25);
      this.txtIndexMin.TabIndex = 10;
      this.txtIndexMin.TextChanged += new System.EventHandler(this.TxtIndexTextChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(216, 8);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(67, 17);
      this.label4.TabIndex = 8;
      this.label4.Text = "à l\'index : ";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(3, 8);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(123, 17);
      this.label2.TabIndex = 7;
      this.label2.Text = "Afficher de l\'index : ";
      // 
      // btRefreshList
      // 
      this.btRefreshList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btRefreshList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btRefreshList.Image = global::RedisManagementStudio.Properties.Resources.Refresh;
      this.btRefreshList.Location = new System.Drawing.Point(477, 4);
      this.btRefreshList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btRefreshList.Name = "btRefreshList";
      this.btRefreshList.Size = new System.Drawing.Size(25, 25);
      this.btRefreshList.TabIndex = 5;
      this.btRefreshList.UseVisualStyleBackColor = true;
      this.btRefreshList.Click += new System.EventHandler(this.BtRefreshListClick);
      // 
      // lstValues
      // 
      this.lstValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lstValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMember,
            this.colScore});
      this.lstValues.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lstValues.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.lstValues.FullRowSelect = true;
      this.lstValues.HideSelection = false;
      this.lstValues.LabelWrap = false;
      this.lstValues.Location = new System.Drawing.Point(0, 38);
      this.lstValues.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.lstValues.MultiSelect = false;
      this.lstValues.Name = "lstValues";
      this.lstValues.ShowGroups = false;
      this.lstValues.Size = new System.Drawing.Size(502, 277);
      this.lstValues.TabIndex = 9;
      this.lstValues.UseCompatibleStateImageBehavior = false;
      this.lstValues.View = System.Windows.Forms.View.Details;
      this.lstValues.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.LstValuesColumnClick);
      this.lstValues.SelectedIndexChanged += new System.EventHandler(this.LstValuesSelectedIndexChanged);
      // 
      // colMember
      // 
      this.colMember.Text = "Membre";
      this.colMember.Width = 300;
      // 
      // colScore
      // 
      this.colScore.Text = "Score";
      this.colScore.Width = 100;
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.Color.White;
      this.panel2.Controls.Add(this.label3);
      this.panel2.Controls.Add(this.lblEdition);
      this.panel2.Controls.Add(this.splitContainer1);
      this.panel2.Controls.Add(this.btAdd);
      this.panel2.Controls.Add(this.btDelete);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 315);
      this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(502, 93);
      this.panel2.TabIndex = 10;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(3, 13);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(67, 17);
      this.label3.TabIndex = 6;
      this.label3.Text = "Sélection :";
      // 
      // lblEdition
      // 
      this.lblEdition.AutoSize = true;
      this.lblEdition.Location = new System.Drawing.Point(3, 62);
      this.lblEdition.Name = "lblEdition";
      this.lblEdition.Size = new System.Drawing.Size(57, 17);
      this.lblEdition.TabIndex = 5;
      this.lblEdition.Text = "Ajouter :";
      // 
      // splitContainer1
      // 
      this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.splitContainer1.Location = new System.Drawing.Point(76, 0);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.lblCurrentMember);
      this.splitContainer1.Panel1.Controls.Add(this.txtNewMember);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.btDecr);
      this.splitContainer1.Panel2.Controls.Add(this.lblCurrentScore);
      this.splitContainer1.Panel2.Controls.Add(this.btIncr);
      this.splitContainer1.Panel2.Controls.Add(this.txtNewScore);
      this.splitContainer1.Size = new System.Drawing.Size(397, 90);
      this.splitContainer1.SplitterDistance = 278;
      this.splitContainer1.TabIndex = 4;
      // 
      // lblCurrentMember
      // 
      this.lblCurrentMember.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblCurrentMember.BackColor = System.Drawing.Color.White;
      this.lblCurrentMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblCurrentMember.Location = new System.Drawing.Point(0, 9);
      this.lblCurrentMember.Name = "lblCurrentMember";
      this.lblCurrentMember.ReadOnly = true;
      this.lblCurrentMember.Size = new System.Drawing.Size(277, 25);
      this.lblCurrentMember.TabIndex = 4;
      // 
      // txtNewMember
      // 
      this.txtNewMember.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtNewMember.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtNewMember.Location = new System.Drawing.Point(0, 60);
      this.txtNewMember.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.txtNewMember.Name = "txtNewMember";
      this.txtNewMember.Size = new System.Drawing.Size(277, 25);
      this.txtNewMember.TabIndex = 3;
      this.txtNewMember.TextChanged += new System.EventHandler(this.TxtNewMemberTextChanged);
      // 
      // btDecr
      // 
      this.btDecr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btDecr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btDecr.Image = global::RedisManagementStudio.Properties.Resources.Decrement;
      this.btDecr.Location = new System.Drawing.Point(90, 60);
      this.btDecr.Name = "btDecr";
      this.btDecr.Size = new System.Drawing.Size(25, 25);
      this.btDecr.TabIndex = 2;
      this.btDecr.UseVisualStyleBackColor = true;
      this.btDecr.Click += new System.EventHandler(this.BtDecrClick);
      // 
      // lblCurrentScore
      // 
      this.lblCurrentScore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblCurrentScore.BackColor = System.Drawing.Color.White;
      this.lblCurrentScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblCurrentScore.Location = new System.Drawing.Point(0, 9);
      this.lblCurrentScore.Name = "lblCurrentScore";
      this.lblCurrentScore.ReadOnly = true;
      this.lblCurrentScore.Size = new System.Drawing.Size(115, 25);
      this.lblCurrentScore.TabIndex = 1;
      // 
      // btIncr
      // 
      this.btIncr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btIncr.Image = global::RedisManagementStudio.Properties.Resources.Increment;
      this.btIncr.Location = new System.Drawing.Point(2, 60);
      this.btIncr.Name = "btIncr";
      this.btIncr.Size = new System.Drawing.Size(25, 25);
      this.btIncr.TabIndex = 1;
      this.btIncr.UseVisualStyleBackColor = true;
      this.btIncr.Click += new System.EventHandler(this.BtIncrClick);
      // 
      // txtNewScore
      // 
      this.txtNewScore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtNewScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtNewScore.DoubleValue = 1D;
      this.txtNewScore.IntegerOnly = false;
      this.txtNewScore.IntValue = 1;
      this.txtNewScore.Location = new System.Drawing.Point(29, 60);
      this.txtNewScore.Name = "txtNewScore";
      this.txtNewScore.Size = new System.Drawing.Size(58, 25);
      this.txtNewScore.TabIndex = 0;
      this.txtNewScore.Text = "1";
      this.txtNewScore.TextChanged += new System.EventHandler(this.TxtNewValueTextChanged);
      // 
      // btAdd
      // 
      this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btAdd.Image = global::RedisManagementStudio.Properties.Resources.Add;
      this.btAdd.Location = new System.Drawing.Point(479, 60);
      this.btAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btAdd.Name = "btAdd";
      this.btAdd.Size = new System.Drawing.Size(23, 25);
      this.btAdd.TabIndex = 1;
      this.btAdd.UseVisualStyleBackColor = true;
      this.btAdd.Click += new System.EventHandler(this.BtAddClick);
      // 
      // btDelete
      // 
      this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btDelete.Image = global::RedisManagementStudio.Properties.Resources.Delete12;
      this.btDelete.Location = new System.Drawing.Point(479, 9);
      this.btDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btDelete.Name = "btDelete";
      this.btDelete.Size = new System.Drawing.Size(23, 25);
      this.btDelete.TabIndex = 4;
      this.btDelete.UseVisualStyleBackColor = true;
      this.btDelete.Click += new System.EventHandler(this.BtDeleteClick);
      // 
      // errorProvider1
      // 
      this.errorProvider1.ContainerControl = this;
      // 
      // EditTypeZSet
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lstValues);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.panel1);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "EditTypeZSet";
      this.Size = new System.Drawing.Size(502, 408);
      this.VisibleChanged += new System.EventHandler(this.EditTypeZSetVisibleChanged);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label lblCount;
    private UI.NumericTextBox txtIndexMax;
    private UI.NumericTextBox txtIndexMin;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btRefreshList;
    private System.Windows.Forms.ListView lstValues;
    private System.Windows.Forms.ColumnHeader colMember;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label lblEdition;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.TextBox lblCurrentMember;
    private System.Windows.Forms.TextBox txtNewMember;
    private System.Windows.Forms.TextBox lblCurrentScore;
    private System.Windows.Forms.Button btAdd;
    private System.Windows.Forms.Button btDelete;
    private System.Windows.Forms.Button btDecr;
    private System.Windows.Forms.Button btIncr;
    private UI.NumericTextBox txtNewScore;
    private System.Windows.Forms.ColumnHeader colScore;
    private System.Windows.Forms.ErrorProvider errorProvider1;
    private System.Windows.Forms.ToolTip toolTip1;
  }
}
