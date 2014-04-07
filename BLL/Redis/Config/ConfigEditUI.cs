using System;
using System.Windows.Forms;

namespace RedisManagementStudio.BLL.Redis.Config
{
  /// <summary>
  /// Permet l'édition d'une configuration serveur
  /// </summary>
  public partial class ConfigEditUI : UserControl
  {
    /// <summary>
    /// La config à éditer ou a afficher
    /// </summary>
    private InformationBase config = null;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="ConfigEditUI" />.
    /// </summary>
    public ConfigEditUI()
    {
      this.InitializeComponent();
      
      this.btEdit.Text = Properties.Resources.ConfigEditUIBtEditT;
      this.toolTip1.SetToolTip(this.btSave, Properties.Resources.ConfigEditUIBtSaveD);
      this.toolTip1.SetToolTip(this.btCancel, Properties.Resources.ConfigEditUIBtCancelD);
      this.Collapse();
    }

    /// <summary>
    /// Notifier les changements dans la config
    /// </summary>
    public event EventHandler OnSaved;

    /// <summary>
    /// La connexion
    /// </summary>
    public RedisConnection Connection { get; set; }

    /// <summary>
    /// Le contrôle peut entrer en édition ou pas
    /// </summary>
    public bool CanEdit
    {
      set
      {
        this.Collapse();
        this.btEdit.Visible = value;
      }
    }

    /// <summary>
    /// La config à éditer
    /// </summary>
    public InformationBase Config
    {
      set
      {
        if (value != null)
        {
          this.config = value;
          this.lblValue.Text = value.Value;
          this.txtEdit.Text = value.OriginalValue;
        }
        else
        {
          this.config = null;
          this.lblValue.Text = string.Empty;
          this.txtEdit.Text = string.Empty;
        }

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
    }

    /// <summary>
    /// Enregistre la config
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">info inutile</param>
    private void BtSaveClick(object sender, EventArgs e)
    {
      if (this.config == null)
      {
        return;
      }
      else
      {
        try
        {
          this.Connection.Connector.ConfigSet(this.config.Code, this.txtEdit.Text);
          this.NotifySaved();
          this.Collapse();
        }
        catch (Exception ex)
        {
          MessageBox.Show(
            this, 
            string.Format(Properties.Resources.ConfigEditUIBtSaveError, ex), 
            Properties.Resources.ConfigEditUIBtSaveTitre, 
            MessageBoxButtons.OK, 
            MessageBoxIcon.Error);
        }
      }
    }

    /// <summary>
    /// Annuler une édition en cours
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtCancelClick(object sender, EventArgs e)
    {
      this.Collapse();
    }
    
    /// <summary>
    /// Le texte vient de changer
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">info inutile</param>
    private void TxtEditTextChanged(object sender, EventArgs e)
    {
      this.EnableButton();
    }

    /// <summary>
    /// Active ou pas le bouton Save
    /// </summary>
    private void EnableButton()
    {
      this.btSave.Enabled = !string.IsNullOrWhiteSpace(this.txtEdit.Text);
    }
    
    /// <summary>
    /// Etend l'affichage pour edition
    /// </summary>
    private void Expand()
    {
      this.btSave.Visible = true;
      this.btCancel.Visible = true;
      this.txtEdit.Visible = true;
      this.btEdit.Visible = false;
      this.lblValue.Visible = false;
      this.EnableButton();
    }

    /// <summary>
    /// Compressions d'affichage
    /// </summary>
    private void Collapse()
    {
      this.btSave.Visible = false;
      this.btCancel.Visible = false;
      this.txtEdit.Visible = false;
      this.btEdit.Visible = true;
      this.lblValue.Visible = true; 
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
