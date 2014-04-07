using System;
using System.Windows.Forms;

namespace RedisManagementStudio
{
  /// <summary>
  /// Classe de démarrage de l'application
  /// </summary>
  public static class Program
  {
    /// <summary>
    /// Point d'entrée principal de l'application.
    /// </summary>
    [STAThread]
    public static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      // Application.Run(new FTest());
      Application.Run(new FManagement());

      // RedisManagementStudio.BLL.Connection.RedisConnectionParam cnnParam = new BLL.Connection.RedisConnectionParam();
      // cnnParam.Name = "Serveur local Base 0";
      // cnnParam.Color = System.Drawing.Color.OrangeRed;
      // cnnParam.Description = "Le serveur local Base 0 = Base de tous les tests";
      // using (RedisManagementStudio.BLL.Redis.RedisConnection cnn = new RedisManagementStudio.BLL.Redis.RedisConnection(cnnParam))
      // {
      //   //FRedisUtil frm = new FRedisUtil();
      //   RedisManagementStudio.BLL.Redis.FManageInfos frm = new RedisManagementStudio.BLL.Redis.FManageInfos();
      //   frm.Connection = cnn;
      //   Application.Run(frm);
      //   //RedisManagementStudio.BLL.Alarm.AlarmSaver.Instance.Flush();
      // }
    }
  }
}
