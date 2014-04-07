using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RedisManagementStudio.BLL.Redis.Keys
{
  /// <summary>
  /// Renommer une clé : obtenir le nouveau nom
  /// </summary>
  public partial class FRename : Form
  {
    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="FRename" />.
    /// </summary>
    public FRename()
    {
      this.InitializeComponent();

      this.Text = Properties.Resources.FRenameText;
      this.label2.Text = Properties.Resources.FRenameTitreOld + " :";
      this.label1.Text = Properties.Resources.FRenameTitreNew + " :";
      this.btCancel.Text = Properties.Resources.BtCancelT;
      this.btOk.Text = Properties.Resources.FRenameOk;
    }

    /// <summary>
    /// Nom avant et après
    /// </summary>
    public string KeyName
    {
      get
      {
        return this.txtNew.Text;
      }

      set
      {
        this.txtOld.Text = value;
        this.txtNew.Text = value;
        this.GereBouton();
      }
    }

    /// <summary>
    /// Event de chargement de la feuille
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void FRename_Load(object sender, EventArgs e)
    {
      this.Location = Properties.Settings.Default.FRenamePosition;
      this.Size = Properties.Settings.Default.FRenameDimension;
    }

    /// <summary>
    /// Fermeture de la fenêtre
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre Inutile</param>
    private void FRename_FormClosed(object sender, FormClosedEventArgs e)
    {
      Properties.Settings.Default.FRenamePosition = this.Location;
      Properties.Settings.Default.FRenameDimension = this.Size;
      Properties.Settings.Default.Save();
    }

    /// <summary>
    /// Valide le formulaire
    /// </summary>
    /// <param name="sender">qui appelle</param>
    /// <param name="e">argument Qui sert à rien</param>
    private void BtOkClick(object sender, EventArgs e)
    {
      if (string.IsNullOrWhiteSpace(this.txtNew.Text))
      {
        return;
      }

      if (this.txtOld.Text == this.txtNew.Text)
      {
        return;
      }

      this.DialogResult = DialogResult.OK;
    }

    /// <summary>
    /// Gere l'activation du bouton Ok
    /// </summary>
    /// <param name="sender">qui appelle</param>
    /// <param name="e">argument Qui sert à rien</param>
    private void TxtNewTextChanged(object sender, EventArgs e)
    {
      this.GereBouton();
    }

    /// <summary>
    /// Gere l'activation du bouton pour valider
    /// </summary>
    private void GereBouton()
    {
      this.btOk.Enabled = !string.IsNullOrWhiteSpace(this.txtNew.Text) && this.txtNew.Text != this.txtOld.Text;
    }
  }
}
