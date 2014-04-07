namespace RedisManagementStudio.BLL.Alarm
{
  /// <summary>
  /// Gère les paramètres d'une alarme de suivi d'un champ entier croissant ou décroissant
  /// La classe abstraite sera surchargée
  /// </summary>
  public abstract class AlarmCounter : IAlarm
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="AlarmCounter" />.
    /// </summary>
    /// <param name="id">Clé de l'alarme</param>
    /// <param name="sensUp">Sens croissant</param>
    public AlarmCounter(string id, bool sensUp)
    {
      this.Id = id;
      this.SensUp = sensUp;
      this.Seuil1 = 0;
      this.Seuil2 = 0;
      this.Historique = false;
    }

    /// <summary>
    /// Clé de l'alarme
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Type d'alarme géré
    /// </summary>
    public AlarmType Type { get; protected set; }

    /// <summary>
    /// Sens croissant ou pas
    /// </summary>
    public bool SensUp { get; private set; }

    /// <summary>
    /// Seuil de niveau 1
    /// </summary>
    public double Seuil1 { get; set; }

    /// <summary>
    /// Seuil de niveau 2
    /// </summary>
    public double Seuil2 { get; set; }

    /// <summary>
    /// Option de suivi de l'historique
    /// </summary>
    public bool Historique { get; set; }

    /// <summary>
    /// Renvoie le statut de l'alarme
    /// </summary>
    /// <param name="value">Valeur double</param>
    /// <returns>Statut renvoyé</returns>
    public abstract AlarmStatus Get(string value);
   }
}
