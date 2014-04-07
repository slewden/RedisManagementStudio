using System.Globalization;

namespace RedisManagementStudio.BLL.Alarm
{
  /// <summary>
  /// Gère les paramètres d'une alarme de suivi d'un champ entier décroissant
  /// </summary>
  public class AlarmDownCounter : AlarmCounter, IAlarm
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="AlarmDownCounter" />.
    /// </summary>
    /// <param name="id">Clé de l'alarme</param>
    public AlarmDownCounter(string id)
      : base(id, true)
    {
      this.Type = AlarmType.CounterDown;
    }

    /// <summary>
    /// Renvoie le statut de l'alarme
    /// </summary>
    /// <param name="value">Valeur double</param>
    /// <returns>Statut renvoyé</returns>
    public override AlarmStatus Get(string value)
    {
      double nb;
      if (double.TryParse(value.Replace(".", NumberFormatInfo.CurrentInfo.NumberDecimalSeparator), out nb))
      { // La value est compatible avec le type d'alarme
        if (nb <= this.Seuil2)
        {
          return AlarmStatus.AlarmRed;
        }
        else if (nb <= this.Seuil1)
        {
          return AlarmStatus.AlarmOrange;
        }
        else
        {
          return AlarmStatus.AlarmGreen;
        }
      }
      else
      {
        return AlarmStatus.AlarmNone;
      }
    }
  }
}
