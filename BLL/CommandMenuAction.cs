namespace RedisManagementStudio.BLL
{
  /// <summary>
  /// Les commandes du menu
  /// </summary>
  public enum CommandMenuAction
  {
    /// <summary>
    /// Aucune action
    /// </summary>
    None,

    /// <summary>
    /// Détail des infos du serveur
    /// </summary>
    Server,

    ///// <summary>
    ///// Les outils d'administration...
    ///// </summary>
    // Tools,

    /// <summary>
    /// Les actions sur les clients
    /// </summary>
    Clients,

    /// <summary>
    /// Afficher un client précis
    /// </summary>
    ClientDetail,

    /// <summary>
    /// Les configurations possibles du serveur
    /// </summary>
    Configuration,

    /// <summary>
    /// Une seule rubrique dans la configuration
    /// </summary>
    ConfigurationRubrique,

    /// <summary>
    /// Les actions sur les clés
    /// </summary>
    Keys,

    /// <summary>
    /// Une seule clé
    /// </summary>
    Key,

    /// <summary>
    /// un dossier avec plusieurs clés
    /// </summary>
    KeyFolder,

    /// <summary>
    /// Lance une trace sur le serveur
    /// </summary>
    Monitor,

    /// <summary>
    /// Abonnement / diffusion : ecran d'accueil
    /// </summary>
    PubSub,

    /// <summary>
    /// Abonnement / diffusion : ecran d'abonnement uniquement
    /// </summary>
    PubSubAbonnement,

    /// <summary>
    /// Liste les serveur suivis par sentinel
    /// </summary>
    SentinelServers,

    /// <summary>
    /// Un serveur Maitre
    /// </summary>
    ServeurSuiviMaster,

    /// <summary>
    /// Un serveur Esclave
    /// </summary>
    ServeurSuiviSlave,
  }
}
