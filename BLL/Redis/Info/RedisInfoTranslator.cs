using System;
using System.Globalization;
using RedisManagementStudio.BLL.Alarm;

namespace RedisManagementStudio.BLL.Redis.Info
{
  /// <summary>
  /// Classe gérant les informations du serveur REDIS
  /// </summary>
  public class RedisInfoTranslator : InformationBase
  {
    /// <summary>
    /// Constructeur de la classe
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
    /// renvoie la rubrique associée au code key
    /// </summary>
    /// <param name="key">La clé</param>
    /// <returns>La rubrique</returns>
    private static CmdInfoRubrique GetRubrique(string key)
    {
      key = key.ToLower();
      switch (key)
      {
        case "redis_version":
        case "redis_git_sha1":
        case "redis_git_dirty":
        case "arch_bits":
        case "multiplexing_api":
        case "process_id":
        case "uptime_in_seconds":
        case "uptime_in_days":
        case "lru_clock":

        case "os":
        case "gcc_version":
        case "run_id":
        case "tcp_port":
        case "mem_allocator":
          return CmdInfoRubrique.Server;

        case "connected_clients":
        case "client_longest_output_list":
        case "client_biggest_input_buf":
        case "blocked_clients":
          return CmdInfoRubrique.Client;

        case "used_memory":
        case "used_memory_human":
        case "used_memory_rss":
        case "used_memory_peak":
        case "used_memory_peak_human":
        case "used_memory_lua":
        case "mem_fragmentation_ratio":
        case "used_cpu_sys":
        case "used_cpu_user":
        case "used_cpu_sys_children":
        case "used_cpu_user_children":
          return CmdInfoRubrique.MemoryCPU;

        case "rdb_changes_since_last_save":
        case "rdb_bgsave_in_progress":
        case "rdb_last_save_time":
        case "rdb_last_bgsave_status":
        case "rdb_last_bgsave_time_sec":
        case "rdb_current_bgsave_time_sec":
        case "changes_since_last_save":
        case "bgsave_in_progress":
        case "last_save_time":
        case "aof_enabled":
        case "aof_rewrite_in_progress":
        case "aof_rewrite_scheduled":
        case "aof_last_bgrewrite_status":
        case "aof_last_rewrite_time_sec":
        case "aof_current_rewrite_time_sec":
        case "bgrewriteaof_in_progress":
        case "aof_current_size":
        case "aof_base_size":
        case "aof_pending_rewrite":
        case "aof_buffer_length":
        case "aof_rewrite_buffer_length":
        case "aof_pending_bio_fsync":
        case "aof_delayed_fsync":
        case "loading":
        case "loading_start_time":
        case "loading_total_bytes":
        case "loading_loaded_bytes":
        case "loading_loaded_perc":
        case "loading_eta_seconds":
        case "lastSave":
          return CmdInfoRubrique.Persistance;

        case "total_connections_received":
        case "total_commands_processed":
        case "instantaneous_ops_per_sec":
        case "rejected_connections":
        case "dbsize":
        case "expired_keys":
        case "evicted_keys":
        case "keyspace_hits":
        case "keyspace_misses":
        case "pubsub_channels":
        case "pubsub_patterns":
        case "latest_fork_usec":
          return CmdInfoRubrique.Statistics;

        case "role":
        case "master_host":
        case "master_port":
        case "master_link_status":
        case "master_last_io_seconds_ago":
        case "master_sync_in_progress":
        case "master_sync_left_bytes":
        case "master_sync_last_io_seconds_ago":
        case "master_link_down_since_seconds":
        case "connected_slaves":
        case "cluster_enabled":
          return CmdInfoRubrique.Replication;

        case "vm_enabled":
          return CmdInfoRubrique.UnKnow;
      }

      if (key.StartsWith("slave") && key.Length == 8)
      { // Clés de la forme slaveXXX
        return CmdInfoRubrique.Replication;
      }
      else if (key.StartsWith("cmdstat_"))
      { // compteurs de commandes
        return CmdInfoRubrique.Command;
      }
      else if (key.StartsWith("db") && (key.Length == 3 || key.Length == 4))
      {
        return CmdInfoRubrique.MemoryCPU;
      }

      // pour les nouvelles commandes
      return CmdInfoRubrique.UnKnow;
    }

    /// <summary>
    /// renvoie la valeur formattée pour le code concerné
    /// </summary>
    /// <param name="key">Code concerné</param>
    /// <param name="value">valeur brute</param>
    /// <returns>Valeur formattée</returns>
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
        case "used_memory":
        case "used_memory_rss":
        case "used_memory_peak":
        case "used_memory_lua":
        case "aof_current_size":
        case "aof_base_size":
        case "aof_buffer_length":
        case "aof_rewrite_buffer_length":
        case "loading_total_bytes":
        case "loading_loaded_bytes":
        case "master_sync_left_bytes":
          return RedisInfoTranslator.GetCounterBit(value);

        // compteur de clients bloqués
        case "blocked_clients":
          if (int.TryParse(value, out nb))
          {
            return RedisInfoTranslator.GetCounterValue(nb, InformationDansRubriqueRessources.Vblocked_clients0, InformationDansRubriqueRessources.Vblocked_clients1, InformationDansRubriqueRessources.Vblocked_clientsN);
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
            return RedisInfoTranslator.GetCounterValue(Math.Abs(ts), InformationDansRubriqueRessources.Vchanges_sincelast_save0, InformationDansRubriqueRessources.Vchanges_sincelast_save1, InformationDansRubriqueRessources.Vchanges_sincelast_saveN);
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
            return RedisInfoTranslator.GetCounterValue(nb, InformationDansRubriqueRessources.Vaof_pending_bio_fsync0, InformationDansRubriqueRessources.Vaof_pending_bio_fsync1, InformationDansRubriqueRessources.Vaof_pending_bio_fsyncN);
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
            return RedisInfoTranslator.GetCounterValue(nb, InformationDansRubriqueRessources.Vconnected_slaves0, InformationDansRubriqueRessources.Vconnected_slaves1, InformationDansRubriqueRessources.Vconnected_slavesN);
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

      if (key.StartsWith("slave") && key.Length == 8)
      { // Clés de la forme slaveXXX : Contient Id, ip adress, port, state
        if (value.IndexOf(",") != -1)
        {
          string[] nfo = value.Split(',');
          string statut = "?";
          if (nfo.Length >= 4)
          {
            if (nfo[3] == "up")
            {
              statut = InformationDansRubriqueRessources.VslaveStatusUp;
            }
            else if (value == "down")
            {
              statut = InformationDansRubriqueRessources.VslaveStatusDown;
            }
            else
            { // en cas de nouvelle valeur...
              statut = nfo[3];
            }

            return string.Format(InformationDansRubriqueRessources.Vslave, nfo[0], nfo[1], nfo[2], statut);
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
      else if (key.StartsWith("cmdstat_"))
      { // compteurs de commandes
        if (value.IndexOf(",") != -1)
        {
          string[] nfo = value.Split(',');
          if (nfo.Length >= 3)
          {
            return string.Format(InformationDansRubriqueRessources.Vcmdstat, nfo[0].Replace("calls=", string.Empty), nfo[1].Replace("usec=", string.Empty), nfo[2].Replace("usecpaercall=", string.Empty));
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

      return value;
    }

    /// <summary>
    /// Renvoie la position
    /// </summary>
    /// <param name="key">La key</param>
    /// <param name="rub">la rubrique</param>
    /// <returns>La position</returns>
    private static int GetOrder(string key, CmdInfoRubrique rub)
    {
      int n = (int)rub * 1000;

      key = key.ToLower();
      switch (key)
      {
        // Server
        case "redis_version":
          n += 1;
          break;
        case "tcp_port":
        case "redis_git_sha1":
          n += 2;
          break;
        case "redis_git_dirty":
          n += 3;
          break;
        case "multiplexing_api":
          n += 4;
          break;
        case "gcc_version":
          n += 5;
          break;
        case "mem_allocator":
          n += 6;
          break;
        case "os":
          n += 7;
          break;
        case "arch_bits":
          n += 8;
          break;
        case "process_id":
          n += 9;
          break;
        case "run_id":
          n += 10;
          break;
        case "uptime_in_days":
          n += 11;
          break;
        case "uptime_in_seconds":
          n += 12;
          break;
        case "lru_clock":
          n += 13;
          break;

        // clients
        case "connected_clients":
          n += 1;
          break;
        case "blocked_clients":
          n += 2;
          break;
        case "client_longest_output_list":
          n += 3;
          break;
        case "client_biggest_input_buf":
          n += 4;
          break;

        // mémoire && CPU
        case "used_memory":
          n += 2;
          break;
        case "used_memory_human":
          n += 3;
          break;
        case "used_memory_rss":
          n += 4;
          break;
        case "used_memory_peak":
          n += 5;
          break;
        case "used_memory_peak_human":
          n += 6;
          break;
        case "used_memory_lua":
          n += 7;
          break;
        case "mem_fragmentation_ratio":
          n += 8;
          break;
        case "used_cpu_sys":
          n += 9;
          break;
        case "used_cpu_user":
          n += 10;
          break;
        case "used_cpu_sys_children":
          n += 11;
          break;
        case "used_cpu_user_children":
          n += 12;
          break;

        // persistance
        case "changes_since_last_save":
        case "rdb_changes_since_last_save":
          n += 1;
          break;
        case "aof_enabled":
          n += 2;
          break;
        case "aof_rewrite_scheduled":
          n += 3;
          break;

        case "rdb_bgsave_in_progress":
        case "bgsave_in_progress":
          n += 4;
          break;
        case "aof_rewrite_in_progress":
          n += 5;
          break;
        case "bgrewriteaof_in_progress":
          n += 6;
          break;
        case "loading":
          n += 7;
          break;

        case "last_save_time":
          n += 8;
          break;
        case "rdb_last_save_time":
          n += 9;
          break;
        case "rdb_last_bgsave_status":
          n += 10;
          break;
        case "rdb_last_bgsave_time_sec":
          n += 11;
          break;
        case "rdb_current_bgsave_time_sec":
          n += 12;
          break;
        case "aof_last_bgrewrite_status":
          n += 13;
          break;
        case "aof_last_rewrite_time_sec":
          n += 14;
          break;
        case "aof_current_rewrite_time_sec":
          n += 15;
          break;
        case "aof_current_size":
          n += 16;
          break;
        case "aof_base_size":
          n += 17;
          break;
        case "aof_pending_rewrite":
          n += 18;
          break;
        case "aof_buffer_length":
          n += 19;
          break;
        case "aof_rewrite_buffer_length":
          n += 20;
          break;
        case "aof_pending_bio_fsync":
          n += 21;
          break;
        case "aof_delayed_fsync":
          n += 22;
          break;
        case "loading_start_time":
          n += 23;
          break;
        case "loading_total_bytes":
          n += 24;
          break;
        case "loading_loaded_bytes":
          n += 25;
          break;
        case "loading_loaded_perc":
          n += 26;
          break;
        case "loading_eta_seconds":
          n += 27;
          break;
        case "lastSave":
          n += 28;
          break;

        // Statistiques
        case "total_connections_received":
          n += 1;
          break;
        case "total_commands_processed":
          n += 2;
          break;
        case "instantaneous_ops_per_sec":
          n += 3;
          break;
        case "rejected_connections":
          n += 4;
          break;
        case "dbsize":
          n += 5;
          break;
        case "expired_keys":
          n += 6;
          break;
        case "evicted_keys":
          n += 7;
          break;
        case "keyspace_hits":
          n += 8;
          break;
        case "keyspace_misses":
          n += 9;
          break;
        case "pubsub_channels":
          n += 10;
          break;
        case "pubsub_patterns":
          n += 11;
          break;
        case "latest_fork_usec":
          n += 12;
          break;

        // Replication
        case "role":
          n += 1;
          break;
        case "connected_slaves":
          n += 2;
          break;
        case "cluster_enabled":
          n += 3;
          break;
        case "master_host":
          n += 4;
          break;
        case "master_port":
          n += 5;
          break;
        case "master_link_down_since_seconds":
          n += 6;
          break;
        case "master_link_status":
          n += 7;
          break;
        case "master_last_io_seconds_ago":
          n += 8;
          break;
        case "master_sync_in_progress":
          n += 9;
          break;
        case "master_sync_left_bytes":
          n += 10;
          break;
        case "master_sync_last_io_seconds_ago":
          n += 11;
          break;

        // inconnu = non documenté
        case "vm_enabled":
          n += 1;
          break;
      }

      if (key.StartsWith("slave") && key.Length == 8)
      { // on est dans le groupe Replication
        n += 15;
      }
      else if (key.StartsWith("cmdstat_"))
      { // on est dans le groupe commandes
        n += 1;
      }
      else if (key.StartsWith("db") && (key.Length == 3 || key.Length == 4))
      { // on est dans le groupe Mémoire & CPU
        n += 15;
      }

      return n;
    }

    /// <summary>
    /// Renvoie le type d'alarme
    /// </summary>
    /// <param name="key">La clé a analyser</param>
    /// <returns>Le type d'alarme</returns>
    private static AlarmType GetType(string key)
    {
      key = key.ToLower();
      switch (key)
      {
        case "used_memory":
        case "used_memory_rss":
        case "used_memory_peak":
        case "used_memory_lua":
        case "connected_clients":
        case "blocked_clients":
        case "client_longest_output_list":
        case "client_biggest_input_buf":
        case "aof_current_size":
        case "aof_base_size":
        case "aof_buffer_length":
        case "aof_rewrite_buffer_length":
        case "aof_pending_bio_fsync":
        case "aof_delayed_fsync":
        case "loading_total_bytes":
        case "loading_loaded_bytes":
        case "total_connections_received":
        case "total_commands_processed":
        case "rejected_connections":
        case "expired_keys":
        case "evicted_keys":
        case "keyspace_hits":
        case "keyspace_misses":
        case "instantaneous_ops_per_sec":
        case "pubsub_channels":
        case "pubsub_patterns":
        case "latest_fork_usec":
        case "master_last_io_seconds_ago":
        case "master_sync_left_bytes":
        case "master_sync_last_io_seconds_ago":
        case "master_link_down_since_seconds":
        case "uptime_in_seconds":
        case "uptime_in_days":
        case "lru_clock":
        case "dbsize":
        case "lastSave":
          return AlarmType.CounterUp;

        case "mem_fragmentation_ratio":
        case "rdb_changes_since_last_save":
        case "changes_since_last_save":
        case "loading_eta_seconds":
        case "used_cpu_sys":
        case "used_cpu_user":
          return AlarmType.CounterDown;

        case "rdb_bgsave_in_progress":
        case "aof_enabled":
        case "bgsave_in_progress":
        case "aof_rewrite_in_progress":
        case "aof_rewrite_scheduled":
        case "bgrewriteaof_in_progress":
        case "aof_pending_rewrite":
        case "loading":
        case "master_sync_in_progress":
        case "connected_slaves":
        case "cluster_enabled":
        case "vm_enabled":
          return AlarmType.BoolControl;

        case "rdb_last_save_time":
        case "rdb_last_bgsave_time_sec":
        case "last_save_time":
        case "aof_last_rewrite_time_sec":
        case "rdb_current_bgsave_time_sec":
        case "aof_current_rewrite_time_sec":
        case "loading_start_time":
        // TODO return AlarmType.TimeSpanControl;

        // TODO warning 32/64 bits ?
        case "arch_bits":

        case "redis_version":
        case "redis_git_sha1":
        case "redis_git_dirty":
        case "multiplexing_api":
        case "process_id":
        case "os":
        case "gcc_version":
        case "run_id":
        case "tcp_port":
        case "mem_allocator":
        case "used_memory_human":
        case "used_memory_peak_human":
        case "used_cpu_sys_children":
        case "used_cpu_user_children":
        case "rdb_last_bgsave_status":
        case "aof_last_bgrewrite_status":
        case "loading_loaded_perc":
        case "role":
        case "master_host":
        case "master_port":
        case "master_link_status":
          return AlarmType.None;
      }

      // pour les nouvelles commandes
      return AlarmType.None;
    }
  }
}
