using System;
using System.Drawing;
using System.Windows.Forms;
using RedisManagementStudio.BLL.Alarm;

namespace RedisManagementStudio.BLL.Redis
{
  /// <summary>
  /// Affiche le détail d'un résultat de la commande INFO
  /// </summary>
  public partial class RedisInfoUI : UserControl
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="RedisInfoUI" />.
    /// </summary>
    public RedisInfoUI()
    {
      this.InitializeComponent();
      this.Height = 290;
      this.lblInfoDescriptionCaption.Text = Properties.Resources.RedisInfoUILblDescriptionCaptionT;
      this.lblInfoValueCaption.Text = Properties.Resources.RedisInfoUILblValueCaptionT;
      this.lblInfoOriginalValueCaption.Text = Properties.Resources.RedisInfoUILblOriginalValueCaptionT;
      this.lblInfoKeyCaption.Text = Properties.Resources.RedisInfoUILblCleCaptionT;
      this.Info = null;
    }

    /// <summary>
    /// Notifie un changement au parent
    /// </summary>
    public event EventHandler OnSaved;

    /// <summary>
    /// La connexion pour les mises à jours
    /// </summary>
    public RedisConnection Connexion
    {
      get
      {
        return this.configEditUI1.Connection;
      }

      set
      {
        this.configEditUI1.Connection = value;
      }
    }

    /// <summary>
    /// L'info à afficher
    /// </summary>
    public InformationBase Info
    {
      set
      {
        if (value != null)
        {
          this.configEditUI1.Config = value;
          this.configEditUI1.CanEdit = value.IsEditable;
          this.lblInfoKey.Text = value.Code;
          this.lblInfoOriginalValue.Text = value.OriginalValue;
          this.lblInfoDescription.Text = value.Description;
          this.alarmStatus1.Visible = value.AlarmeType != AlarmType.None;
          this.alarmStatus1.Info = value;
        }
        else
        {
          this.configEditUI1.Config = null;
          this.configEditUI1.CanEdit = false;
          this.lblInfoKey.Text = string.Empty;
          this.lblInfoOriginalValue.Text = string.Empty;
          this.lblInfoDescription.Text = string.Empty;
          this.alarmStatus1.Visible = false;
        }
      }
    }

    /// <summary>
    /// Enregistrement d'une configuration
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">info inutile</param>
    private void ConfigEditUI1OnSaved(object sender, EventArgs e)
    {
      this.FireSaved();
    }

    /// <summary>
    /// Alarme enregistrée
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">info inutile</param>
    private void AlarmStatus1OnSaved(object sender, EventArgs e)
    {
      this.FireSaved();
    }

    /// <summary>
    /// Notifie le parent
    /// </summary>
    private void FireSaved()
    {
      if (this.OnSaved != null)
      {
        this.OnSaved(this, new EventArgs());
      }
    }
  }
}