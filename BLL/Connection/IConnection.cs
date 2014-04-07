using System.Xml.Linq;

namespace RedisManagementStudio.BLL.Connection
{
  /// <summary>
  /// Gère les éléments de connexion
  /// </summary>
  public interface IConnection
  {
    /// <summary>
    /// Le nom
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Méthode de chargement depuis un noeud XML
    /// </summary>
    /// <param name="r">le noeud XML</param>
    void Load(XElement r);

    /// <summary>
    /// Méthodes de sauvegarde
    /// </summary>
    /// <returns>Le Noeud XML de l'objet</returns>
    XElement Save();
  }
}
