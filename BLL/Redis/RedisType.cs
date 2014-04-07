using System;

namespace RedisManagementStudio.BLL.Redis
{
  /// <summary>
  /// Type de données manipulée par REDIS
  /// </summary>
  public enum ETypeKey
  {
    /// <summary>
    /// string = texte
    /// </summary>
    Tstring,

    /// <summary>
    /// List = liste ordonnées d'info
    /// </summary>
    Tlist,

    /// <summary>
    /// SEt = Liste de valeur distinctes
    /// </summary>
    Tset,

    /// <summary>
    /// ZSet = liste de valeur avec pondérateur
    /// </summary>
    Tzset,

    /// <summary>
    /// Hash = Table clé valeur
    /// </summary>
    Thash,

    /// <summary>
    /// None = Clé expirée
    /// </summary>
    Tnone,

    /// <summary>
    /// Inconnu = valeur d'erreur
    /// </summary>
    UnKnow,

    /// <summary>
    /// Pour les dossiers
    /// </summary>
    Folder
  }

  /// <summary>
  /// Classe d'aide pour l'ENUM ETypeKey
  /// </summary>
  public static class TypeKeyHelper
  {
    /// <summary>
    /// Convertie un type redis (renvoyé par la commande TYPE) en ETypeKey
    /// </summary>
    /// <param name="txt">Type renvoyé par la commande TYPE</param>
    /// <returns>L'ETypeKey retrouvé</returns>
    public static ETypeKey ToTypeKey(this string txt)
    {
      if (!string.IsNullOrWhiteSpace(txt))
      {
        ETypeKey t;
        if (Enum.TryParse("T" + txt.ToLower(), out t))
        {
          return t;
        }
        else
        {
          throw new NotImplementedException(string.Format(Properties.Resources.RedisTypeUnknowError, txt));
        }
      }

      return ETypeKey.UnKnow;
    }

    /// <summary>
    /// Renvoie le libellé du type redis (renvoyé par la commande TYPE)
    /// </summary>
    /// <param name="t">Le Type</param>
    /// <returns>Le texte</returns>
    public static string GetLibelle(this ETypeKey t)
    {
      return Rubrique.GetLibelle(t, "T");
    }

    /// <summary>
    /// Renvoie la description détaillée
    /// </summary>
    /// <param name="t">Renvoie le type de clé</param>
    /// <returns>Renvoie le libellé pour le type</returns>
    public static string GetLongLibelle(this ETypeKey t)
    {
      return Rubrique.GetLibelle(t, "D");
    }

    /// <summary>
    /// Renvoie le libellé pour les filtre du type redis (renvoyé par la commande TYPE)
    /// </summary>
    /// <param name="t">Le Type</param>
    /// <returns>Le texte</returns>
    public static string GetFiltreLibelle(this ETypeKey t)
    {
      return Rubrique.GetLibelle(t, "F").Trim() + " "; 
    }

    /// <summary>
    /// Indique si les type sont les mêmes (pour les recherche)
    /// Dans ce cas UnKnow correspond à toutes les valeurs
    /// </summary>
    /// <param name="key">Clé N°1</param>
    /// <param name="key2">Clé N°2</param>
    /// <returns>Indique si c'est les mêmes</returns>
    public static bool IsSame(this ETypeKey key, ETypeKey key2)
    {
      return key2 == ETypeKey.UnKnow || key == key2;
    }
  }
}