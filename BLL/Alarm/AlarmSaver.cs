using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ServiceStack.Text;

namespace RedisManagementStudio.BLL.Alarm
{
  /// <summary>
  /// Classe utilisée pour charger et sauver des alarmes
  /// </summary>
  public class AlarmSaver : IDisposable
  {
    /// <summary>
    /// Fichier des alarmes
    /// </summary>
    private const string FILEALARM = @"Alarmes.alr";

    /// <summary>
    /// Singleton des alarmes
    /// </summary>
    private static AlarmSaver instance = null;

    /// <summary>
    /// Liste des alarmes sur info booléenne
    /// </summary>
    private Dictionary<string, AlarmBool> alarmBool = null;

    /// <summary>
    /// Liste des alarmes sur info numérique croissante
    /// </summary>
    private Dictionary<string, AlarmCounter> alarmCount = null;

    /// <summary>
    /// Liste des alarmes sur info numérique décroissante
    /// </summary>
    private Dictionary<string, AlarmDownCounter> alarmDownCount = null;

    /// <summary>
    /// Empêche la création d'une instance par défaut de la classe <see cref="AlarmSaver" />.
    /// </summary>
    private AlarmSaver()
    {
      this.Load();
    }

    #region Interface publique
    /// <summary>
    /// Méthode pour le singleton
    /// </summary>
    public static AlarmSaver Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new AlarmSaver();
        }

        return instance;
      }
    }

    /// <summary>
    /// Sauvegarde sur disque
    /// </summary>
    public void Flush()
    {
      this.Save();
    }

    /// <summary>
    /// Nettoyage = Sauvegarde sur disque
    /// </summary>
    public void Dispose()
    {
      this.Save();
    }

    /// <summary>
    /// Renvoie une alarme
    /// </summary>
    /// <param name="key">La clé de l'alarme</param>
    /// <param name="typ">Le type d'alarme</param>
    /// <returns>L'alarme si trouvé NULL sinon</returns>
    public IAlarm Get(string key, AlarmType typ)
    {
      switch (typ)
      {
        case AlarmType.BoolControl:
          return this.GetBool(key);
        case AlarmType.CounterUp:
          return this.GetCounter(key);
        case AlarmType.CounterDown:
          return this.GetDownCounter(key);
      }

      return null;
    }

    /// <summary>
    /// Défini une alarme
    /// </summary>
    /// <param name="alrm">Alarme à stoker</param>
    public void Set(IAlarm alrm)
    {
      switch (alrm.Type)
      {
        case AlarmType.BoolControl:
          this.SetBool(alrm as AlarmBool);
          break;
        case AlarmType.CounterUp:
          this.SetCounter(alrm as AlarmCounter);
          break;
        case AlarmType.CounterDown:
          this.SetDownCounter(alrm as AlarmDownCounter);
          break;
      }
    }

    /// <summary>
    /// Efface une alarme 
    /// </summary>
    /// <param name="alrm">Alarme à effacer</param>
    public void Del(IAlarm alrm)
    {
      switch (alrm.Type)
      {
        case AlarmType.BoolControl:
          this.DelBool(alrm as AlarmBool);
          break;
        case AlarmType.CounterUp:
          this.DelCounter(alrm as AlarmCounter);
          break;
        case AlarmType.CounterDown:
          this.DelDownCounter(alrm as AlarmDownCounter);
          break;
      }
    }
    #endregion

    #region Méthodes privées
    /// <summary>
    /// Renvoie une alarme de type booléenne
    /// </summary>
    /// <param name="key">La clé</param>
    /// <returns>L'alarme si trouvé NULL sinon</returns>
    private AlarmBool GetBool(string key)
    {
      if (this.alarmBool.ContainsKey(key))
      {
        return this.alarmBool[key];
      }
      else
      {
        return null;
      }
    }

    /// <summary>
    /// Renvoie une alarme de type numérique croissant
    /// </summary>
    /// <param name="key">La clé</param>
    /// <returns>L'alarme si trouvé NULL sinon</returns>
    private AlarmCounter GetCounter(string key)
    {
      if (this.alarmCount.ContainsKey(key))
      {
        return this.alarmCount[key];
      }
      else
      {
        return null;
      }
    }

    /// <summary>
    /// Renvoie une alarme de type numérique décroissante
    /// </summary>
    /// <param name="key">La clé</param>
    /// <returns>L'alarme si trouvé NULL sinon</returns>
    private AlarmDownCounter GetDownCounter(string key)
    {
      if (this.alarmDownCount.ContainsKey(key))
      {
        return this.alarmDownCount[key];
      }
      else
      {
        return null;
      }
    }

    /// <summary>
    /// Défini une alarme booléenne
    /// </summary>
    /// <param name="alrm">Alarme à stoker</param>
    private void SetBool(AlarmBool alrm)
    {
      if (this.alarmBool.ContainsKey(alrm.Id))
      {
        this.alarmBool[alrm.Id] = alrm;
      }
      else
      {
        this.alarmBool.Add(alrm.Id, alrm);
      }
    }

    /// <summary>
    /// Défini une alarme numérique croissante
    /// </summary>
    /// <param name="alrm">Alarme à stoker</param>
    private void SetCounter(AlarmCounter alrm)
    {
      if (this.alarmCount.ContainsKey(alrm.Id))
      {
        this.alarmCount[alrm.Id] = alrm;
      }
      else
      {
        this.alarmCount.Add(alrm.Id, alrm);
      }
    }

    /// <summary>
    /// Défini une alarme numérique décroissante
    /// </summary>
    /// <param name="alrm">Alarme à stoker</param>
    private void SetDownCounter(AlarmDownCounter alrm)
    {
      if (this.alarmDownCount.ContainsKey(alrm.Id))
      {
        this.alarmDownCount[alrm.Id] = alrm;
      }
      else
      {
        this.alarmDownCount.Add(alrm.Id, alrm);
      }
    }

    /// <summary>
    /// Efface une alarme booléenne
    /// </summary>
    /// <param name="alrm">Alarme à effacer</param>
    private void DelBool(AlarmBool alrm)
    {
      if (this.alarmBool.ContainsKey(alrm.Id))
      {
        this.alarmBool.Remove(alrm.Id);
      }
    }

    /// <summary>
    /// Efface une alarme numérique croissante
    /// </summary>
    /// <param name="alrm">Alarme à effacer</param>
    private void DelCounter(AlarmCounter alrm)
    {
      if (this.alarmCount.ContainsKey(alrm.Id))
      {
        this.alarmCount.Remove(alrm.Id);
      }
    }

    /// <summary>
    /// Efface une alarme numérique décroissante
    /// </summary>
    /// <param name="alrm">Alarme à effacer</param>
    private void DelDownCounter(AlarmDownCounter alrm)
    {
      if (this.alarmDownCount.ContainsKey(alrm.Id))
      {
        this.alarmDownCount.Remove(alrm.Id);
      }
    }

    /// <summary>
    /// Renvoie le nom du fichier des alarmes
    /// </summary>
    /// <returns>Le nom du fichier</returns>
    private string GetFileName()
    {
      FileInfo fi = new FileInfo(Application.ExecutablePath);
      return Path.Combine(fi.DirectoryName, AlarmSaver.FILEALARM);
    }

    /// <summary>
    /// Charge les alarmes
    /// </summary>
    private void Load()
    {
      this.alarmBool = new Dictionary<string, AlarmBool>();
      this.alarmCount = new Dictionary<string, AlarmCounter>();
      this.alarmDownCount = new Dictionary<string, AlarmDownCounter>();

      if (System.IO.File.Exists(this.GetFileName()))
      {
        using (StreamReader rd = new StreamReader(this.GetFileName()))
        {
          string line;
          while ((line = rd.ReadLine()) != null)
          {
            if (!line.StartsWith("#") && line.IndexOf('@') != -1)
            {
              string[] nfo = line.Split('@');
              AlarmType type = (AlarmType)Enum.Parse(typeof(AlarmType), nfo[0]);
              switch (type)
              {
                case AlarmType.BoolControl:
                  AlarmBool bl = this.Deserialize<AlarmBool>(nfo[1]);
                  this.alarmBool.Add(bl.Id, bl);
                  break;
                case AlarmType.CounterUp:
                  AlarmCounter bc = this.Deserialize<AlarmCounter>(nfo[1]);
                  this.alarmCount.Add(bc.Id, bc);
                  break;
                case AlarmType.CounterDown:
                  AlarmDownCounter bu = this.Deserialize<AlarmDownCounter>(nfo[1]);
                  this.alarmDownCount.Add(bu.Id, bu);
                  break;
              }
            }
          }
        }
      }
    }

    /// <summary>
    /// Enregistre sur disque les alarmes
    /// </summary>
    private void Save()
    {
      using (StreamWriter sw = new StreamWriter(this.GetFileName()))
      {
        this.SaveCollection(sw, AlarmType.BoolControl, this.alarmBool);
        this.SaveCollection(sw, AlarmType.CounterUp, this.alarmCount);
        this.SaveCollection(sw, AlarmType.CounterDown, this.alarmDownCount);
      }
    }

    /// <summary>
    /// Enregistre une collection d'alarmes
    /// </summary>
    /// <typeparam name="IAlarm">Type de la collection d'alarme doit respecter l'interface IALARM</typeparam>
    /// <param name="sw">le flux d'écriture</param>
    /// <param name="typ">Le type d'alarme</param>
    /// <param name="lst">La collection</param>
    private void SaveCollection<IAlarm>(StreamWriter sw, AlarmType typ, Dictionary<string, IAlarm> lst)
    {
      JsonSerializer<IAlarm> serializer = new JsonSerializer<IAlarm>();
      foreach (string key in lst.Keys)
      {
        var n = lst[key];
        sw.WriteLine(string.Format("{0}@{1}", typ, n.SerializeToString()));
      }
    }

    /// <summary>
    /// Extrait une alarme
    /// </summary>
    /// <typeparam name="T">Le Type d'objet à créer</typeparam>
    /// <param name="strValue">la chaine sérialisé</param>
    /// <returns>L'objet remplis</returns>
    private T Deserialize<T>(string strValue)
    {
      JsonSerializer<T> serializer = new JsonSerializer<T>();
      return serializer.DeserializeFromString(strValue);
    }
    #endregion
  }
}