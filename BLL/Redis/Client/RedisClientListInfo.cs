using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedisManagementStudio.BLL.Redis.Client
{
  /// <summary>
  /// Gère une propriété des informations de connexion d'un client REDIS
  /// </summary>
  public class RedisClientListInfo : InformationBase
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="RedisClientListInfo" />.
    /// </summary>
    /// <param name="key">Clé de l'information</param>
    /// <param name="value">valeur affecté</param>
    public RedisClientListInfo(string key, string value)
      : base("CLIENT", key, value)
    {
      this.Value = RedisClientListInfo.GetValue(key, value);
    }

    /// <summary>
    /// indique si la propriété sert à construire un nom pour le client
    /// </summary>
    public bool IsInTitle
    {
      get
      {
        switch (this.Code.ToLower())
        {
          case "addr":
          case "db":
            return true;
        }

        return false;
      }
    }

    /// <summary>
    /// Renvoie la valeur affichable
    /// </summary>
    /// <param name="key">La clé</param>
    /// <param name="value">La valeur brute</param>
    /// <returns>La valeur formatée</returns>
    private static string GetValue(string key, string value)
    {
      key = key.ToLower();
      switch (key)
      {
        // afficher tel quel
        case "addr":
        case "fd":
        case "omem":
          return value;
        case "cmd":
          return value.ToUpper();

        // durée en sec
        case "age":
        case "idle":
          return RedisClientListInfo.GetTimeSpanSecValue(value);

        // flags spécifiques
        case "flags":
          return InformationDansRubriqueRessources.GetFlagValue(value);
        case "events":
          return InformationDansRubriqueRessources.GetEventsValue(value);
        case "db":
          return "ID N° " + value;

        case "sub":
          return RedisClientListInfo.GetCounterValue(value, InformationDansRubriqueRessources.Vsub0, InformationDansRubriqueRessources.Vsub1, InformationDansRubriqueRessources.VsubN);

        case "psub":
          return RedisClientListInfo.GetCounterValue(value, InformationDansRubriqueRessources.Vpsub0, InformationDansRubriqueRessources.Vpsub1, InformationDansRubriqueRessources.VpsubN);

        case "multi":
          return RedisClientListInfo.GetCounterValue(value, InformationDansRubriqueRessources.Vmulti0, InformationDansRubriqueRessources.Vmulti1, InformationDansRubriqueRessources.VmultiN);

        case "qbuf":
        case "qbuf-free":
        case "obl":
        case "oll":
          return RedisClientListInfo.GetCounterBit(value);
      }

      // dans le doute
      return value;
    }
  }
}
