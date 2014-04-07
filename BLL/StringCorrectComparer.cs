using System;
using System.Collections.Generic;

namespace RedisManagementStudio.BLL
{
  /// <summary>
  /// Classe pour le trie correct des clés lors de la recherche
  /// </summary>
  public class StringCorrectComparer : IComparer<string>
  {
    /// <summary>
    /// Méthode de comparaison qui déchire sa race
    /// </summary>
    /// <param name="x">première chaine</param>
    /// <param name="y">Seconde chaine</param>
    /// <returns>La valeur de la comparaison</returns>
    public int Compare(string x, string y)
    {
      if (string.IsNullOrWhiteSpace(x))
      {
        return 1;
      }
      else if (string.IsNullOrWhiteSpace(y))
      {
        return -1;
      }
      else if (x.Equals(y))
      {
        return 0;
      }
      else
      {
        int i = 0;
        char a, b;
        while (i < Math.Min(x.Length, y.Length))
        {
          a = x[i].ToString().ToUpper()[0];
          b = y[i].ToString().ToUpper()[0];
          if (a != b)
          {
            return a.CompareTo(b);
          }

          i++;
        }

        return (x.Length > y.Length) ? 1 : -1;
      }
    }
  }
}
