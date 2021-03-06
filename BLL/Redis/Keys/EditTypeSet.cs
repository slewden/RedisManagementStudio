﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RedisManagementStudio.BLL.Redis;

namespace RedisManagementStudio.BLL.Redis.Keys
{
  /// <summary>
  /// Editeur de données du type SET
  /// </summary>
  public partial class EditTypeSet : UserControl
  {
    /// <summary>
    /// Nombre de valeur max affichées
    /// </summary>
    public const int SEUIL = 500000;

    /// <summary>
    /// La clé en cours d'affichage
    /// </summary>
    private string myKey = string.Empty;

    /// <summary>
    /// Nombre de valeur dans le set
    /// </summary>
    private int nombreValeur = 0;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="EditTypeSet" />.
    /// </summary>
    public EditTypeSet()
    {
      this.InitializeComponent();
      this.label1.Text = Properties.Resources.EditTypeSetLbl1T;
      this.label2.Text = Properties.Resources.EditTypeSetLbl2T;
      this.label3.Text = Properties.Resources.EditTypeSetLbl3T;
      this.colValue.Text = Properties.Resources.EditTypeSetColValue;
    }

    #region Interface publique
    /// <summary>
    /// Notifie un changement au parent
    /// </summary>
    public event EventHandler OnChange;

    /// <summary>
    /// Défini la connexion à utiliser
    /// </summary>
    public RedisConnection Connection { get; set; }

    /// <summary>
    /// Renvoie ou défini la clé en cours d'édition
    /// </summary>
    public string Key
    {
      get
      {
        return this.myKey;
      }

      set
      {
        if (this.Connection == null && !string.IsNullOrWhiteSpace(value))
        {
          throw new ArgumentException(Properties.Resources.ErrorEditorsWithoutConnection);
        }

        if (!string.IsNullOrWhiteSpace(value))
        {
          if (this.Connection.Type(value) != ETypeKey.Tset)
          { // invalid key
            return;
          }
        }

        this.myKey = value;
        this.FillDisplay();
      }
    }

    /// <summary>
    /// Renvoie le nombre de valeurs
    /// </summary>
    public int Count
    {
      get
      {
        return this.nombreValeur;
      }
    }

    /// <summary>
    /// Enregistre les propriétés de mise en forme du contrôle
    /// </summary>
    public void SaveProperties()
    {
      // TODO If needed
    }

    /// <summary>
    /// Charge les propriété du composant
    /// </summary>
    public void LoadProperties()
    {
      // TODO If needed
    }
    #endregion

    #region Events
    /// <summary>
    /// Changement du type d'éditeur ==> on ajuste la taille des colonnes
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void EditTypeSetSizeChanged(object sender, EventArgs e)
    {
      this.colValue.Width = this.lstValues.Width;
    }

    /// <summary>
    /// Changement d'élément sélectionné
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void LstValuesSelectedIndexChanged(object sender, EventArgs e)
    {
      this.GereBoutons();
    }
    
    /// <summary>
    /// Active le trie des valeurs
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre de tri</param>
    private void LstValuesColumnClick(object sender, ColumnClickEventArgs e)
    {
      if (this.lstValues.ListViewItemSorter == null)
      {
        this.lstValues.ListViewItemSorter = new ListViewTextSorter(e.Column);
      }
      else
      {
        ((ListViewTextSorter)this.lstValues.ListViewItemSorter).Change(e.Column);
      }

      this.lstValues.Sort();
    }

    /// <summary>
    /// Changement du texte pour une nouvelle valeur
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void TxtNewValueTextChanged(object sender, EventArgs e)
    {
      this.GereBoutons();
    }

    /// <summary>
    /// Suppression de la valeur en cours
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtDeleteClick(object sender, EventArgs e)
    {
      if (MessageBox.Show(
        this, 
        Properties.Resources.EditTypeSetBtDeleteConfirmD, 
        Properties.Resources.EditTypeSetBtDeleteConfirmT, 
        MessageBoxButtons.YesNo, 
        MessageBoxIcon.Question, 
        MessageBoxDefaultButton.Button2) == DialogResult.Yes)
      {
        int n = this.Connection.Connector.SRem(this.myKey, this.lstValues.SelectedItems[0].Text);
        if (n == 1)
        {
          this.NotifyChange();
        }
      }
    }

    /// <summary>
    /// Ajoute une valeur au set
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtAddClick(object sender, EventArgs e)
    {
      if (string.IsNullOrWhiteSpace(this.txtNewValue.Text))
      {
        return;
      }

      int n = this.Connection.Connector.SAdd(this.myKey, this.txtNewValue.Text);
      this.txtNewValue.Text = string.Empty;
      this.GereBoutons();
      this.NotifyChange();
    }

    /// <summary>
    /// changement du texte de recherche
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void TxtSearchTextChanged(object sender, EventArgs e)
    {
      this.GereBoutons();
    }

    /// <summary>
    /// recherche d'une clé
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Paramètre inutile</param>
    private void BtSearchClick(object sender, EventArgs e)
    {
      if (string.IsNullOrWhiteSpace(this.txtSearch.Text))
      {
        return;
      }

      if (this.Connection.Connector.SIsMember(this.myKey, this.txtSearch.Text))
      {
        MessageBox.Show(
          this,
          string.Format(Properties.Resources.EditTypeSetBtSearchMessageOkD, this.txtSearch.Text, this.myKey),
          Properties.Resources.EditTypeSetBtSearchMessageT, 
          MessageBoxButtons.OK, 
          MessageBoxIcon.Information);
        ListViewItem itx = new ListViewItem(this.txtSearch.Text);
        this.lstValues.Items.Add(itx);
        itx.Selected = true;
        itx.EnsureVisible();
        this.txtSearch.Text = string.Empty;
        this.GereBoutons();
        this.NotifyChange();
      }
      else
      {
        MessageBox.Show(
          this,
          string.Format(Properties.Resources.EditTypeSetBtSearchMessageKoD, this.txtSearch.Text, this.myKey),
          Properties.Resources.EditTypeSetBtSearchMessageT, 
          MessageBoxButtons.OK, 
          MessageBoxIcon.Error);
      }
    }
    #endregion

    /// <summary>
    /// Remplit l'interface avec les infos sur la clé de type SET
    /// </summary>
    private void FillDisplay()
    {
      if (string.IsNullOrWhiteSpace(this.myKey))
      {
        this.nombreValeur = 0;
      }
      else
      {
        this.nombreValeur = this.Connection.Connector.SCard(this.myKey);
      }

      this.lstValues.Items.Clear();
      if (this.nombreValeur > 0)
      {
        List<string> values;
        if (this.nombreValeur > EditTypeSet.SEUIL)
        { // Trop de données on affiche un échantillon
          values = this.Connection.Connector.SRandMember(this.myKey, EditTypeSet.SEUIL);
          foreach (string s in values)
          {
            this.lstValues.Items.Add(s);
          }

          ListViewItem itx = new ListViewItem("...");
          itx.ToolTipText = Properties.Resources.EditTypeFillDisplayMoreD;
          this.lstValues.Items.Add(itx);

          this.pnlSearch.Visible = true;
          this.lstValues.Height = this.pnlSearch.Top > 5 ? this.pnlSearch.Top - this.lstValues.Top - 5 : 0;
        }
        else
        { // on affiche toutes les valeurs 
          values = this.Connection.Connector.SMembers(this.myKey);
          values.Sort(new StringCorrectComparer());
          foreach (string s in values)
          {
            this.lstValues.Items.Add(s);
          }

          this.pnlSearch.Visible = false;
          this.lstValues.Height = this.pnlSearch.Bottom - this.lstValues.Top;
        }
      }

      this.GereBoutons();
    }

    /// <summary>
    /// Active o pas les boutons
    /// </summary>
    private void GereBoutons()
    {
      if (this.lstValues.SelectedItems.Count > 0)
      {
        this.lblCurrentValue.Text = this.lstValues.SelectedItems[0].Text;
      }
      else
      {
        this.lblCurrentValue.Text = string.Empty;
      }

      this.btAdd.Enabled = !string.IsNullOrWhiteSpace(this.txtNewValue.Text);
      this.btSearch.Enabled = !string.IsNullOrWhiteSpace(this.txtSearch.Text);
      this.btDelete.Enabled = this.lstValues.SelectedItems.Count == 1;
    }

    /// <summary>
    /// Notifie les parent d'un changement
    /// </summary>
    private void NotifyChange()
    {
      if (this.OnChange != null)
      {
        this.OnChange(this, new EventArgs());
      }
    }
  }
}
