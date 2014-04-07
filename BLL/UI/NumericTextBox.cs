using System.ComponentModel;
using System.Windows.Forms;

namespace RedisManagementStudio.BLL.UI
{
  /// <summary>
  /// Gère la saisie d'un entier ou d'un double
  /// </summary>
  public partial class NumericTextBox : TextBox
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="NumericTextBox" />.
    /// </summary>
    public NumericTextBox()
    {
      this.InitializeComponent();

      this.DefaultDoubleValue = double.NaN;
      this.DefaultIntValue = 0;
      this.IntegerOnly = true;
    }

    /// <summary>
    /// Indique si on ne gère que des entiers (TRUE) ou des doubles (FALSE)
    /// </summary>
    [DefaultValue(true)]
    [Description("Indique si on ne gère que des entiers (true) ou des doubles (false)")]
    public bool IntegerOnly { get; set; }

    /// <summary>
    /// Valeur par défaut en édition d'entier
    /// Lorsque le contrôle à la valeur par défaut le texte n'est pas affiché
    /// </summary>
    [DefaultValue(0)]
    [Description(@"Valeur par défaut en édion d'entier
Lorsque le controle à la valeur par défaut le texte n'est pas affiché")]
    public int DefaultIntValue { get; set; }

    /// <summary>
    /// Valeur entière
    /// </summary>
    [DefaultValue(0)]
    [Description("Valeur Entière")]
    public int IntValue
    {
      get
      {
        int n;
        if (string.IsNullOrWhiteSpace(this.Text))
        {
          return this.DefaultIntValue;
        }
        else if (int.TryParse(this.Text, out n))
        {
          return n;
        }
        else
        {
          return this.DefaultIntValue;
        }
      }

      set
      {
        if (value == this.DefaultIntValue)
        {
          this.Text = string.Empty;
        }
        else
        {
          this.Text = value.ToString();
        }
      }
    }

    /// <summary>
    /// Valeur par défaut pour un double
    /// Lorsque le contrôle à la valeur par défaut le texte n'est pas affiché
    /// </summary>
    [DefaultValue(double.NaN)]
    [Description(@"Valeur par défaut pour un double
Lorsque le controle à la valeur par défaut le texte n'est pas affiché")]
    public double DefaultDoubleValue { get; set; }

    /// <summary>
    /// Valeur double
    /// </summary>
    [DefaultValue(0)]
    [Description("Valeur double")]
    public double DoubleValue
    {
      get
      {
        double n;
        if (string.IsNullOrWhiteSpace(this.Text))
        {
          return this.DefaultDoubleValue;
        }
        else
        {
          string t = this.Text.Replace(".", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator).Replace(",", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
          if (double.TryParse(t, out n))
          {
            return n;
          }
          else
          {
            return this.DefaultDoubleValue;
          }
        }
      }

      set
      {
        if (value == this.DefaultDoubleValue)
        {
          this.Text = string.Empty;
        }
        else
        {
          this.Text = value.ToString();
        }
      }
    }

    /// <summary>
    /// Une touche est enfoncé absorber les caractère invalides
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">informations sur la touche appuyée</param>
    private void NumericTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (this.IntegerOnly)
      {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        {
          e.Handled = true;
        }
      }
      else
      {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
        {
          e.Handled = true;
        }
      }
    }
  }
}
