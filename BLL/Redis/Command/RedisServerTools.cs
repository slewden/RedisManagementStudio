using System;
using System.Drawing;
using System.Windows.Forms;

namespace RedisManagementStudio.BLL.Redis.Command
{
  /// <summary>
  /// Les outils serveurs
  /// </summary>
  public partial class RedisServerTools : UserControl
  {
    /// <summary>
    /// Constructeur de la classe
    /// </summary>
    public RedisServerTools()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Notifie le parent qu'il faut rafraichir l'affichage
    /// </summary>
    public event EventHandler OnNotifyRefreshNeed;

    /// <summary>
    /// La connexion à la base
    /// </summary>
    public RedisConnection Connection { get; set; }

    /// <summary>
    /// Charge les propriétés nécessaire au controle
    /// </summary>
    public void LoadProperties()
    {
      // throw new NotImplementedException();
    }

    /// <summary>
    /// Sauve les propriété du controle
    /// </summary>
    public void SaveProperties()
    {
      // throw new NotImplementedException();
    }

    /// <summary>
    /// Affiche un bulle d'aide à la tooltip
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">parametre inutile</param>
    private void ImgConfigStatMouseHover(object sender, EventArgs e)
    {
      Control help = sender as Control;
      if (help != null)
      {
        pnlTips.Location = new Point(help.Right, help.Top);
        lblTips.Text = RedisCommand.GetTips(help.Tag.ToString());
        pnlTips.Visible = true;
      }
    }

    /// <summary>
    /// Notifie le parent qu'il doit rafraichir l'écran
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
