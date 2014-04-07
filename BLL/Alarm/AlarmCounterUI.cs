using System;
using System.Globalization;
using System.Windows.Forms;

namespace RedisManagementStudio.BLL.Alarm
{
  /// <summary>
  /// Editeur d'une alarme de type compteur up ou down
  /// </summary>
  public partial class AlarmCounterUI : UserControl, IAlarmEdit
  {
    /// <summary>
    /// Alarme quand la valeur monte ou baisse
    /// </summary>
    private bool sensUp = false;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="AlarmCounterUI" />.
    /// </summary>
    public AlarmCounterUI()
    {
      this.InitializeComponent();

      this.lblSeuil1Caption.Text = Properties.Resources.AlarmCounterUIlblSeuil1;
      this.lblSeuil1Caption2.Text = Properties.Resources.AlarmCounterUIlblIcone1;
      this.lblSeuil2Caption.Text = Properties.Resources.AlarmCounterUIlblSeuil2;
      this.lblSeuil2Caption2.Text = Properties.Resources.AlarmCounterUIlblIcone2;
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
        return this.sensUp ? AlarmType.CounterUp : AlarmType.CounterDown;
      }
    }

    /// <summary>
    /// Clé à utiliser pour crée l'alarme
    /// </summary>
    public string Key { private get; set; }

    /// <summary>
    /// Alarme quand la valeur monte ou baisse
    /// </summary>
    public bool SensUp
    {
      set
      {
        this.sensUp = value;
        this.lblSeuil1Caption.Text = this.sensUp ? "Quand la valeur dépasse :" : "Quand la valeur est en dessous de :";
        this.lblSeuil2Caption.Text = this.sensUp ? "Puis quand la valeur dépasse :" : "Puis quand la valeur est en dessous de :";
      }
    }

    /// <summary>
    /// L'alarme éditée
    /// </summary>
    public AlarmCounter Alarm
    {
      get
      {
        AlarmCounter res;
        if (this.sensUp)
        {
          res = new AlarmUpCounter(this.Key);
        }
        else
        {
          res = new AlarmDownCounter(this.Key);
        }

        // res.Historique = this.chkHistorique.Checked;
        res.Seuil1 = this.GetDouble(this.txtSeuil1.Text);
        res.Seuil2 = this.GetDouble(this.txtSeuil2.Text);
        return res;
      }

      set
      {
        if (value == null)
        {
          this.txtSeuil1.Text = string.Empty;
          this.txtSeuil2.Text = string.Empty;
        }
        else
        {
          this.txtSeuil1.Text = this.GetText(value.Seuil1);
          this.txtSeuil2.Text = this.GetText(value.Seuil2);
        }
      }
    }

    /// <summary>
    /// Renvoie la valeur par défaut si le seuil saisi n'est pas valide
    /// </summary>
    private double DefaultValue
    {
      get
      {
        return this.sensUp ? double.MaxValue : double.MinValue;
      }
    }

    /// <summary>
    /// Filtre les caractère non valide : ici on saisi des doubles (on accepte la virgule ou le point)
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Infos sur la touche appuyée</param>
    private void TxtKeyPress(object sender, KeyPressEventArgs e)
    {
      if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',' && e.KeyChar != '-')
      {
        e.Handled = true;
      }
    }

    /// <summary>
    /// Indique le changement au parent
    /// </summary>
    /// <param name="sender">Seuil qui a changé</param>
    /// <param name="e">Y a Rien ici</param>
    private void TxtTextChanged(object sender, EventArgs e)
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
    /// Renvoie une valeur de seuil depuis la chaine saisie
    /// </summary>
    /// <param name="p">chaine saisie</param>
    /// <returns>Valeur en double</returns>
    private double GetDouble(string p)
    {
      if (!string.IsNullOrWhiteSpace(p))
      {
        double n;
        if (double.TryParse(p.Replace(".", NumberFormatInfo.CurrentInfo.NumberDecimalSeparator).Replace(",", NumberFormatInfo.CurrentInfo.NumberDecimalSeparator), out n))
        {
          return n;
        }
      }

      return this.DefaultValue;
    }

    /// <summary>
    /// Renvoie le texte à mettre dans les champs de saisie en fonction de la valeur
    /// </summary>
    /// <param name="p">valeur à analyser</param>
    /// <returns>Texte à afficher</returns>
    private string GetText(double p)
    {
      if (p.IsBadDouble())
      { // problème avec la valeur
        return string.Empty;
      }
      else
      {
        return p.ToString();
      }
    }
  }
}
