using System;
using System.Text;

namespace RedisManagementStudio.BLL.Redis.Config
{
  /// <summary>
  /// Gère les informations de configuration
  /// </summary>
  public class RedisConfigTranslator : InformationBase
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="RedisConfigTranslator" />.
    /// </summary>
    /// <param name="key">Clé de l'information</param>
    /// <param name="value">valeur affecté</param>
    public RedisConfigTranslator(string key, string value)
      : base("CONFIG", key, value)
    {
      this.Value = RedisConfigTranslator.GetValue(this.Code, this.OriginalValue);
      this.IsEditable = true;
    }

    /// <summary>
    /// Renvoie la valeur affichable
    /// </summary>
    /// <param name="key">La clé</param>
    /// <param name="value">La valeur brute</param>
    /// <returns>La valeur formatée</returns>
    private static string GetValue(string key, string value)
    {
      switch (key)
      {
        case "dir":
        case "dbfilename":
        case "maxmemory-policy":
        case "maxmemory-samples":

        case "bind":
        case "unixsocket":
        case "logFile":
        case "pidFile":
        case "hash-max-ziplist-entries":
        case "hash-max-ziplist-value":
        case "lua-time-limit":
        case "port":
        case "databases":
        case "repl-ping-slave-period":
        case "repl-timeout":
        case "maxclients":
        case "watchdog-period":
        case "slave-priority":
        case "client-output-buffer-limit":
        case "unixsocketperm":
        case "slaveof":
          return value;
        case "requirepass":
        case "masterauth":
          return RedisConfigTranslator.GetNonNilValue(value);
        case "maxmemory":
        case "auto-aof-rewrite-min-size":
        case "hash-max-zipmap-entries":
        case "hash-max-zipmap-value":
        case "list-max-ziplist-entries":
        case "list-max-ziplist-value":
        case "set-max-intset-entries":
        case "zset-max-ziplist-entries":
        case "zset-max-ziplist-value":
        case "slowlog-max-len":
          return RedisConfigTranslator.GetCounterBit(value);
        case "timeout":
          return RedisConfigTranslator.GetTimeSpanSecValue(value);
        case "slowlog-log-slower-than":
          return RedisConfigTranslator.GetTimeSpanMicroSecValue(value);
        case "appendonly":
        case "no-appendfsync-on-rewrite":
        case "slave-serve-stale-data":
        case "stop-writes-on-bgsave-error":
        case "daemonize":
        case "rdbcompression":
        case "rdbchecksum":
        case "slave-read-only":
        case "activerehashing":
          return RedisConfigTranslator.GetYesNoValue(value);
        case "appendfsync":
          if (value.ToLower() == "everysec")
          {
            return InformationDansRubriqueRessources.Vappendfsync_everysec;
          }
          else
          {
            return value;
          }

        case "save":
          return GetSaveIntervalles(value);
        case "auto-aof-rewrite-percentage":
          return RedisConfigTranslator.GetPercentageValue(value, false);
        case "loglevel":
          return InformationDansRubriqueRessources.GetLogLevelValue(value);
      }

      return value;
    }

    /// <summary>
    /// Renvoie formaté la valeur de save
    /// </summary>
    /// <param name="value">La valeur</param>
    /// <returns>La listes des paramètre formatée en clair</returns>
    private static string GetSaveIntervalles(string value)
    {
      if (string.IsNullOrWhiteSpace(value) || value.IndexOf(' ') == -1)
      {
        return value;
      }
      else
      {
        StringBuilder res = new StringBuilder();
        string[] nfo = value.Split(' ');
        int i = 0;
        int n, t;
        string fmt;
        TimeSpan ts;
        while (i + 1 <= nfo.Length)
        {
          if (int.TryParse(nfo[i], out t) && int.TryParse(nfo[i + 1], out n))
          {
            fmt = n > 1 ? InformationDansRubriqueRessources.VsaveN : InformationDansRubriqueRessources.Vsave1;
            ts = new TimeSpan(0, 0, t);
            res.AppendFormat(fmt.Trim(), n, ts.ToFormatted().Trim());
          }

          i = i + 2;
          if (i + 1 < nfo.Length)
          {
            res.Append(" " + InformationDansRubriqueRessources.VsaveSepi.Trim() + " ");
          }
        }

        return res.ToString().Trim();
      }
    }
  }
}