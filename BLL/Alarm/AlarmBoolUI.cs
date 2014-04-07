using System;
using System.Windows.Forms;

namespace RedisManagementStudio.BLL.Alarm
{
  /// <summary>
  /// Editeur d'une alarme de type booléenne
  /// </summary>
  public partial class AlarmBoolUI : UserControl, IAlarmEdit
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="AlarmBoolUI" />.
    /// </summary>
    public AlarmBoolUI()
    {
      this.InitializeComponent();

      this.lblTrueOption.Text = Properties.Resources.AlarmBoolUIlblTrueOption;
      this.lblFalseOption.Text = Properties.Resources.AlarmBoolUIlblFalseOption;
    }

    /// <summary>
    /// Notifier les changements
    /// </summary>
    public event EventHandler OnChange;

    /// <summary>
    /// Renvoie le type d'alarme géré
    /// </summary>
    public AlarmType Type
    {
      get 
      { 
        return AlarmType.BoolControl; 
      }
    }

    /// <summary>
    /// Clé à utiliser pour crée l'alarme
    /// </summary>
    public string Key { private get; set; }

    /// <summary>
    /// L'alarme éditée
    /// </summary>
    public AlarmBool Alarm
    {
      get
      {
        AlarmBool res = new AlarmBool(this.Key);
        res.False = this.GetSeuil(this.cbFalseOption.SelectedItem);
        res.True = this.GetSeuil(this.cbTrueOption.SelectedItem);
        return res;
      }

      set
      {
        if (value == null)
        {
          this.cbFalseOption.SelectedItem = null;
          this.cbTrueOption.SelectedItem = null;
        }
        else
        {
          this.cbFalseOption.SelectedItem = value.False.ToString();
          this.cbTrueOption.SelectedItem = value.True.ToString();
        }
      }
    }

    /// <summary>
    /// Tracé des images dans les listes
    /// </summary>
    /// <param name="sender">Cb à dessiner</param>
    /// <param name="e">Informations pour le dessin</param>
    private void ComboBoxDrawItem(object sender, DrawItemEventArgs e)
    {
      e.DrawBackground();
      e.DrawFocusRectangle();

      if (e.Index >= 0)
      {
        string key = (sender as ComboBox).Items[e.Index].ToString();
        e.Graphics.DrawImage(this.imageLib1.Alarms.Images[key], e.Bounds.Left, e.Bounds.Top);
      }
    }

    /// <summary>
    /// Indique le changement au parent
    /// </summary>
    /// <param name="sender">Combo a changé</param>
    /// <param name="e">Y a Rien ici</param>
    private void ComboBoxSelectedIndexChanged(object sender, EventArgs e)
    {
      this.FireOnChange();
    }

    /// <summary>
    /// Propage l'évènement
    /// </summary>
    private void FireOnChange()
    {
      if (this.OnChange != null)
      {
        this.OnChange(this, new EventArgs());
      }
    }

    /// <summary>
    /// Renvoie la valeur sélectionnée
    /// </summary>
    /// <param name="item">Elément d'une liste sélectionné</param>
    /// <returns>Le seuil choisi</returns>
    private AlarmStatus GetSeuil(object item)
    {
      if (item == null)
      {
        return AlarmStatus.AlarmNone;
      }
      else
      {
        return (AlarmStatus)Enum.Parse(typeof(AlarmStatus), item.ToString());
      }
    }
  }
}
