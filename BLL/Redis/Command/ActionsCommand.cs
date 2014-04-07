using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ClientRedisLib;

namespace RedisManagementStudio.BLL.Redis.Command
{
  /// <summary>
  /// Interface d'action pour la rubrique command
  /// </summary>
  public partial class ActionsCommand : UserControl
  {
    /// <summary>
    /// Nom du fichier pour les commandes lentes
    /// </summary>
    private const string NOMFILE = "SlowLog.txt";

    /// <summary>
    /// Chaine de séparation des colonnes des informations du fichier slowLog.txt
    /// </summary>
    private const string SEPICOLONNE = "\t";

    /// <summary>
    /// La connexion
    /// </summary>
    private RedisConnection myCnn;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="ActionsCommand" />.
    /// </summary>
    public ActionsCommand()
    {
      this.InitializeComponent();
      this.Height = 40;

      this.lblInfo.Text = Properties.Resources.ActionsCommandLblInfoCount0;
      this.btShow.Text = Properties.Resources.ActionsCommandBtShowT;
      this.btReset.Text = Properties.Resources.ActionsCommandBtResetT;

      this.toolTip1.SetToolTip(this.btShow, Properties.Resources.ActionsCommandBtShowD);
      this.toolTip1.SetToolTip(this.btReset, Properties.Resources.ActionsCommandBtResetD);
    }

    /// <summary>
    /// Notifie le parent qu'un rafraichissement est nécessaire
    /// </summary>
    public event EventHandler OnNotifyRefreshNeed;

    /// <summary>
    /// La connexion
    /// </summary>
    public RedisConnection Connection
    {
      get
      {
        return this.myCnn;
      }

      set
      {
        this.myCnn = value;
        this.CountSLowLog();
      }
    }

    /// <summary>
    /// A chaque affichage on actualise les infos
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">paramètre inutile</param>
    private void ActionsCommand_VisibleChanged(object sender, EventArgs e)
    {
      if (this.Visible)
      {
        this.CountSLowLog();
      }
    }

    /// <summary>
    /// Réinitialise les statistiques
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">paramètre inutile</param>
    private void BtResetClick(object sender, EventArgs e)
    {
      if (MessageBox.Show(
        this, 
        Properties.Resources.ActionsCommandBtResetConfirmD, 
        Properties.Resources.ActionsCommandBtResetConfirmT, 
        MessageBoxButtons.YesNo, 
        MessageBoxIcon.Exclamation, 
        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
      {
        if (this.Connection.Connector.SlowLogReset())
        {
          this.CountSLowLog();
          this.FireNotifyRefresh();
        }
        else
        {
          MessageBox.Show(
            this, 
            this.Connection.Connector.LastErrorText, 
            Properties.Resources.ActionsCommandBtResetErrorT, 
            MessageBoxButtons.OK, 
            MessageBoxIcon.Error);
        }
      }
    }

    /// <summary>
    /// Affiche le détail
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">paramètre inutile</param>
    private void BtShowClick(object sender, EventArgs e)
    {
      List<SlowLogData> infos = this.Connection.Connector.SlowLogGet(0);

      if (infos != null && infos.Count > 0)
      {
        FileInfo fi = new FileInfo(Application.ExecutablePath);
        string fileName = Path.Combine(fi.DirectoryName, ActionsCommand.NOMFILE);
        using (StreamWriter tw = new StreamWriter(fileName))
        {
          tw.WriteLine(string.Format(Properties.Resources.ActionsCommandFileEntete, SEPICOLONNE));
          foreach (SlowLogData info in infos)
          {
            tw.WriteLine(string.Format(
              Properties.Resources.ActionsCommandFileRow, 
              SEPICOLONNE, 
              info.Index, 
              info.Date, 
              info.Duration, 
              info.CommandLine));
          }
        }

        System.Diagnostics.Process.Start(fileName);
      }
      else if (string.IsNullOrWhiteSpace(this.Connection.Connector.LastErrorText))
      {
        MessageBox.Show(
          this, 
          Properties.Resources.ActionsCommandFileError0D, 
          Properties.Resources.ActionsCommandFileError0T, 
          MessageBoxButtons.OK, 
          MessageBoxIcon.Information);
      }
      else
      {
        MessageBox.Show(
          this, 
          this.Connection.Connector.LastErrorText, 
          Properties.Resources.ActionsCommandFileErrorXT, 
          MessageBoxButtons.OK, 
          MessageBoxIcon.Error);
      }
    }

    /// <summary>
    /// Compte le nombre de commande lente et l'affiche
    /// </summary>
    private void CountSLowLog()
    {
      if (this.Connection != null && this.Connection.Connector != null)
      {
        int nb = this.Connection.Connector.SlowLogLen();
        this.btReset.Enabled = nb > 0;
        this.btShow.Enabled = nb > 0;
        if (nb == 0)
        {
          this.lblInfo.Text = Properties.Resources.ActionsCommandLblInfoCount0;
        }
        else if (nb == 1)
        {
          this.lblInfo.Text = string.Format(Properties.Resources.ActionsCommandLblInfoCount1, nb);
        }
        else
        {
          this.lblInfo.Text = string.Format(Properties.Resources.ActionsCommandLblInfoCountN, nb);
        }
      }
      else
      {
        this.lblInfo.Text = string.Empty;
        this.btReset.Enabled = false;
        this.btShow.Enabled = false;
      }
    }

    /// <summary>
    /// Notifie le parent qu'il faut Rafraichir
    /// </summary>
    private void FireNotifyRefresh()
    {
      if (this.OnNotifyRefreshNeed != null)
      {
        this.OnNotifyRefreshNeed(this, new EventArgs());
      }
    }
  }
}
