using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using RedisManagementStudio.BLL.Alarm;

namespace RedisManagementStudio.BLL.Redis
{
  /// <summary>
  /// Singleton pour la gestion de la sauvegarde et du chargement 
  /// des propriétés d'un serveur
  /// </summary>
  public class RubriqueManager
  {
    /// <summary>
    /// Fichier de configuration
    /// </summary>
    private const string FILECONFIG = @"rubriques.xml";

    /// <summary>
    /// L'instance du singleton
    /// </summary>
    private static RubriqueManager myStaticInstance;

    /// <summary>
    /// Empêche la création d'une instance par défaut de la classe <see cref="RubriqueManager" />.
    /// </summary>
    private RubriqueManager()
    {
      string nomfichier = RubriqueManager.GetFileName();
      if (!System.IO.File.Exists(nomfichier))
      { // pas de config on en crée une par défaut
        this.CreeFile(nomfichier);
      }

      this.Load(nomfichier);
    }

    /// <summary>
    /// Le singleton
    /// </summary>
    public static RubriqueManager Instance
    {
      get
      {
        if (myStaticInstance == null)
        {
          myStaticInstance = new RubriqueManager();
        }

        return myStaticInstance;
      }
    }

    /// <summary>
    /// Les données en statiques
    /// </summary>
    public static List<InformationDansRubrique> Donnees
    {
      get
      {
        return Instance.Datas;
      }
    }

    /// <summary>
    /// Les données
    /// </summary>
    public List<InformationDansRubrique> Datas { get; private set; }

    /// <summary>
    /// Renvoie l'informationDansRubrique qui correspond au code de la commande demandée
    /// </summary>
    /// <param name="command">Commande demandée</param>
    /// <param name="code">Code demandé</param>
    /// <returns>l'information Dans Rubrique</returns>
    public static InformationDansRubrique Get(string command, string code)
    {
      return Instance.Getinformation(command, code);
    }

    /// <summary>
    /// Renvoie la liste des rubrique complété par celle obtenue en DB
    /// </summary>
    /// <param name="redisConnection">la connexion</param>
    /// <param name="rubrique">La rubrique</param>
    /// <returns>La liste</returns>
    public static IEnumerable<InformationDansRubrique> Liste(RedisConnection redisConnection, CmdInfoRubrique rubrique)
    {
      return Instance.GetListeInformation(redisConnection, rubrique);
    }

    /// <summary>
    /// Sauvegarde du fichier
    /// </summary>
    public static void Save()
    {
      Instance.Save(RubriqueManager.GetFileName());
    }

    /// <summary>
    /// Chargement d'une config depuis le fichier
    /// </summary>
    /// <param name="fileName">Nom du fichier à charger</param>
    public void Load(string fileName)
    {
      this.Datas = new List<InformationDansRubrique>();
      XDocument doc = XDocument.Load(fileName);
      foreach (XElement r in doc.Element("rubs").Elements("rub"))
      {
        InformationDansRubrique rub = new InformationDansRubrique();
        rub.Load(r);
        this.Datas.Add(rub);
      }
    }

    /// <summary>
    /// Sauvegarde du fichier
    /// </summary>
    /// <param name="fileName">Nom du fichier à sauvegarder</param>
    public void Save(string fileName)
    {
      XElement rac = new XElement("rubs");
      foreach (InformationDansRubrique r in this.Datas)
      {
        rac.Add(r.Save());
      }

      rac.Save(fileName);
    }

    /// <summary>
    /// renvoie Le nom du fichier de config
    /// </summary>
    /// <returns>Le nom du fichier de config</returns>
    private static string GetFileName()
    {
      FileInfo fi = new FileInfo(Application.ExecutablePath);
      return Path.Combine(fi.DirectoryName, RubriqueManager.FILECONFIG);
    }

    /// <summary>
    /// Crée un fichier
    /// </summary>
    /// <param name="fileName">Nom du fichier à créer</param>
    private void CreeFile(string fileName)
    {
      this.Datas = new List<InformationDansRubrique>();

      this.Datas.Add(new InformationDansRubrique("INFO", "redis_version", CmdInfoRubrique.Server, 0, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "redis_git_sha1", CmdInfoRubrique.Server, 1, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "redis_git_dirty", CmdInfoRubrique.Server, 2, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "multiplexing_api", CmdInfoRubrique.Server, 3, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "mem_allocator", CmdInfoRubrique.Server, 4, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "maxmemory-policy", CmdInfoRubrique.Server, 5, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "gcc_version", CmdInfoRubrique.Server, 6, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "vm_enabled", CmdInfoRubrique.Server, 7, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "os", CmdInfoRubrique.Server, 8, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "arch_bits", CmdInfoRubrique.Server, 9, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "daemonize", CmdInfoRubrique.Server, 10, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "tcp_port", CmdInfoRubrique.Server, 11, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "port", CmdInfoRubrique.Server, 12, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "process_id", CmdInfoRubrique.Server, 13, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "run_id", CmdInfoRubrique.Server, 14, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "redis_mode", CmdInfoRubrique.Server, 15, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "databases", CmdInfoRubrique.Server, 16, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "maxclients", CmdInfoRubrique.Server, 17, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "uptime_in_seconds", CmdInfoRubrique.Server, 18, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "uptime_in_days", CmdInfoRubrique.Server, 19, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "lru_clock", CmdInfoRubrique.Server, 20, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "loglevel", CmdInfoRubrique.Server, 21, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "requirepass", CmdInfoRubrique.Server, 22, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "masterauth", CmdInfoRubrique.Server, 23, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "unixsocket", CmdInfoRubrique.Server, 24, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "logfile", CmdInfoRubrique.Server, 25, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "pidfile", CmdInfoRubrique.Server, 26, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "bind", CmdInfoRubrique.Server, 27, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "activerehashing", CmdInfoRubrique.Server, 28, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "unixsocketperm", CmdInfoRubrique.Server, 29, AlarmType.None));

      this.Datas.Add(new InformationDansRubrique("INFO", "connected_clients", CmdInfoRubrique.Client, 0, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "blocked_clients", CmdInfoRubrique.Client, 1, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "client_longest_output_list", CmdInfoRubrique.Client, 2, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "client_biggest_input_buf", CmdInfoRubrique.Client, 3, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "timeout", CmdInfoRubrique.Client, 4, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "client-output-buffer-limit", CmdInfoRubrique.Client, 5, AlarmType.None));

      this.Datas.Add(new InformationDansRubrique("INFO", "used_memory", CmdInfoRubrique.MemoryCPU, 0, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "used_memory_human", CmdInfoRubrique.MemoryCPU, 1, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "used_memory_rss", CmdInfoRubrique.MemoryCPU, 2, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "used_memory_peak", CmdInfoRubrique.MemoryCPU, 3, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "used_memory_peak_human", CmdInfoRubrique.MemoryCPU, 4, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "mem_fragmentation_ratio", CmdInfoRubrique.MemoryCPU, 5, AlarmType.CounterDown));
      this.Datas.Add(new InformationDansRubrique("INFO", "used_cpu_sys", CmdInfoRubrique.MemoryCPU, 6, AlarmType.CounterDown));
      this.Datas.Add(new InformationDansRubrique("INFO", "used_cpu_user", CmdInfoRubrique.MemoryCPU, 7, AlarmType.CounterDown));
      this.Datas.Add(new InformationDansRubrique("INFO", "used_cpu_sys_children", CmdInfoRubrique.MemoryCPU, 8, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "used_cpu_user_children", CmdInfoRubrique.MemoryCPU, 9, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "used_memory_lua", CmdInfoRubrique.MemoryCPU, 10, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "lua-time-limit", CmdInfoRubrique.MemoryCPU, 11, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "maxmemory", CmdInfoRubrique.MemoryCPU, 12, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "maxmemory-policy", CmdInfoRubrique.MemoryCPU, 13, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "maxmemory-samples", CmdInfoRubrique.MemoryCPU, 14, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "hash-max-zipmap-entries", CmdInfoRubrique.MemoryCPU, 15, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "hash-max-zipmap-value", CmdInfoRubrique.MemoryCPU, 16, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "hash-max-ziplist-entries", CmdInfoRubrique.MemoryCPU, 17, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "hash-max-ziplist-value", CmdInfoRubrique.MemoryCPU, 18, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "list-max-ziplist-entries", CmdInfoRubrique.MemoryCPU, 19, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "list-max-ziplist-value", CmdInfoRubrique.MemoryCPU, 20, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "set-max-intset-entries", CmdInfoRubrique.MemoryCPU, 21, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "zset-max-ziplist-entries", CmdInfoRubrique.MemoryCPU, 22, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "zset-max-ziplist-value", CmdInfoRubrique.MemoryCPU, 23, AlarmType.None));

      this.Datas.Add(new InformationDansRubrique("INFO", "rdb_changes_since_last_save", CmdInfoRubrique.Persistance, 0, AlarmType.CounterDown));
      this.Datas.Add(new InformationDansRubrique("INFO", "changes_since_last_save", CmdInfoRubrique.Persistance, 1, AlarmType.CounterDown));
      this.Datas.Add(new InformationDansRubrique("INFO", "rdb_bgsave_in_progress", CmdInfoRubrique.Persistance, 2, AlarmType.BoolControl));
      this.Datas.Add(new InformationDansRubrique("INFO", "bgsave_in_progress", CmdInfoRubrique.Persistance, 3, AlarmType.BoolControl));
      this.Datas.Add(new InformationDansRubrique("INFO", "rdb_last_save_time", CmdInfoRubrique.Persistance, 4, AlarmType.TimeSpanControl));
      this.Datas.Add(new InformationDansRubrique("INFO", "rdb_last_bgsave_status", CmdInfoRubrique.Persistance, 5, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "rdb_last_bgsave_time_sec", CmdInfoRubrique.Persistance, 6, AlarmType.TimeSpanControl));
      this.Datas.Add(new InformationDansRubrique("INFO", "rdb_current_bgsave_time_sec", CmdInfoRubrique.Persistance, 7, AlarmType.TimeSpanControl));
      this.Datas.Add(new InformationDansRubrique("INFO", "last_save_time", CmdInfoRubrique.Persistance, 8, AlarmType.TimeSpanControl));
      this.Datas.Add(new InformationDansRubrique("INFO", "aof_enabled", CmdInfoRubrique.Persistance, 9, AlarmType.BoolControl));
      this.Datas.Add(new InformationDansRubrique("INFO", "aof_rewrite_in_progress", CmdInfoRubrique.Persistance, 10, AlarmType.BoolControl));
      this.Datas.Add(new InformationDansRubrique("INFO", "aof_rewrite_scheduled", CmdInfoRubrique.Persistance, 11, AlarmType.BoolControl));
      this.Datas.Add(new InformationDansRubrique("INFO", "aof_last_bgrewrite_status", CmdInfoRubrique.Persistance, 12, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "aof_last_rewrite_time_sec", CmdInfoRubrique.Persistance, 13, AlarmType.TimeSpanControl));
      this.Datas.Add(new InformationDansRubrique("INFO", "aof_current_rewrite_time_sec", CmdInfoRubrique.Persistance, 14, AlarmType.TimeSpanControl));
      this.Datas.Add(new InformationDansRubrique("INFO", "bgrewriteaof_in_progress", CmdInfoRubrique.Persistance, 15, AlarmType.BoolControl));
      this.Datas.Add(new InformationDansRubrique("INFO", "aof_current_size", CmdInfoRubrique.Persistance, 16, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "aof_base_size", CmdInfoRubrique.Persistance, 17, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "aof_pending_rewrite", CmdInfoRubrique.Persistance, 18, AlarmType.BoolControl));
      this.Datas.Add(new InformationDansRubrique("INFO", "aof_buffer_length", CmdInfoRubrique.Persistance, 19, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "aof_rewrite_buffer_length", CmdInfoRubrique.Persistance, 20, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "aof_pending_bio_fsync", CmdInfoRubrique.Persistance, 21, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "aof_delayed_fsync", CmdInfoRubrique.Persistance, 22, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "loading", CmdInfoRubrique.Persistance, 23, AlarmType.BoolControl));
      this.Datas.Add(new InformationDansRubrique("INFO", "loading_start_time", CmdInfoRubrique.Persistance, 24, AlarmType.TimeSpanControl));
      this.Datas.Add(new InformationDansRubrique("INFO", "loading_total_bytes", CmdInfoRubrique.Persistance, 25, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "loading_loaded_bytes", CmdInfoRubrique.Persistance, 26, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "loading_loaded_perc", CmdInfoRubrique.Persistance, 27, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "loading_eta_seconds", CmdInfoRubrique.Persistance, 28, AlarmType.CounterDown));
      this.Datas.Add(new InformationDansRubrique("INFO", "lastsave", CmdInfoRubrique.Persistance, 29, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "dir", CmdInfoRubrique.Persistance, 30, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "dbfilename", CmdInfoRubrique.Persistance, 31, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "auto-aof-rewrite-min-size", CmdInfoRubrique.Persistance, 32, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "auto-aof-rewrite-percentage", CmdInfoRubrique.Persistance, 33, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "appendonly", CmdInfoRubrique.Persistance, 34, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "no-appendfsync-on-rewrite", CmdInfoRubrique.Persistance, 35, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "appendfsync", CmdInfoRubrique.Persistance, 36, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "save", CmdInfoRubrique.Persistance, 37, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "stop-writes-on-bgsave-error", CmdInfoRubrique.Persistance, 38, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "rdbcompression", CmdInfoRubrique.Persistance, 39, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "rdbchecksum", CmdInfoRubrique.Persistance, 40, AlarmType.None));

      this.Datas.Add(new InformationDansRubrique("INFO", "total_connections_received", CmdInfoRubrique.Statistics, 0, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "total_commands_processed", CmdInfoRubrique.Statistics, 1, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "instantaneous_ops_per_sec", CmdInfoRubrique.Statistics, 2, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "rejected_connections", CmdInfoRubrique.Statistics, 3, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "dbsize", CmdInfoRubrique.Statistics, 4, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "expired_keys", CmdInfoRubrique.Statistics, 5, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "evicted_keys", CmdInfoRubrique.Statistics, 6, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "keyspace_hits", CmdInfoRubrique.Statistics, 7, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "keyspace_misses", CmdInfoRubrique.Statistics, 8, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "pubsub_channels", CmdInfoRubrique.Statistics, 9, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "pubsub_patterns", CmdInfoRubrique.Statistics, 10, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "latest_fork_usec", CmdInfoRubrique.Statistics, 11, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "dbxxx", CmdInfoRubrique.Statistics, 12, AlarmType.None));

      this.Datas.Add(new InformationDansRubrique("INFO", "role", CmdInfoRubrique.Replication, 0, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "master_host", CmdInfoRubrique.Replication, 1, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "master_port", CmdInfoRubrique.Replication, 2, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "master_link_status", CmdInfoRubrique.Replication, 3, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "master_last_io_seconds_ago", CmdInfoRubrique.Replication, 4, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "master_sync_in_progress", CmdInfoRubrique.Replication, 5, AlarmType.BoolControl));
      this.Datas.Add(new InformationDansRubrique("INFO", "master_sync_left_bytes", CmdInfoRubrique.Replication, 6, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "master_sync_last_io_seconds_ago", CmdInfoRubrique.Replication, 7, AlarmType.TimeSpanControl));
      this.Datas.Add(new InformationDansRubrique("INFO", "master_link_down_since_seconds", CmdInfoRubrique.Replication, 8, AlarmType.TimeSpanControl));
      this.Datas.Add(new InformationDansRubrique("INFO", "connected_slaves", CmdInfoRubrique.Replication, 9, AlarmType.BoolControl));
      this.Datas.Add(new InformationDansRubrique("INFO", "cluster_enabled", CmdInfoRubrique.Replication, 10, AlarmType.BoolControl));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "slave-serve-stale-data", CmdInfoRubrique.Replication, 11, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "repl-ping-slave-period", CmdInfoRubrique.Replication, 12, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "repl-timeout", CmdInfoRubrique.Replication, 13, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "watchdog-period", CmdInfoRubrique.Replication, 14, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "slave-priority", CmdInfoRubrique.Replication, 15, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "slave-read-only", CmdInfoRubrique.Replication, 16, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "slaveof", CmdInfoRubrique.Replication, 17, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "slavexxx", CmdInfoRubrique.Replication, 18, AlarmType.None));

      this.Datas.Add(new InformationDansRubrique("CONFIG", "slowlog-max-len", CmdInfoRubrique.Command, 0, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "slowlog-log-slower-than", CmdInfoRubrique.Command, 1, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("CONFIG", "cmdstat_xxx", CmdInfoRubrique.Command, 2, AlarmType.None));

      this.Datas.Add(new InformationDansRubrique("INFO", "sentinel_tilt", CmdInfoRubrique.Sentinel, 0, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "sentinel_running_scripts", CmdInfoRubrique.Sentinel, 1, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("INFO", "sentinel_scripts_queue_length", CmdInfoRubrique.Sentinel, 2, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "sentinel_masters", CmdInfoRubrique.Sentinel, 3, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("INFO", "masterxxx", CmdInfoRubrique.Sentinel, 4, AlarmType.None));

      this.Datas.Add(new InformationDansRubrique("SENTINEL_SERVERS", "name", CmdInfoRubrique.SentinelServer, 0, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("SENTINEL_SERVERS", "ip", CmdInfoRubrique.SentinelServer, 1, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("SENTINEL_SERVERS", "port", CmdInfoRubrique.SentinelServer, 2, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("SENTINEL_SERVERS", "runid", CmdInfoRubrique.SentinelServer, 3, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("SENTINEL_SERVERS", "flags", CmdInfoRubrique.SentinelServer, 4, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("SENTINEL_SERVERS", "pending-commands", CmdInfoRubrique.SentinelServer, 5, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("SENTINEL_SERVERS", "last-ok-ping-reply", CmdInfoRubrique.SentinelServer, 6, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("SENTINEL_SERVERS", "last-ping-reply", CmdInfoRubrique.SentinelServer, 7, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("SENTINEL_SERVERS", "info-refresh", CmdInfoRubrique.SentinelServer, 8, AlarmType.CounterUp));
      this.Datas.Add(new InformationDansRubrique("SENTINEL_SERVERS", "num-slaves", CmdInfoRubrique.SentinelServer, 9, AlarmType.CounterDown));
      this.Datas.Add(new InformationDansRubrique("SENTINEL_SERVERS", "num-other-sentinels", CmdInfoRubrique.SentinelServer, 10, AlarmType.CounterDown));
      this.Datas.Add(new InformationDansRubrique("SENTINEL_SERVERS", "quorum", CmdInfoRubrique.SentinelServer, 11, AlarmType.CounterDown));
      this.Datas.Add(new InformationDansRubrique("SENTINEL_SERVERS", "master-link-down-time", CmdInfoRubrique.SentinelServer, 12, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("SENTINEL_SERVERS", "master-link-status", CmdInfoRubrique.SentinelServer, 13, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("SENTINEL_SERVERS", "master-host", CmdInfoRubrique.SentinelServer, 14, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("SENTINEL_SERVERS", "master-port", CmdInfoRubrique.SentinelServer, 15, AlarmType.None));
      this.Datas.Add(new InformationDansRubrique("SENTINEL_SERVERS", "slave-priority", CmdInfoRubrique.SentinelServer, 16, AlarmType.None));

      this.Save(fileName);
    }

    /// <summary>
    /// Renvoie l'informationDansRubrique qui correspond au code de la commande demandé
    /// </summary>
    /// <param name="command">Commande demandée</param>
    /// <param name="code">Code demandé</param>
    /// <returns>l'information Dans Rubrique</returns>
    private InformationDansRubrique Getinformation(string command, string code)
    {
      command = command.ToUpper();
      code = code.ToLower();
      return this.Datas.Where(x => x.Command == command && x.Code == code).FirstOrDefault();
    }

    /// <summary>
    /// Renvoie la liste des informations dans une rubrique
    /// </summary>
    /// <param name="redisConnection">la connexion</param>
    /// <param name="rubrique">La rubrique</param>
    /// <returns>la liste</returns>
    private IEnumerable<InformationDansRubrique> GetListeInformation(RedisConnection redisConnection, CmdInfoRubrique rubrique)
    {
      if (redisConnection != null)
      {
        var res1 = this.Datas.Where(x => x.Rubrique == rubrique);
        var nfos = redisConnection.GetInfoAndConfig();
        IEnumerable<InformationDansRubrique> rubs = nfos.Where(x => x.Rubrique == rubrique).Select(x => (InformationDansRubrique)x);
        IEnumerable<InformationDansRubrique> res2 = rubs.Except(res1);
        this.Datas.AddRange(res2);
      }

      return this.Datas.Where(x => x.Rubrique == rubrique).OrderBy(x => x.Position);
    }
  }
}
