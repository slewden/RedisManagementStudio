namespace RedisManagementStudio.BLL.Keys
{
  partial class EditTypeList
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
      this.lstValues = new System.Windows.Forms.ListView();
      this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.panel2 = new System.Windows.Forms.Panel();
      this.lblCurrentValue = new System.Windows.Forms.TextBox();
      this.cbNewAction = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtNewValue = new System.Windows.Forms.TextBox();
      this.btAdd = new System.Windows.Forms.Button();
      this.btDelete = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.lblCount = new System.Windows.Forms.Label();
      this.txtIndexMax = new RedisManagementStudio.BLL.UI.NumericTextBox();
      this.txtIndexMin = new RedisManagementStudio.BLL.UI.NumericTextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.btRefreshList = new System.Windows.Forms.Button();
      this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
      this.SuspendLayout();
      // 
      // lstValues
      // 
      this.lstValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lstValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colValue});
      this.lstValues.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lstValues.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.lstValues.FullRowSelect = true;
      this.lstValues.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.lstValues.HideSelection = false;
      this.lstValues.LabelWrap = false;
      this.lstValues.Location = new System.Drawing.Point(0, 38);
      this.lstValues.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.lstValues.MultiSelect = false;
      this.lstValues.Name = "lstValues";
      this.lstValues.ShowGroups = false;
      this.lstValues.Size = new System.Drawing.Size(502, 277);
      this.lstValues.TabIndex = 3;
      this.lstValues.UseCompatibleStateImageBehavior = false;
      this.lstValues.View = System.Windows.Forms.View.Details;
      this.lstValues.SelectedIndexChanged += new System.EventHandler(this.LstValuesSelectedIndexChanged);
      // 
      // colValue
      // 
      this.colValue.Text = "Valeurs";
      this.colValue.Width = 200;
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.Color.White;
      this.panel2.Controls.Add(this.lblCurrentValue);
      this.panel2.Controls.Add(this.cbNewAction);
      this.panel2.Controls.Add(this.label3);
      this.panel2.Controls.Add(this.txtNewValue);
      this.panel2.Controls.Add(this.btAdd);
      this.panel2.Controls.Add(this.btDelete);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 315);
      this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(502, 93);
      this.panel2.TabIndex = 6;
      // 
      // lblCurrentValue
      // 
      this.lblCurrentValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblCurrentValue.BackColor = System.Drawing.Color.White;
      this.lblCurrentValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblCurrentValue.Location = new System.Drawing.Point(156, 9);
      this.lblCurrentValue.Name = "lblCurrentValue";
      this.lblCurrentValue.ReadOnly = true;
      this.lblCurrentValue.Size = new System.Drawing.Size(309, 25);
      this.lblCurrentValue.TabIndex = 10;
      // 
      // cbNewAction
      // 
      this.cbNewAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbNewAction.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbNewAction.FormattingEnabled = true;
      this.cbNewAction.Items.AddRange(new object[] {
            "Ajouter",
            "Modifier sélection",
            "Insérer avant sélection",
            "Insérer après sélection"});
      this.cbNewAction.Location = new System.Drawing.Point(6, 60);
      this.cbNewAction.Name = "cbNewAction";
      this.cbNewAction.Size = new System.Drawing.Size(144, 25);
      this.cbNewAction.TabIndex = 9;
      this.cbNewAction.SelectedIndexChanged += new System.EventHandler(this.NewElementChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(3, 13);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(67, 17);
      this.label3.TabIndex = 7;
      this.label3.Text = "Sélection :";
      // 
      // txtNewValue
      // 
      this.txtNewValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtNewValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtNewValue.Location = new System.Drawing.Point(156, 60);
      this.txtNewValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.txtNewValue.Name = "txtNewValue";
      this.txtNewValue.Size = new System.Drawing.Size(309, 25);
      this.txtNewValue.TabIndex = 0;
      this.txtNewValue.TextChanged += new System.EventHandler(this.NewElementChanged);
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
      this.panel1.TabIndex = 7;
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
      this.btRefreshList.Location = new System.Drawing.Point(479, 4);
      this.btRefreshList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btRefreshList.Name = "btRefreshList";
      this.btRefreshList.Size = new System.Drawing.Size(23, 25);
      this.btRefreshList.TabIndex = 5;
      this.btRefreshList.UseVisualStyleBackColor = true;
      this.btRefreshList.Click += new System.EventHandler(this.BtRefreshListClick);
      // 
      // errorProvider1
      // 
      this.errorProvider1.ContainerControl = this;
      // 
      // EditTypeList
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lstValues);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.panel2);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "EditTypeList";
      this.Size = new System.Drawing.Size(502, 408);
      this.SizeChanged += new System.EventHandler(this.EditTypeSetSizeChanged);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListView lstValues;
    private System.Windows.Forms.ColumnHeader colValue;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtNewValue;
    private System.Windows.Forms.Button btAdd;
    private System.Windows.Forms.Button btDelete;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btRefreshList;
    private System.Windows.Forms.ComboBox cbNewAction;
    private UI.NumericTextBox txtIndexMax;
    private UI.NumericTextBox txtIndexMin;
    private System.Windows.Forms.ErrorProvider errorProvider1;
    private System.Windows.Forms.Label lblCount;
    private System.Windows.Forms.TextBox lblCurrentValue;
  }
}
