using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using RedisManagementStudio.BLL.Redis;

namespace RedisManagementStudio
{
  /// <summary>
  /// Fenêtre de tests
  /// </summary>
  public partial class FTest : Form
  {
    /// <summary>
    /// La connexion
    /// </summary>
    private RedisConnection cnn;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="FTest" />.
    /// </summary>
    public FTest()
    {
      this.InitializeComponent();
    }

    /// <summary>
    /// Chargement de la page
    /// </summary>
    /// <param name="sender">qui appelle</param>
    /// <param name="e">paramètre inutile</param>
    private void FTest_Load(object sender, EventArgs e)
    {
    }

    /// <summary>
    /// Pour tests
    /// </summary>
    /// <param name="sender">qui appelle</param>
    /// <param name="e">paramètre inutile</param>
    private void Button1_Click(object sender, EventArgs e)
    {
      var p = new BLL.Connection.RedisConnectionParam();
      p.URL = "localhost";
      List<string> lst;
      using (this.cnn = new RedisConnection(p))
      {
        lst = this.cnn.Connector.Keys("SE*");
      }

      lst.Sort(new RedisManagementStudio.BLL.StringCorrectComparer());
      this.listBox1.DataSource = lst;
    }
  }
}
