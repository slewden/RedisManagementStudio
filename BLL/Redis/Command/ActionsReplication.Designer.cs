namespace RedisManagementStudio.BLL.Redis.Command
{
  partial class ActionsReplication
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
      this.btSlaveOfNone = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.pnlSlave = new System.Windows.Forms.Panel();
      this.label4 = new System.Windows.Forms.Label();
      this.lblMasterDetail = new System.Windows.Forms.Label();
      this.pnlMaster = new System.Windows.Forms.Panel();
      this.label5 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.lblCountSlaves = new System.Windows.Forms.Label();
      this.btSlaveOf = new System.Windows.Forms.Button();
      this.pnlStandAlone = new System.Windows.Forms.Panel();
      this.label6 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.txtPort = new RedisManagementStudio.BLL.UI.NumericTextBox();
      this.txtAdresse = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.pnlSlave.SuspendLayout();
      this.pnlMaster.SuspendLayout();
      this.pnlStandAlone.SuspendLayout();
      this.SuspendLayout();
      // 
      // btSlaveOfNone
      // 
      this.btSlaveOfNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btSlaveOfNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btSlaveOfNone.Location = new System.Drawing.Point(425, 5);
      this.btSlaveOfNone.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
      this.btSlaveOfNone.Name = "btSlaveOfNone";
      this.btSlaveOfNone.Size = new System.Drawing.Size(152, 30);
      this.btSlaveOfNone.TabIndex = 37;
      this.btSlaveOfNone.Text = "Stopper l\'abonnement";
      this.btSlaveOfNone.UseVisualStyleBackColor = true;
      this.btSlaveOfNone.Click += new System.EventHandler(this.BtSlaveOfNoneClick);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 12);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(89, 17);
      this.label1.TabIndex = 36;
      this.label1.Text = "Actuellement :";
      // 
      // pnlSlave
      // 
      this.pnlSlave.Controls.Add(this.label4);
      this.pnlSlave.Controls.Add(this.label1);
      this.pnlSlave.Controls.Add(this.btSlaveOfNone);
      this.pnlSlave.Controls.Add(this.lblMasterDetail);
      this.pnlSlave.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlSlave.Location = new System.Drawing.Point(0, 40);
      this.pnlSlave.Name = "pnlSlave";
      this.pnlSlave.Size = new System.Drawing.Size(577, 40);
      this.pnlSlave.TabIndex = 38;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(100, 6);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(73, 25);
      this.label4.TabIndex = 38;
      this.label4.Text = "Esclave";
      // 
      // lblMasterDetail
      // 
      this.lblMasterDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblMasterDetail.AutoSize = true;
      this.lblMasterDetail.Location = new System.Drawing.Point(210, 12);
      this.lblMasterDetail.Name = "lblMasterDetail";
      this.lblMasterDetail.Size = new System.Drawing.Size(140, 17);
      this.lblMasterDetail.TabIndex = 44;
      this.lblMasterDetail.Text = "Maître : localhost:6379";
      // 
      // pnlMaster
      // 
      this.pnlMaster.Controls.Add(this.label5);
      this.pnlMaster.Controls.Add(this.label2);
      this.pnlMaster.Controls.Add(this.lblCountSlaves);
      this.pnlMaster.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlMaster.Location = new System.Drawing.Point(0, 80);
      this.pnlMaster.Name = "pnlMaster";
      this.pnlMaster.Size = new System.Drawing.Size(577, 40);
      this.pnlMaster.TabIndex = 39;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(100, 6);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(67, 25);
      this.label5.TabIndex = 37;
      this.label5.Text = "Maître";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(6, 12);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(89, 17);
      this.label2.TabIndex = 36;
      this.label2.Text = "Actuellement :";
      // 
      // lblCountSlaves
      // 
      this.lblCountSlaves.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblCountSlaves.AutoSize = true;
      this.lblCountSlaves.Location = new System.Drawing.Point(210, 12);
      this.lblCountSlaves.Name = "lblCountSlaves";
      this.lblCountSlaves.Size = new System.Drawing.Size(78, 17);
      this.lblCountSlaves.TabIndex = 44;
      this.lblCountSlaves.Text = "xxx Esclaves";
      // 
      // btSlaveOf
      // 
      this.btSlaveOf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btSlaveOf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btSlaveOf.Location = new System.Drawing.Point(494, 5);
      this.btSlaveOf.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
      this.btSlaveOf.Name = "btSlaveOf";
      this.btSlaveOf.Size = new System.Drawing.Size(83, 30);
      this.btSlaveOf.TabIndex = 37;
      this.btSlaveOf.Text = "S\'abonner";
      this.btSlaveOf.UseVisualStyleBackColor = true;
      this.btSlaveOf.Click += new System.EventHandler(this.BtSlaveOfClick);
      // 
      // pnlStandAlone
      // 
      this.pnlStandAlone.BackColor = System.Drawing.SystemColors.Control;
      this.pnlStandAlone.Controls.Add(this.label6);
      this.pnlStandAlone.Controls.Add(this.label3);
      this.pnlStandAlone.Controls.Add(this.btSlaveOf);
      this.pnlStandAlone.Controls.Add(this.txtPort);
      this.pnlStandAlone.Controls.Add(this.txtAdresse);
      this.pnlStandAlone.Controls.Add(this.label7);
      this.pnlStandAlone.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlStandAlone.Location = new System.Drawing.Point(0, 0);
      this.pnlStandAlone.Name = "pnlStandAlone";
      this.pnlStandAlone.Size = new System.Drawing.Size(577, 40);
      this.pnlStandAlone.TabIndex = 40;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(100, 6);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(100, 25);
      this.label6.TabIndex = 42;
      this.label6.Text = "Autonome";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(6, 12);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(89, 17);
      this.label3.TabIndex = 38;
      this.label3.Text = "Actuellement :";
      // 
      // txtPort
      // 
      this.txtPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtPort.DoubleValue = 6379D;
      this.txtPort.IntValue = 6379;
      this.txtPort.Location = new System.Drawing.Point(441, 10);
      this.txtPort.Name = "txtPort";
      this.txtPort.Size = new System.Drawing.Size(47, 25);
      this.txtPort.TabIndex = 41;
      this.txtPort.Text = "6379";
      this.txtPort.TextChanged += new System.EventHandler(this.TxtMasterTextChanged);
      // 
      // txtAdresse
      // 
      this.txtAdresse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.txtAdresse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtAdresse.Location = new System.Drawing.Point(324, 10);
      this.txtAdresse.Name = "txtAdresse";
      this.txtAdresse.Size = new System.Drawing.Size(111, 25);
      this.txtAdresse.TabIndex = 39;
      this.txtAdresse.TextChanged += new System.EventHandler(this.TxtMasterTextChanged);
      // 
      // label7
      // 
      this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(210, 12);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(108, 17);
      this.label7.TabIndex = 43;
      this.label7.Text = "Nouveau maître :";
      // 
      // ActionsReplication
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.pnlMaster);
      this.Controls.Add(this.pnlSlave);
      this.Controls.Add(this.pnlStandAlone);
      this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "ActionsReplication";
      this.Size = new System.Drawing.Size(577, 181);
      this.VisibleChanged += new System.EventHandler(this.ActionsReplication_VisibleChanged);
      this.pnlSlave.ResumeLayout(false);
      this.pnlSlave.PerformLayout();
      this.pnlMaster.ResumeLayout(false);
      this.pnlMaster.PerformLayout();
      this.pnlStandAlone.ResumeLayout(false);
      this.pnlStandAlone.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btSlaveOfNone;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel pnlSlave;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Panel pnlMaster;
    private System.Windows.Forms.Label lblCountSlaves;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btSlaveOf;
    private System.Windows.Forms.Panel pnlStandAlone;
    private UI.NumericTextBox txtPort;
    private System.Windows.Forms.TextBox txtAdresse;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ToolTip toolTip1;
    private System.Windows.Forms.Label lblMasterDetail;
  }
}
