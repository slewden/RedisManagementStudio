using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedisManagementStudio.BLL.Redis.Keys
{
  /// <summary>
  /// Classe pour stocker le résultat d'une recherche
  /// </summary>
  public class KeySearchResult
  {
    /// <summary>
    /// La liste des clé résultats fils
    /// </summary>
    private List<KeySearchResult> myChildrens;

    /// <summary>
    /// Le type de clé
    /// </summary>
    private ETypeKey myType;

    /// <summary>
    /// La taille totale
    /// </summary>
    private long mySize;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="KeySearchResult" />.
    /// </summary>
    /// <param name="key">Le nom de la clé ou du regroupement de clé</param>
    /// <param name="type">Le type de clé</param>
    public KeySearchResult(string key, ETypeKey type)
    {
      this.Key = key;
      this.myType = type;
      this.myChildrens = new List<KeySearchResult>();
      this.mySize = -1;
    }

    /// <summary>
    /// La clé ou début de texte de la clé
    /// </summary>
    public string Key { get; private set; }

    /// <summary>
    /// le type de la clé
    /// </summary>
    public ETypeKey Type
    {
      get
      {
        if (this.myChildrens.Count == 0)
        {
          return this.myType;
        }
        else
        {
          ETypeKey tk = this.myType;
          foreach (KeySearchResult fils in this.myChildrens)
          {
            if (tk != fils.Type)
            { // différence = groupe multi nature
              return ETypeKey.UnKnow;
            }
          }

          return tk;
        }
      }
    }

    /// <summary>
    /// La liste des clés fils
    /// </summary>
    public IEnumerable<KeySearchResult> Childrens 
    { 
      get 
      { 
        return this.myChildrens; 
      } 
    }

    /// <summary>
    /// Le KEYSEARCHRESULT Parent
    /// </summary>
    public KeySearchResult Parent { get; set; }

    /// <summary>
    /// On ne compte que les Clé (donc les feuilles pas les intermédiaires)
    /// </summary>
    public int Nombre
    {
      get
      {
        if (this.myChildrens.Count == 0)
        { // on compte les feuilles
          return 1;
        }
        else
        { // on additionne les arbres
          return (from k in this.Childrens
                  select k.Nombre).Sum();
        }
      }
    }

    /// <summary>
    /// Nombre de fils (Quel qu'ils soient)
    /// </summary>
    public int ChildrensCount
    {
      get
      {
        return this.myChildrens.Count;
      }
    }

    /// <summary>
    /// Ajoute un fils
    /// </summary>
    /// <param name="fils">le fils à ajouter</param>
    public void ChildrensAdd(KeySearchResult fils)
    {
      fils.Parent = this;
      this.myChildrens.Add(fils);
      this.mySize = -1;
    }

    /// <summary>
    /// Retire un fils
    /// </summary>
    /// <param name="fils">le fils à retirer</param>
    public void ChildrensRemove(KeySearchResult fils)
    {
      this.myChildrens.Remove(fils);
      fils.Parent = null;
      this.mySize = -1;
    }

    /// <summary>
    /// renvoie La Taille de la clé (et des fils de type clé redis)
    /// </summary>
    /// <param name="connection">La connexion pour demander l'info</param>
    /// <returns>Le nombre total d'octets</returns>
    public long Size(RedisConnection connection)
    {
      if (this.mySize == -1)
      { // reclacule la taille
        if (this.myChildrens.Count == 0)
        { // Clé simple
          this.mySize = connection.GetSizeOfAKey(this.Key);
        }
        else
        { // regrouppement
          this.mySize = 0;
          foreach (KeySearchResult fils in this.Childrens)
          {
            this.mySize += fils.Size(connection);
          }
        }
      }

      return this.mySize;
    }

    /// <summary>
    /// Supprime la clé et ses fils
    /// </summary>
    /// <param name="connection">La connexion pour passer les commandes</param>
    /// <returns>Le nombre de clé supprimées</returns>
    public int Del(RedisConnection connection)
    {
      if (this.myChildrens.Count == 0)
      { // Clé simple
        return connection.Connector.Del(this.Key);
      }
      else
      { // regrouppement
        int nombre = 0;
        foreach (KeySearchResult fils in this.Childrens)
        {
          nombre += fils.Del(connection);
        }

        return nombre;
      }
    }

    /// <summary>
    /// Renomme une cl en DB
    /// </summary>
    /// <param name="connection">la connexion</param>
    /// <param name="newName">Le nouveau nom</param>
    /// <returns>TRUE si ok</returns>
    public bool Rename(RedisConnection connection, string newName)
    {
      bool ok = connection.Connector.Rename(this.Key, newName);
      if (ok)
      {
        this.Key = newName;
      }

      return ok;
    }

    /// <summary>
    /// actualise le type en demandant à redis le type de la clé
    /// </summary>
    /// <param name="connection">La connexion à utiliser</param>
    public void RefreshType(RedisConnection connection)
    {
      if (this.myChildrens.Count == 0)
      {
        this.myType = connection.Type(this.Key);
      }
    }
  }
}
