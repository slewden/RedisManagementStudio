using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ClientRedisLib.RedisClass;

namespace RedisManagementStudio.BLL.Redis
{
  /// <summary>
  /// Affichages des propriétés élémentaires du serveur
  /// </summary>
  public partial class ServerResume : UserControl
  {
    /// <summary>
    /// La connexion à utiliser
    /// </summary>
    private RedisConnection myCnn;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="ServerResume" />.
    /// </summary>
    public ServerResume()
    {
      this.InitializeComponent();

      this.label1.Text = Properties.Resources.ServerResumeLbl1T;
      this.label2.Text = Properties.Resources.ServerResumeLbl2T;
      this.label3.Text = Properties.Resources.ServerResumeLbl3T;
      this.label4.Text = Properties.Resources.ServerResumeLbl4T;
      this.label5.Text = Properties.Resources.ServerResumeLbl5T;
      this.label6.Text = Properties.Resources.ServerResumeLbl6T;
      this.label7.Text = Properties.Resources.ServerResumeLbl7T;
      this.label8.Text = Properties.Resources.ServerResumeLbl8T;
      this.label9.Text = Properties.Resources.ServerResumeLbl9T;
      this.label10.Text = Properties.Resources.ServerResumeLbl10T;
      this.btShowBase.Text = Properties.Resources.ServerResumeBtShowBaseT;
      this.colBase.Text = Properties.Resources.ServerResumeColBase;
      this.colKeys.Text = Properties.Resources.ServerResumeColKeys;
      this.btFlushDb.Text = string.Format(Properties.Resources.ServerResumeBtFlushDB, "???");
      this.chkShowActions.Text = Properties.Resources.ServerResumeBtShowActionT;
      this.btFlusAllDb.Text = Properties.Resources.ServerResumeBtFlushAllDBT;
      this.btShutDown.Text = Properties.Resources.ServerResumeBtShutDownT;
    }

    /// <summary>
    /// La connexion à utiliser
    /// </summary>
    public RedisConnection Connection
    {
      set
      {
        if (value != null)
        { // on a une connexion
          this.myCnn = value;
          bool sentinel = this.myCnn.Connector.ServerInSentinelMode;
          this.panel1.BackColor = this.myCnn.Param.Color == Color.Empty ? SystemColors.Control : this.myCnn.Param.Color;
          this.lblConnexion.Text = this.myCnn.Param.Name;
          this.lblAdresse.Text = this.myCnn.Param.URL;
          this.lblPort.Text = this.myCnn.Param.Port.ToString();
          this.lblBase.Text = this.myCnn.Param.Base.ToString();
          this.lblDescription.Text = this.myCnn.Param.Description;
          this.lblVersion.Text = this.myCnn.Connector.GetServerVersionText();
          this.lblRedisMode.Text = sentinel ? InformationDansRubriqueRessources.VModeSentinel : InformationDansRubriqueRessources.VModeAlone;
          this.lblTotalCles.Text = this.myCnn.Connector.DbSize().ToString();
          this.listView1.Visible = false;
          this.btClose.Visible = false;
          this.btFlushDb.Text = string.Format(Properties.Resources.ServerResumeBtFlushDB, this.myCnn.Param.Base);
          this.btFlushDb.Enabled = true;
          this.btShowBase.Visible = !sentinel;
          this.label9.Visible = sentinel;
          this.label7.Visible = !sentinel;
          this.lblTotalCles.Visible = !sentinel;
        }
        else
        { // pas de connexion
          this.panel1.BackColor = SystemColors.Control;
          this.lblConnexion.Text = string.Empty;
          this.lblAdresse.Text = string.Empty;
          this.lblPort.Text = string.Empty;
          this.lblBase.Text = string.Empty;
          this.lblDescription.Text = string.Empty;
          this.lblVersion.Text = string.Empty;
          this.lblRedisMode.Text = string.Empty;
          this.lblTotalCles.Text = string.Empty;
          this.listView1.Visible = false;
          this.btClose.Visible = false;
          this.btFlushDb.Text = string.Format(Properties.Resources.ServerResumeBtFlushDB, "???");
          this.btFlushDb.Enabled = false;
          this.btShowBase.Visible = false;
          this.label9.Visible = false;
        }

        this.GereBouton();
      }
    }

    /// <summary>
    /// Chargement des propriétés
    /// </summary>
    public void LoadProperties()
    {
      // TODO : if needed
    }

    /// <summary>
    /// Sauvegarde des propriétés
    /// </summary>
    public void SaveProperties()
    {
      // TODO : if needed
    }

    #region Events
    /// <summary>
    /// A l'affichage du panneau : on masque les infos étendues
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void ServerResumeVisibleChanged(object sender, EventArgs e)
    {
      this.listView1.Visible = false;
      this.btClose.Visible = false;
    }

    /// <summary>
    /// Affichage des informations des bases du serveur
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtShowBaseLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      this.listView1.Items.Clear();
      if (this.myCnn != null)
      { // on a une connexion
        Dictionary<string, string> nfos = this.myCnn.Connector.Info();
        ListViewItem itx;
        foreach (string key in nfos.Keys.Where(x => x.ToLower().StartsWith("db")))
        { // pour chaque info de la forme dbXXX (ou XXX est le N° de la base)
          string data = nfos[key].ToLower();
          if (!string.IsNullOrWhiteSpace(data) && data.IndexOf(',') != -1)
          { // Les infos sont de la forme Keys=yyy,autreinfo=zzz,...
            string[] nf = data.Split(',');
            string nb = nf.Where(x => x.StartsWith("keys=")).FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(nb) && nb.Length > 5)
            { // nb contient bien un truc du style keys=yyy
              itx = new ListViewItem(key.Substring(2)); // dbXXX ==> xxx start at 2 index
              itx.SubItems.Add(nb.Substring(5));        // keys=yyy ==> yyy start at 5 index
              this.listView1.Items.Add(itx);
            }
          }
        }
      }

      this.listView1.Visible = true;
      this.btClose.Visible = true;
      this.listView1.Focus();
    }

    /// <summary>
    /// Masquer les informations des bases du serveur
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtCloseClick(object sender, EventArgs e)
    {
      this.listView1.Hide();
      this.btClose.Hide();
    }

    /// <summary>
    /// RAZ de la base de données
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtFlushDbClick(object sender, EventArgs e)
    {
      if (this.myCnn != null)
      {
        string titre = string.Format(Properties.Resources.ServerResumeBtFlushConfirmT, this.myCnn.Param.Base);

        if (MessageBox.Show(this, Properties.Resources.ServerResumeBtFlushConfirm1D, titre, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
        {
          if (MessageBox.Show(this, Properties.Resources.ServerResumeBtFlushConfirm2D, titre, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) == DialogResult.No)
          {
            this.myCnn.Connector.FlushDB();
            this.Connection = this.myCnn; // pour forcer le rechargement des données
            MessageBox.Show(this, Properties.Resources.ServerResumeBtFlushResultOkD, titre, MessageBoxButtons.OK);
          }
        }
      }
    }

    /// <summary>
    /// RAZ de TOUTES les bases de données
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtFlusAllDbClick(object sender, EventArgs e)
    {
      if (this.myCnn != null)
      {
        if (MessageBox.Show(this, Properties.Resources.ServerResumeBtFlushAllConfirm1D, Properties.Resources.ServerResumeBtFlushAllConfirmT, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
        {
          if (MessageBox.Show(this, Properties.Resources.ServerResumeBtFlushAllConfirm2D, Properties.Resources.ServerResumeBtFlushAllConfirmT, MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1) == DialogResult.No)
          {
            if (MessageBox.Show(this, Properties.Resources.ServerResumeBtFlushAllConfirm3D, Properties.Resources.ServerResumeBtFlushAllConfirmT, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
              this.myCnn.Connector.FlushAll();
              this.Connection = this.myCnn; // pour forcer le rechargement des données
              MessageBox.Show(this, Properties.Resources.ServerResumeBtFlushResultAllOkD, Properties.Resources.ServerResumeBtFlushAllConfirmT, MessageBoxButtons.OK);
            }
          }
        }
      }
    }

    /// <summary>
    /// RAZ de la base de données
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtShutDownClick(object sender, EventArgs e)
    {
      if (this.myCnn != null)
      {
        if (MessageBox.Show(this, Properties.Resources.ServerResumeBtShutDownConfirm1D, Properties.Resources.ServerResumeBtShutDownConfirmT, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
        {
          DialogResult rep = MessageBox.Show(this, Properties.Resources.ServerResumeBtShutDownConfirm2D, Properties.Resources.ServerResumeBtShutDownConfirmT, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
          if (rep != DialogResult.Cancel)
          {
            this.myCnn.Connector.Shutdown(rep == DialogResult.Yes ? ShutdownOption.SAVE : ShutdownOption.NOSAVE);
            this.Connection = null; // pour forcer le rechargement des données
            MessageBox.Show(this, Properties.Resources.ServerResumeBtShutDownOKD, Properties.Resources.ServerResumeBtShutDownConfirmT, MessageBoxButtons.OK);
            
            if (this.ParentForm != null)
            { // on ferme la fenêtre
              this.ParentForm.Close();
            }
          }
        }
      }
    }

    /// <summary>
    /// RAZ de la base de données
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void ChkShowActionsCheckedChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }
    #endregion

    /// <summary>
    /// RAZ de la base de données
    /// </summary>
    private void GereBouton()
    {
      this.btFlusAllDb.Visible = this.chkShowActions.Checked;
      this.btFlushDb.Visible = this.chkShowActions.Checked;
      this.btShutDown.Visible = this.chkShowActions.Checked;
    }
  }
}
