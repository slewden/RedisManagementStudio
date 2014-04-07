using System;
using System.Text;

namespace RedisManagementStudio.BLL
{
  /// <summary>
  /// Classe d'aide générale
  /// </summary>
  public static class Helper
  {
    /// <summary>
    /// Renvoie le titre de l'action
    /// </summary>
    /// <param name="act">Action  concernée</param>
    /// <returns>le titre</returns>
    public static string GetTitre(this CommandMenuAction act)
    {
      return Menu.GetLibelle(act, "T");
    }

    /// <summary>
    /// La description des items du menu
    /// </summary>
    /// <param name="act">L'item menu</param>
    /// <returns>le texte à afficher</returns>
    public static string GetDescription(this CommandMenuAction act)
    {
      return Menu.GetLibelle(act, "D");
    }

    /// <summary>
    /// Affiche le TIMESPAN un peu mieux
    /// </summary>
    /// <param name="ts">Durées à mettre en forme</param>
    /// <returns>Chaine représentant le TIMESPAN</returns>
    public static string ToFormatted(this TimeSpan ts)
    {
      StringBuilder res = new StringBuilder();
      if (ts.Days > 1)
      {
        res.AppendFormat(Menu.TimeSpanNjour.Trim() + " ", ts.Days);
      }
      else if (ts.Days == 1)
      {
        res.Append(Menu.TimeSpan1jour.Trim() + " ");
      }

      if (ts.Hours > 1)
      {
        res.AppendFormat(Menu.TimeSpanNHeure.Trim() + " ", ts.Hours);
      }
      else if (ts.Hours == 1)
      {
        res.Append(Menu.TimeSpan1Heure.Trim() + " ");
      }

      if (ts.Minutes > 1)
      {
        res.AppendFormat(Menu.TimeSpanNMinute.Trim() + " ", ts.Minutes);
      }
      else if (ts.Minutes == 1)
      {
        res.Append(Menu.TimeSpan1Minute.Trim() + " ");
      }

      if (ts.Seconds > 1)
      {
        res.AppendFormat(Menu.TimeSpanNSeconde.Trim() + " ", ts.Seconds);
      }
      else if (ts.Seconds == 1)
      {
        res.Append(Menu.TimeSpan1Seconde.Trim() + " ");
      }

      if (ts.Milliseconds > 1)
      {
        res.AppendFormat(Menu.TimeSpanNMilliSeconde.Trim() + " ", ts.Milliseconds);
      }
      else if (ts.Milliseconds == 1)
      {
        res.Append(Menu.TimeSpan1MilliSeconde.Trim() + " ");
      }

      if (ts.Ticks > 0 && res.Length == 0)
      {
        double d = (double)ts.Ticks / 10;
        res.AppendFormat(Menu.TimeSpanNxMilliSecondes.Trim() + " ", d / 1000);
      }

      return res.ToString();
    }
  }
}
