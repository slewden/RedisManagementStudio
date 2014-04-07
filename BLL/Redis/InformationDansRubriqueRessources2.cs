using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedisManagementStudio.BLL.Redis
{
  /// <summary>
  /// Ressource pour les informations
  /// </summary>
  internal partial class InformationDansRubriqueRessources
  {
    /// <summary>
    /// Renvoie la ressource demandée
    /// </summary>
    /// <param name="key">La clé</param>
    /// <returns>L'info formatée</returns>
    public static string GetRessource(string key)
    {
      return ResourceManager.GetString(key.Replace("-", "_"), resourceCulture);
    }

    /// <summary>
    /// Renvoie la valeur pour la propriété LOGLEVEL
    /// </summary>
    /// <param name="key">La clé</param>
    /// <returns>L'info formatée</returns>
    public static string GetLogLevelValue(string key)
    {
      string v = ResourceManager.GetString("Vloglevel_" + key.ToLower().Replace("-", "_"), resourceCulture);
      if (string.IsNullOrWhiteSpace(v))
      {
        return key;
      }
      else
      {
        return v;
      }
    }

    /// <summary>
    /// Renvoie la valeur pour la propriété APPENDFSYNC
    /// </summary>
    /// <param name="key">La clé</param>
    /// <returns>L'info formatée</returns>
    public static string GetAppendfSyncValue(string key)
    {
      string v = ResourceManager.GetString("Vappendfsync_" + key.ToLower().Replace("-", "_"), resourceCulture);
      if (string.IsNullOrWhiteSpace(v))
      {
        return key;
      }
      else
      {
        return v;
      }
    }

    /// <summary>
    /// Renvoie la description de la valeur key pour la propriété flags
    /// </summary>
    /// <param name="key">La valeur de la propriété flags</param>
    /// <returns>L'info formatée</returns>
    public static string GetFlagValue(string key)
    {
      string v = ResourceManager.GetString("flags_" + key.ToLower(), resourceCulture);
      if (string.IsNullOrWhiteSpace(v))
      {
        return key;
      }
      else
      {
        return v;
      }
    }

    /// <summary>
    /// Renvoie la description de la valeur de la propriété events
    /// </summary>
    /// <param name="key">La valeur de la propriété events</param>
    /// <returns>L'info formatée</returns>
    public static string GetEventsValue(string key)
    {
      string v = ResourceManager.GetString("events_" + key.ToLower(), resourceCulture);
      if (string.IsNullOrWhiteSpace(v))
      {
        return key;
      }
      else
      {
        return v;
      }
    }
  }
}
