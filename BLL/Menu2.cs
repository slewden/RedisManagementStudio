using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedisManagementStudio.BLL
{
  /// <summary>
  /// Gestion des ressource pour les menus
  /// </summary>
  internal partial class Menu
  {
    /// <summary>
    /// Renvoie le libellé de la commande
    /// </summary>
    /// <param name="rub">la commande à détailler</param>
    /// <param name="postFix">le type de libellé (T pour titre)</param>
    /// <returns>le texte associé</returns>
    public static string GetLibelle(CommandMenuAction rub, string postFix)
    {
      return ResourceManager.GetString("CommandMenuAction" + rub.ToString() + postFix, resourceCulture);
    }
  }
}
