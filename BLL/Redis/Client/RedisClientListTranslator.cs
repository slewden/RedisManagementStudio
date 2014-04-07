using System.Collections.Generic;

namespace RedisManagementStudio.BLL.Redis.Client
{
  /// <summary>
  /// Gère les infos fournies par la commande REDIS client list
  /// </summary>
  public class RedisClientListTranslator
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="RedisClientListTranslator" />.
    /// </summary>
    /// <param name="index">Position du client dans la liste</param>
    /// <param name="infos">Liste des infos</param>
    public RedisClientListTranslator(int index, Dictionary<string, string> infos)
    {
      this.Index = index;
      this.Properties = new List<RedisClientListInfo>();

      if (infos != null && infos.Count > 0)
      {
        foreach (string key in infos.Keys)
        {
          this.Properties.Add(new RedisClientListInfo(key, infos[key]));

          if (key.ToLower() == "addr")
          { // on identifie l'adresse IP
            this.AdressIp = infos[key];
          }
          else if (key.ToLower() == "db")
          {
            this.BaseId = infos[key];
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
    public List<RedisClientListInfo> Properties { get; private set; }

    /// <summary>
    /// L'adresse IP (+ port) du client
    /// </summary>
    public string AdressIp { get; private set; }

    /// <summary>
    /// L'id de la base connecté
    /// </summary>
    public string BaseId { get; private set; }
    
    /// <summary>
    /// Renvoie une chaine décrivant le client
    /// </summary>
    /// <returns>La chaine représentant le client</returns>
    public override string ToString()
    {
      return string.Format(RedisManagementStudio.Properties.Resources.RedisClientListTranslatorToString, this.Index, this.AdressIp, this.BaseId); 
    }
  }
}
