using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using ClientRedisLib;

namespace RedisManagementStudio.BLL.Connection
{
  /// <summary>
  /// Connexion à une base REDIS
  /// </summary>
  public class RedisConnectionParam : IConnection
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="RedisConnectionParam" />.
    /// </summary>
    public RedisConnectionParam()
    {
      this.Name = string.Empty;
      this.Password = string.Empty;
      this.URL = RedisConnector.DEFAULTHOST;
      this.Port = RedisConnector.DEFAULTPORT;
      this.Base = RedisConnector.DEFAULTDB;
      this.Color = Color.Empty;
      this.Description = string.Empty;
    }

    /// <summary>
    /// Nom de la connexion
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// mot de passe pour la connexion
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// URL du serveur REDIS
    /// </summary>
    public string URL { get; set; }

    /// <summary>
    /// Port du serveur REDIS
    /// </summary>
    public int Port { get; set; }

    /// <summary>
    /// ID de la base sur le serveur
    /// </summary>
    public int Base { get; set; }

    /// <summary>
    /// Couleur de la connexion
    /// </summary>
    public Color Color { get; set; }

    /// <summary>
    /// Description de la connexion
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Renvoie la description de la connexion
    /// </summary>
    public string FullDescription
    {
      get
      {
        return string.Format(Properties.Resources.ConnectionParamToString, this.Name, this.URL, this.Port, this.Base, this.Description);
      }
    }

    /// <summary>
    /// Formate une clé pour la coupler à ce serveur (utilisé pour les alarmes)
    /// </summary>
    /// <param name="key">La clé</param>
    /// <returns>La clé encodé pour la connexion en cours</returns>
    public string GetKey(string key)
    {
      return string.Format("{0}:{1}:{2}:{3}", this.URL, this.Port, this.Base, key);
    }

    /// <summary>
    /// Charge l'objet depuis un noeud XML
    /// </summary>
    /// <param name="rac">Le noeud</param>
    public void Load(XElement rac)
    {
      this.Name = rac.Element("Name") != null ? rac.Element("Name").Value : string.Empty;
      this.Password = rac.Element("Password") != null ? rac.Element("Password").Value : string.Empty;
      this.URL = rac.Element("URL") != null ? rac.Element("URL").Value : RedisConnector.DEFAULTHOST;
      this.Port = rac.Element("Port") != null ? Convert.ToInt32(rac.Element("Port").Value) : RedisConnector.DEFAULTPORT;
      this.Base = rac.Element("Base") != null ? Convert.ToInt32(rac.Element("Base").Value) : RedisConnector.DEFAULTDB;
      this.Color = rac.Element("Color") != null ? Color.FromArgb(Convert.ToInt32(rac.Element("Color").Value)) : Color.Empty;
      this.Description = rac.Element("Description") != null ? rac.Element("Description").Value : string.Empty;
    }

    /// <summary>
    /// Sauve l'objet dans un noeud XML
    /// </summary>
    /// <returns>Le noeud remplis</returns>
    public XElement Save()
    {
      XElement nfo = new XElement("Connection");
      nfo.Add(new XElement("Name", this.Name));
      if (!string.IsNullOrWhiteSpace(this.Password))
      {
        nfo.Add(new XElement("Password", this.Password));
      }

      if (!string.IsNullOrWhiteSpace(this.URL) && this.URL != RedisConnector.DEFAULTHOST)
      {
        nfo.Add(new XElement("URL", this.URL));
      }

      if (this.Port != RedisConnector.DEFAULTPORT)
      {
        nfo.Add(new XElement("Port", this.Port));
      }

      if (this.Base != RedisConnector.DEFAULTDB)
      {
        nfo.Add(new XElement("Base", this.Base));
      }

      if (this.Color != Color.Empty)
      {
        nfo.Add(new XElement("Color", this.Color.ToArgb()));
      }

      if (!string.IsNullOrWhiteSpace(this.Description))
      {
        nfo.Add(new XElement("Description", this.Description));
      }

      return nfo;
    }

    /// <summary>
    /// Renvoie un TREENODE représentant une REDISCONNECTIONPARAM
    /// </summary>
    /// <param name="mnu">Le menu contextuel à connecter</param>
    /// <returns>le TREENODE</returns>
    public TreeNode GetConnection(ContextMenuStrip mnu)
    {
      TreeNode nod = new TreeNode();
      nod.Text = this.Name;
      nod.Tag = this;
      nod.ToolTipText = this.Description;
      nod.ContextMenuStrip = mnu;
      nod.ImageKey = ConnectionFolder.IMGKEYCONNECTION;
      nod.SelectedImageKey = ConnectionFolder.IMGKEYCONNECTION + ConnectionFolder.IMGKEYSEL;
      return nod;
    }
  }
}
