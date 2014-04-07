using System;
using System.Drawing;
using System.Windows.Forms;
using ClientRedisLib;
using RedisManagementStudio.BLL.Connection;

namespace RedisManagementStudio.BLL.UI
{
  /// <summary>
  /// Gère la saisie d'une connexion à une base REDIS
  /// </summary>
  public partial class FConnexion : Form
  {
    /// <summary>
    /// La connexion à renseigner
    /// </summary>
    private RedisConnectionParam myCnn = null;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="FConnexion" />.
    /// </summary>
    public FConnexion()
    {
      this.InitializeComponent();
      this.Text = Properties.Resources.FConnexionT;
      this.btCancel.Text = Properties.Resources.BtCancelT;
      this.btOk.Text = Properties.Resources.BtSaveT;
      this.label1.Text = Properties.Resources.FConnexionLbl1T;
      this.label2.Text = Properties.Resources.FConnexionLbl2T;
      this.label3.Text = Properties.Resources.FConnexionLbl3T;
      this.label4.Text = Properties.Resources.FConnexionLbl4T;
      this.label5.Text = Properties.Resources.FConnexionLbl5T;
      this.label6.Text = Properties.Resources.FConnexionLbl6T;
      this.label7.Text = Properties.Resources.FConnexionLbl7T;
      this.label8.Text = Properties.Resources.FConnexionLbl8T;
    }

    /// <summary>
    /// La connexion à renseigner
    /// </summary>
    public Connection.RedisConnectionParam Connexion
    {
      get
      {
        if (this.myCnn == null)
        { // pas de connexion on est en création
          this.myCnn = new RedisConnectionParam();
        }

        this.myCnn.Base = this.cbBaseId.SelectedIndex;
        this.myCnn.Color = this.pnlColor.BackColor != this.BackColor ? this.pnlColor.BackColor : Color.Empty;
        this.myCnn.Description = this.txtDescription.Text;
        this.myCnn.Name = this.txtName.Text;
        this.myCnn.Password = this.txtPassword.Text;
        this.myCnn.Port = this.GetPortValue(RedisConnector.DEFAULTPORT);
        this.myCnn.URL = string.IsNullOrWhiteSpace(this.txtUrl.Text) ? RedisConnector.DEFAULTHOST : this.txtUrl.Text;
        return this.myCnn;
      }

      set
      {
        this.myCnn = value;
        this.cbBaseId.SelectedIndex = this.myCnn.Base;
        this.pnlColor.BackColor = this.myCnn.Color.IsEmpty ? this.BackColor : this.myCnn.Color;
        this.txtDescription.Text = this.myCnn.Description;
        this.txtName.Text = this.myCnn.Name;
        this.txtPassword.Text = this.myCnn.Password;
        this.txtPort.Text = this.myCnn.Port.ToString();
        this.txtUrl.Text = this.myCnn.URL;
        this.GereBouton();
      }
    }

    #region Events
    /// <summary>
    /// Chargement de la page
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void FConnexionLoad(object sender, EventArgs e)
    {
      this.Location = Properties.Settings.Default.FConnexionPosition;
      this.Size = Properties.Settings.Default.FConnexionDimension;
      this.GereBouton();
    }

    /// <summary>
    /// On quitte la page
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void FConnexionFormClosed(object sender, FormClosedEventArgs e)
    {
      Properties.Settings.Default.FConnexionPosition = this.Location;
      Properties.Settings.Default.FConnexionDimension = this.Size;
      Properties.Settings.Default.Save();
    }

    /// <summary>
    /// Changement d'une valeur du formulaire
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void TxtTextChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }

    /// <summary>
    /// Choix d'un couleur
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtChooseColorClick(object sender, EventArgs e)
    {
      this.colorDialog1.Color = this.pnlColor.BackColor;
      if (this.colorDialog1.ShowDialog(this) == DialogResult.OK)
      {
        this.pnlColor.BackColor = this.colorDialog1.Color;
        this.GereBouton();
      }
    }

    /// <summary>
    /// RAZ d'une couleur
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtClearColorClick(object sender, EventArgs e)
    {
      this.pnlColor.BackColor = this.BackColor;
      this.GereBouton();
    }

    /// <summary>
    /// Validation du formulaire
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtOkClick(object sender, EventArgs e)
    {
      if (string.IsNullOrWhiteSpace(this.txtName.Text))
      { // il manque des infos essentielles
        return;
      }

      int port = this.GetPortValue(-1);
      if (port == -1)
      { // obligatoire aussi !
        return;
      }

      this.DialogResult = DialogResult.OK;
    }

    /// <summary>
    /// Ici on filtre les touches invalides
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void TxtPortKeyPress(object sender, KeyPressEventArgs e)
    {
      if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
      { // on ne garde que les chiffres et les touches spéciales
        e.Handled = true;
      }
    }
    #endregion

    /// <summary>
    /// Gère le bouton Ok
    /// </summary>
    private void GereBouton()
    {
      this.btOk.Enabled = !string.IsNullOrWhiteSpace(this.txtName.Text) && this.GetPortValue(-1) != -1;
    }

    /// <summary>
    /// Renvoie le port choisi dans l'interface
    /// </summary>
    /// <param name="defaultValue">Port par défaut</param>
    /// <returns>Le port choisi</returns>
    private int GetPortValue(int defaultValue)
    {
      if (string.IsNullOrWhiteSpace(this.txtPort.Text))
      { // pas de donnée on renvoie la valeur par défaut
        return defaultValue;
      }
      else
      {
        int nb = defaultValue;
        if (int.TryParse(this.txtPort.Text, out nb))
        {
          if (nb < 0 || nb > 99999)
          { // out of range
            return defaultValue;
          }
          else
          {
            return nb;
          }
        }
        else
        {
          return defaultValue;
        }
      }
    }
  }
}
