using System;
using System.Linq;
using System.Windows.Forms;
using RedisManagementStudio.BLL.Alarm;
using RedisManagementStudio.BLL.Redis;

namespace RedisManagementStudio.BLL.Redis
{
  /// <summary>
  /// Gestion des informations et paramétrage de leurs classements
  /// </summary>
  public partial class FManageInfos : Form
  {
    /// <summary>
    /// Elément de droite sélectionné
    /// </summary>
    private InformationDansRubrique currentRight = null;

    /// <summary>
    /// Elément de gauche sélectionné
    /// </summary>
    private InformationDansRubrique currentLeft = null;

    /// <summary>
    /// Indique si on est en cours de mise à jour
    /// </summary>
    private bool updating = false;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="FManageInfos" />.
    /// </summary>
    public FManageInfos()
    {
      this.InitializeComponent();
      this.Text = Properties.Resources.FManageInfosT;
      this.colCommand.Text = Properties.Resources.FManageInfosColCommand;
      this.colCode.Text = Properties.Resources.FManageInfosColCode;
      this.colTypeAlarm.Text = Properties.Resources.FManageInfosColAlarm;
      this.colTitre.Text = Properties.Resources.FManageInfosColTitre;
      this.colCommand2.Text = Properties.Resources.FManageInfosColCommand;
      this.colCode2.Text = Properties.Resources.FManageInfosColCode;
      this.colTypeAlarm2.Text = Properties.Resources.FManageInfosColAlarm;
      this.colTitre2.Text = Properties.Resources.FManageInfosColTitre;
      this.label1.Text = Properties.Resources.FManageInfosLbl1T;
      this.label2.Text = Properties.Resources.FManageInfosLbl2T;
      this.btClasse.Text = Properties.Resources.FManageInfosBtClasseUnKnow;
      this.btNoClasse.Text = Properties.Resources.FManageInfosBtNotClassed;
      this.btTop.Text = Properties.Resources.FManageInfosBtTop;
      this.btUp.Text = Properties.Resources.FManageInfosBtUp;
      this.btBottom.Text = Properties.Resources.FManageInfosBtBottom;
      this.btDown.Text = Properties.Resources.FManageInfosBtDown;
      this.lblTitreLeft.Text = Properties.Resources.FManageInfosLblTitreLeft;
      this.InitList();
    }

    /// <summary>
    /// La connexion à la base
    /// </summary>
    public RedisConnection Connection { get; set; }

    /// <summary>
    /// La rubrique à présélectionner
    /// </summary>
    public CmdInfoRubrique Rubrique
    {
      set
      {
        if (value != CmdInfoRubrique.AllRubrique && value != CmdInfoRubrique.UnKnow)
        {
          this.cbRubrique.SelectedItem = value;
        }
      }
    }

    #region Events
    /// <summary>
    /// Chargement de la feuille
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void FManageInfos_Load(object sender, EventArgs e)
    {
      this.Location = Properties.Settings.Default.FManageInfoPosition;
      this.Size = Properties.Settings.Default.FManageInfoDimensions;
      this.splitContainer1.SplitterDistance = Properties.Settings.Default.FManageInfoSpliter;
      this.colCommand.Width = Properties.Settings.Default.ColManageCommand;
      this.colCode.Width = Properties.Settings.Default.ColManageCode;
      this.colTypeAlarm.Width = Properties.Settings.Default.ColManageTypeAlarm;
      this.colTitre.Width = Properties.Settings.Default.ColManageTitre;

      this.colCommand2.Width = Properties.Settings.Default.ColManageCommand;
      this.colCode2.Width = Properties.Settings.Default.ColManageCode;
      this.colTypeAlarm2.Width = Properties.Settings.Default.ColManageTypeAlarm;
      this.colTitre2.Width = Properties.Settings.Default.ColManageTitre;

      this.currentRight = null;
      this.FillAListe(this.lstRubRight, this.lblCountRight, CmdInfoRubrique.UnKnow, this.currentRight);
      this.GereBouton();
    }

    /// <summary>
    /// Fermeture de la feuille
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void FManageInfos_FormClosed(object sender, FormClosedEventArgs e)
    {
      RubriqueManager.Save();
      Properties.Settings.Default.FManageInfoPosition = this.Location;
      Properties.Settings.Default.FManageInfoDimensions = this.Size;
      Properties.Settings.Default.FManageInfoSpliter = this.splitContainer1.SplitterDistance;
      Properties.Settings.Default.ColManageCommand = this.colCommand.Width;
      Properties.Settings.Default.ColManageCode = this.colCode.Width;
      Properties.Settings.Default.ColManageTypeAlarm = this.colTypeAlarm.Width;
      Properties.Settings.Default.ColManageTitre = this.colTitre.Width;
      Properties.Settings.Default.Save();
    }

    /// <summary>
    /// Changement du groupe de rubrique de droite
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void CbRubriqueSelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.updating)
      {
        return;
      }

      this.currentRight = null;
      this.FillAListe(this.lstRubLeft, this.lblCountLeft, (CmdInfoRubrique)this.cbRubrique.SelectedItem, this.currentLeft);
      this.GereBouton();
    }

    /// <summary>
    /// Sélection d'un code rubrique sur la liste de droite
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void LstRubLeftSelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.updating)
      {
        return;
      }

      this.updating = true;
      this.currentLeft = this.lstRubLeft.SelectedItems.Count > 0 ? (InformationDansRubrique)this.lstRubLeft.SelectedItems[0].Tag : null;
      this.GereBouton();
      this.updating = false;
    }

    /// <summary>
    /// Sélection d'un code rubrique sur la liste de gauche
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void LstRubRightSelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.updating)
      {
        return;
      }

      this.updating = true;
      this.currentRight = this.lstRubRight.SelectedItems.Count > 0 ? (InformationDansRubrique)this.lstRubRight.SelectedItems[0].Tag : null;
      this.GereBouton();
      this.updating = false;
    }

    #region Boutons d'action
    /// <summary>
    /// Changement du type d'alarme possible
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void CbAlarmeSelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.currentLeft == null)
      {
        return;
      }

      this.updating = true;
      this.currentLeft.AlarmeType = (AlarmType)this.cbAlarme.SelectedItem;
      this.GereBouton();
      this.updating = false;
    }

    /// <summary>
    /// Bouton mettre en premier
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void BtTopClick(object sender, EventArgs e)
    {
      if (this.currentLeft == null)
      {
        return;
      }

      int pos = this.currentLeft.Position;
      if (pos == 0)
      { // déjà en premier !
        return;
      }

      this.updating = true;
      InformationDansRubrique rub;
      foreach (ListViewItem itx in this.lstRubLeft.Items)
      {
        rub = itx.Tag as InformationDansRubrique;
        if (rub.Position > pos)
        {
          continue;
        }
        else if (rub == this.currentLeft)
        {
          rub.Position = 0;
          break;
        }
        else
        {
          rub.Position += 1;
        }
      }

      this.FillAListe(this.lstRubLeft, this.lblCountLeft, (CmdInfoRubrique)this.cbRubrique.SelectedItem, this.currentLeft);
      this.GereBouton();
      this.updating = false;
    }

    /// <summary>
    /// Bouton Monte d'un cran
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void BtUpClick(object sender, EventArgs e)
    {
      if (this.currentLeft == null)
      {
        return;
      }

      int pos = this.currentLeft.Position;
      if (pos == 0)
      { // Déjà au top !
        return;
      }

      this.updating = true;
      InformationDansRubrique rub;
      foreach (ListViewItem itx in this.lstRubLeft.Items)
      {
        rub = itx.Tag as InformationDansRubrique;
        if (rub.Position != pos && rub.Position != pos - 1)
        {
          continue;
        }
        else if (rub == this.currentLeft)
        {
          rub.Position -= 1;
          break;
        }
        else
        {
          rub.Position += 1;
        }
      }

      this.FillAListe(this.lstRubLeft, this.lblCountLeft, (CmdInfoRubrique)this.cbRubrique.SelectedItem, this.currentLeft);
      this.GereBouton();
      this.updating = false;
    }

    /// <summary>
    /// Déplacer l'info dans les non classés
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void BNoClasseClick(object sender, EventArgs e)
    {
      if (this.currentLeft == null)
      {
        return;
      }

      if (this.updating)
      {
        return;
      }

      int pos = this.currentLeft.Position;
      this.currentLeft.Rubrique = CmdInfoRubrique.UnKnow;
      this.currentLeft.Position = this.lstRubRight.Items.Count;
      InformationDansRubrique rub;
      foreach (ListViewItem itx in this.lstRubLeft.Items)
      {
        rub = itx.Tag as InformationDansRubrique;
        if (rub.Position <= pos)
        {
          continue;
        }
        else if (rub == this.currentLeft)
        {
          continue;
        }
        else
        {
          rub.Position -= 1;
        }
      }

      this.FillAListe(this.lstRubRight, this.lblCountRight, CmdInfoRubrique.UnKnow, null);
      this.currentLeft = null;
      this.FillAListe(this.lstRubLeft, this.lblCountLeft, (CmdInfoRubrique)this.cbRubrique.SelectedItem, this.currentLeft);
      this.GereBouton();
    }

    /// <summary>
    /// Mettre dans la rubrique courant l'information non classée
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void BtClasseClick(object sender, EventArgs e)
    {
      if (this.cbRubrique.SelectedItem == null)
      { // il faut une rubrique d'acceuil
        return;
      }

      if (this.currentRight == null)
      {
        return;
      }

      if (this.updating)
      {
        return;
      }

      int pos = this.currentRight.Position;
      this.currentRight.Rubrique = (CmdInfoRubrique)this.cbRubrique.SelectedItem;
      this.currentRight.Position = this.lstRubLeft.Items.Count;
      InformationDansRubrique rub;
      foreach (ListViewItem itx in this.lstRubRight.Items)
      {
        rub = itx.Tag as InformationDansRubrique;
        if (rub.Position <= pos)
        {
          continue;
        }
        else if (rub == this.currentRight)
        {
          continue;
        }
        else
        {
          rub.Position -= 1;
        }
      }

      this.FillAListe(this.lstRubLeft, this.lblCountLeft, (CmdInfoRubrique)this.cbRubrique.SelectedItem, null);
      this.currentRight = null;
      this.FillAListe(this.lstRubRight, this.lblCountRight, CmdInfoRubrique.UnKnow, this.currentRight);
      this.GereBouton();
    }

    /// <summary>
    /// Descend d'un cran 
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void BtDownClick(object sender, EventArgs e)
    {
      if (this.currentLeft == null)
      {
        return;
      }

      int nb = this.lstRubLeft.Items.Count - 1;
      int pos = this.currentLeft.Position;
      if (pos >= nb)
      {
        return;
      }

      this.updating = true;
      InformationDansRubrique rub;
      foreach (ListViewItem itx in this.lstRubLeft.Items)
      {
        rub = itx.Tag as InformationDansRubrique;
        if (rub.Position != pos && rub.Position != pos + 1)
        {
          continue;
        }
        else if (rub == this.currentLeft)
        {
          rub.Position += 1;
        }
        else
        {
          rub.Position -= 1;
        }
      }

      this.FillAListe(this.lstRubLeft, this.lblCountLeft, (CmdInfoRubrique)this.cbRubrique.SelectedItem, this.currentLeft);
      this.GereBouton();
      this.updating = false;
    }

    /// <summary>
    /// Descend tout en bas
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void BtBottomClick(object sender, EventArgs e)
    {
      if (this.currentLeft == null)
      {
        return;
      }

      int nb = this.lstRubLeft.Items.Count - 1;
      int pos = this.currentLeft.Position;
      if (pos >= nb)
      {
        return;
      }

      this.updating = true;
      InformationDansRubrique rub;
      foreach (ListViewItem itx in this.lstRubLeft.Items)
      {
        rub = itx.Tag as InformationDansRubrique;
        if (rub.Position < pos)
        {
          continue;
        }
        else if (rub == this.currentRight)
        {
          rub.Position = nb;
        }
        else
        {
          rub.Position -= 1;
        }
      }

      this.FillAListe(this.lstRubLeft, this.lblCountLeft, (CmdInfoRubrique)this.cbRubrique.SelectedItem, this.currentLeft);
      this.GereBouton();
      this.updating = false;
    }
    #endregion
    #endregion

    /// <summary>
    /// Gestion de l'activation des boutons
    /// </summary>
    private void GereBouton()
    {
      if (this.currentLeft == null)
      {
        this.btTop.Enabled = false;
        this.btUp.Enabled = false;
        this.cbAlarme.Enabled = false;
        this.cbAlarme.SelectedItem = null;
        this.btNoClasse.Enabled = false;
        this.btDown.Enabled = false;
        this.btBottom.Enabled = false;
      }
      else
      {
        this.btTop.Enabled = this.currentLeft.Position > 0;
        this.btUp.Enabled = this.currentLeft.Position > 0;
        this.cbAlarme.Enabled = true;
        this.cbAlarme.SelectedItem = this.currentLeft.AlarmeType;
        this.btNoClasse.Enabled = true;
        int nb = this.lstRubLeft.Items.Count - 1;
        this.btDown.Enabled = this.currentLeft.Position < nb;
        this.btBottom.Enabled = this.currentLeft.Position < nb;
      }

      if (this.currentRight == null)
      {
        this.btClasse.Enabled = false;
      }
      else
      {
        this.btClasse.Enabled = this.cbRubrique.SelectedItem != null;
      }

      if (this.cbRubrique.SelectedItem != null)
      {
        this.btClasse.Text = this.cbRubrique.SelectedItem.ToString();
      }
    }

    /// <summary>
    /// Remplir une liste
    /// </summary>
    /// <param name="lst">la liste</param>
    /// <param name="lblCount">Le label pour afficher le nombre d'éléments</param>
    /// <param name="rubrique">le groupe de commande à remplir</param>
    /// <param name="current">l'élément courant à sélectionner</param>
    private void FillAListe(ListView lst, Label lblCount, CmdInfoRubrique rubrique, InformationDansRubrique current)
    {
      lst.BeginUpdate();
      lst.Items.Clear();
      ListViewItem itx;
      bool oneSel = false;
      foreach (InformationDansRubrique rub in RubriqueManager.Liste(this.Connection, rubrique))
      {
        itx = new ListViewItem(rub.Command);
        itx.SubItems.Add(rub.Code);
        itx.SubItems.Add(rub.AlarmeType.ToString());
        itx.SubItems.Add(rub.Titre);
        itx.Tag = rub;
        itx.ToolTipText = rub.Description;
        lst.Items.Add(itx);

        if (rub.Equals(current))
        {
          oneSel = true;
          itx.Selected = true;
        }
      }

      lst.EndUpdate();
      if (lst.Items.Count == 0)
      {
        lblCount.Text = Properties.Resources.FManageInfosFillCount0;
      }
      else if (lst.Items.Count == 1)
      {
        lblCount.Text = Properties.Resources.FManageInfosFillCount1;
      }
      else
      {
        lblCount.Text = string.Format(Properties.Resources.FManageInfosFillCountN, lst.Items.Count);
      }

      if (lst.Items.Count > 0 && !oneSel)
      {
        current = lst.Items[0].Tag as InformationDansRubrique;
        lst.Items[0].Selected = true;
      }
    }
    
    /// <summary>
    /// Remplit les liste de départ
    /// </summary>
    private void InitList()
    {
      this.cbRubrique.Items.Clear();
      foreach (CmdInfoRubrique rub in Enum.GetValues(typeof(CmdInfoRubrique)))
      {
        if (rub != CmdInfoRubrique.AllRubrique && rub != CmdInfoRubrique.UnKnow)
        {
          this.cbRubrique.Items.Add(rub);
        }
      }

      this.cbRubrique.SelectedItem = CmdInfoRubrique.Server;
      this.cbAlarme.Items.Clear();
      foreach (AlarmType alrm in Enum.GetValues(typeof(AlarmType)))
      {
        this.cbAlarme.Items.Add(alrm);
      }
    }
  }
}