namespace RedisManagementStudio.BLL.Keys
{
  partial class EditTypeText
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
      this.cbTypeAffichage = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.lblDetail = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.pnlToolNumerique = new System.Windows.Forms.Panel();
      this.btDecr = new System.Windows.Forms.Button();
      this.btIncr = new System.Windows.Forms.Button();
      this.txtIncremValue = new RedisManagementStudio.BLL.UI.NumericTextBox();
      this.panel2 = new System.Windows.Forms.Panel();
      this.pnlSetBit = new System.Windows.Forms.Panel();
      this.btSetBit = new System.Windows.Forms.Button();
      this.chkSetBit = new System.Windows.Forms.CheckBox();
      this.txtSetBitOffset = new RedisManagementStudio.BLL.UI.NumericTextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.txtNewValue = new System.Windows.Forms.TextBox();
      this.btUpdate = new System.Windows.Forms.Button();
      this.lstValues = new System.Windows.Forms.ListView();
      this.colKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.panel1 = new System.Windows.Forms.Panel();
      this.lblWrongFormat = new System.Windows.Forms.Label();
      this.panel3 = new System.Windows.Forms.Panel();
      this.bitDisplay1 = new RedisManagementStudio.BLL.Keys.BitDisplay();
      this.pnlToolNumerique.SuspendLayout();
      this.panel2.SuspendLayout();
      this.pnlSetBit.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      // 
      // cbTypeAffichage
      // 
      this.cbTypeAffichage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbTypeAffichage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.cbTypeAffichage.FormattingEnabled = true;
      this.cbTypeAffichage.Items.AddRange(new object[] {
            "Valeur brute",
            "Numérique",
            "Champ de bit",
            "JSon"});
      this.cbTypeAffichage.Location = new System.Drawing.Point(90, 13);
      this.cbTypeAffichage.Name = "cbTypeAffichage";
      this.cbTypeAffichage.Size = new System.Drawing.Size(144, 25);
      this.cbTypeAffichage.TabIndex = 10;
      this.cbTypeAffichage.SelectedIndexChanged += new System.EventHandler(this.TypeAffichageSelectedIndexChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(15, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(69, 17);
      this.label1.TabIndex = 11;
      this.label1.Text = "Affichage :";
      // 
      // lblDetail
      // 
      this.lblDetail.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblDetail.Location = new System.Drawing.Point(88, 54);
      this.lblDetail.Name = "lblDetail";
      this.lblDetail.Size = new System.Drawing.Size(498, 408);
      this.lblDetail.TabIndex = 12;
      this.lblDetail.Text = "label2";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(15, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(52, 17);
      this.label2.TabIndex = 13;
      this.label2.Text = "Valeur :";
      // 
      // pnlToolNumerique
      // 
      this.pnlToolNumerique.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.pnlToolNumerique.BackColor = System.Drawing.Color.White;
      this.pnlToolNumerique.Controls.Add(this.btDecr);
      this.pnlToolNumerique.Controls.Add(this.btIncr);
      this.pnlToolNumerique.Controls.Add(this.txtIncremValue);
      this.pnlToolNumerique.Location = new System.Drawing.Point(511, 8);
      this.pnlToolNumerique.Name = "pnlToolNumerique";
      this.pnlToolNumerique.Size = new System.Drawing.Size(75, 29);
      this.pnlToolNumerique.TabIndex = 14;
      // 
      // btDecr
      // 
      this.btDecr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btDecr.Image = global::RedisManagementStudio.Properties.Resources.Decrement;
      this.btDecr.Location = new System.Drawing.Point(48, 0);
      this.btDecr.Name = "btDecr";
      this.btDecr.Size = new System.Drawing.Size(25, 25);
      this.btDecr.TabIndex = 2;
      this.btDecr.UseVisualStyleBackColor = true;
      this.btDecr.Click += new System.EventHandler(this.BtDecrClick);
      // 
      // btIncr
      // 
      this.btIncr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btIncr.Image = global::RedisManagementStudio.Properties.Resources.Increment;
      this.btIncr.Location = new System.Drawing.Point(0, 0);
      this.btIncr.Name = "btIncr";
      this.btIncr.Size = new System.Drawing.Size(25, 25);
      this.btIncr.TabIndex = 1;
      this.btIncr.UseVisualStyleBackColor = true;
      this.btIncr.Click += new System.EventHandler(this.BtIncrClick);
      // 
      // txtIncremValue
      // 
      this.txtIncremValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtIncremValue.IntValue = 1;
      this.txtIncremValue.Location = new System.Drawing.Point(27, 0);
      this.txtIncremValue.Name = "txtIncremValue";
      this.txtIncremValue.Size = new System.Drawing.Size(20, 25);
      this.txtIncremValue.TabIndex = 0;
      this.txtIncremValue.Text = "1";
      this.txtIncremValue.TextChanged += new System.EventHandler(this.TxtNewValueTextChanged);
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.Color.White;
      this.panel2.Controls.Add(this.pnlSetBit);
      this.panel2.Controls.Add(this.label4);
      this.panel2.Controls.Add(this.pnlToolNumerique);
      this.panel2.Controls.Add(this.txtNewValue);
      this.panel2.Controls.Add(this.btUpdate);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 462);
      this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(586, 72);
      this.panel2.TabIndex = 15;
      // 
      // pnlSetBit
      // 
      this.pnlSetBit.Controls.Add(this.btSetBit);
      this.pnlSetBit.Controls.Add(this.chkSetBit);
      this.pnlSetBit.Controls.Add(this.txtSetBitOffset);
      this.pnlSetBit.Controls.Add(this.label3);
      this.pnlSetBit.Location = new System.Drawing.Point(88, 8);
      this.pnlSetBit.Name = "pnlSetBit";
      this.pnlSetBit.Size = new System.Drawing.Size(200, 29);
      this.pnlSetBit.TabIndex = 15;
      // 
      // btSetBit
      // 
      this.btSetBit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btSetBit.Image = global::RedisManagementStudio.Properties.Resources.Save;
      this.btSetBit.Location = new System.Drawing.Point(172, 1);
      this.btSetBit.Name = "btSetBit";
      this.btSetBit.Size = new System.Drawing.Size(25, 25);
      this.btSetBit.TabIndex = 3;
      this.btSetBit.UseVisualStyleBackColor = true;
      this.btSetBit.Click += new System.EventHandler(this.BtSetBitClick);
      // 
      // chkSetBit
      // 
      this.chkSetBit.AutoSize = true;
      this.chkSetBit.Location = new System.Drawing.Point(91, 4);
      this.chkSetBit.Name = "chkSetBit";
      this.chkSetBit.Size = new System.Drawing.Size(66, 21);
      this.chkSetBit.TabIndex = 2;
      this.chkSetBit.Text = "Activer";
      this.chkSetBit.UseVisualStyleBackColor = true;
      this.chkSetBit.CheckedChanged += new System.EventHandler(this.SetBitOffsetTextChanged);
      // 
      // txtSetBitOffset
      // 
      this.txtSetBitOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtSetBitOffset.DefaultIntValue = -1;
      this.txtSetBitOffset.IntValue = -1;
      this.txtSetBitOffset.Location = new System.Drawing.Point(52, 0);
      this.txtSetBitOffset.Name = "txtSetBitOffset";
      this.txtSetBitOffset.Size = new System.Drawing.Size(32, 25);
      this.txtSetBitOffset.TabIndex = 1;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(3, 4);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(50, 17);
      this.label3.TabIndex = 0;
      this.label3.Text = "Offset :";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(3, 47);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(49, 17);
      this.label4.TabIndex = 2;
      this.label4.Text = "Editer :";
      // 
      // txtNewValue
      // 
      this.txtNewValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtNewValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtNewValue.Location = new System.Drawing.Point(88, 43);
      this.txtNewValue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.txtNewValue.Name = "txtNewValue";
      this.txtNewValue.Size = new System.Drawing.Size(469, 25);
      this.txtNewValue.TabIndex = 0;
      this.txtNewValue.TextChanged += new System.EventHandler(this.TxtNewValueTextChanged);
      // 
      // btUpdate
      // 
      this.btUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btUpdate.Image = global::RedisManagementStudio.Properties.Resources.Save;
      this.btUpdate.Location = new System.Drawing.Point(563, 43);
      this.btUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btUpdate.Name = "btUpdate";
      this.btUpdate.Size = new System.Drawing.Size(23, 25);
      this.btUpdate.TabIndex = 1;
      this.btUpdate.UseVisualStyleBackColor = true;
      this.btUpdate.Click += new System.EventHandler(this.BtUpdateClick);
      // 
      // lstValues
      // 
      this.lstValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lstValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colKey,
            this.colValue});
      this.lstValues.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lstValues.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.lstValues.FullRowSelect = true;
      this.lstValues.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.lstValues.HideSelection = false;
      this.lstValues.LabelWrap = false;
      this.lstValues.Location = new System.Drawing.Point(88, 54);
      this.lstValues.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.lstValues.MultiSelect = false;
      this.lstValues.Name = "lstValues";
      this.lstValues.ShowGroups = false;
      this.lstValues.Size = new System.Drawing.Size(498, 408);
      this.lstValues.TabIndex = 16;
      this.lstValues.UseCompatibleStateImageBehavior = false;
      this.lstValues.View = System.Windows.Forms.View.Details;
      // 
      // colKey
      // 
      this.colKey.Text = "Clé";
      this.colKey.Width = 140;
      // 
      // colValue
      // 
      this.colValue.Text = "Valeurs";
      this.colValue.Width = 200;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.lblWrongFormat);
      this.panel1.Controls.Add(this.cbTypeAffichage);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(586, 54);
      this.panel1.TabIndex = 17;
      // 
      // lblWrongFormat
      // 
      this.lblWrongFormat.AutoSize = true;
      this.lblWrongFormat.Location = new System.Drawing.Point(245, 16);
      this.lblWrongFormat.Name = "lblWrongFormat";
      this.lblWrongFormat.Size = new System.Drawing.Size(43, 17);
      this.lblWrongFormat.TabIndex = 12;
      this.lblWrongFormat.Text = "label5";
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.label2);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel3.Location = new System.Drawing.Point(0, 54);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(88, 408);
      this.panel3.TabIndex = 18;
      // 
      // bitDisplay1
      // 
      this.bitDisplay1.Connection = null;
      this.bitDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.bitDisplay1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.bitDisplay1.Key = null;
      this.bitDisplay1.Location = new System.Drawing.Point(88, 54);
      this.bitDisplay1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.bitDisplay1.Name = "bitDisplay1";
      this.bitDisplay1.Size = new System.Drawing.Size(498, 408);
      this.bitDisplay1.TabIndex = 19;
      this.bitDisplay1.Click += new System.EventHandler(this.BitDisplay1Click);
      // 
      // EditTypeText
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lstValues);
      this.Controls.Add(this.bitDisplay1);
      this.Controls.Add(this.lblDetail);
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.panel2);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "EditTypeText";
      this.Size = new System.Drawing.Size(586, 534);
      this.pnlToolNumerique.ResumeLayout(false);
      this.pnlToolNumerique.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.pnlSetBit.ResumeLayout(false);
      this.pnlSetBit.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ComboBox cbTypeAffichage;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lblDetail;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Panel pnlToolNumerique;
    private System.Windows.Forms.Button btIncr;
    private UI.NumericTextBox txtIncremValue;
    private System.Windows.Forms.Button btDecr;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtNewValue;
    private System.Windows.Forms.Button btUpdate;
    private System.Windows.Forms.ListView lstValues;
    private System.Windows.Forms.ColumnHeader colKey;
    private System.Windows.Forms.ColumnHeader colValue;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Panel panel3;
    private RedisManagementStudio.BLL.Keys.BitDisplay bitDisplay1;
    private System.Windows.Forms.Panel pnlSetBit;
    private System.Windows.Forms.Button btSetBit;
    private System.Windows.Forms.CheckBox chkSetBit;
    private UI.NumericTextBox txtSetBitOffset;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label lblWrongFormat;
  }
}
