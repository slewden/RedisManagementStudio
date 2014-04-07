namespace RedisManagementStudio.BLL.Redis
{
  /// <summary>
  /// Liste des rubriques de groupement des informations serveur
  /// </summary>
  public enum CmdInfoRubrique
  {
    /// <summary>
    /// Toutes les rubriques
    /// </summary>
    AllRubrique = 0,
    
    /// <summary>
    /// Rubrique infos sur le Serveur
    /// </summary>
    Server = 1,

    /// <summary>
    /// Informations sur la mémoire et le CPU
    /// </summary>
    MemoryCPU = 2,

    /// <summary>
    /// Informations sur les clients
    /// </summary>
    Client = 3,

    /// <summary>
    /// Information sur la persistance disque et sauvegardes
    /// </summary>
    Persistance = 4,

    /// <summary>
    /// informations sur la réplication
    /// </summary>
    Replication = 5,

    /// <summary>
    /// Informations sur les statistiques de fonctionnement du serveur
    /// </summary>
    Statistics = 6,

    /// <summary>
    /// Informations sur les commandes serveur
    /// </summary>
    Command = 7,

    /// <summary>
    /// informations sur les configurations spécifiques
    /// </summary>
    Configuration = 8,

    /// <summary>
    /// Regroupe les datas sentinel
    /// </summary>
    Sentinel = 9,

    /// <summary>
    /// Regroupe les données des serveur suivi par un sentinel
    /// </summary>
    SentinelServer = 10,

    /// <summary>
    /// Rubrique inconnue
    /// </summary>
    UnKnow = 11,

    /// <summary>
    /// Regroupe les données à ne pas afficher
    /// </summary>
    None = 12,
  }
}
