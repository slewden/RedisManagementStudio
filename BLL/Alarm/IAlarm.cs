namespace RedisManagementStudio.BLL.Alarm
{
  /// <summary>
  /// Type de statut d'alarme à afficher
  /// </summary>
  public enum AlarmStatus
  {
    /// <summary>
    /// Aucun statut
    /// </summary>
    AlarmNone = 0,

    /// <summary>
    /// Statut Ok
    /// </summary>
    AlarmGreen = 1,

    /// <summary>
    /// Statut PB niveau 1 = Message
    /// </summary>
    AlarmOrange = 2,

    /// <summary>
    /// Statut PB niveau 2 = Erreur
    /// </summary>
    AlarmRed = 3
  }
  
  /// <summary>
  /// Type d'alarme disponible pour une info
  /// </summary>
  public enum AlarmType
  {
    /// <summary>
    /// Aucune alarme
    /// </summary>
    None,

    /// <summary>
    /// gestion d'un double qui croit
    /// </summary>
    CounterUp,

    /// <summary>
    /// Gestion d'un double qui décroit
    /// </summary>
    CounterDown,

    /// <summary>
    /// Gestion d'un booléen
    /// </summary>
    BoolControl,

    /// <summary>
    /// Temps passé
    /// </summary>
    TimeSpanControl,
  }

  /// <summary>
  /// Défini une Alarme
  /// </summary>
  public interface IAlarm
  {
    /// <summary>
    /// Clé de l'alarme
    /// </summary>
    string Id { get; set; }

    /// <summary>
    /// Type d'alarme
    /// </summary>
    AlarmType Type { get; }

    /// <summary>
    /// Renvoie le statut du paramètre
    /// </summary>
    /// <param name="value">Valeur à mesurer</param>
    /// <returns>Statut de l'alarme</returns>
    AlarmStatus Get(string value);
  }

  /// <summary>
  /// Défini un editeur d'alarme
  /// </summary>
  public interface IAlarmEdit
  {
    /// <summary>
    /// Type d'alarme édité
    /// </summary>
    AlarmType Type { get; }
  }

  /// <summary>
  /// Classe d'aide pour les méthodes statique
  /// </summary>
  public static class AHelper
  {
    /// <summary>
    /// Renvoie la description d'un statut d'alarme
    /// </summary>
    /// <param name="seuil">statut à analyser</param>
    /// <returns>la description</returns>
    public static string GetDescription(this AlarmStatus seuil)
    {
      switch (seuil)
      { 
        case AlarmStatus.AlarmGreen:
          return Properties.Resources.AlarmStatusAlarmGreen;
        case AlarmStatus.AlarmNone:
          return Properties.Resources.AlarmStatusAlarmNone;
        case AlarmStatus.AlarmOrange:
          return Properties.Resources.AlarmStatusAlarmOrange;
        case AlarmStatus.AlarmRed:
          return Properties.Resources.AlarmStatusAlarmRed;
      }

      return seuil.ToString();
    }

    /// <summary>
    /// Renvoie une description d'un type d'alarme
    /// </summary>
    /// <param name="alrm">le type à décrire</param>
    /// <returns>La description du type</returns>
    public static string GetDescription(this AlarmType alrm)
    {
      switch (alrm)
      { 
        case AlarmType.BoolControl:
          return Properties.Resources.AlarmTypeBoolControl;
        case AlarmType.CounterDown:
          return Properties.Resources.AlarmTypeCounterDown;
        case AlarmType.CounterUp:
          return Properties.Resources.AlarmTypeCounterUp;
        case AlarmType.None:
          return string.Empty;
      }

      return alrm.ToString();
    }

    /// <summary>
    /// Indique si le double est une valeur "normale" ou un "EXTREME = mauvaise valeur"
    /// </summary>
    /// <param name="p">double à analyser</param>
    /// <returns>TRUE si le double est un "EXTREME = mauvaise valeur"</returns>
    public static bool IsBadDouble(this double p)
    {
      return p == double.Epsilon || p == double.MaxValue || p == double.MinValue || p == double.NaN || p == double.NegativeInfinity || p == double.PositiveInfinity;
    }
  }
}
