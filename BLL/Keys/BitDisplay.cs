using System;
using System.Windows.Forms;
using RedisManagementStudio.BLL.Redis;

namespace RedisManagementStudio.BLL.Keys
{
  /// <summary>
  /// Controle pour l'affichage d'une chaine comme un champ de bit
  /// </summary>
  public partial class BitDisplay : UserControl
  {
    /// <summary>
    /// Constructeur par défaut
    /// </summary>
    public BitDisplay()
    {
      InitializeComponent();
      this.Offset = -1;
    }

    /// <summary>
    /// La connexion
    /// </summary>
    public RedisConnection Connection { get; set; }

    /// <summary>
    /// La clé concernée
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// Le texte à décortiquer
    /// </summary>
    public new string Text
    {
      get
      {
        return this.lbltText.Text;
      }

      set
      {
        this.lbltText.Text = value;
        this.UpdateDisplay();
      }
    }

    /// <summary>
    /// La dernière offset survollé par la souris
    /// </summary>
    public int Offset { get; private set; }

    /// <summary>
    /// Event la souris se déplace sur la grille
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">corrdonnées de la souris</param>
    private void ListviewMouseMove(object sender, MouseEventArgs e)
    {
      ListViewItem itx = this.listView1.GetItemAt(e.Location.X, e.Location.Y);
      if (itx != null)
      {
        int col = -1;
        int row = -1;
        bool value = false;

        int dw = 0;
        int index = 0;
        while (dw < e.Location.X && index < this.listView1.Columns.Count)
        {
          dw += this.listView1.Columns[index].Width;
          index++;
        }

        if (index >= 1 && index < 10 && index < itx.SubItems.Count)
        {
          col = index - 2;
          value = itx.SubItems[index - 1].Text == "X";
        }

        if (itx.Tag != null)
        {
          row = (int)itx.Tag;
        }

        if (col >= 0 && row >= 0)
        {
          this.Offset = (row * 8) + col;
          this.LblDescription.Text = string.Format("Bit d'offset {0} : {1}", this.Offset, value ? "Activé" : "Effacé");
        }
        else
        {
          this.Offset = -1;
        }
      }
    }

    /// <summary>
    /// Click dans la grille ==> on propage l'event au controle
    /// </summary>
    /// <param name="sender">Qui appelle</param>
    /// <param name="e">Parametre inutile</param>
    private void ListView1Click(object sender, EventArgs e)
    {
      this.OnClick(e);
    }

    /// <summary>
    /// Met à jour l'affichage
    /// </summary>
    private void UpdateDisplay()
    {
      this.listView1.BeginUpdate();
      this.listView1.Items.Clear();
      ListViewItem itx = new ListViewItem();
      bool ok;
      double realVal;
      int offset = 0;
      int row = 0;
      foreach (char c in this.lbltText.Text)
      {
        realVal = 0;
        itx = new ListViewItem(c.ToString());
        for (int i = 0; i < 8; i++)
        {
          ok = this.Connection.Connector.GetBit(this.Key, offset);
          itx.SubItems.Add(ok ? "X" : string.Empty);
          itx.Tag = row;
          if (ok)
          {
            realVal += Math.Pow(2, 7 - i);
          }

          offset++;
        }

        row++;
        itx.SubItems.Add(string.Format("0x{0:X}", Convert.ToInt32(realVal)));
        this.listView1.Items.Add(itx);
      }

      this.LblDescription.Text = string.Empty;
      this.listView1.EndUpdate();
    }
  }
}
