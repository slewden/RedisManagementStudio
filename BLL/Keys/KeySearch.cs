using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using RedisManagementStudio.BLL.Redis;

namespace RedisManagementStudio.BLL.Keys
{
  /// <summary>
  /// Controle de recherche de clés 
  /// </summary>
  public partial class KeySearch : UserControl
  {
    #region Membres privés
    /// <summary>
    /// Nombre de clé dans la DB en dessous duquel on peut lancer une requette "*"
    /// </summary>
    private const long SEUILSANSFILTRE = 2000;

    /// <summary>
    /// Les séparateurs pour le mode ponctuation
    /// </summary>
    private char[] separators = { ':', '.', '!', ',', ';', '/', '|', '\\', '§', '@', ']', ')', '(', '[', '-', '_', '{', '}', '+', '=', '*', '$', '£', '~', '&', '#', '"', '\'', '`', '^', '°', '¨', '¤', '%', '<', '>' };

    /// <summary>
    /// Nombre de clé trouvées (-1 = pas de recherches)
    /// </summary>
    private int nombreCle = -1;

    /// <summary>
    /// Nombre de clés dans la db
    /// </summary>
    private long nombreKeys = -1;

    /// <summary>
    /// Indique que toutes les clés n'ont pas été affichées
    /// </summary>
    private bool tropDeCles = false;

    /// <summary>
    /// Mode d'affichage
    /// </summary>
    private EDisplayMode displayMode = EDisplayMode.IndentPonctuation;

    /// <summary>
    /// La connexion à la db
    /// </summary>
    private RedisConnection cnn;
    #endregion

    /// <summary>
    /// Constructeur par défaut
    /// </summary>
    public KeySearch()
    {
      this.InitializeComponent();

      this.NombreCharCommunMin = 3;
      this.lblCountCle.Text = this.CountCle();
      
    }

    #region Events publics
    /// <summary>
    /// Notifie la fin d'une recherche au parent
    /// </summary>
    public event EventHandler OnSearch;

    /// <summary>
    /// Notifie un changement de sélection au parent
    /// </summary>
    public event EventHandler OnChange;
    #endregion

    /// <summary>
    /// Les différents mode d'affichage des clés
    /// </summary>
    internal enum EDisplayMode
    {
      /// <summary>
      /// pas d'indentation
      /// </summary>
      Flat = 0,

      /// <summary>
      /// Indentation en groupant par chaine identiques
      /// </summary>
      IndentText = 1,

      /// <summary>
      /// Indentation en groupant par blocs de caractèrès séparé par un caractère de ponctuation
      /// </summary>
      IndentPonctuation = 2,

      /// <summary>
      /// Séparation en groupant les bloc de caractère ou des nombres.
      /// </summary>
      IndentNombre = 3,
    }

    #region Properties & public methods
    /// <summary>
    /// Nombre de caractère en commun min pour factoriser (3 par défaut)
    /// </summary>
    [DefaultValue(3)]
    public int NombreCharCommunMin { get; set; }

    /// <summary>
    /// La connexion à la base
    /// </summary>
    public RedisConnection Connection
    {
      get
      {
        return this.cnn;
      }

      set
      {
        this.cnn = value;
        if (this.cnn != null)
        {
          this.nombreKeys = this.cnn.Connector.DbSize();
        }
        else
        {
          this.nombreKeys = -1;
        }

        this.GereBouton();
      }
    }

    /// <summary>
    /// Défini ou renvoie le texte cherché
    /// </summary>
    public string SearchText
    {
      get
      {
        return this.txtSearch.Text;
      }

      set
      {
        this.txtSearch.Text = value;
      }
    }

    /// <summary>
    /// Renvoie l'élément sélectionné
    /// </summary>
    public string SelectedText
    {
      get
      {
        if (this.lstKeys.SelectedNode == null)
        {
          return string.Empty;
        }
        else if (this.lstKeys.SelectedNode.Tag != null)
        { // ce test pour ne pas notifier lorsque l'on clique sur l'item "Warning trop de clés trouvées" qui est le seul a ne pas avoir de tag
          return this.lstKeys.SelectedNode.Text;
        }
        else
        {
          return string.Empty;
        }
      }
    }

    /// <summary>
    /// Renvoie le type sélectionné
    /// </summary>
    public ETypeKey SelectedType
    {
      get
      {
        if (this.lstKeys.SelectedNode == null)
        {
          return ETypeKey.Tnone;
        }
        else if (this.lstKeys.SelectedNode.Tag != null)
        { // ce test pour ne pas notifier lorsque l'on clique sur l'item "Warning trop de clés trouvées" qui est le seul a ne pas avoir de tag
          string t = this.lstKeys.SelectedNode.ImageKey;
          if (t.StartsWith("G"))
          {
            t = t.Substring(1);
          }

          return (ETypeKey)Enum.Parse(typeof(ETypeKey), t);
        }
        else
        {
          return ETypeKey.Tnone;
        }
      }
    }

    /// <summary>
    /// Indique si on a sélectionné un group ou une clé
    /// </summary>
    public bool SelectedIsGroup
    {
      get
      {
        if (this.lstKeys.SelectedNode == null)
        {
          return false;
        }
        else if (this.lstKeys.SelectedNode.Tag != null)
        { // ce test pour ne pas notifier lorsque l'on clique sur l'item "Warning trop de clés trouvées" qui est le seul a ne pas avoir de tag
          string t = this.lstKeys.SelectedNode.ImageKey;
          return t.StartsWith("G");
        }
        else
        {
          return false;
        }
      }
    }

    /// <summary>
    /// Renvoie le node sélectionné (s'il y a !)
    /// ou sélectionne le node similaire à celui fourni
    /// </summary>
    public TreeNode SelectedNode
    {
      get
      {
        if (this.lstKeys.SelectedNode == null)
        {
          return null;
        }
        else if (this.lstKeys.SelectedNode.Tag != null)
        { // ce test pour ne pas notifier lorsque l'on clique sur l'item "Warning trop de clés trouvées" qui est le seul a ne pas avoir de tag
          return this.lstKeys.SelectedNode;
        }
        else
        {
          return null;
        }
      }

      set
      {
        if (this.lstKeys.SelectedNode != null)
        {
          this.Selectionne(this.lstKeys.SelectedNode.Nodes, value);
        }
        else
        {
          this.Selectionne(this.lstKeys.Nodes, value);
        }
      }
    }

    /// <summary>
    /// Sauvegarde les propriétés du composant
    /// </summary>
    public void SaveProperties()
    {
      Properties.Settings.Default.KeySearchDisplayMode = Convert.ToInt32(this.displayMode);
    }

    /// <summary>
    /// Charge les propriétes du composant
    /// </summary>
    public void LoadProperties()
    {
      this.displayMode = (EDisplayMode)Properties.Settings.Default.KeySearchDisplayMode;
      this.GereBouton();
    }
    #endregion

    #region Internals Events
    /// <summary>
    /// Changement de sélection (on notifie la parent)
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">param inutile</param>
    private void LstKeysAfterSelect(object sender, TreeViewEventArgs e)
    {
      if (this.OnChange != null)
      {
        this.OnChange(this, new EventArgs());
      }
    }

    /// <summary>
    /// Le filtre de recherche change
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">param inutile</param>
    private void TxtSearchTextChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }

    /// <summary>
    /// Recherche de clé
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">param inutile</param>
    private void BtSearchClick(object sender, EventArgs e)
    {
      this.lstKeys.Nodes.Clear();
      this.tropDeCles = false;
      Cursor oldCursor = this.Cursor;
      this.Cursor = Cursors.WaitCursor;
      Application.DoEvents();
      try
      {

        int nb = 0;
        if (this.Connection != null)
        {
          ETypeKey typeFiltre = this.GetSelectedTypeFiltre();

          // recherche en DB
          List<string> lst = this.Connection.Connector.Keys(this.GetPattern());
          if (lst != null)
          { // y a des données
            lst.Sort();
            TreeNode node;
            TreeNode old = null;
            ETypeKey tk;
            string common;
            foreach (string key in lst)
            {
              tk = this.Connection.Type(key);
              if (tk.IsSame(typeFiltre))
              { // la clé doit être affichée : elle fait partie du filtre de type
                nb++;
                node = this.CreateNode(tk, key);
                if (old != null)
                { // on a une node avant
                  common = this.Compare(old, node);
                  if (string.IsNullOrWhiteSpace(common))
                  { // pas de point commun
                    this.lstKeys.Nodes.Add(node);
                  }
                  else
                  { // y a un point commun
                    this.AccrocheCommun(tk, node, old, common);
                  }
                }
                else
                { // première node ou flat style
                  this.lstKeys.Nodes.Add(node);
                }

                if (this.displayMode != EDisplayMode.Flat)
                { // ne sert que pour les affichages indenté
                  old = node;
                }

                if (nb > SEUILSANSFILTRE)
                { // Trops de clés dans le résultat
                  this.lstKeys.Nodes.Add(this.GetMoreKeys());
                  this.tropDeCles = true;
                  break;
                }
              }
            }
          }

          if (this.lstKeys.Nodes.Count > 0)
          {
            this.lstKeys.SelectedNode = this.lstKeys.Nodes[0];
          }
        }

        this.nombreCle = nb;
        this.lblCountCle.Text = this.CountCle();
      }
      finally
      {
        this.Cursor = oldCursor;
      }

      this.NotifySearch();
    }

    /// <summary>
    /// Changement du format d'affichage
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">param inutile</param>
    private void BtDisplayModeClick(object sender, EventArgs e)
    {
      if (this.displayMode == EDisplayMode.IndentNombre)
      {
        this.displayMode = EDisplayMode.Flat;
      }
      else
      {
        this.displayMode = (EDisplayMode)(Convert.ToInt32(this.displayMode) + 1);
      }

      this.GereBouton();
    }

    #endregion

    #region Private Methods
    /// <summary>
    /// Gère l'activation des boutons
    /// </summary>
    private void GereBouton()
    {
      if (this.nombreKeys == -1)
      {
        this.btSearch.Enabled = false;
        this.toolTip1.SetToolTip(this.panel1, "Pas de connection, pas de recherche");
      }
      else if (this.nombreKeys > SEUILSANSFILTRE)
      {
        this.btSearch.Enabled = !string.IsNullOrEmpty(this.txtSearch.Text) && this.txtSearch.Text != "*";
        this.toolTip1.SetToolTip(this.panel1, this.btSearch.Enabled ? string.Empty : string.Format("Le filtre positionné est trop faible par rapport aux {0} clés dans la base", this.nombreKeys));
      }
      else
      {
        this.btSearch.Enabled = true;
        this.toolTip1.SetToolTip(this.panel1, string.Empty);
      }

      this.btDisplayMode.Text = this.GetDisplayText();
      this.toolTip1.SetToolTip(this.btDisplayMode, string.Format("Type d'indentation du résultat : {0}", this.GetDisplayModeTips()));
    }

    /// <summary>
    /// Déplace old et le place avec node dans un nouveau folder de type tk et dont le nom est common 
    /// </summary>
    /// <param name="tk">Type de noueds à déplacer</param>
    /// <param name="node">Noeud N°2 à ajouter</param>
    /// <param name="old">Noeud à déplacer</param>
    /// <param name="common">Nom du grouppement</param>
    private void AccrocheCommun(ETypeKey tk, TreeNode node, TreeNode old, string common)
    {
      TreeNode folder;
      if (old.Parent != null)
      { // old n'est pas à la racine 
        if (old.Parent.Tag.ToString() == common)
        { // la partie commune est la même
          old.Parent.Nodes.Add(node);
        }
        else if (common.Length > old.Parent.Tag.ToString().Length)
        { // le père de old est moins complet : on s'accroche dessus
          folder = this.GetFolder(tk, common);
          old.Parent.Nodes.Add(folder);
          int index = old.Parent.Nodes.IndexOf(old);
          old.Parent.Nodes.RemoveAt(index);
          folder.Nodes.Add(old);
          folder.Nodes.Add(node);
        }
        else
        { // le père est plus complet on cherche plus haut récursivement
          this.AccrocheCommun(tk, node, old.Parent, common);
        }
      }
      else
      { // old est à la racine : on cree un dossier on met les 2 dedans
        folder = this.GetFolder(tk, common);
        this.lstKeys.Nodes.Add(folder);
        int index = this.lstKeys.Nodes.IndexOf(old);
        this.lstKeys.Nodes.RemoveAt(index);
        folder.Nodes.Add(old);
        folder.Nodes.Add(node);
      }
    }

    /// <summary>
    /// Compare 2 nodes pour voir s'il peuvent être regroupés sous un même parent
    /// </summary>
    /// <param name="old">Ancien noeud</param>
    /// <param name="node">Nouveau noeud</param>
    /// <param name="displayMode">mode d'affichage choisit</param>
    /// <returns>Le texte qu'ils ont en commun</returns>
    private string Compare(TreeNode old, TreeNode node)
    {
      if (old.ImageKey == node.ImageKey)
      { // Même type ils sont compatible à la comparaison
        int n = 0;
        string t1 = old.Tag.ToString();
        string t2 = node.Tag.ToString();
        int lenMin;
        bool isSame;
        StringBuilder common = new StringBuilder();
        if (this.displayMode == EDisplayMode.IndentPonctuation)
        { // Méthode de comparaison par bloc de caractères séparés par une ponctuation
          string[] nfo1 = t1.Split(this.separators);
          string[] nfo2 = t2.Split(this.separators);
          lenMin = Math.Min(nfo1.Length, nfo2.Length);
          int index = 0;
          do
          {
            isSame = nfo1[n] == nfo2[n];
            if (isSame)
            {
              index += nfo1[n].Length + 1;
              common.Append(nfo1[n]);
              if (index < t1.Length)
              {
                common.Append(t1[index - 1]);
              }
            }

            n++;
          }
          while (n < lenMin && isSame);
        }
        else if (this.displayMode== EDisplayMode.IndentText)
        { // Méthode de comparaison caractères par caractère
          lenMin = Math.Min(t1.Length, t2.Length);
          do
          {
            isSame = t1[n] == t2[n];
            if (isSame)
            {
              common.Append(t1[n]);
            }

            n++;
          }
          while (n < lenMin && isSame);
        }
        else
        { // if (this.displayMode == EDisplayMode.IndentNombre)
          // Méthode de comparaison caractères par caractère + si changement de caractère à nombre ou nombre ver car
          bool oldC = char.IsDigit(t1[0]);
          bool currentC;
          lenMin = Math.Min(t1.Length, t2.Length);
          do
          {
            currentC = char.IsDigit(t1[n]);
            isSame = t1[n] == t2[n] && oldC == currentC;
            if (isSame)
            {
              common.Append(t1[n]);
            }

            oldC = currentC;
            n++;
          }
          while (n < lenMin && isSame);
         
        }

        string res = common.ToString();
        if (res.Length > this.NombreCharCommunMin)
        { // On a de quoi répondre
          return res;
        }
        else
        {
          return string.Empty;
        }
      }
      else
      {
        return string.Empty;
      }
    }

    /// <summary>
    /// Crée une node
    /// </summary>
    /// <param name="tk">Le type</param>
    /// <param name="key">Le nom</param>
    /// <returns>Le node</returns>
    private TreeNode CreateNode(ETypeKey tk, string key)
    {
      TreeNode node;
      node = new TreeNode(key);
      node.ImageKey = tk.ToString();
      node.SelectedImageKey = tk.ToString();
      node.Tag = key;
      return node;
    }

    /// <summary>
    /// Crée un Node de type Groupe
    /// </summary>
    /// <param name="tk">Le type des noeuds qui sont dedans</param>
    /// <param name="common">le texte</param>
    /// <returns>Le node</returns>
    private TreeNode GetFolder(ETypeKey tk, string common)
    {
      TreeNode node;
      node = new TreeNode(common);
      node.ImageKey = "G" + tk.ToString();
      node.SelectedImageKey = "G" + tk.ToString();
      node.Tag = common;
      return node;
    }

    /// <summary>
    /// renvoie un noeud qui notifie le remplissage partiel de la liste de résultat
    /// </summary>
    /// <returns>Le noeud</returns>
    private TreeNode GetMoreKeys()
    {
      TreeNode node;
      node = new TreeNode("Trop de clés trouvées : affichage interrompu");
      node.ImageKey = "warning";
      node.SelectedImageKey = "warning";
      node.Tag = null;
      return node;
    }

    /// <summary>
    /// Renvoie le type de donnée à filtrer
    /// </summary>
    /// <returns>Le type à filtre tous les type ssi UnKnow</returns>
    private ETypeKey GetSelectedTypeFiltre()
    {
      ETypeKey res = ETypeKey.UnKnow;
      switch (this.cbFiltreType.SelectedIndex)
      {
        case 1: return ETypeKey.Tstring;
        case 2: return ETypeKey.Tlist;
        case 3: return ETypeKey.Tset;
        case 4: return ETypeKey.Tzset;
        case 5: return ETypeKey.Thash;
      }

      return res;
    }

    /// <summary>
    /// Renvoie le pattern de recherche
    /// </summary>
    /// <returns>Le pattern appliqué</returns>
    private string GetPattern()
    {
      if (string.IsNullOrWhiteSpace(this.txtSearch.Text))
      {
        return "*";
      }
      else
      {
        return this.txtSearch.Text;
      }
    }

    /// <summary>
    /// Renvoie le mode d'affichage du résultat
    /// </summary>
    /// <returns>le mode</returns>
    private string GetDisplayText()
    {
      switch (this.displayMode)
      {
        case EDisplayMode.IndentText:
          return "T";
        case EDisplayMode.IndentPonctuation:
          return "P";
        case EDisplayMode.IndentNombre:
          return "N";
      }

      return "X";
    }

    /// <summary>
    /// Renvoie une pharese qui décrit le mode d'indentation
    /// </summary>
    /// <returns>la phrase</returns>
    private string GetDisplayModeTips()
    {
      switch (this.displayMode)
      {
        case EDisplayMode.IndentNombre:
          return "Nombre : Les clés sont regrouppées par groupe de lettres ou nombre identiques";
        case EDisplayMode.IndentPonctuation:
          StringBuilder res = new StringBuilder();
          res.Append("Ponctuation : Les clés sont regroupées par groupe de lettres séparé par un caractère de ponctuation qui peut être ");
          foreach (char c in this.separators)
          {
            res.Append(c);
          }

          return res.ToString();
        case EDisplayMode.IndentText:
          return "Caractère : Les clés sont regroupées lorsqu'elles ont la même séquence de caractères quels qu'ils soient";
      }

      return "Aucun regrouppement";
    }

    /// <summary>
    /// Renvoie le nombre de clé trouvées
    /// </summary>
    /// <returns>La phrase pour le nombre de clés</returns>
    private string CountCle()
    {
      if (this.nombreCle < 0)
      { // pas de recherche
        return string.Empty;
      }
      else if (this.nombreCle == 0)
      {
        return "Aucune clé trouvée";
      }
      else if (this.nombreCle == 1)
      {
        ETypeKey tk = this.GetSelectedTypeFiltre();
        string typeFilte = tk.GetFiltreLibelle();
        return string.Format("Une seule clé {0}pour le texte : {1}", typeFilte, this.GetPattern());
      }
      else if (this.tropDeCles)
      { // affichage partiel car trop de clés trouvées
        return string.Format("Affichage partiel du résultat car plus de {0} clés trouvées", SEUILSANSFILTRE);
      }
      else
      {
        ETypeKey tk = this.GetSelectedTypeFiltre();
        string typeFilte = tk.GetFiltreLibelle();
        return string.Format("{0} clés {1}trouvées pour le texte : {2}", this.nombreCle, typeFilte, this.GetPattern());
      }
    }

    /// <summary>
    /// Sélectionne le node dans la collection
    /// </summary>
    /// <param name="nodes">La collection à parcourir</param>
    /// <param name="value">la valeur à sélectionner</param>
    private void Selectionne(TreeNodeCollection nodes, TreeNode value)
    {
      foreach (TreeNode nod in nodes)
      {
        if (nod.Text == value.Text && nod.ImageKey == value.ImageKey)
        {
          this.lstKeys.SelectedNode = nod;
          this.LstKeysAfterSelect(null, null);
          return;
        }
      }
    }

    /// <summary>
    /// Notifie les parent d'une fin de recherche
    /// </summary>
    private void NotifySearch()
    {
      if (this.OnSearch != null)
      {
        this.OnSearch(this, new EventArgs());
      }
    }
    #endregion
  }
}
