using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedisManagementStudio.BLL.Redis.Sentinel
{
  /// <summary>
  /// Gère les infos d'un serveur suivi par Sentinel
  /// </summary>
  public class SentinelServer
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="SentinelServer" />.
    /// </summary>
    /// <param name="index">Position dans la liste</param>
    /// <param name="infos">Dictionnaire des informations a associer</param>
    public SentinelServer(int index, Dictionary<string, string> infos)
    {
      this.Index = index;
      this.Properties = new List<SentinelServerSuivisInfo>();
      this.Slaves = new List<SentinelServer>();
      this.Master = null;

      if (infos != null && infos.Count > 0)
      {
        foreach (string key in infos.Keys)
        {
          this.Properties.Add(new SentinelServerSuivisInfo(key, infos[key]));

          if (key.ToLower() == "name")
          { // on identifie l'adresse IP
            this.Name = infos[key];
          }
          else if (key.ToLower() == "flags")
          {
            this.IsMaster = infos[key] == "master";
          }
        }
      }
    }

    /// <summary>
    /// Rang du client dans la liste
    /// </summary>
    public int Index { get; private set; }

    /// <summary>
    /// liste des propriétés
    /// </summary>
    public List<SentinelServerSuivisInfo> Properties { get; private set; }

    /// <summary>
    /// Le nom d'identification du serveur
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Indique si c'est un maitre ou un esclave
    /// </summary>
    public bool IsMaster { get; private set; }

    /// <summary>
    /// Liste des esclaves
    /// </summary>
    public List<SentinelServer> Slaves { get; private set; }
    
    /// <summary>
    /// Le maitre dans le cas d'un esclave
    /// </summary>
    public SentinelServer Master { get; private set; }
   
    /// <summary>
    /// Renvoie une chaine décrivant le serveur
    /// </summary>
    /// <returns>La chaine représentant le serveur</returns>
    public override string ToString()
    {
      if (this.IsMaster)
      {
        return string.Format(RedisManagementStudio.Properties.Resources.SentinelServerSuivisListInfoToStringM, this.Index, this.Name);
      }
      else
      {
        return string.Format(RedisManagementStudio.Properties.Resources.SentinelServerSuivisListInfoToStringE, this.Index, this.Name);
      }
    }

    /// <summary>
    /// Ajout des slaves
    /// </summary>
    /// <param name="slaves">La liste des slaves</param>
    public void SlavesAdd(List<SentinelServer> slaves)
    {
      foreach (SentinelServer slave in slaves)
      {
        this.Slaves.Add(slave);
        slave.Master = this;
      }
    }
  }
}
