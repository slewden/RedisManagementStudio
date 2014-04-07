namespace RedisManagementStudio.BLL.Keys
{
  partial class EditTypeSet
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
      this.label1 = new System.Windows.Forms.Label();
      this.btAdd = new System.Windows.Forms.Button();
      this.txtNewValue = new System.Windows.Forms.TextBox();
      this.lstValues = new System.Windows.Forms.ListView();
      this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.panel2 = new System.Windows.Forms.Panel();
      this.lblCurrentValue = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.btDelete = new System.Windows.Forms.Button();
      this.pnlSearch = new System.Windows.Forms.Panel();
      this.label2 = new System.Windows.Forms.Label();
      this.btSearch = new System.Windows.Forms.Button();
      this.txtSearch = new System.Windows.Forms.TextBox();
      this.panel2.SuspendLayout();
      this.pnlSearch.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(3, 64);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(57, 17);
      this.label1.TabIndex = 2;
      this.label1.Text = "Ajouter :";
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
      // txtNewValue
      // 
      this.txtNewValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtNewValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtNewValue.Location = new System.Drawing.Point(76, 60);
      this.txtNewValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.txtNewValue.Name = "txtNewValue";
      this.txtNewValue.Size = new System.Drawing.Size(389, 25);
      this.txtNewValue.TabIndex = 0;
      this.txtNewValue.TextChanged += new System.EventHandler(this.TxtNewValueTextChanged);
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
      this.lstValues.Location = new System.Drawing.Point(0, 0);
      this.lstValues.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.lstValues.MultiSelect = false;
      this.lstValues.Name = "lstValues";
      this.lstValues.ShowGroups = false;
      this.lstValues.Size = new System.Drawing.Size(502, 273);
      this.lstValues.TabIndex = 2;
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
      this.panel2.Controls.Add(this.label3);
      this.panel2.Controls.Add(this.label1);
      this.panel2.Controls.Add(this.txtNewValue);
      this.panel2.Controls.Add(this.btAdd);
      this.panel2.Controls.Add(this.btDelete);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 315);
      this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(502, 93);
      this.panel2.TabIndex = 5;
      // 
      // lblCurrentValue
      // 
      this.lblCurrentValue.BackColor = System.Drawing.Color.White;
      this.lblCurrentValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblCurrentValue.Location = new System.Drawing.Point(77, 9);
      this.lblCurrentValue.Name = "lblCurrentValue";
      this.lblCurrentValue.ReadOnly = true;
      this.lblCurrentValue.Size = new System.Drawing.Size(388, 25);
      this.lblCurrentValue.TabIndex = 8;
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
      // pnlSearch
      // 
      this.pnlSearch.BackColor = System.Drawing.Color.White;
      this.pnlSearch.Controls.Add(this.label2);
      this.pnlSearch.Controls.Add(this.btSearch);
      this.pnlSearch.Controls.Add(this.txtSearch);
      this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnlSearch.Location = new System.Drawing.Point(0, 273);
      this.pnlSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.pnlSearch.Name = "pnlSearch";
      this.pnlSearch.Size = new System.Drawing.Size(502, 42);
      this.pnlSearch.TabIndex = 6;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(3, 12);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(100, 17);
      this.label2.TabIndex = 2;
      this.label2.Text = "Est il présent ? :";
      // 
      // btSearch
      // 
      this.btSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btSearch.Image = global::RedisManagementStudio.Properties.Resources.Search;
      this.btSearch.Location = new System.Drawing.Point(479, 7);
      this.btSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btSearch.Name = "btSearch";
      this.btSearch.Size = new System.Drawing.Size(23, 25);
      this.btSearch.TabIndex = 1;
      this.btSearch.UseVisualStyleBackColor = true;
      this.btSearch.Click += new System.EventHandler(this.BtSearchClick);
      // 
      // txtSearch
      // 
      this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtSearch.Location = new System.Drawing.Point(106, 7);
      this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.txtSearch.Name = "txtSearch";
      this.txtSearch.Size = new System.Drawing.Size(359, 25);
      this.txtSearch.TabIndex = 0;
      this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearchTextChanged);
      // 
      // EditTypeSet
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lstValues);
      this.Controls.Add(this.pnlSearch);
      this.Controls.Add(this.panel2);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "EditTypeSet";
      this.Size = new System.Drawing.Size(502, 408);
      this.SizeChanged += new System.EventHandler(this.EditTypeSetSizeChanged);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.pnlSearch.ResumeLayout(false);
      this.pnlSearch.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btAdd;
    private System.Windows.Forms.TextBox txtNewValue;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ListView lstValues;
    private System.Windows.Forms.Button btDelete;
    private System.Windows.Forms.ColumnHeader colValue;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Panel pnlSearch;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btSearch;
    private System.Windows.Forms.TextBox txtSearch;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox lblCurrentValue;
  }
}
