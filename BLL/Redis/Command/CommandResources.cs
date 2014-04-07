namespace RedisManagementStudio.BLL.Redis.Command
{
  /// <summary>
  /// Ressource pour les commandes
  /// </summary>
  internal partial class RedisCommand
  {
    /// <summary>
    /// Renvoie le titre d'une propriété
    /// </summary>
    /// <param name="key">La clé</param>
    /// <returns>L'info formattée</returns>
    public static string GetTips(string key)
    {
      return ResourceManager.GetString(key.ToLower().Replace("-", "_") + "Tips", resourceCulture);
    }
  }
}
