using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RedisManagementStudio.BLL.Connection
{
  /// <summary>
  /// Gère un dossier qui regroupe des connexions
  /// L'objet se charge
  /// </summary>
  public class ConnectionFolder : IConnection
  {
    /// <summary>
    /// Image de l'objet
    /// </summary>
    public const string IMGKEYFOLDER = "Folder";

    /// <summary>
    /// Image d'une connexion
    /// </summary>
    public const string IMGKEYCONNECTION = "Connection";

    /// <summary>
    /// Post fixe pour les versions sélectionnées
    /// </summary>
    public const string IMGKEYSEL = "Sel";

    /// <summary>
    /// Fichier de config XML
    /// </summary>
    private const string FILECONFIG = @"Config.xml";

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="ConnectionFolder" />.
    /// </summary>
    public ConnectionFolder()
    {
      this.Name = string.Empty;
      this.Folders = new List<ConnectionFolder>();
      this.Childs = new List<RedisConnectionParam>();
      this.Open = false;
      this.Description = string.Empty;
    }

    /// <summary>
    /// Nom du fichier de sauvegarde des connexion Paramètre
    /// </summary>
    public static string FileConfig
    {
      get
      {
        FileInfo fi = new FileInfo(Application.ExecutablePath);
        return Path.Combine(fi.DirectoryName, ConnectionFolder.FILECONFIG);
      }
    }

    /// <summary>
    /// Nom du dossier
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Liste des sous dossiers
    /// </summary>
    public List<ConnectionFolder> Folders { get; private set; }

    /// <summary>
    /// Liste des connexions filles
    /// </summary>
    public List<RedisConnectionParam> Childs { get; private set; }

    /// <summary>
    /// Indique si le dossier est remplié ou pas
    /// </summary>
    public bool Open { get; set; }

    /// <summary>
    /// Description du dossier
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Met à jour l'objet à partir des infos du TREENODE et sauvegarde sur disque
    /// </summary>
    /// <param name="fileName">Fichier disque</param>
    /// <param name="rac">Noeud à analyser</param>
    /// <returns>Message d'erreur en cas de problème. Vide si ok</returns>
    public static string ConnectionsSynchroniseAndSave(string fileName, TreeNode rac)
    {
      ConnectionFolder fld = new ConnectionFolder();
      ConnectionFolder.SynchroniseFolder(fld, rac);
      return fld.Save(fileName);
    }

    /// <summary>
    /// Charge l'objet depuis le fichier
    /// </summary>
    /// <param name="fileName">Nom du fichier</param>
    /// <returns>Message d'erreur en cas de problème. Vide si ok</returns>
    public string Load(string fileName)
    {
      XDocument doc = null;
      try
      {
        doc = XDocument.Load(fileName);
        XElement fld = doc.Element("Folder");
        if (fld != null)
        {
          this.Load(fld);
          return string.Empty; // Ok
        }
        else
        {
          return Properties.Resources.ConnectionFolderLoadError;
        }
      }
      catch (Exception ex)
      {
        return ex.ToString();
      }
    }

    /// <summary>
    /// Charge l'objet depuis le bout de XML
    /// </summary>
    /// <param name="rac">Noeud XML</param>
    public void Load(XElement rac)
    {
      this.Name = rac.Element("Name") != null ? rac.Element("Name").Value : string.Empty;
      this.Open = rac.Attribute("Open") != null ? rac.Attribute("Open").Value == "1" : false;
      this.Description = rac.Element("Description") != null ? rac.Element("Description").Value : string.Empty;
      this.Folders.Clear();
      XElement fld = rac.Element("Folders");
      if (fld != null)
      {
        foreach (XElement nod in fld.Elements("Folder"))
        {
          ConnectionFolder cnn = new ConnectionFolder();
          cnn.Load(nod);
          this.Folders.Add(cnn);
        }
      }

      this.Childs.Clear();
      XElement child = rac.Element("Connections");
      if (child != null)
      {
        foreach (XElement cnn in child.Elements("Connection"))
        {
          RedisConnectionParam prm = new RedisConnectionParam();
          prm.Load(cnn);
          this.Childs.Add(prm);
        }
      }
    }

    /// <summary>
    /// Sauvegarde l'objet dans un fichier XML
    /// </summary>
    /// <param name="fileName">Nom du fichier</param>
    /// <returns>Message d'erreur en cas de problème. Vide si ok</returns>
    public string Save(string fileName)
    {
      try
      {
        XDocument doc = new XDocument();
        doc.Add(this.Save());
        doc.Save(fileName);
        return string.Empty; // pas d'erreurs
      }
      catch (Exception ex)
      {
        return ex.ToString();
      }
    }

    /// <summary>
    /// renvoie le noeud XML représentant l'objet
    /// </summary>
    /// <returns>Le noeud XML</returns>
    public XElement Save()
    {
      XElement nfo = new XElement("Folder");
      nfo.Add(new XElement("Name", this.Name));
      if (this.Open)
      {
        nfo.Add(new XAttribute("Open", "1"));
      }

      if (!string.IsNullOrWhiteSpace(this.Description))
      {
        nfo.Add(new XElement("Description", this.Description));
      }

      XElement folds = new XElement("Folders");
      nfo.Add(folds);
      foreach (ConnectionFolder fld in this.Folders)
      {
        folds.Add(fld.Save());
      }

      XElement conn = new XElement("Connections");
      nfo.Add(conn);
      foreach (RedisConnectionParam prm in this.Childs)
      {
        conn.Add(prm.Save());
      }

      return nfo;
    }

    /// <summary>
    /// Renvoie un TREE NODE représentant un CONNECTIONFOLDER
    /// </summary>
    /// <param name="mnu">le menu contextuel à accrocher au TREENODE</param>
    /// <returns>Le TREE NODE</returns>
    public TreeNode GetFolder(ContextMenuStrip mnu)
    {
      TreeNode nod = new TreeNode();
      nod.ImageKey = ConnectionFolder.IMGKEYFOLDER;
      nod.Text = this.Name;
      nod.ToolTipText = this.Description;
      nod.SelectedImageKey = ConnectionFolder.IMGKEYFOLDER + ConnectionFolder.IMGKEYSEL;
      nod.ContextMenuStrip = mnu;
      nod.Tag = this;
      foreach (ConnectionFolder fl in this.Folders)
      {
        nod.Nodes.Add(fl.GetFolder(mnu));
      }

      foreach (RedisConnectionParam cn in this.Childs)
      {
        nod.Nodes.Add(cn.GetConnection(mnu));
      }

      if (this.Open)
      {
        nod.Expand();
      }
      else
      {
        nod.Collapse();
      }

      return nod;
    }

    /// <summary>
    /// Met à jour un TREENODE avec les infos d'un CONNECTIONFOLDER
    /// </summary>
    /// <param name="fld">L'objet à synchroniser</param>
    /// <param name="treeNode">Le TREE NODE qui contient les infos</param>
    private static void SynchroniseFolder(ConnectionFolder fld, TreeNode treeNode)
    {
      fld.Name = treeNode.Text;
      fld.Open = treeNode.IsExpanded;
      fld.Description = treeNode.ToolTipText;
      foreach (TreeNode nod in treeNode.Nodes)
      {
        if (nod.ImageKey == IMGKEYFOLDER)
        { // we got a folder
          ConnectionFolder fl = new ConnectionFolder();
          ConnectionFolder.SynchroniseFolder(fl, nod);
          fld.Folders.Add(fl);
        }
        else if (nod.ImageKey == IMGKEYCONNECTION)
        { // we got a connection
          RedisConnectionParam cn = nod.Tag as RedisConnectionParam;
          if (cn != null)
          {
            fld.Childs.Add(cn);
          }
        }
      }
    }
  }
}