using System;
using System.Collections.Generic;
using System.Linq;
using ClientRedisLib;
using RedisManagementStudio.BLL.Connection;
using RedisManagementStudio.BLL.Redis.Client;
using RedisManagementStudio.BLL.Redis.Config;
using RedisManagementStudio.BLL.Redis.Sentinel;

namespace RedisManagementStudio.BLL.Redis
{
  /// <summary>
  /// La connexion à la DB et les fonctions métier qui en découlent
  /// </summary>
  public class RedisConnection : IDisposable
  {
    /// <summary>
    /// Nombre de tentatives en cas d'échec d'une connexion
    /// </summary>
    private const int NOMBRETENTATIVEMAX = 2;

    /// <summary>
    /// Le client Redis
    /// </summary>
    private RedisConnector myConnector = null;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="RedisConnection" />.
    /// </summary>
    /// <param name="param">paramètre de connexion</param>
    public RedisConnection(RedisConnectionParam param)
    {
      this.Param = param;
    }

    /// <summary>
    /// Les informations de connexion non modifiables
    /// </summary>
    public RedisConnectionParam Param { get; private set; }

    /// <summary>
    /// Renvoie la description de la connexion
    /// </summary>
    public string FullDescription
    {
      get
      {
        if (this.Param != null)
        {
          return this.Param.FullDescription;
        }
        else
        {
          return string.Empty;
        }
      }
    }

    /// <summary>
    /// Renvoie le client Redis
    /// </summary>
    public RedisConnector Connector
    {
      get
      {
        if (this.myConnector == null)
        {
          this.myConnector = new RedisConnector(this.Param.URL, this.Param.Port, this.Param.Password);
          
          // this.myConnector.ConnectTimeout = 200;
          this.myConnector.Db = this.Param.Base;
        }

        return this.myConnector;
      }
    }

    /// <summary>
    /// Nettoyage en fin de séjour
    /// </summary>
    public void Dispose()
    {
      if (this.myConnector != null)
      {
        this.myConnector.Dispose();
        this.myConnector = null;
      }
    }

    /// <summary>
    /// Renvoie la liste des informations et configurations
    /// </summary>
    /// <returns>La liste des infos serveur + la config</returns>
    public IEnumerable<InformationBase> GetInfoAndConfig()
    {
      return this.GetInfoAndConfig(0);
    }
 
    /// <summary>
    /// Méthode de récupération de la liste des clients
    /// </summary>
    /// <returns>La liste des clients</returns>
    public List<RedisClientListTranslator> GetClients()
    {
      return this.GetClients(0);
    }

    /// <summary>
    /// Méthode de récupération de la liste des serveurs Masters gérés par sentinel
    /// </summary>
    /// <returns>La liste des clients</returns>
    public List<SentinelServer> GetSentinelServers()
    {
      return this.GetSentinelServers(0);
    }

    /// <summary>
    /// Méthode de récupération de la liste des serveurs Slaves gérés par sentinel
    /// </summary>
    /// <param name="masterKey">Le nom de la connexion du master</param>
    /// <returns>La liste des clients</returns>
    public List<SentinelServer> GetSentinelSlaves(string masterKey)
    {
      return this.GetSentinelSlaves(masterKey, 0);
    }

    /// <summary>
    /// Tue une connexion client
    /// </summary>
    /// <param name="adressIp">L'adresse IP + port à tuer</param>
    /// <returns>si problème de suppression renvoie le message. Vise si ok</returns>
    public string ClientKill(string adressIp)
    {
      if (!this.Connector.ClientKill(adressIp))
      {
        return this.Connector.LastErrorText;
      }
      else
      {
        return string.Empty;
      }
    }

    /// <summary>
    /// Renvoie le type de clé
    /// </summary>
    /// <param name="key">La clé à analyser</param>
    /// <returns>Le type de la clé</returns>
    public ETypeKey Type(string key)
    {
      return this.Connector.Type(key).ToTypeKey();
    }

    /// <summary>
    /// Calcule la taille de la clé key
    /// </summary>
    /// <param name="key">la clé</param>
    /// <returns>La taille</returns>
    public long GetSizeOfAKey(string key)
    {
      if (!string.IsNullOrWhiteSpace(key))
      {
        Dictionary<string, string> nfos = this.Connector.DebugObject(key);
        string sizeTxt = string.Empty;
        if (nfos.ContainsKey("serializedlength"))
        {
          sizeTxt = nfos["serializedlength"];
          long sizeLong = 0;
          if (long.TryParse(sizeTxt, out sizeLong))
          {
            return sizeLong;
          }
        }
      }

      return 0;
    }

    #region Private
    /// <summary>
    /// Renvoie la liste des client 
    /// fait plusieurs tentatives en cas d'erreur de connexion au serveur
    /// </summary>
    /// <param name="numTentative">index de la tentative</param>
    /// <returns>La liste des infos clients</returns>
    private List<RedisClientListTranslator> GetClients(int numTentative)
    {
      List<RedisClientListTranslator> res = new List<RedisClientListTranslator>();
      List<Dictionary<string, string>> clients;
      try
      {
        clients = this.Connector.ClientList();
      }
      catch
      {
        if (numTentative < NOMBRETENTATIVEMAX)
        {
          return this.GetClients(numTentative + 1);
        }
        else
        {
          clients = null;
        }
      }

      if (clients != null)
      {
        int i = 0;
        foreach (Dictionary<string, string> client in clients)
        {
          if (client.Count > 0)
          {
            res.Add(new RedisClientListTranslator(i++, client));
          }
        }
      }

      return res;
    }
    
    /// <summary>
    /// Renvoie la liste des serveur sentinel 
    /// fait plusieurs tentatives en cas d'erreur de connexion au serveur
    /// </summary>
    /// <param name="numTentative">index de la tentative</param>
    /// <returns>La liste des infos serveurs Sentinel</returns>
    private List<SentinelServer> GetSentinelServers(int numTentative)
    {
      List<SentinelServer> res = new List<SentinelServer>();
      List<Dictionary<string, string>> serveurs;
      try
      {
        serveurs = this.Connector.SentinelMasters();
      }
      catch
      {
        if (numTentative < NOMBRETENTATIVEMAX)
        {
          return this.GetSentinelServers(numTentative + 1);
        }
        else
        {
          serveurs = null;
        }
      }

      if (serveurs != null)
      {
        int i = 0;
        foreach (Dictionary<string, string> serveur in serveurs)
        {
          if (serveur.Count > 0)
          {
            res.Add(new SentinelServer(i++, serveur));
          }
        }
      }

      return res;
    }

    /// <summary>
    /// Renvoie la liste des esclaves d'un serveur suivi par sentinel 
    /// fait plusieurs tentatives en cas d'erreur de connexion au serveur
    /// </summary>
    /// <param name="masterKey">Le nom de la connexion du master</param>
    /// <param name="numTentative">index de la tentative</param>
    /// <returns>La liste des infos serveurs sentinel</returns>
    private List<SentinelServer> GetSentinelSlaves(string masterKey, int numTentative)
    {
      List<SentinelServer> res = new List<SentinelServer>();
      List<Dictionary<string, string>> slaves;
      try
      {
        slaves = this.Connector.SentinelSlaves(masterKey);
      }
      catch
      {
        if (numTentative < NOMBRETENTATIVEMAX)
        {
          return this.GetSentinelSlaves(masterKey, numTentative + 1);
        }
        else
        {
          slaves = null;
        }
      }

      if (slaves != null)
      {
        int i = 0;
        foreach (Dictionary<string, string> serveur in slaves)
        {
          if (serveur.Count > 0)
          {
            res.Add(new SentinelServer(i++, serveur));
          }
        }
      }

      return res;
    }

    /// <summary>
    /// Renvoie la liste des informations et configurations
    /// fait plusieurs tentatives en cas d'erreur de connexion au serveur
    /// </summary>
    /// <param name="numTentative">index de la tentative</param>
    /// <returns>La liste des infos serveur + la config</returns>
    private IEnumerable<InformationBase> GetInfoAndConfig(int numTentative)
    {
      IEnumerable<InformationBase> r = null;
      
      // Phase 1 : Les informations
      Dictionary<string, string> srvInfos;
      try
      {
        srvInfos = this.Connector.Info();
      }
      catch
      {
        if (numTentative < NOMBRETENTATIVEMAX)
        {
          return this.GetInfoAndConfig(numTentative + 1);
        }
        else
        {
          srvInfos = null;
        }
      }

      if (srvInfos != null)
      {
        List<RedisInfoTranslator> nfos = (from key in srvInfos.Keys
                                          select new RedisInfoTranslator(key, srvInfos[key])).ToList();

        // Phase 2 : dbSize
        RedisInfoTranslator nfoDbSize = this.GetBaseSize(0);
        if (nfoDbSize != null)
        {
          nfos.Add(nfoDbSize);
        }

        // Phase 3 : LastSave
        RedisInfoTranslator nfoLastSave = this.GetLastSave(0);
        if (nfoLastSave != null)
        {
          nfos.Add(nfoLastSave);
        }

        // Phase 4 : Les config
        List<RedisConfigTranslator> cfgs = this.GetConfigs(0);
        if (cfgs != null)
        {
          r = (from n in nfos select n as InformationBase).Union(cfgs);
        }
        else
        {
          r = from n in nfos select n as InformationBase;
        }
      }

      return r;
    }

    /// <summary>
    /// Renvoie l'information de la taille de la base (avec reprise sur erreur)
    /// </summary>
    /// <param name="numTentative">Nombre de tentatives</param>
    /// <returns>L'info ou nul si bug</returns>
    private RedisInfoTranslator GetBaseSize(int numTentative)
    {
      try
      {
        long size = this.Connector.DbSize();
        if (size >= 0)
        {
          return new RedisInfoTranslator("dbsize", size.ToString());
        }
        else
        { // une taille inférieur à 0 indique une erreur (ou on est en mode sentinel)
          return null;
        }
      }
      catch
      {
        if (numTentative < NOMBRETENTATIVEMAX)
        {
          return this.GetBaseSize(numTentative + 1);
        }
        else
        {
          return null;
        }
      }
    }

    /// <summary>
    /// Renvoie l'information de la dernière sauvegarde (avec reprise sur erreur)
    /// </summary>
    /// <param name="numTentative">Nombre de tentatives</param>
    /// <returns>L'info ou nul si bug</returns>
    private RedisInfoTranslator GetLastSave(int numTentative)
    {
      try
      {
        DateTime lastSave = this.Connector.LastSave();
        if (lastSave != DateTime.MaxValue)
        {
          return new RedisInfoTranslator("lastsave", lastSave.ToString("G"));
        }
        else
        { // si maxvalue ==> y a eu une erreur (ou sentinel mode !)
          return null;
        }
      }
      catch
      {
        if (numTentative < NOMBRETENTATIVEMAX)
        {
          return this.GetLastSave(numTentative + 1);
        }
        else
        {
          return null;
        }
      }
    }

    /// <summary>
    /// Renvoie la liste des config (avec reprise sur erreur
    /// </summary>
    /// <param name="numTentative">Nombre de tentatives</param>
    /// <returns>La liste ou nul si bug</returns>
    private List<RedisConfigTranslator> GetConfigs(int numTentative)
    {
      try
      {
        Dictionary<string, string> configs = this.Connector.ConfigGet("*");
        return (from key in configs.Keys
                select new RedisConfigTranslator(key, configs[key])).ToList();
      }
      catch
      {
        if (numTentative < NOMBRETENTATIVEMAX)
        {
          return this.GetConfigs(numTentative + 1);
        }

        return null;
      }
    }
    #endregion
  }
}