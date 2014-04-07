using System;
using System.Windows.Forms;
using RedisManagementStudio.BLL.Redis;

namespace RedisManagementStudio.BLL.Keys
{
  /// <summary>
  /// Affiche un groupe de clés
  /// </summary>
  public partial class KeyGroup : UserControl
  {
    /// <summary>
    /// Constructeur par défaut
    /// </summary>
    public KeyGroup()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Notifie un changement de sélection au parent
    /// </summary>
    public event EventHandler OnChange;
    
    /// <summary>
    /// L'image list à utiliser
    /// </summary>
    public ImageList ImageList
    {
      get
      {
        return this.lstNodes.SmallImageList;
      }

      set
      {
        this.lstNodes.SmallImageList = value;
      }
    }

    /// <summary>
    /// le noeud sélectionné
    /// </summary>
    public TreeNode Selection
    {
      get
      {
        if (this.lstNodes.SelectedItems.Count == 0)
        {
          return null;
        }
        else
        {
          TreeNode tn = new TreeNode(this.lstNodes.SelectedItems[0].Text);
          tn.ImageKey = this.lstNodes.SelectedItems[0].ImageKey;
          tn.SelectedImageKey = tn.ImageKey;
          tn.Tag = this.lstNodes.SelectedItems[0].Tag;
          return tn;
        }
      }
      
      set
      {
        this.lstNodes.BeginUpdate();
        this.lstNodes.Items.Clear();
        if (value != null)
        { // y a quelque chose
          int n = 0;
          ListViewItem itx;
          ETypeKey tk = ETypeKey.Tnone;
          string t;
          foreach (TreeNode node in value.Nodes)
          {
            itx = new ListViewItem(node.Text);
            itx.ImageKey = node.ImageKey;
            itx.Tag = node.Tag;
            t = node.ImageKey;
            if (t.StartsWith("G"))
            {
              t = t.Substring(1);
            }

            tk = (ETypeKey)Enum.Parse(typeof(ETypeKey), t);
            itx.SubItems.Add(tk.GetLibelle());
            this.lstNodes.Items.Add(itx);
            n++;
          }

          if (n > 0)
          {
            this.lblCount.Text = string.Format("{0} clé{1}", n, n > 1 ? "s" : string.Empty);
          }
          else
          {
            this.lblCount.Text = "Aucune clé";
          }

          this.lblDescription.Text = tk.GetLongLibelle();
        }
        else
        {
          this.lblCount.Text = string.Empty;
          this.lblDescription.Text = string.Empty;
        }
        
        this.lstNodes.EndUpdate();
      }
    }

    /// <summary>
    /// Event double click sur un noeud ==> notifier le parent
    /// </summary>
    /// <param name="sender">qui appelle</param>
    /// <param name="e">param inutile</param>
    private void LstNodesDoubleClick(object sender, EventArgs e)
    {
      if (this.OnChange != null)
      {
        this.OnChange(this, new EventArgs());
      }
    }
  }
}
