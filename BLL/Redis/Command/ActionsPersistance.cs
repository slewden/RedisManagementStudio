using System;
using System.Windows.Forms;

namespace RedisManagementStudio.BLL.Redis.Command
{
  /// <summary>
  /// Interface d'action pour la rubrique persistance
  /// </summary>
  public partial class ActionsPersistance : UserControl
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="ActionsPersistance" />.
    /// </summary>
    public ActionsPersistance()
    {
      this.InitializeComponent();
      this.Height = 40;

      this.btSave.Text = Properties.Resources.ActionsPersistanceBtSaveT;
      this.btBgSave.Text = Properties.Resources.ActionsPersistanceBtBgSaveT;
      this.btBgRewriteAOF.Text = Properties.Resources.ActionsPersistanceBtRewriteAOFT;
      this.toolTip1.SetToolTip(this.btSave, Properties.Resources.ActionsPersistanceBtSaveD);
      this.toolTip1.SetToolTip(this.btBgSave, Properties.Resources.ActionsPersistanceBtBgSaveD);
      this.toolTip1.SetToolTip(this.btBgRewriteAOF, Properties.Resources.ActionsPersistanceBtRewriteAOFD);
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
    /// Lance un SNAPSHOT cmd Save
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">paramètre inutile</param>
    private void BtSaveClick(object sender, EventArgs e)
    {
      Cursor cur = this.Cursor;
      this.Cursor = Cursors.WaitCursor;
      Application.DoEvents();
      this.Connection.Connector.Save();
      MessageBox.Show(
        this,
        Properties.Resources.ActionsPersistanceBtSaveMessageD,
        Properties.Resources.ActionsPersistanceBtSaveMessageT,
        MessageBoxButtons.OK);
      this.Cursor = cur;
      this.FireNotifyRefresh();
    }

    /// <summary>
    /// Lance un SNAPSHOT en tâche de fond cmd BGSave
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">paramètre inutile</param>
    private void BtBgSaveClick(object sender, EventArgs e)
    {
      this.Connection.Connector.BgSave();
      this.FireNotifyRefresh();
    }

    /// <summary>
    /// Lance une sauvegarde différentielle
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">paramètre inutile</param>
    private void BtBgRewriteAOFClick(object sender, EventArgs e)
    {
      this.Connection.Connector.BgRewriteAOF();
      this.FireNotifyRefresh();
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
