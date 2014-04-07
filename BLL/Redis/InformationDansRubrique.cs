using System;
using System.Xml.Linq;
using RedisManagementStudio.BLL.Alarm;

namespace RedisManagementStudio.BLL.Redis
{
  /// <summary>
  /// Une rubrique d'information
  /// </summary>
  public class InformationDansRubrique : IComparable
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="InformationDansRubrique" />.
    /// /// </summary>
    public InformationDansRubrique()
    {
      this.InternalTitre = string.Empty;
      this.InternalDescription = string.Empty;
      this.InternalCode = string.Empty;
      this.InternalCommand = string.Empty;
      this.InternalRubriqueCode = string.Empty;
      this.RefreshConfig();
    }

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="InformationDansRubrique" />.
    /// </summary>
    /// <param name="cmd">la commande</param>
    /// <param name="code">le code rubrique</param>
    /// <param name="rub">la rubrique de regroupement à associer</param>
    /// <param name="pos">la position dans la rubrique de regroupement</param>
    /// <param name="alr">le type d'alarme possible</param>
    public InformationDansRubrique(string cmd, string code, CmdInfoRubrique rub, int pos, AlarmType alr)
    {
      // on passe par les propriétés interne volontairement ici pour 
      // ne pas modifier la rubrique, la position et l'alarme
      this.InternalCommand = cmd;
      this.InternalCode = code;
      this.InternalRubriqueCode = code;
      this.Rubrique = rub;
      this.Position = pos;
      this.AlarmeType = alr;
    }

    #region Propriétés publiques
    /// <summary>
    /// La commande
    /// </summary>
    public string Command
    {
      get
      {
        return this.InternalCommand;
      }

      set
      {
        this.InternalCommand = value;
        this.RefreshConfig();
      }
    }

    /// <summary>
    /// Le code rubrique
    /// </summary>
    public string Code
    {
      get
      {
        return this.InternalCode;
      }

      set
      {
        this.InternalCode = value;
        this.ComputeInternalCodeRubrique();
        this.RefreshConfig();
      }
    }

    /// <summary>
    /// la rubrique de regroupement
    /// </summary>
    public CmdInfoRubrique Rubrique { get; set; }

    /// <summary>
    /// la position dans la rubrique de regroupement
    /// </summary>
    public int Position { get; set; }

    /// <summary>
    /// Le type d'alarme possible
    /// </summary>
    public AlarmType AlarmeType { get; set; }

    /// <summary>
    /// Le titre associé à la clé (issu d'un fichier de ressources)
    /// </summary>
    public string Titre
    {
      get
      {
        if (string.IsNullOrWhiteSpace(this.InternalTitre))
        {
          this.LoadTitre();
        }

        return this.InternalTitre;
      }
    }

    /// <summary>
    /// La description détaillée de l'info (issu d'un fichier de ressources)
    /// </summary>
    public string Description
    {
      get
      {
        if (string.IsNullOrWhiteSpace(this.InternalDescription))
        {
          this.LoadDescription(); 
        }

        return this.InternalDescription;
      }
    }
    #endregion
    
    #region Propriétés protected
    /// <summary>
    /// La commande
    /// </summary>
    protected string InternalCommand { get; set; }

    /// <summary>
    /// La code 
    /// </summary>
    protected string InternalCode { get; set; }

    /// <summary>
    /// Le titre
    /// </summary>
    protected string InternalTitre { get; set; }

    /// <summary>
    /// La description
    /// </summary>
    protected string InternalDescription { get; set; }

    /// <summary>
    /// Code à utiliser pour calculer la rubrique (=INTERNALCODE sauf pour les codes indexé comme DB0, DB1, ... ==> DBXXX)
    /// </summary>
    protected string InternalRubriqueCode { get; set; }
    #endregion

    #region Interface publique
    /// <summary>
    /// Sauvegarde l'objet dans un noeud XML
    /// </summary>
    /// <returns>Le noeud XML</returns>
    public XElement Save()
    {
      XElement nod = new XElement("rub");
      nod.Add(new XAttribute("cmd", this.Command));
      nod.Add(new XAttribute("pos", this.Position));
      nod.Add(new XAttribute("cod", this.Code));
      nod.Add(new XAttribute("rub", this.Rubrique.ToString()));
      nod.Add(new XAttribute("alr", this.AlarmeType.ToString()));
      return nod;
    }

    /// <summary>
    /// Charge l'objet depuis un noeud XML
    /// </summary>
    /// <param name="nod">Le noeud XML</param>
    public void Load(XElement nod)
    {
      // on passe par les propriétés interne volontairement ici pour 
      // ne pas modifier la rubrique, la position et l'alarme
      this.InternalCommand = nod.Attribute("cmd").Value;
      this.InternalCode = nod.Attribute("cod").Value;
      this.Rubrique = (CmdInfoRubrique)Enum.Parse(typeof(CmdInfoRubrique), nod.Attribute("rub").Value);
      this.Position = Convert.ToInt32(nod.Attribute("pos").Value);
      this.AlarmeType = (AlarmType)Enum.Parse(typeof(AlarmType), nod.Attribute("alr").Value);
    }

    /// <summary>
    /// Pour affichage
    /// </summary>
    /// <returns>un texte représentatif</returns>
    public override string ToString()
    {
      return string.Format("{0} - {1}", this.Command, this.Code);
    }

    /// <summary>
    /// Pour les comparaisons
    /// </summary>
    /// <param name="obj">autre RUBINFO</param>
    /// <returns>TRUE si c'est la même commande, même rubrique</returns>
    public override bool Equals(object obj)
    {
      InformationDansRubrique nfo = obj as InformationDansRubrique;
      if ((object)nfo == null)
      {
        return false;
      }
      else
      {
        return this.Command == nfo.Command && this.Code == nfo.Code;
      }
    }

    /// <summary>
    /// Retourne le code de HASHAGE
    /// </summary>
    /// <returns>Le code de HASH</returns>
    public override int GetHashCode()
    {
      return (this.Command + this.Code).GetHashCode();
    }

    /// <summary>
    /// Comparaison pour la gestion dans les listes
    /// </summary>
    /// <param name="obj">Objet à comparer</param>
    /// <returns>Ce qu'il faut pour classer</returns>
    public int CompareTo(object obj)
    {
      InformationDansRubrique nfo = obj as InformationDansRubrique;
      if ((object)nfo == null)
      {
        return 1;
      }
      else
      {
        if (this.Command == nfo.Command)
        {
          if (this.Code == nfo.Code)
          {
            return 0;
          }
          else
          {
            return this.Code.CompareTo(nfo.Code);
          }
        }
        else
        {
          return this.Command.CompareTo(nfo.Command);
        }
      }
    }
    #endregion

    /// <summary>
    /// Calcule le code pour trouver la rubrique dans RubriqueManager
    /// </summary>
    protected virtual void ComputeInternalCodeRubrique()
    {
      this.InternalRubriqueCode = this.InternalCode;
    }

    /// <summary>
    /// Chargement du titre par défaut
    /// </summary>
    protected virtual void LoadTitre()
    {
      this.InternalTitre = LoadAResource("T", this.Command, this.Code);
    }

    /// <summary>
    /// Chargement de la description par défaut
    /// </summary>
    protected virtual void LoadDescription()
    {
      this.InternalDescription = LoadAResource("D", this.Command, this.Code);
    }

    /// <summary>
    /// Renvoie un nom depuis le fichier de ressource
    /// </summary>
    /// <param name="typeName">Type de demande (T pour titre ou D our description)</param>
    /// <param name="command">Commande a documenter</param>
    /// <param name="code">Code rubrique</param>
    /// <returns>Le texte à chercher</returns>
    private static string LoadAResource(string typeName, string command, string code)
    {
      typeName = typeName.ToUpper();
      command = command.ToUpper();
      code = code.ToLower();
      string key;

      if (command == "INFO")
      {
        if (code.StartsWith("slave") && code.Length == 8)
        { // Clés de la forme slaveXXX
          key = typeName == "T" ? InformationDansRubriqueRessources.INFOTslavexxx : InformationDansRubriqueRessources.INFODslavexxx;
          return string.Format(key, code.Replace("slave", string.Empty));
        }
        else if (code.StartsWith("cmdstat_"))
        { // compteurs de commandes
          key = typeName == "T" ? InformationDansRubriqueRessources.INFOTcmdstat_xxx : InformationDansRubriqueRessources.INFODcmdstat_xxx;
          return string.Format(key, code.Replace("cmdstat_", string.Empty));
        }
        else if (code.StartsWith("db") && (code.Length == 3 || code.Length == 4))
        {
          key = typeName == "T" ? InformationDansRubriqueRessources.INFOTdbxxx : InformationDansRubriqueRessources.INFODdbxxx;
          return string.Format(key, code.Replace("db", string.Empty));
        }
      }

      // cas par défaut
      key = string.Concat(command, typeName, code);
      string res = InformationDansRubriqueRessources.GetRessource(key);
      if (!string.IsNullOrWhiteSpace(res))
      {
        return res;
      }
      else
      { // pour les nouvelles commandes
        return key;
      }
    }

    /// <summary>
    /// Remplit de nouveau les propriétés de l'objet
    /// </summary>
    private void RefreshConfig()
    {
      if (!string.IsNullOrWhiteSpace(this.InternalCommand) && !string.IsNullOrWhiteSpace(this.InternalCode))
      {
        InformationDansRubrique rub = RubriqueManager.Get(this.Command, this.InternalRubriqueCode);
        if (rub != null)
        {
          this.Rubrique = rub.Rubrique;
          this.Position = rub.Position;
          this.AlarmeType = rub.AlarmeType;
          return;
        }
      }

      // Valeurs par défaut
      this.Rubrique = CmdInfoRubrique.UnKnow;
      this.Position = 0;
      this.AlarmeType = AlarmType.None;
    }
  }
}
