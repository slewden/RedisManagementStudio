using System;
using System.Globalization;
using RedisManagementStudio.BLL.Alarm;

namespace RedisManagementStudio.BLL.Redis.Config
{
  /// <summary>
  /// Classe gérant les informations du serveur REDIS
  /// </summary>
  public class RedisInfoTranslator : InformationBase
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="RedisInfoTranslator" />.
    /// </summary>
    /// <param name="code">Le code de la rubrique</param>
    /// <param name="value">la valeur</param>
    public RedisInfoTranslator(string code, string value)
      : base("INFO", code, value)
    {
      this.Value = RedisInfoTranslator.GetValue(this.Code, this.OriginalValue);
      this.IsEditable = false;
    }

    /// <summary>
    /// Fourni le code interne à utiliser pour la recherche des infos
    /// </summary>
    protected override void ComputeInternalCodeRubrique()
    {
      if (this.Code.StartsWith("slave") && this.Code.Length >= 6)
      {
        this.InternalRubriqueCode = "slavexxx";
      }
      else if (this.Code.StartsWith("cmdstat_") && this.Code.Length >= 8)
      {
        this.InternalRubriqueCode = "cmdstat_xxx";
      }
      else if (this.Code.StartsWith("db") && (this.Code.Length == 3 || this.Code.Length == 4))
      {
        this.InternalRubriqueCode = "dbxxx";
      }
      else if (this.Code.StartsWith("master")  && this.Code.Length > 6)
      {
        this.InternalRubriqueCode = "masterxxx";
      }
      else
      {
        base.ComputeInternalCodeRubrique();
      }
    }

    /// <summary>
    /// Charge les titres
    /// </summary>
    protected override void LoadTitre()
    {
      string index;
      if (this.Code.StartsWith("slave") && this.Code.Length >= 6)
      {
        index = this.Code.Substring(5);
        this.InternalTitre = string.Format(InformationDansRubriqueRessources.INFOTslavexxx, index);
      }
      else if (this.Code.StartsWith("cmdstat_") && this.Code.Length >= 8)
      {
        index = this.Code.Substring(8);
        this.InternalTitre = string.Format(InformationDansRubriqueRessources.INFOTcmdstat_xxx, index);
      }
      else if (this.Code.StartsWith("db") && (this.Code.Length == 3 || this.Code.Length == 4))
      {
        index = this.Code.Substring(3);
        this.InternalTitre = string.Format(InformationDansRubriqueRessources.INFOTdbxxx, index);
      }
      else if (this.Code.StartsWith("master")  && this.Code.Length > 6)
      {
        index = this.Code.Substring(6);
        this.InternalTitre = string.Format(InformationDansRubriqueRessources.INFOTmasterxxx, index);
      }
      else
      {
        base.LoadTitre();
      }
    }

    /// <summary>
    /// Charge les descriptions
    /// </summary>
    protected override void LoadDescription()
    {
      string index;
      if (this.Code.StartsWith("slave") && this.Code.Length >= 6)
      {
        index = this.Code.Substring(5);
        this.InternalDescription = string.Format(InformationDansRubriqueRessources.INFODslavexxx, index);
      }
      else if (this.Code.StartsWith("cmdstat_") && this.Code.Length >= 8)
      {
        index = this.Code.Substring(8);
        this.InternalDescription = string.Format(InformationDansRubriqueRessources.INFODcmdstat_xxx, index);
      }
      else if (this.Code.StartsWith("db") && (this.Code.Length == 3 || this.Code.Length == 4))
      {
        index = this.Code.Substring(3);
        this.InternalDescription = string.Format(InformationDansRubriqueRessources.INFODdbxxx, index);
      }
      else if (this.Code.StartsWith("master") && this.Code.Length > 6)
      {
        index = this.Code.Substring(6);
        this.InternalDescription = string.Format(InformationDansRubriqueRessources.INFODmasterxxx, index);
      }
      else
      {
        base.LoadDescription();
      }
    }

    /// <summary>
    /// renvoie la valeur formatée pour le code concerné
    /// </summary>
    /// <param name="key">Code concerné</param>
    /// <param name="value">valeur brute</param>
    /// <returns>Valeur formatée</returns>
    private static string GetValue(string key, string value)
    {
      key = key.ToLower();
      long ts;
      int nb;
      double per;

      switch (key)
      {
        // Valeurs telle quelle
        case "redis_version":
        case "redis_git_sha1":
        case "multiplexing_api":
        case "process_id":
        case "os":
        case "gcc_version":
        case "run_id":
        case "tcp_port":
        case "mem_allocator":
        case "used_memory_human":
        case "used_memory_peak_human":
        case "aof_delayed_fsync":
        case "total_connections_received":
        case "total_commands_processed":
        case "instantaneous_ops_per_sec":
        case "rejected_connections":
        case "expired_keys":
        case "evicted_keys":
        case "keyspace_hits":
        case "keyspace_misses":
        case "pubsub_channels":
        case "pubsub_patterns":
        case "master_host":
        case "master_port":
        case "dbsize":
        case "lastSave":

        case "sentinel_masters":
        case "sentinel_running_scripts":
        case "sentinel_scripts_queue_length":
          return value;

        // Booléens
        case "redis_git_dirty":
        case "rdb_bgsave_in_progress":
        case "bgsave_in_progress":
        case "aof_enabled":
        case "aof_rewrite_in_progress":
        case "aof_rewrite_scheduled":
        case "bgrewriteaof_in_progress":
        case "aof_pending_rewrite":
        case "loading":
        case "master_sync_in_progress":
        case "cluster_enabled":
        case "vm_enabled":
        case "sentinel_tilt":
          return RedisInfoTranslator.GetBooleanValue(value);

        // format de l'architecture 32 ou 64 bits
        case "arch_bits":
          return string.Format(InformationDansRubriqueRessources.Varch_bits, value);

        // durées en Sec
        case "uptime_in_seconds":
        case "rdb_last_bgsave_time_sec":
        case "rdb_current_bgsave_time_sec":
        case "aof_last_rewrite_time_sec":
        case "aof_current_rewrite_time_sec":
        case "loading_eta_seconds":
        case "master_last_io_seconds_ago":
        case "master_sync_last_io_seconds_ago":
        case "master_link_down_since_seconds":
          return RedisInfoTranslator.GetTimeSpanSecValue(value);

        // durées en micoSec
        case "latest_fork_usec":
          return RedisInfoTranslator.GetTimeSpanMicroSecValue(value);

        // Nombre de jours
        case "uptime_in_days":
          if (int.TryParse(value, out nb))
          {
            return RedisInfoTranslator.GetCounterValue(nb, InformationDansRubriqueRessources.Vuptime_in_days0, InformationDansRubriqueRessources.Vuptime_in_days1, InformationDansRubriqueRessources.Vuptime_in_daysN);
          }
          else
          {
            return value;
          }

        // nombres de minutes
        case "lru_clock":
          return RedisInfoTranslator.GetTimeSpanMinuteValue(value);

        // Compteur de clients
        case "connected_clients":
          if (int.TryParse(value, out nb))
          {
            nb--; // on enlève la connexion de ce programme !
            return RedisInfoTranslator.GetCounterValue(nb, InformationDansRubriqueRessources.Vconnected_clients0, InformationDansRubriqueRessources.Vconnected_clients1, InformationDansRubriqueRessources.Vconnected_clientsN);
          }
          else
          {
            return value;
          }

        // Compteur de bits
        case "client_longest_output_list":
        case "client_biggest_input_buf":
        case "used_memory_lua":
        case "aof_current_size":
        case "aof_base_size":
        case "aof_buffer_length":
        case "aof_rewrite_buffer_length":
        case "loading_total_bytes":
        case "loading_loaded_bytes":
        case "master_sync_left_bytes":
          return RedisInfoTranslator.GetCounterBit(value);

        case "used_memory":
        case "used_memory_rss":
        case "used_memory_peak":
          return RedisInfoTranslator.GetCounterMegaBit(value);

        // compteur de clients bloqués
        case "blocked_clients":
          if (int.TryParse(value, out nb))
          {
            return RedisInfoTranslator.GetCounterValue(
              nb,
              InformationDansRubriqueRessources.Vblocked_clients0,
              InformationDansRubriqueRessources.Vblocked_clients1,
              InformationDansRubriqueRessources.Vblocked_clientsN);
          }
          else
          {
            return value;
          }

        // pourcentages
        case "mem_fragmentation_ratio":
        case "loading_loaded_perc":
          return RedisInfoTranslator.GetPercentageValue(value, true);

        // compteurs de changements
        case "rdb_changes_since_last_save":
        case "changes_since_last_save":
          if (long.TryParse(value, out ts))
          {
            return RedisInfoTranslator.GetCounterValue(
              Math.Abs(ts),
              InformationDansRubriqueRessources.Vchanges_sincelast_save0,
              InformationDansRubriqueRessources.Vchanges_sincelast_save1,
              InformationDansRubriqueRessources.Vchanges_sincelast_saveN);
          }
          else
          {
            return value;
          }

        // Timespan unix
        case "rdb_last_save_time":
        case "last_save_time":
        case "loading_start_time":
          return RedisInfoTranslator.GetDateValue(value);

        // Status de sauvegarde
        case "aof_last_bgrewrite_status":
        case "rdb_last_bgsave_status":
          if (value == "1")
          { // TODO rdb_last_bgsave_status : Valeurs possibles A vérifier ??
            return InformationDansRubriqueRessources.Vlast_bgsave_statusOk;
          }
          else if (value == "0")
          {
            return InformationDansRubriqueRessources.Vlast_bgsave_statusKo;
          }
          else
          { // au cas ou il y aurait d'autres valeurs
            return value;
          }

        // compteur de Job de synchronisation
        case "aof_pending_bio_fsync":
          if (int.TryParse(value, out nb))
          {
            return RedisInfoTranslator.GetCounterValue(
              nb,
              InformationDansRubriqueRessources.Vaof_pending_bio_fsync0,
              InformationDansRubriqueRessources.Vaof_pending_bio_fsync1,
              InformationDansRubriqueRessources.Vaof_pending_bio_fsyncN);
          }
          else
          {
            return value;
          }

        // Rôle dans la réplication
        case "role":
          if (value == "master")
          {
            return InformationDansRubriqueRessources.VroleMaster;
          }
          else
          {
            return InformationDansRubriqueRessources.VroleSlave;
          }

        case "redis_mode":
          if (value == "standalone")
          {
            return InformationDansRubriqueRessources.VModeAlone;
          }
          else if (value == "sentinel")
          {
            return InformationDansRubriqueRessources.VModeSentinel;
          }
          else
          {
            return value + " ??";
          }

        // connecté ou pas au master
        case "master_link_status":
          if (value == "up")
          {
            return InformationDansRubriqueRessources.Vmaster_link_statusUp;
          }
          else if (value == "down")
          {
            return InformationDansRubriqueRessources.Vmaster_link_statusDown;
          }
          else
          { // en cas de nouvelle valeur...
            return value;
          }

        // compteur d'abonné à une replication
        case "connected_slaves":
          if (int.TryParse(value, out nb))
          {
            return RedisInfoTranslator.GetCounterValue(
              nb,
              InformationDansRubriqueRessources.Vconnected_slaves0,
              InformationDansRubriqueRessources.Vconnected_slaves1,
              InformationDansRubriqueRessources.Vconnected_slavesN);
          }
          else
          {
            return value;
          }

        // compteurs d'activité CPU
        case "used_cpu_sys":
        case "used_cpu_user":
        case "used_cpu_sys_children":
        case "used_cpu_user_children":
          if (double.TryParse(value.Replace(".", NumberFormatInfo.CurrentInfo.NumberDecimalSeparator), out per))
          {
            if (per == 0)
            {
              return InformationDansRubriqueRessources.VcpuNone;
            }
            else
            {
              return string.Format(InformationDansRubriqueRessources.VcpuN, per);
            }
          }
          else
          {
            return value;
          }
      }

      if (key.StartsWith("slave") && key.Length >= 6)
      { // Clés de la forme slaveXXX : Contient Id, ip adress, port, state
        string index = key.Substring(5);
        
        if (value.IndexOf(",") != -1)
        {
          string[] nfo = value.Split(',');
          string statut = "?";
          if (nfo.Length >= 3)
          {
            if (nfo[2] == "up")
            {
              statut = InformationDansRubriqueRessources.VslaveStatusUp;
            }
            else if (value == "down")
            {
              statut = InformationDansRubriqueRessources.VslaveStatusDown;
            }
            else
            { // en cas de nouvelle valeur...
              statut = nfo[2];
            }
          }
         
          return string.Format(InformationDansRubriqueRessources.Vslave, index, nfo[0], nfo[1], statut);
        }
        else
        { // c'est pas le format prévu
          return value;
        }
      }
      else if (key.StartsWith("cmdstat_"))
      { // compteurs de commandes
        if (value.IndexOf(",") != -1)
        {
          string[] nfo = value.Split(',');
          if (nfo.Length >= 3)
          {
            return string.Format(
              InformationDansRubriqueRessources.Vcmdstat, 
              nfo[0].Replace("calls=", string.Empty), 
              nfo[1].Replace("usec=", string.Empty), 
              nfo[2].Replace("usecpaercall=", string.Empty));
          }
          else
          { // c'est pas le format prévu
            return value;
          }
        }
        else
        { // c'est pas le format prévu
          return value;
        }
      }
      else if (key.StartsWith("db") && (key.Length == 3 || key.Length == 4))
      { // Compteur de clés
        if (value.IndexOf(",") != -1)
        {
          string[] nfo = value.Split(',');
          if (nfo.Length >= 2)
          {
            return string.Format(InformationDansRubriqueRessources.Vdb, nfo[0].Replace("keys=", string.Empty), nfo[1].Replace("expires=", string.Empty));
          }
          else
          { // c'est pas le format prévu
            return value;
          }
        }
        else
        { // c'est pas le format prévu
          return value;
        }
      }
      else if (key.StartsWith("master") && key.Length > 6)
      {
        if (value.IndexOf(",") != -1)
        {
          string[] nfo = value.Split(',');
          if (nfo.Length >= 3)
          {
            return string.Format(
              InformationDansRubriqueRessources.Vmaster,
              nfo[0].Replace("name=", string.Empty),
              nfo[1].Replace("status=", string.Empty),
              nfo[2].Replace("adress=", string.Empty));
          }
          else
          { // c'est pas le format prévu
            return value;
          }
        }
        else
        { // c'est pas le format prévu
          return value;
        }
      }

      return value;
    }
  }
}
