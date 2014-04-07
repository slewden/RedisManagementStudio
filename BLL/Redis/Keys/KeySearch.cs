using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RedisManagementStudio.BLL.Redis;

namespace RedisManagementStudio.BLL.Redis.Keys
{
  /// <summary>
  /// Contrôle de recherche de clés 
  /// </summary>
  public partial class KeySearch : UserControl
  {
    #region Membres privés
    /// <summary>
    /// Nombre de clé dans la DB en dessous duquel on peut lancer une requête "*"
    /// </summary>
    private const long SEUILSANSFILTRE = 200000;

    /// <summary>
    /// Les séparateurs pour le mode ponctuation
    /// </summary>
    private char[] separators = { ':', '.', '!', ',', ';', '/', '|', '\\', '§', '@', ']', ')', '(', '[', '-', '_', '{', '}', '+', '=', '*', '$', '£', '~', '&', '#', '"', '\'', '`', '^', '°', '¨', '¤', '%', '<', '>' };

     /// <summary>
    /// Nombre de clés dans la base
    /// </summary>
    private long nombreKeysTotal = -1;

    /// <summary>
    /// Nombre de clé trouvés dans la dernière recherche (-1 = pas de recherches)
    /// </summary>
    private long nombreKeyFound = -1;

    /// <summary>
    /// Indique que toutes les clés n'ont pas été affichées
    /// </summary>
    private bool tropDeCles = false;

    /// <summary>
    /// Mode d'affichage
    /// </summary>
    private EDisplayMode displayMode = EDisplayMode.IndentPonctuation;

    /// <summary>
    /// La connexion à la base
    /// </summary>
    private RedisConnection cnn;

    /// <summary>
    /// La liste des clé trouvées
    /// </summary>
    private List<KeySearchResult> nodesTrouves = null;
    #endregion

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="KeySearch" />.
    /// </summary>
    public KeySearch()
    {
      this.InitializeComponent();

      this.cbFiltreType.Items.AddRange(
        new object[] 
        {
            Rubrique.ETypeKeyUnKnowR,
            ETypeKey.Tstring.GetLibelle(),
            ETypeKey.Tlist.GetLibelle(),
            ETypeKey.Tset.GetLibelle(),
            ETypeKey.Tset.GetLibelle(),
            ETypeKey.Thash.GetLibelle()
        });
      this.label1.Text = Properties.Resources.KeySearchLbl1T;
      this.label2.Text = Properties.Resources.KeySearchLbl2T + " :";
      this.label3.Text = Properties.Resources.KeySearchLbl3T + " :";
      this.label4.Text = Properties.Resources.KeySearchLbl4T + " :";
      this.lblDetail.Text = Properties.Resources.KeySearcLblDetailT;
      this.chkMelangeType.Text = Properties.Resources.KeySearchChkMelangeType;
      this.rdDisplayMode0.Text = Properties.Resources.KeySearchDisplayModeNone;
      this.rdDisplayMode1.Text = Properties.Resources.KeySearchDisplayModeText;
      this.toolTip1.SetToolTip(this.btSizeOf, Properties.Resources.KeySearchBtSizeOfD);
      this.toolTip1.SetToolTip(this.btAddKey, Properties.Resources.KeyExplorerBtAddKeyD);
      StringBuilder res = new StringBuilder();
      foreach (char c in this.separators)
      {
        res.Append(c);
      }

      this.rdDisplayMode2.Text = string.Format(Properties.Resources.KeySearchDisplayModePonctuation, res);
      this.rdDisplayMode3.Text = Properties.Resources.KeySearchDisplayModeNumber;
      this.txtMinChar.IntValue = 2;
      this.lblCountCle.Text = this.CountCle(false);
      this.lblPoids.Text = string.Empty;
      this.GereBouton();
    }

    #region Events publics
    /// <summary>
    /// Notifie la fin d'une recherche au parent
    /// </summary>
    public event EventHandler OnSearch;
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
      /// Indentation en groupant par blocs de caractères séparé par un caractère de ponctuation
      /// </summary>
      IndentPonctuation = 2,

      /// <summary>
      /// Séparation en groupant les bloc de caractère ou des nombres.
      /// </summary>
      IndentNombre = 3,
    }

    #region Properties & public methods
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
          this.nombreKeysTotal = this.cnn.Connector.DbSize();
        }
        else
        {
          this.nombreKeysTotal = -1;
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
        this.GereBouton();
      }
    }

    /// <summary>
    /// Renvoie les infos résultat de la recherche
    /// </summary>
    public List<KeySearchResult> Resultat
    {
      get
      {
        return this.nodesTrouves;
      }
    }
     
    /// <summary>
    /// Sauvegarde les propriétés du composant
    /// </summary>
    public void SaveProperties()
    {
      Properties.Settings.Default.KeySearchDisplayMode = Convert.ToInt32(this.displayMode);
      Properties.Settings.Default.KeySearchDisplayMelangeType = this.chkMelangeType.Checked;
      Properties.Settings.Default.KeySearchNombreMinChar = this.txtMinChar.IntValue;
    }

    /// <summary>
    /// Charge les propriétés du composant
    /// </summary>
    public void LoadProperties()
    {
      this.chkMelangeType.Checked = Properties.Settings.Default.KeySearchDisplayMelangeType;
      this.displayMode = (EDisplayMode)Properties.Settings.Default.KeySearchDisplayMode;
      this.txtMinChar.IntValue = Properties.Settings.Default.KeySearchNombreMinChar;

      switch (this.displayMode)
      { 
        case EDisplayMode.Flat:
          this.rdDisplayMode0.Checked = true;
          break;
        case EDisplayMode.IndentText:
          this.rdDisplayMode1.Checked = true;
          break;
        case EDisplayMode.IndentPonctuation:
          this.rdDisplayMode2.Checked = true;
          break;
        case EDisplayMode.IndentNombre:
          this.rdDisplayMode3.Checked = true;
          break;
      }
      
      this.GereBouton();
    }
    
    /// <summary>
    /// Renvoie le nombre de clé trouvées en texte simple ou détaillé
    /// </summary>
    /// <param name="simple">Si simple le texte renvoyé fait au plus court, sinon jolie phrase</param>
    /// <returns>La phrase pour le nombre de clés</returns>
    public string CountCle(bool simple)
    {
      if (this.nombreKeyFound < 0)
      { // pas de recherche
        return string.Empty;
      }
      else if (this.nombreKeyFound == 0)
      {
        return Properties.Resources.KeySearchResultCount0;
      }
      else if (this.nombreKeyFound == 1)
      {
        if (simple)
        {
          return Properties.Resources.KeySearchResultCountSimple1;
        }
        else
        {
          ETypeKey tk = this.GetSelectedTypeFiltre();
          string typeFilte = tk.GetFiltreLibelle();
          return string.Format(Properties.Resources.KeySearchResultCount1, typeFilte, this.GetPattern());
        }
      }
      else if (this.tropDeCles)
      { // affichage partiel car trop de clés trouvées
        return string.Format(Properties.Resources.KeySearchResultCountTooMany, SEUILSANSFILTRE);
      }
      else
      {
        if (simple)
        {
          return string.Format(Properties.Resources.KeySearchResultCountSimpleN, this.nombreKeyFound);
        }
        else
        {
          ETypeKey tk = this.GetSelectedTypeFiltre();
          string typeFilte = tk.GetFiltreLibelle();
          return string.Format(Properties.Resources.KeySearchResultCountN, this.nombreKeyFound, typeFilte, this.GetPattern());
        }
      }
    }

    /// <summary>
    /// Supprime la clé key du résultat de recherche
    /// </summary>
    /// <param name="key">La clé à supprimer</param>
    /// <param name="withFire">Déclenche ou pas les évents au parent (utilisé en cas d'appels successifs)</param>
    public void RemoveKey(KeySearchResult key, bool withFire)
    {
      if (this.nodesTrouves.Contains(key))
      { // trouvé à la racine
        this.nodesTrouves.Remove(key);
        this.nombreKeyFound--;
      }
      else
      { // on recherche dans les fils
        this.RemoveKey(key, this.nodesTrouves);
      }

      if (withFire)
      {
        this.NotifySearch();
      }
    }

    /// <summary>
    /// Lance une recherche
    /// </summary>
    public void FireSearch()
    {
      this.NotifySearch();
    }
    #endregion

    #region Internals Events
    /// <summary>
    /// Le filtre de recherche change
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramêtre inutile</param>
    private void TxtSearchTextChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }

    /// <summary>
    /// Gestion du retour charriot dans le texte de recherche
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">paramêtre inutile</param>
    private void TxtSearchKeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == '\n' || e.KeyChar == '\r')
      {
        this.btSearch.PerformClick();
      }
    }

    /// <summary>
    /// Recherche de clé
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">paramêtre inutile</param>
    private void BtSearchClick(object sender, EventArgs e)
    {
      Cursor oldCursor = this.Cursor;
      this.Cursor = Cursors.WaitCursor;
      Application.DoEvents();
      try
      {
        if (this.nodesTrouves == null)
        { // première recherche
          this.nodesTrouves = new List<KeySearchResult>();
        }
        else
        {
          this.nodesTrouves.Clear();
        }

        this.tropDeCles = false;
        int nb = 0;
        if (this.Connection != null)
        {
          ETypeKey typeFiltre = this.GetSelectedTypeFiltre();

          // recherche en DB
          List<string> lst = this.Connection.Connector.Keys(this.GetPattern());
          if (lst != null)
          { // y a des données
            lst.Sort(new RedisManagementStudio.BLL.StringCorrectComparer());
            KeySearchResult node;
            KeySearchResult old = null;
            ETypeKey tk;
            string common;
            foreach (string key in lst)
            {
              // tk = this.Connection.Type(key);
              tk = ETypeKey.UnKnow;
              if (tk.IsSame(typeFiltre))
              { // la clé doit être affichée : elle fait partie du filtre de type
                nb++;
                node = new KeySearchResult(key, tk);
                if (old != null)
                { // on a une node avant
                  common = this.Compare(old, node);
                  if (string.IsNullOrWhiteSpace(common))
                  { // pas de point commun
                    this.nodesTrouves.Add(node);
                  }
                  else
                  { // y a un point commun
                    this.AccrocheCommun(tk, node, old, common);
                  }
                }
                else
                { // première node ou flat style
                  this.nodesTrouves.Add(node);
                }

                if (this.displayMode != EDisplayMode.Flat)
                { // ne sert que pour les affichages indenté
                  old = node;
                }

                if (nb > SEUILSANSFILTRE)
                { // Trops de clés dans le résultat
                  KeySearchResult notFound = new KeySearchResult(Properties.Resources.KeySearchErrorTooMany, ETypeKey.Tnone);
                  this.nodesTrouves.Add(notFound);
                  this.tropDeCles = true;
                  break;
                }
              }
            }
          }
        }

        this.nombreKeyFound = nb;
        this.lblCountCle.Text = this.CountCle(false);
        this.GereBouton();
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
    /// <param name="e">paramêtre inutile</param>
    private void BtDisplayModeClick(object sender, EventArgs e)
    {
      if (sender != null)
      {
        RadioButton rd = sender as RadioButton;
        if (rd != null && rd.Tag != null)
        {
          this.displayMode = (EDisplayMode)Convert.ToInt32(rd.Tag);
        }
      }

      this.GereBouton();
    }
    
    /// <summary>
    /// Changement de l'option activer le multi-type ou pas
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">paramêtre inutile</param>
    private void ChkMelangeTypeCheckedChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }

    /// <summary>
    /// Ajoute une clé
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">paramêtre inutile</param>
    private void BtAddKeyClick(object sender, EventArgs e)
    {
      FAddKey.ProcessAdd(this.Connection, this);
    }

    /// <summary>
    /// Calcule la taille de l'ensemble des clés de la recherche
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">paramêtre inutile</param>
    private void BtSizeOfClick(object sender, EventArgs e)
    {
      if (this.nodesTrouves == null || this.nodesTrouves.Count == 0)
      { // pas de recherche pas de calcul (au cas ou)
        return;
      }

      long size = 0;
      int nombreKey = 0;

      foreach (KeySearchResult key in this.nodesTrouves)
      {
        size += key.Size(this.Connection);
        nombreKey += key.Nombre;
      }

      string txt, sizeTxt;
      if (size == 0)
      {
        txt = Properties.Resources.KeyExplorerBtSizeOfConfirmD0;
        sizeTxt = Properties.Resources.KeySize0;
      }
      else
      {
        sizeTxt = InformationBase.GetCounterBit(size);
        if (nombreKey > 1)
        {
          txt = string.Format(Properties.Resources.KeyExplorerBtSizeOfConfirmDNN, sizeTxt, nombreKey);
        }
        else
        {
          txt = string.Format(Properties.Resources.KeyExplorerBtSizeOfConfirmDN1, sizeTxt);
        }
      }

      this.lblPoids.Text = sizeTxt;
      MessageBox.Show(this, txt, Properties.Resources.KeyExplorerBtSizeOfConfirmT, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Gère l'activation des boutons
    /// </summary>
    private void GereBouton()
    {
      if (this.nombreKeysTotal == -1)
      {
        this.btSearch.Enabled = false;
        this.toolTip1.SetToolTip(this.panel1, Properties.Resources.KeySearchErrorConnection);
      }
      else if (this.nombreKeysTotal > SEUILSANSFILTRE)
      {
        this.btSearch.Enabled = !string.IsNullOrEmpty(this.txtSearch.Text) && this.txtSearch.Text != "*";
        this.toolTip1.SetToolTip(this.panel1, this.btSearch.Enabled ? string.Empty : string.Format(Properties.Resources.KeySearchErrorBadFilter, this.nombreKeysTotal));
      }
      else
      {
        this.btSearch.Enabled = true;
        this.toolTip1.SetToolTip(this.panel1, string.Empty);
      }

      this.chkMelangeType.Enabled = this.displayMode != EDisplayMode.Flat;
      this.pnlResult.Visible = this.nombreKeysTotal > 0 && this.nombreKeyFound >= 0;
      this.lblPoids.Text = string.Empty;
      this.btSizeOf.Enabled = this.nodesTrouves != null && this.nodesTrouves.Count > 0;
    }

    /// <summary>
    /// Déplace old et le place avec NODE dans un nouveau dossier de type TK et dont le nom est common 
    /// </summary>
    /// <param name="tk">Type de noeud à déplacer</param>
    /// <param name="node">Noeud N°2 à ajouter</param>
    /// <param name="old">Noeud à déplacer</param>
    /// <param name="common">Nom du groupement</param>
    private void AccrocheCommun(ETypeKey tk, KeySearchResult node, KeySearchResult old, string common)
    {
      KeySearchResult folder;
      if (old.Parent != null)
      { // old n'est pas à la racine 
        if (old.Parent.Key == common)
        { // la partie commune est la même
          old.Parent.ChildrensAdd(node);
        }
        else if (common.Length > old.Parent.Key.Length)
        { // le père de old est moins complet : on s'accroche dessus
          folder = new KeySearchResult(common, ETypeKey.Folder); 
          old.Parent.ChildrensAdd(folder);
          old.Parent.ChildrensRemove(old);
          folder.ChildrensAdd(old);
          folder.ChildrensAdd(node);
        }
        else
        { // le père est plus complet on cherche plus haut récursivement
          this.AccrocheCommun(tk, node, old.Parent, common);
        }
      }
      else
      { // old est à la racine : on cree un dossier on met les 2 dedans
        folder = new KeySearchResult(common, ETypeKey.Folder); 
        this.nodesTrouves.Add(folder);
        int index = this.nodesTrouves.IndexOf(old);
        this.nodesTrouves.RemoveAt(index);
        folder.ChildrensAdd(old);
        folder.ChildrensAdd(node);
      }
    }

    /// <summary>
    /// Compare 2 NOEUDS pour voir s'il peuvent être regroupés sous un même parent
    /// </summary>
    /// <param name="old">Ancien noeud</param>
    /// <param name="node">Nouveau noeud</param>
    /// <returns>Le texte qu'ils ont en commun</returns>
    private string Compare(KeySearchResult old, KeySearchResult node)
    {
      if (this.chkMelangeType.Checked || old.Type == node.Type)
      { // Même type (ou tous type mélangés autorisé) : ils sont compatible à la comparaison
        int n = 0;
        string t1 = old.Key;
        string t2 = node.Key;
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
        else if (this.displayMode == EDisplayMode.IndentText)
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
        if (res.Length >= this.txtMinChar.IntValue)
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
    /// Renvoie le type de donnée à filtrer
    /// </summary>
    /// <returns>Le type à filtre tous les type si UnKnow</returns>
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
    /// Retire Key de la collection
    /// </summary>
    /// <param name="key">La clé à supprimer</param>
    /// <param name="nodes">La collection à analyser</param>
    /// <returns>vrai si supprimé</returns>
    private bool RemoveKey(KeySearchResult key, IEnumerable<KeySearchResult> nodes)
    {
      foreach (KeySearchResult nod in nodes)
      {
        if (nod.Childrens.Contains(key))
        { // effectue la supression
          this.nombreKeyFound -= key.Nombre; // le nombre de clé retirées
          nod.ChildrensRemove(key);
          if (nod.ChildrensCount == 0)
          { // nod était un dossier qui est vide maintenant 
            if (nod.Parent != null)
            { // on enlève de la collection du père nod lui même
              nod.Parent.ChildrensRemove(nod);
            }
            else
            { // nod est à la racine, on le vire aussi
              this.nodesTrouves.Remove(nod);
            }
          }

          return true;
        }

        if (this.RemoveKey(key, nod.Childrens))
        {
          return true;
        }
      }

      return false;
    }

    /// <summary>
    /// Notifie le parent d'une fin de recherche
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
