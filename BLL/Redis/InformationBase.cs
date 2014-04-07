using System;
using System.Globalization;
using ClientRedisLib;
using RedisManagementStudio.BLL.Alarm;
using RedisManagementStudio.BLL.Redis.Config;

namespace RedisManagementStudio.BLL.Redis
{
  /// <summary>
  /// Classe de base pour gérer et afficher le détail d'une information serveur REDIS
  /// </summary>
  public abstract class InformationBase : InformationDansRubrique
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="InformationBase" />.
    /// </summary>
    /// <param name="cmd">La commande</param>
    /// <param name="key">La clé</param>
    /// <param name="value">La valeur originale</param>
    public InformationBase(string cmd, string key, string value)
    {
      base.Command = cmd;
      base.Code = key;
      this.OriginalValue = value;
    }

    #region Propriétés
    /// <summary>
    /// La commande : en lecture seule de l'extérieur de l'objet : en lecture seule
    /// </summary>
    public new string Command
    {
      get
      {
        return base.Command;
      }
    }

    /// <summary>
    /// Le code : en lecture seule de l'extérieur de l'objet : en lecture seule
    /// </summary>
    public new string Code
    {
      get
      {
        return base.Code;
      }
    }

    /// <summary>
    /// La rubrique de regroupement des données : en lecture seule
    /// </summary>
    public new CmdInfoRubrique Rubrique 
    {
      get
      {
        return base.Rubrique;
      }
    }

    /// <summary>
    /// La position dans la rubrique : en lecture seule
    /// </summary>
    public new int Position
    {
      get
      {
        return base.Position;
      }
    }

    /// <summary>
    /// Type d'alarme acceptée par le champ : en lecture seule
    /// </summary>
    public new AlarmType AlarmeType
    {
      get
      {
        return base.AlarmeType;
      }
   }

    /// <summary>
    /// La valeur originale
    /// </summary>
    public string OriginalValue { get; protected set; }
    
    /// <summary>
    /// La valeur affichable à l'utilisateur
    /// </summary>
    public string Value { get; protected set; }
    
    /// <summary>
    /// Indique si l'information est éditable ou pas
    /// </summary>
    public bool IsEditable { get; protected set; }
    #endregion

    #region Properties
    /// <summary>
    /// L'alarme et son statut
    /// </summary>
    public IAlarm Alarm { get; set; }
    #endregion

    #region Les méthodes de décryptage des données
    /// <summary>
    /// fiche une taille en Octets, Ko, MO, Go... à partir de la chaine qui représente un long
    /// </summary>
    /// <param name="value">valeur à affiché (long)</param>
    /// <returns>la taille localisée</returns>
    public static string GetCounterBit(string value)
    {
      long taille;
      if (long.TryParse(value, out taille))
      {
        return InformationBase.GetCounterBit(taille);
      }
      else
      {
        return value;
      }
    }

    /// <summary>
    /// Affiche une taille en Octets, Ko, MO, Go...
    /// </summary>
    /// <param name="taille">La taille</param>
    /// <returns>la taille localisée</returns>
    public static string GetCounterBit(long taille)
    {
      if (taille < 1024)
      { // Octet
        return RedisInfoTranslator.GetCounterValue(taille, InformationDansRubriqueRessources.Vbit_count0, InformationDansRubriqueRessources.Vbit_count1, InformationDansRubriqueRessources.VBit_countN);
      }
      else if (taille < 1024 * 1024)
      { // Kilos
        return string.Format(InformationDansRubriqueRessources.VbitKN, (double)taille / 1024.0);
      }
      else if (taille < 1024 * 1024 * 1024)
      { // Mega
        return string.Format(InformationDansRubriqueRessources.VbitMN, (double)taille / (1024.0 * 1024.0));
      }
      else
      { // Giga
        return string.Format(InformationDansRubriqueRessources.VbitGN, (double)taille / (1024.0 * 1024.0 * 1024.0));
      }
    }

    /// <summary>
    /// Affiche une taille quand la valeur passée est en Mégabit
    /// </summary>
    /// <param name="value">Valeur à afficher</param>
    /// <returns>Le texte</returns>
    public static string GetCounterMegaBit(string value)
    {
      double taille;
      if (double.TryParse(value, out taille))
      {
        if (taille < 1024 * 1024 * 1024)
        { // Mega
          return string.Format(InformationDansRubriqueRessources.VbitMN, (double)taille / (1024.0 * 1024.0));
        }
        else
        { // Giga
          return string.Format(InformationDansRubriqueRessources.VbitGN, (double)taille / (1024.0 * 1024.0 * 1024.0));
        }
      }
      else
      {
        return value;
      }
    }

    /// <summary>
    /// Affiche un compte en fonction de la quantité
    /// </summary>
    /// <param name="value">Valeur à afficher</param>
    /// <param name="fmt0">Texte à afficher si 0</param>
    /// <param name="fmt1">Texte à afficher si 1</param>
    /// <param name="fmtN">Format d'affichage si > 1</param>
    /// <returns>Le texte résultat</returns>
    public static string GetCounterValue(long value, string fmt0, string fmt1, string fmtN)
    {
      if (value == 0)
      {
        return fmt0;
      }
      else if (value == 1)
      {
        return fmt1;
      }
      else
      {
        return string.Format(fmtN, value);
      }
    }

     /// <summary>
    /// Affiche un compte en fonction de la quantité
    /// </summary>
    /// <param name="value">Valeur à afficher</param>
    /// <param name="fmt0">Texte à afficher si 0</param>
    /// <param name="fmt1">Texte à afficher si 1</param>
    /// <param name="fmtN">Format d'affichage si > 1</param>
    /// <returns>Le texte résultat</returns>
    public static string GetCounterValue(string value, string fmt0, string fmt1, string fmtN)
    {
      long nb;
      if (long.TryParse(value, out nb))
      {
        return GetCounterValue(nb, fmt0, fmt1, fmtN);
      }
      else
      {
        return value;
      }
    }

    /// <summary>
    /// Affiche booléen
    /// </summary>
    /// <param name="value">Valeur à afficher</param>
    /// <returns>Le texte résultat</returns>
    public static string GetBooleanValue(string value)
    {
      if (value == "1")
      {
        return InformationDansRubriqueRessources.OptionYes;
      }
      else if (value == "0")
      {
        return InformationDansRubriqueRessources.OptionNo;
      }
      else
      { // en cas d'erreur de programmation
        return value;
      }
    }

    /// <summary>
    /// Affiche une durée la valeur de départ est en microsecondes
    /// </summary>
    /// <param name="value">durée en microsecondes</param>
    /// <returns>Le texte résultat</returns>
    public static string GetTimeSpanMicroSecValue(string value)
    {
      long ts;
      if (long.TryParse(value, out ts))
      { // value est en MicroSecondes
        TimeSpan tspan = new TimeSpan(ts * 10);
        return tspan.ToFormatted();
      }
      else
      {
        return value;
      }
    }

    /// <summary>
    /// Affiche une durée la valeur de départ est en millisecondes
    /// </summary>
    /// <param name="value">durée en millisecondes</param>
    /// <returns>Le texte résultat</returns>
    public static string GetTimeSpanMilliSecValue(string value)
    {
      long ts;
      if (long.TryParse(value, out ts))
      { // value est en MicroSecondes
        TimeSpan tspan = TimeSpan.FromMilliseconds(ts);
        return tspan.ToFormatted();
      }
      else
      {
        return value;
      }
    }

    /// <summary>
    /// Affiche une durée la valeur de départ est en minutes
    /// </summary>
    /// <param name="value">durée en minutes</param>
    /// <returns>Le texte résultat</returns>
    public static string GetTimeSpanMinuteValue(string value)
    {
      long ts;
      if (long.TryParse(value, out ts))
      { // value est en minutes
        TimeSpan tspan = new TimeSpan(ts * 60 * 10000000);
        return tspan.ToFormatted();
      }
      else
      {
        return value;
      }
    }

    /// <summary>
    /// Affiche une date
    /// </summary>
    /// <param name="value">la date exprimée en UNIXTime</param>
    /// <returns>Le texte résultat</returns>
    public static string GetDateValue(string value)
    {
      double per;
      if (double.TryParse(value.Replace(".", NumberFormatInfo.CurrentInfo.NumberDecimalSeparator), out per))
      {
        return RedisConnector.GetDateTimeFromUnixTime(per).ToLocalTime().ToString("G"); // Date courte
      }
      else
      {
        return value;
      }
    }

    /// <summary>
    /// Affiche un pourcentage (la valeur doit être de 1 pour avoir 100.00 %)
    /// </summary>
    /// <param name="value">Texte de la valeur</param>
    /// <param name="multiplyByfactor100">Indique s'il faut ou pas multiplier par 100 le nombre pour avoir le pourcentage</param>
    /// <returns>Le texte résultat</returns>
    public static string GetPercentageValue(string value, bool multiplyByfactor100)
    {
      double per;
      if (double.TryParse(value.Replace(".", NumberFormatInfo.CurrentInfo.NumberDecimalSeparator), out per))
      {
        double factor = multiplyByfactor100 ? 100 : 1;
        return string.Format("{0:N2} %", per * factor);
      }
      else
      {
        return value;
      }
    }

    /// <summary>
    /// Affiche la valeur tel quelle en masquant les (Nil)
    /// </summary>
    /// <param name="value">Texte de la valeur</param>
    /// <returns>Le texte résultat</returns>
    public static string GetNonNilValue(string value)
    {
      if (string.IsNullOrWhiteSpace(value) || value.ToLower() == "(nil)")
      {
        return string.Empty;
      }
      else
      {
        return value;
      }
    }

    /// <summary>
    /// Affiche la valeur Oui / non
    /// </summary>
    /// <param name="value">Texte de la valeur</param>
    /// <returns>Le texte résultat</returns>
    public static string GetYesNoValue(string value)
    {
      if (value.ToLower() == "yes")
      {
        return InformationDansRubriqueRessources.Yes;
      }
      else if (value.ToLower() == "no")
      {
        return InformationDansRubriqueRessources.No;
      }
      else
      {
        return value;
      }
    }
   
    /// <summary>
    /// Affiche une durée la valeur de départ est en secondes
    /// </summary>
    /// <param name="value">durée en secondes</param>
    /// <returns>Le texte résultat</returns>
    public static string GetTimeSpanSecValue(string value)
    {
      long ts;
      if (long.TryParse(value, out ts))
      { // value est en Secondes
        TimeSpan tspan = new TimeSpan(ts * 10000000);
        return tspan.ToFormatted();
      }
      else
      {
        return value;
      }
    }
    #endregion

    /// <summary>
    /// Charge l'alarme en cours 
    /// </summary>
    public void LoadAlarm()
    {
      if (this.AlarmeType != AlarmType.None)
      { // on peut avoir une alarme sur ce type d'info
        if (this.Alarm == null)
        { // recherche de l'alarme en db
          this.Alarm = AlarmSaver.Instance.Get(this.Code, this.AlarmeType);
        }

        if (this.Alarm != null)
        { // correction des clés
          this.Alarm.Id = this.Code;
        }
      }
    }

    /// <summary>
    /// Renvoie le statut de l'alarme en cours
    /// </summary>
    /// <returns>Le statut calculé</returns>
    public AlarmStatus GetAlarmStatut()
    {
      if (this.Alarm != null)
      { // Y a bien une alarme : on vérifie
        return this.Alarm.Get(this.OriginalValue);
      }
      else
      {
        return AlarmStatus.AlarmNone;
      }
    }

    /// <summary>
    /// Renvoie un moyen de comparer des clés
    /// </summary>
    /// <param name="info2">l'autre information</param>
    /// <returns>TRUE si les clés sont identiques</returns>
    public virtual bool CompareKey(InformationBase info2)
    {
      if (info2 == null)
      {
        return false;
      }
      else
      {
        return this.Command.Equals(info2.Command) && this.Code.Equals(info2.Code);
      }
    }
  }
}
