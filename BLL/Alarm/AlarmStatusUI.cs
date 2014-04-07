using System;
using System.Windows.Forms;
using RedisManagementStudio.BLL.Redis;
using RedisManagementStudio.BLL.Redis.Config;

namespace RedisManagementStudio.BLL.Alarm
{
  /// <summary>
  /// Affiche une alarme et permet de l'éditer aussi
  /// </summary>
  public partial class AlarmStatusUI : UserControl
  {
    /// <summary>
    /// Le type de niveau d'alarme à afficher
    /// </summary>
    private AlarmStatus seuil = AlarmStatus.AlarmNone;

    /// <summary>
    /// La type d'alarme en cours d'affichage / édition
    /// </summary>
    private AlarmType type = AlarmType.None;

    /// <summary>
    /// L'alarme en cours d'affichage / édition
    /// </summary>
    private IAlarm alarm = null;
    
    /// <summary>
    /// L'éditeur en cours d'affichage
    /// </summary>
    private IAlarmEdit editor = null;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="AlarmStatusUI" />.
    /// </summary>
    public AlarmStatusUI()
    {
      this.InitializeComponent();

      this.btEdit.Text = Properties.Resources.AlarmStatusUIBtEditT;
      this.toolTip1.SetToolTip(this.btEdit, Properties.Resources.AlarmStatusUIBtEditD);
      this.toolTip1.SetToolTip(this.btDel, Properties.Resources.AlarmStatusUIBtDelD);
      this.toolTip1.SetToolTip(this.btSave, Properties.Resources.AlarmStatusUIBtSaveD);
      this.toolTip1.SetToolTip(this.pictureBox1, Properties.Resources.AlarmStatusUIImageD);
      this.toolTip1.SetToolTip(this.btCancel, Properties.Resources.AlarmStatusUIBtCancelD);
      this.Collapse();
    }

    /// <summary>
    /// Notifier les changements dans l'alarme
    /// </summary>
    public event EventHandler OnSaved;

    /// <summary>
    /// L'info auquel correspond l'alarme à afficher / editer
    /// </summary>
    public InformationBase Info
    {
      set
      {
        if (value != null && value.AlarmeType != AlarmType.None)
        {
          this.type = value.AlarmeType;
          this.alarm = value.Alarm;
          this.seuil = value.Alarm == null ? AlarmStatus.AlarmNone : value.Alarm.Get(value.OriginalValue);
          
          // Transmission des clés
          this.alarmBoolUI1.Key = value.Code;
          this.alarmCounterUI1.Key = value.Code;
        }
        else
        { // pas de bras pas de chocolat
          this.type = AlarmType.None;
          this.seuil = AlarmStatus.AlarmNone;
          this.alarm = null;

          this.alarmBoolUI1.Key = string.Empty;
          this.alarmCounterUI1.Key = string.Empty;
        }

        this.DisplaySeuil();
        this.Collapse();
      }
    }
            
    /// <summary>
    /// Demande de modification des paramètres de l'alarme
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">info inutile</param>
    private void BtEditClick(object sender, EventArgs e)
    {
      this.Expand();
      switch (this.type)
      {
        case AlarmType.CounterUp:
          this.editor = this.alarmCounterUI1;

          this.alarmBoolUI1.Visible = false;
          this.alarmCounterUI1.Visible = true;
          this.alarmCounterUI1.SensUp = true;
          this.alarmCounterUI1.Alarm = (AlarmUpCounter)this.alarm;
          break;
        case AlarmType.CounterDown:
          this.editor = this.alarmCounterUI1;
          this.alarmBoolUI1.Visible = false;
          this.alarmCounterUI1.Visible = true;
          this.alarmCounterUI1.SensUp = false;
          this.alarmCounterUI1.Alarm = (AlarmDownCounter)this.alarm;
          break;
        case AlarmType.BoolControl:
          this.editor = this.alarmBoolUI1;
          this.alarmCounterUI1.Visible = false;
          this.alarmBoolUI1.Visible = true;
          this.alarmBoolUI1.Alarm = (AlarmBool)this.alarm;
          break;
        default:
          this.editor = null;
          this.Collapse();
          break;
      }
    }

    /// <summary>
    /// Annuler une édition en cours
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtCancelClick(object sender, EventArgs e)
    {
      this.editor = null;
      this.Collapse();
    }

    /// <summary>
    /// L'éditeur a notifié un changement
    /// </summary>
    /// <param name="sender">Editeur qui est affiché</param>
    /// <param name="e">paramètre inutile</param>
    private void AlarmOnChange(object sender, EventArgs e)
    {
      // on s'en fout en fait !!
    }

    /// <summary>
    /// Enregistre les modifications de l'alarme
    /// </summary>
    /// <param name="sender">Bouton save</param>
    /// <param name="e">paramètre inutile</param>
    private void BtSaveClick(object sender, EventArgs e)
    {
      if (this.editor != null)
      { // on est en cours d'édition
        IAlarm newAlarm = null;
        switch (this.type)
        {
          case AlarmType.CounterUp:
          case AlarmType.CounterDown:
            newAlarm = this.alarmCounterUI1.Alarm;
            break;
          case AlarmType.BoolControl:
            newAlarm = this.alarmBoolUI1.Alarm;
            break;
        }

        if (this.alarm != null && newAlarm == null)
        { // Suppression
          AlarmSaver.Instance.Del(newAlarm);
          this.alarm = null;
        }
        else
        { // Mise à jour
          AlarmSaver.Instance.Set(newAlarm);
          this.alarm = newAlarm;
        }

        this.NotifySaved();
      }

      this.Collapse();
    }

    /// <summary>
    /// Suppression de l'alarme en cours
    /// </summary>
    /// <param name="sender">Bouton Del</param>
    /// <param name="e">paramètre inutile</param>
    private void BtDelClick(object sender, EventArgs e)
    {
      if (this.alarm != null)
      { // Suppression
        AlarmSaver.Instance.Del(this.alarm);
        this.alarm = null;
        this.Collapse();
        this.NotifySaved();
      }
    }

    /// <summary>
    /// Etend l'affichage pour edition
    /// </summary>
    private void Expand()
    {
      this.Height = 150;
      this.btSave.Visible = true;
      this.btCancel.Visible = true;
      this.btDel.Visible = this.alarm != null; 
      this.btEdit.Visible = false;
    }

    /// <summary>
    /// reflète l'affichage du seuil
    /// </summary>
    private void DisplaySeuil()
    {
      this.imgStatut.Image = this.imageLib1.Alarms.Images[this.seuil.ToString()];

      if (this.seuil != AlarmStatus.AlarmNone)
      {
        this.lblDescription.Text = this.seuil.GetDescription();
      }
      else if (this.alarm != null)
      {
        this.lblDescription.Text = this.type.GetDescription();
      }
      else
      {
        this.lblDescription.Text = AlarmStatus.AlarmNone.GetDescription();
      }
    }
    
    /// <summary>
    /// Compression de l'affichage
    /// </summary>
    private void Collapse()
    {
      this.Height = 30;
      this.btDel.Visible = false;
      this.btSave.Visible = false;
      this.btCancel.Visible = false;
      this.btEdit.Visible = true;
      this.alarmBoolUI1.Visible = false;
      this.alarmCounterUI1.Visible = false;
      this.editor = null;
    }

    /// <summary>
    /// Prévient le parent d'un enregistrement
    /// </summary>
    private void NotifySaved()
    {
      if (this.OnSaved != null)
      { // notifier le parent
        this.OnSaved(this, new EventArgs());
      }
    }
  }
}
