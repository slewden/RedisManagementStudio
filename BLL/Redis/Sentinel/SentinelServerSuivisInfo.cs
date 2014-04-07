using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedisManagementStudio.BLL.Redis.Client;

namespace RedisManagementStudio.BLL.Redis.Sentinel
{
  /// <summary>
  /// Gère une propriété des information d'un serveur suivi par sentinel 
  /// </summary>
  public class SentinelServerSuivisInfo : InformationBase
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="SentinelServerSuivisInfo" />.
    /// </summary>
    /// <param name="key">La clé</param>
    /// <param name="value">LA valeur</param>
    public SentinelServerSuivisInfo(string key, string value)
      : base("SENTINEL_SERVERS", key, value)
    {
      this.Value = SentinelServerSuivisInfo.GetValue(key, value);
    }

    /// <summary>
    /// Renvoie la valeur en clair
    /// </summary>
    /// <param name="key">La clé</param>
    /// <param name="value">LA valeur cryptée</param>
    /// <returns>LA valeur en clair</returns>
    private static string GetValue(string key, string value)
    {
      key = key.ToLower();
      switch (key)
      {
        // Afficher tel quel
        case "name":
        case "ip":
        case "port":
        case "runid":
        case "master-host":
        case "master-port":
        case "slave-priority":
          return value;

        case "flags":
          if (value == "master")
          {
            return InformationDansRubriqueRessources.VSentinelflagsmaster;
          }
          else if (value == "slave")
          {
            return InformationDansRubriqueRessources.VSentinelflagsslave;
          }
          else
          { // TODO : trouver les autres valeurs
            return value + "??";
          }

        case "pending-commands":
          return RedisClientListInfo.GetCounterValue(
         value,
         InformationDansRubriqueRessources.VSentinelpending_commands0,
         InformationDansRubriqueRessources.VSentinelpending_commands1,
         InformationDansRubriqueRessources.VSentinelpending_commandsN);

        case "last-ok-ping-reply":
        case "last-ping-reply":
        case "info-refresh":
        case "master-link-down-time":
          return RedisClientListInfo.GetTimeSpanMilliSecValue(value);
        case "num-slaves":
          return RedisClientListInfo.GetCounterValue(
            value,
          InformationDansRubriqueRessources.VSentinelnum_slaves0,
          InformationDansRubriqueRessources.VSentinelnum_slaves1,
          InformationDansRubriqueRessources.VSentinelnum_slavesN);
        case "num-other-sentinels":
          return RedisClientListInfo.GetCounterValue(
            value,
          InformationDansRubriqueRessources.VSentinelnum_other_sentinels0,
          InformationDansRubriqueRessources.VSentinelnum_other_sentinels1,
          InformationDansRubriqueRessources.VSentinelnum_other_sentinelsN);
        case "quorum":
          return RedisClientListInfo.GetCounterValue(
            value,
          InformationDansRubriqueRessources.VSentinelquorum0,
          InformationDansRubriqueRessources.VSentinelquorum1,
          InformationDansRubriqueRessources.VSentinelquorumN);
        case "master-link-status":
          if (value == "ok")
          {
            return InformationDansRubriqueRessources.VSentinelmaster_link_statusok;
          }
          else
          {
            return value + "??";
          }
      }

      return value + "???";
    }
  }
}
