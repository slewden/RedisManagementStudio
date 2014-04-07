using RedisManagementStudio.BLL.Redis;
using RedisManagementStudio.BLL.Redis.Client;
using RedisManagementStudio.BLL.Redis.Keys;
using RedisManagementStudio.BLL.Redis.Sentinel;

namespace RedisManagementStudio.BLL
{
  /// <summary>
  /// une commande de menu
  /// </summary>
  public class CommandMenu
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="CommandMenu" />.
    /// </summary>
    /// <param name="act">L'action associée</param>
    public CommandMenu(CommandMenuAction act)
    {
      this.ActionPrincipale = act;
      this.ConfiguationRubrique = CmdInfoRubrique.AllRubrique;
      this.Client = null;
      this.Key = null;
      this.Serveur = null;
    }

    /// <summary>
    /// L'action principale
    /// </summary>
    public CommandMenuAction ActionPrincipale { get; set; }

    /// <summary>
    /// La rubrique associée
    /// </summary>
    public CmdInfoRubrique ConfiguationRubrique { get; set; }

    /// <summary>
    /// Le client
    /// </summary>
    public RedisClientListTranslator Client { get; set; }

    /// <summary>
    /// La clé ou le dossier de clé
    /// </summary>
    public KeySearchResult Key { get; set; }

    /// <summary>
    /// Le serveur suivi par sentinel
    /// </summary>
    public SentinelServer Serveur { get; set; }

    /// <summary>
    /// Egalité entre 2 command Menu
    /// </summary>
    /// <param name="obj">l'objet à comparer</param>
    /// <returns>TRUE si c'est les même</returns>
    public override bool Equals(object obj)
    {
      CommandMenu cmd = obj as CommandMenu;
      if ((object)cmd == null)
      {
        return false;
      }

      if (this.ActionPrincipale != cmd.ActionPrincipale)
      { // pas les mêmes action ==> pas les mêmes objets !
        return false;
      }

      switch (this.ActionPrincipale)
      { 
        case CommandMenuAction.Configuration:
          return this.ConfiguationRubrique.Equals(cmd.ConfiguationRubrique);
        case CommandMenuAction.ClientDetail:
          return this.Client.Equals(cmd.Client);
        case CommandMenuAction.Key:
        case CommandMenuAction.KeyFolder:
        case CommandMenuAction.None:
          return this.Key.Equals(cmd.Key);
        case CommandMenuAction.ServeurSuiviMaster:
        case CommandMenuAction.ServeurSuiviSlave:
          return this.Serveur.Equals(cmd.Serveur);
      }

      return true;
    }

    /// <summary>
    /// Méthode de hash pour la comparaison dans les listes
    /// </summary>
    /// <returns>le code de hash</returns>
    public override int GetHashCode()
    {
      switch (this.ActionPrincipale)
      {
        case CommandMenuAction.Configuration:
          return this.ActionPrincipale.GetHashCode() + this.ConfiguationRubrique.GetHashCode();
        case CommandMenuAction.ClientDetail:
          return this.ActionPrincipale.GetHashCode() + this.Client.GetHashCode();
        case CommandMenuAction.Key:
        case CommandMenuAction.KeyFolder:
        case CommandMenuAction.None:
          return this.ActionPrincipale.GetHashCode() + this.Key.GetHashCode();
        case CommandMenuAction.ServeurSuiviMaster:
        case CommandMenuAction.ServeurSuiviSlave:
          return this.ActionPrincipale.GetHashCode() + this.Serveur.GetHashCode();
      }

      return this.ActionPrincipale.GetHashCode();
    }
  }
}
