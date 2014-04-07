using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RedisManagementStudio.BLL;
using RedisManagementStudio.BLL.Redis;
using RedisManagementStudio.BLL.Redis.Client;
using RedisManagementStudio.BLL.Redis.Keys;
using RedisManagementStudio.BLL.Redis.Sentinel;

namespace RedisManagementStudio
{
  /// <summary>
  /// Gestion d'un serveur REDIS
  /// </summary>
  public partial class FRedisUtil : Form
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="FRedisUtil" />.
    /// </summary>
    public FRedisUtil()
    {
      this.InitializeComponent();

      this.toolStripStatusLabel1.Text = Properties.Resources.FRedisUtilLbl1T;
      this.toolStripStatusLabel2.Text = Properties.Resources.FRedisUtilLbl2T;
      this.toolStripStatusLabel3.Text = Properties.Resources.FRedisUtilLbl3T;
      this.toolStripStatusLabel4.Text = Properties.Resources.FRedisUtilLbl4T;
      this.toolStripStatusLabel5.Text = Properties.Resources.FRedisUtilLbl5T;
      this.toolStripStatusLabel6.Text = Properties.Resources.FRedisUtilLbl6T;

      this.redisClientUI1.Dock = DockStyle.Fill;
      this.redisListInfoUI1.Dock = DockStyle.Fill;
      this.keySearch1.Dock = DockStyle.Fill;
      this.keyGroup1.Dock = DockStyle.Fill;
      this.keysExplorer1.Dock = DockStyle.Fill;
      this.pubSubConsole1.Dock = DockStyle.Fill;
      this.monitorConsole1.Dock = DockStyle.Fill;
      this.serverResume1.Dock = DockStyle.Fill;
      this.sentinelServersUI1.Dock = DockStyle.Fill;

      this.keysExplorer1.KeySearcher = this.keySearch1;
      this.keyGroup1.KeySearcher = this.keySearch1;
      this.keyGroup1.ImageList = this.imageLib1.Actions;

      this.redisClientUI1.Visible = false;
      this.redisListInfoUI1.Visible = false;
      this.keySearch1.Visible = false;
      this.keyGroup1.Visible = false;
      this.keysExplorer1.Visible = false;
      this.pubSubConsole1.Visible = false;
      this.monitorConsole1.Visible = false;
      this.serverResume1.Visible = false;
      this.sentinelServersUI1.Visible = false;
    }

    /// <summary>
    /// Paramètre de connexion 
    /// </summary>
    public RedisConnection Connection
    {
      get
      {
        return this.redisListInfoUI1.Connection;
      }

      set
      {
        this.serverResume1.Connection = value;
        this.redisClientUI1.Connection = value;
        this.redisListInfoUI1.Connection = value;
        this.keySearch1.Connection = value;
        this.keyGroup1.Connection = value;
        this.keysExplorer1.Connection = value;
        this.monitorConsole1.ConnectionParam = value.Param;
        this.pubSubConsole1.Connection = value;
        this.sentinelServersUI1.Connection = value;

        this.CreateMenu();

        this.FillDisplay(value);
      }
    }

    #region Event internes
    /// <summary>
    /// Chargement de la fenêtre
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void FRedisUtil_Load(object sender, EventArgs e)
    {
      this.Location = Properties.Settings.Default.FRedisUtilPostion;
      this.Size = Properties.Settings.Default.FRedisUtilDimension;
      this.splitContainer1.SplitterDistance = Properties.Settings.Default.FRedisUtilSplit;

      this.serverResume1.LoadProperties();
      this.keySearch1.LoadProperties();
      this.keyGroup1.LoadProperties();
      this.keysExplorer1.LoadProperties();
      this.redisClientUI1.LoadProperties();
      this.redisListInfoUI1.LoadProperties();
      this.monitorConsole1.LoadProperties();
      this.pubSubConsole1.LoadProperties();
      this.sentinelServersUI1.LoadProperties();
      this.FillDisplay(this.Connection);
    }

    /// <summary>
    /// Avant la fermeture de la fenêtre
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void FRedisUtil_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (this.monitorConsole1.TraceIsActive)
      { // arrete la trace en cours
        this.monitorConsole1.Stop();
      }

      if (this.pubSubConsole1.TraceIsActive)
      {  // arrete la trace en cours
        this.pubSubConsole1.Stop();
      }
    }

    /// <summary>
    /// Fermeture de la fenêtre
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void FRedisUtil_FormClosed(object sender, FormClosedEventArgs e)
    {
      this.serverResume1.SaveProperties();
      this.redisClientUI1.SaveProperties();
      this.redisListInfoUI1.SaveProperties();
      this.keySearch1.SaveProperties();
      this.keyGroup1.SaveProperties();
      this.keysExplorer1.SaveProperties();
      this.monitorConsole1.SaveProperties();
      this.pubSubConsole1.SaveProperties();
      this.sentinelServersUI1.SaveProperties();
      if (this.WindowState == FormWindowState.Normal)
      {
        Properties.Settings.Default.FRedisUtilPostion = this.Location;
        Properties.Settings.Default.FRedisUtilDimension = this.Size;
      }
      else
      {
        Properties.Settings.Default.FRedisUtilPostion = this.RestoreBounds.Location;
        Properties.Settings.Default.FRedisUtilDimension = this.RestoreBounds.Size;
      }

      Properties.Settings.Default.FRedisUtilSplit = this.splitContainer1.SplitterDistance;
      Properties.Settings.Default.Save();
    }

    /// <summary>
    /// Choix d'un menu
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void MenuItemSelected(object sender, TreeViewEventArgs e)
    {
      if (e.Node.Tag != null)
      {
        CommandMenu cmd = e.Node.Tag as CommandMenu;
        this.MenuClick(cmd, e.Node);
      }
    }

    /// <summary>
    /// Lorsque la liste d'info est actualisée
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void RedisListInfoUI1OnRefreshList(object sender, EventArgs e)
    {
      if (this.tvMenu.SelectedNode != null)
      {
        TreeNode menu = this.SelectMenu(CommandMenuAction.ConfigurationRubrique, this.tvMenu.SelectedNode);
        if (menu != null)
        { // on a trouvé le menu
          this.RefillConfigurationRubrique(menu);
        }
      }
    }

    /// <summary>
    /// Lorsqu'un recherche vient de se finir
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void KeySearch1OnSearch(object sender, EventArgs e)
    {
      if (this.tvMenu.SelectedNode != null)
      {
        TreeNode menu = this.SelectMenu(CommandMenuAction.Keys, this.tvMenu.SelectedNode);
        if (menu != null)
        { // on a trouvé le menu
          this.RefillKeys(menu);
          this.MenuClick(menu.Tag as CommandMenu, menu);
        }
      }
    }

    /// <summary>
    /// changement de la sélection dans un groupe de clés
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void KeyGroup1OnChange(object sender, EventArgs e)
    {
      if (this.tvMenu.SelectedNode != null)
      { 
        TreeNode sel = this.keyGroup1.Selection;
        if (sel != null)
        {
          foreach (TreeNode nod in this.tvMenu.SelectedNode.Nodes)
          {
            if (nod.Tag == sel.Tag)
            {
              this.tvMenu.SelectedNode = nod;
              nod.Expand();
              return;
            }
          }
        }
      }
    }

    /// <summary>
    /// changement de change la sélection dans un serveur suivi
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void SentinelServersUI1OnChange(object sender, EventArgs e)
    {
      if (this.tvMenu.SelectedNode != null)
      {
        if (this.sentinelServersUI1.SelectedSlave != null)
        {
          CommandMenu cmd = this.GetCommandMenuFromServeur(this.sentinelServersUI1.SelectedSlave);
          foreach (TreeNode nod in this.tvMenu.SelectedNode.Nodes)
          {
            if (nod.Tag.Equals(cmd))
            {
              this.tvMenu.SelectedNode = nod;
              nod.Expand();
              return;
            }
          }
        }
      }
    }
    
    /// <summary>
    /// Force un remplissage des serveurs suivis
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void SentinelServersUI1OnRefresh(object sender, EventArgs e)
    {
      if (this.tvMenu.SelectedNode != null)
      {
        TreeNode menu = this.SelectMenu(CommandMenuAction.SentinelServers, this.tvMenu.SelectedNode);
        if (menu != null)
        { // on a trouvé le menu
          this.RefillListServeurSuivis(menu);
          this.MenuClick(menu.Tag as CommandMenu, menu);
        }
      }
    }

    /// <summary>
    /// Force un remplissage de la liste des clients
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void RedisClientUI1OnRefresh(object sender, EventArgs e)
    {
      if (this.tvMenu.SelectedNode != null)
      {
        TreeNode menu = this.SelectMenu(CommandMenuAction.Clients, this.tvMenu.SelectedNode);
        if (menu != null)
        { // on a trouvé le menu
          this.RefillListClient(menu);
          this.MenuClick(menu.Tag as CommandMenu, menu);
        }
      }
    }
    
    /// <summary>
    /// Sélection d'un client
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void RedisClientUI1OnChange(object sender, EventArgs e)
    {
      if (this.tvMenu.SelectedNode != null)
      {
        if (this.redisClientUI1.SelectedClient != null)
        {
          CommandMenu cmd = this.GetCommandMenuFromServeur(this.redisClientUI1.SelectedClient);
          foreach (TreeNode nod in this.tvMenu.SelectedNode.Nodes)
          {
            if (nod.Tag.Equals(cmd))
            {
              this.tvMenu.SelectedNode = nod;
              nod.Expand();
              return;
            }
          }
        }
      }
    }

    /// <summary>
    /// Notifie le besoin de basculer de publication vers abonnement 
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void PubSubConsole1OnChange(object sender, EventArgs e)
    {
      if (this.tvMenu.SelectedNode != null)
      {
        if (this.tvMenu.SelectedNode.Nodes.Count > 0)
        { // de la diffusion vers abonnement
          this.tvMenu.SelectedNode.Expand(); 
          this.tvMenu.SelectedNode = this.tvMenu.SelectedNode.FirstNode;
          return;
        }
        else if (this.tvMenu.SelectedNode.Parent != null)
        { // d'abonnement vers le parent
          this.tvMenu.SelectedNode = this.tvMenu.SelectedNode.Parent;
          this.tvMenu.SelectedNode.Expand();
        }
      }
    }
    #endregion

    #region Remplissages intermédiaires
    /// <summary>
    /// Rempli les rubriques de configuration
    /// </summary>
    /// <param name="node">Le noeud à remplir</param>
    private void RefillConfigurationRubrique(TreeNode node)
    {
      node.Nodes.Clear();

      if (this.redisListInfoUI1.Groupes != null)
      {
        foreach (CmdInfoRubrique rub in this.redisListInfoUI1.Groupes)
        {
          node.Nodes.Add(this.GetSubMenu(rub));
        }
      }

      node.Expand();
    }

    /// <summary>
    /// Rempli la listes des clients
    /// </summary>
    /// <param name="node">Le noeud à remplir</param>
    private void RefillListClient(TreeNode node)
    {
      node.Nodes.Clear();

      List<RedisClientListTranslator> clients = this.redisClientUI1.Clients;
      if (clients != null)
      {
        foreach (RedisClientListTranslator cli in clients)
        {
          node.Nodes.Add(this.GetSubMenu(cli));
        }

        string nombre = InformationBase.GetCounterValue(
          clients.Count,
          Properties.Resources.RedisClientUICountClient0,
          Properties.Resources.RedisClientUICountClient1,
          Properties.Resources.RedisClientUICountClientN);
        node.Text = string.Format(
          "{0} ({1})",
          CommandMenuAction.Clients.GetTitre(),
          nombre);
      }

      node.Expand();
    }
    
    /// <summary>
    /// Remplir la liste des clé trouvées
    /// </summary>
    /// <param name="parent">le noeud auquel accroche les données</param>
    private void RefillKeys(TreeNode parent)
    {
      parent.Nodes.Clear();
      this.RefillKeys(parent, this.keySearch1.Resultat);
      this.MajCountCle(parent);
      parent.Expand();
    }
    
    /// <summary>
    /// Rempli la listes des serveur suivis
    /// </summary>
    /// <param name="node">Le noeud à remplir</param>
    private void RefillListServeurSuivis(TreeNode node)
    {
      node.Nodes.Clear();

      List<SentinelServer> servers = this.sentinelServersUI1.Serveurs;
      if (servers != null)
      {
        foreach (SentinelServer srv in servers)
        {
          node.Nodes.Add(this.GetSubMenu(srv));
        }

        string nombre = InformationBase.GetCounterValue(
          servers.Count,
          Properties.Resources.SentinelServersCount0,
          Properties.Resources.SentinelServersCount1,
          Properties.Resources.SentinelServersCountN);
        node.Text = string.Format(
          "{0} ({1})",
          CommandMenuAction.SentinelServers.GetTitre(),
          nombre);
      }

      node.Expand();
    }

    /// <summary>
    /// Met à jour le nombre de clés trouvés sur le nom du TREENODE
    /// </summary>
    /// <param name="parent">Le TREENODE à mettre à jour</param>
    private void MajCountCle(TreeNode parent)
    {
      parent.Text = string.Format(
          "{0} ({1})",
          CommandMenuAction.Keys.GetTitre(),
          this.keySearch1.CountCle(true));
    }

    /// <summary>
    ///  Remplir la liste des clé trouvées (Récursif)
    /// </summary>
    /// <param name="parent">TREENODE père</param>
    /// <param name="nodes">Collection des noeud à utiliser</param>
    private void RefillKeys(TreeNode parent, IEnumerable<KeySearchResult> nodes)
    {
      TreeNode node;
      foreach (KeySearchResult key in nodes)
      {
        node = this.GetTreeNode(key);
        parent.Nodes.Add(node);
        this.RefillKeys(node, key.Childrens);
      }
    }
    #endregion

    #region Gestion Menu
    /// <summary>
    /// Crée les menus disponibles
    /// </summary>
    private void CreateMenu()
    {
      this.tvMenu.BeginUpdate();
      this.tvMenu.ImageList = this.imageLib1.Actions;
      this.tvMenu.Nodes.Clear();
      if (this.Connection != null)
      {
        bool sentinel = this.Connection.Connector.ServerInSentinelMode;
        this.tvMenu.Nodes.Add(this.GetMenu(CommandMenuAction.Server));
        this.tvMenu.Nodes.Add(this.GetMenu(CommandMenuAction.ConfigurationRubrique));
        if (!sentinel)
        { // en mode sentinel ces infos sont non manipulables
          this.tvMenu.Nodes.Add(this.GetMenu(CommandMenuAction.Clients));
          this.tvMenu.Nodes.Add(this.GetMenu(CommandMenuAction.Keys));
          this.tvMenu.Nodes.Add(this.GetMenu(CommandMenuAction.Monitor));
        }

        if (sentinel)
        { // sentinel mode
          this.tvMenu.Nodes.Add(this.GetMenu(CommandMenuAction.PubSubAbonnement));
          this.tvMenu.Nodes.Add(this.GetMenu(CommandMenuAction.SentinelServers));
        }
        else
        { // mode normal
          TreeNode nodPub = this.GetMenu(CommandMenuAction.PubSub);
          this.tvMenu.Nodes.Add(nodPub);
          nodPub.Nodes.Add(this.GetMenu(CommandMenuAction.PubSubAbonnement));
        }
      }
      
      this.tvMenu.EndUpdate();
    }

    /// <summary>
    /// Renvoie un sous menu à partir d'une rubrique de configuration
    /// </summary>
    /// <param name="rub">la rubrique à afficher</param>
    /// <returns>Le noeud</returns>
    private TreeNode GetSubMenu(CmdInfoRubrique rub)
    {
      TreeNode node = new TreeNode(Rubrique.GetLibelle(rub));
      node.ImageKey = rub.ToString();
      node.SelectedImageKey = node.ImageKey;
      CommandMenu cmd = new CommandMenu(CommandMenuAction.Configuration);
      cmd.ConfiguationRubrique = rub;
      node.Tag = cmd;
      return node;
    }

    /// <summary>
    /// Renvoie un sous menu à partir d'une information client
    /// </summary>
    /// <param name="cli">le client à afficher</param>
    /// <returns>Le noeud</returns>
    private TreeNode GetSubMenu(RedisClientListTranslator cli)
    {
      TreeNode node = new TreeNode(cli.ToString());
      node.ImageKey = "Client";
      node.SelectedImageKey = node.ImageKey;
      node.Tag = this.GetCommandMenuFromServeur(cli);
      return node;
    }

    /// <summary>
    /// Renvoi la commande pour le client donné
    /// </summary>
    /// <param name="cli">Le client</param>
    /// <returns>la commande</returns>
    private CommandMenu GetCommandMenuFromServeur(RedisClientListTranslator cli)
    {
      CommandMenu cmd = new CommandMenu(CommandMenuAction.ClientDetail);
      cmd.Client = cli;
      return cmd;
    }

    /// <summary>
    /// Renvoie un menu
    /// </summary>
    /// <param name="act">Commande du menu</param>
    /// <returns>Le menu crée</returns>
    private TreeNode GetMenu(CommandMenuAction act)
    {
      TreeNode node = new TreeNode(act.GetTitre());
      node.ToolTipText = act.GetDescription();
      node.ImageKey = act.ToString();
      node.SelectedImageKey = act.ToString();
      node.Tag = new CommandMenu(act);
      return node;
    }

    /// <summary>
    /// Renvoie un sous menu à partir d'une information de serveur suivi
    /// </summary>
    /// <param name="srv">le Serveur suivi à afficher</param>
    /// <returns>Le noeud</returns>
    private TreeNode GetSubMenu(SentinelServer srv)
    {
      CommandMenu cmd = this.GetCommandMenuFromServeur(srv);

      TreeNode node = new TreeNode(srv.ToString());
      node.ImageKey = cmd.ActionPrincipale.ToString();
      node.SelectedImageKey = node.ImageKey;
      node.Tag = cmd;

      // Ajout des Esclaves
      foreach (SentinelServer slave in srv.Slaves)
      {
        node.Nodes.Add(this.GetSubMenu(slave));
      }

      return node;
    }

    /// <summary>
    /// Renvoie la command menu crée en fonction du serveur suivi
    /// </summary>
    /// <param name="srv">Le serveur suivi</param>
    /// <returns>La commande menu</returns>
    private CommandMenu GetCommandMenuFromServeur(SentinelServer srv)
    {
      CommandMenuAction act = srv.IsMaster ? CommandMenuAction.ServeurSuiviMaster : CommandMenuAction.ServeurSuiviSlave;
      CommandMenu cmd = new CommandMenu(act);
      cmd.Serveur = srv;
      return cmd;
    }

    /// <summary>
    /// Renvoie l'action du menu contenu dans le TREENODE (s'il y en a un)
    /// </summary>
    /// <param name="treeNode">le noeud à analyser</param>
    /// <returns>L'action trouvée</returns>
    private CommandMenuAction GetCommandMenuActionFromMenu(TreeNode treeNode)
    {
      CommandMenuAction resultat = CommandMenuAction.None;
      if (treeNode != null && treeNode.Tag != null)
      {
        CommandMenu menu = treeNode.Tag as CommandMenu;
        if (menu != null)
        {
          resultat = menu.ActionPrincipale;
        }
      }

      return resultat;
    }

    /// <summary>
    /// recherche à partir du TREENODE le parent qui est le menu COMMANDMENUACTION
    /// </summary>
    /// <param name="commandMenuAction">L'action à retrouver</param>
    /// <param name="treeNode">Le noeud de départ</param>
    /// <returns>Le menu</returns>
    private TreeNode SelectMenu(CommandMenuAction commandMenuAction, TreeNode treeNode)
    {
      CommandMenuAction act = this.GetCommandMenuActionFromMenu(treeNode);
      if (act != CommandMenuAction.None)
      { // y a un menu
        if (act == commandMenuAction)
        { // c'est le bon
          return treeNode;
        }
      }

      if (treeNode.Parent != null)
      { // y a un parent on regarde celui la
        return this.SelectMenu(commandMenuAction, treeNode.Parent);
      }
      else
      { // racine = Pas trouvé
        return null;
      }
    }
    #endregion

    #region Divers
    /// <summary>
    /// Traitement du menu
    /// </summary>
    /// <param name="cmd">La commande</param>
    /// <param name="node">Le noeud à activer</param>
    private void MenuClick(CommandMenu cmd, TreeNode node)
    {
      this.serverResume1.Visible = false;
      this.redisClientUI1.Visible = false;
      this.redisListInfoUI1.Visible = false;
      this.keySearch1.Visible = false;
      this.keyGroup1.Visible = false;
      this.keysExplorer1.Visible = false;
      this.monitorConsole1.Visible = false;
      this.pubSubConsole1.Visible = false;
      this.sentinelServersUI1.Visible = false;
      if (cmd != null)
      { // menuPrincipal
        switch (cmd.ActionPrincipale)
        {
          case CommandMenuAction.Server:
            this.serverResume1.Visible = true;
            break;
          case CommandMenuAction.ConfigurationRubrique:
            this.redisListInfoUI1.PerformFill(CmdInfoRubrique.AllRubrique);
            this.RefillConfigurationRubrique(node);
            this.redisListInfoUI1.Visible = true;

            break;
          case CommandMenuAction.Configuration:
            this.redisListInfoUI1.PerformFill(cmd.ConfiguationRubrique);
            this.redisListInfoUI1.Visible = true;
            break;
          case CommandMenuAction.Clients:
            this.RefillListClient(node);
            this.redisClientUI1.Client = null;
            this.redisClientUI1.Visible = true;
            break;
          case CommandMenuAction.ClientDetail:
            this.redisClientUI1.Client = cmd.Client;
            this.redisClientUI1.Visible = true;
            break;
          case CommandMenuAction.Keys:
            this.keySearch1.Visible = true;
            break;
          case CommandMenuAction.Key:
            if (cmd.Key.Type == ETypeKey.UnKnow)
            {
              cmd.Key.RefreshType(this.Connection);
              node.ImageKey = cmd.Key.Type.ToString();
              node.SelectedImageKey = node.ImageKey;
            }
            
            this.keysExplorer1.CurrentKey = cmd.Key;
            this.keysExplorer1.Visible = true;
            break;
          case CommandMenuAction.KeyFolder:
            this.keyGroup1.Selection = this.tvMenu.SelectedNode;
            this.keyGroup1.Visible = true;
            break;
          case CommandMenuAction.Monitor:
            this.monitorConsole1.Visible = true;
            break;
          case CommandMenuAction.PubSub:
          case CommandMenuAction.PubSubAbonnement:
            this.pubSubConsole1.Mode = cmd.ActionPrincipale;
            this.pubSubConsole1.Visible = true;
            break;
          case CommandMenuAction.SentinelServers:
            this.RefillListServeurSuivis(node);
            this.sentinelServersUI1.Serveur = null;
            this.sentinelServersUI1.Visible = true;
            break;
          case CommandMenuAction.ServeurSuiviMaster:
          case CommandMenuAction.ServeurSuiviSlave:
            this.sentinelServersUI1.Serveur = cmd.Serveur;
            this.sentinelServersUI1.Visible = true;
            break;
        }
      }
    }

    /// <summary>
    /// Remplis les information sur la connexion
    /// </summary>
    /// <param name="cnn">La connexion à utiliser</param>
    private void FillDisplay(RedisConnection cnn)
    {
      if (cnn != null)
      { // on a une connexion
        this.Text = string.Format(Properties.Resources.FReditUtilTx, cnn.Param.Name);
        this.statusStrip1.BackColor = cnn.Param.Color == Color.Empty ? SystemColors.Control : cnn.Param.Color;
        this.lblConnexionName.Text = cnn.Param.Name;
        this.lblConnexionUrl.Text = cnn.Param.URL;
        this.lblConnexionPort.Text = cnn.Param.Port.ToString();
        this.lblConnexionBase.Text = cnn.Param.Base.ToString();
        this.lblConnexionDescription.Text = cnn.Param.Description;
        this.lblConnexionVersion.Text = cnn.Connector.GetServerVersionText();
      }
      else
      { // pas de connexion
        this.Text = Properties.Resources.FReditUtilT0;
        this.statusStrip1.BackColor = SystemColors.Control;
        this.lblConnexionName.Text = string.Empty;
        this.lblConnexionUrl.Text = string.Empty;
        this.lblConnexionPort.Text = string.Empty;
        this.lblConnexionBase.Text = string.Empty;
        this.lblConnexionDescription.Text = string.Empty;
        this.lblConnexionVersion.Text = string.Empty;
      }
    }

    /// <summary>
    /// Crée un Noeud à partir d'un KEYSEARCHRESULT
    /// </summary>
    /// <param name="key">L'objet métier</param>
    /// <returns>Le noeud</returns>
    private TreeNode GetTreeNode(KeySearchResult key)
    {
      TreeNode node;
      CommandMenuAction cmd;
      node = new TreeNode(key.Key);
      if (key.Type == ETypeKey.Tnone)
      { // Warning
        node.ImageKey = "warning";
        cmd = CommandMenuAction.None;
      }
      else if (key.ChildrensCount > 0)
      {
        cmd = CommandMenuAction.KeyFolder;
        if (key.Type == ETypeKey.UnKnow || key.Type == ETypeKey.Folder)
        {
          node.ImageKey = "Groupe";
        }
        else
        {
          node.ImageKey = "G" + key.Type.ToString();
        }
      }
      else
      {
        cmd = CommandMenuAction.Key;
        node.ImageKey = key.Type.ToString();
      }

      node.SelectedImageKey = node.ImageKey;
      CommandMenu mnu = new CommandMenu(cmd);
      mnu.Key = key;
      node.Tag = mnu;
      return node;
    }
    #endregion
  }
}
