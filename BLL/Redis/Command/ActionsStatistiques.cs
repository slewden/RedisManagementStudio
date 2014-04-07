using System;
using System.Windows.Forms;

namespace RedisManagementStudio.BLL.Redis.Command
{
  /// <summary>
  ///  Les actions possibles pour les statistiques
  /// </summary>
  public partial class ActionsStatistiques : UserControl
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="ActionsStatistiques" />.
    /// </summary>
    public ActionsStatistiques()
    {
      this.InitializeComponent();
      this.Height = 40;

      this.btConfigResetStat.Text = Properties.Resources.ActionsStatistiquesBtConfigResetT;
      this.toolTip1.SetToolTip(this.btConfigResetStat, Properties.Resources.ActionsStatistiquesBtConfigResetD);
    }

    /// <summary>
    /// Notifie le parent qu'un rafraichissement est nécessaire
    /// </summary>
    public event EventHandler OnNotifyRefreshNeed;

    /// <summary>
    /// La connexion
    /// </summary>
    public RedisConnection Connection { get; set; }
    
    /// <summary>
    /// Event de traitement du RAZ des statistiques
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtConfigResetStatClick(object sender, EventArgs e)
    {
      if (MessageBox.Show(
        this, 
        Properties.Resources.ActionsStatistiquesBtConfigResetQuestionD,
        Properties.Resources.ActionsStatistiquesBtConfigResetQuestionT, 
        MessageBoxButtons.YesNo, 
        MessageBoxIcon.Question, 
        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
      {
        try
        {
          this.Connection.Connector.ConfigResetStat();
          MessageBox.Show(
            this,
            Properties.Resources.ActionsStatistiquesBtConfigResetOk,
            Properties.Resources.ActionsStatistiquesBtConfigResetQuestionT, 
            MessageBoxButtons.OK, 
            MessageBoxIcon.Information);
          this.FireNotifyRefresh();
        }
        catch (Exception ex)
        {
          MessageBox.Show(
            this, 
            string.Format(Properties.Resources.ActionsStatistiquesBtConfigResetErreur, ex),
            Properties.Resources.ActionsStatistiquesBtConfigResetQuestionT, 
            MessageBoxButtons.OK, 
            MessageBoxIcon.Error);
        }
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
