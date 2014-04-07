using System.Drawing;

namespace RedisManagementStudio.BLL.Redis
{
  /// <summary>
  /// Rubrique ressources
  /// </summary>
  internal partial class Rubrique
  {
    /// <summary>
    /// Renvoie le libellé de la rubrique
    /// </summary>
    /// <param name="rub">la rubrique à détailler</param>
    /// <returns>le titre de la rubrique</returns>
    public static string GetLibelle(CmdInfoRubrique rub)
    {
      return ResourceManager.GetString("CmdInfoRubrique" + rub.ToString(), resourceCulture);
    }

    /// <summary>
    /// Renvoie le libellé du type de données
    /// </summary>
    /// <param name="tk">le type de données à détailler</param>
    /// <param name="postFix">le type de texte voulue T pour titre D pour description, F pour les phrases de filtre</param>
    /// <returns>le texte cherché</returns>
    public static string GetLibelle(ETypeKey tk, string postFix)
    {
      string key = string.Format("ETypeKey{0}{1}", tk, postFix);
      return ResourceManager.GetString(key, resourceCulture);
    }

    /// <summary>
    /// renvoie l'image associée à une rubrique
    /// </summary>
    /// <param name="rub">la rubrique</param>
    /// <returns>l'image associée</returns>
    public static Image GetImage(CmdInfoRubrique rub)
    {
      switch (rub)
      { 
        case CmdInfoRubrique.Server:
          return Properties.Resources.ServerLight;
        case CmdInfoRubrique.Client:
          return Properties.Resources.ClientLight;
        case CmdInfoRubrique.MemoryCPU:
          return Properties.Resources.MemoryCPULight;
        case CmdInfoRubrique.Persistance:
          return Properties.Resources.PersistanceLight;
        case CmdInfoRubrique.Replication:
          return Properties.Resources.ReplicationLight;
        case CmdInfoRubrique.Statistics:
          return Properties.Resources.StatisticsLight;
        case CmdInfoRubrique.Command:
          return Properties.Resources.CommandLight;
        case CmdInfoRubrique.Configuration:
          return Properties.Resources.Configuration;
        case CmdInfoRubrique.Sentinel:
          // TODO : pas d'image pour l'instant 
          break;
        case CmdInfoRubrique.None:
          // pas d'image dans ce cas
          break;
      }

      return null;
    }
  }
}
