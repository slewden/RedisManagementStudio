namespace RedisManagementStudio.BLL.Alarm
{
  /// <summary>
  /// Gère les paramètres d'une alarme de suivi d'un champ booléen
  /// </summary>
  public class AlarmBool : IAlarm
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="AlarmBool" />.
    /// </summary>
    /// <param name="id">Clé de l'alarme</param>
    public AlarmBool(string id)
    {
      this.Id = id;
      this.True = AlarmStatus.AlarmNone;
      this.False = AlarmStatus.AlarmNone;
      this.Type = AlarmType.BoolControl;
    }

    /// <summary>
    /// Clé de l'alarme
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Type d'alarme gérée
    /// </summary>
    public AlarmType Type { get; private set; }

    /// <summary>
    /// Information de seuil pour l'option OK
    /// </summary>
    public AlarmStatus True { get; set; }

    /// <summary>
    /// Information de seuil pour l'option false
    /// </summary>
    public AlarmStatus False { get; set; }

    /// <summary>
    /// Renvoie le statut de l'alarme
    /// </summary>
    /// <param name="value">Valeur booléenne</param>
    /// <returns>Statut renvoyé</returns>
    public AlarmStatus Get(string value)
    {
      if (value == "1")
      {
        return this.True;
      }
      else
      {
        return this.False;
      }
    }
  }
}
