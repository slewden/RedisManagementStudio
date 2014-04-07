using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RedisManagementStudio.BLL.Redis.Keys
{
  /// <summary>
  /// Classe pour le trie des LISTVIEW sur les colonnes
  /// </summary>
  public class ListViewTextSorter : IComparer
  {
    /// <summary>
    /// L'index de la colonne à trier
    /// </summary>
    private int columnIndex;

    /// <summary>
    /// L'ordre de trie
    /// </summary>
    private SortOrder sortOrder;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="ListViewTextSorter" />.
    /// </summary>
    /// <param name="index">colonne cliquée pour le trie</param>
    public ListViewTextSorter(int index)
    {
      this.columnIndex = index;
      this.sortOrder = SortOrder.Ascending;
    }

    /// <summary>
    /// Change le trie
    /// </summary>
    /// <param name="newindex">Nouvelle colonne cliquée</param>
    public void Change(int newindex)
    {
      if (this.columnIndex != newindex)
      { // changement de colonne
        this.columnIndex = newindex;
        this.sortOrder = SortOrder.Ascending;
      }
      else
      { // même colonne on inverse le trie
        this.sortOrder = this.sortOrder == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
      }
    }

    /// <summary>
    /// Comparateur de LISTVIEWITEM
    /// </summary>
    /// <param name="x">Premier objet</param>
    /// <param name="y">Second objet</param>
    /// <returns>L'ordre de trie</returns>
    public int Compare(object x, object y)
    {
      ListViewItem a = x as ListViewItem;
      ListViewItem b = y as ListViewItem;

      if (a == null)
      {
        return b == null ? 0 : -1;
      }
      else if (b == null)
      {
        return 1;
      }
      else
      {
        string aa;
        string bb;

        if (this.columnIndex == 0)
        {
          aa = a.Text;
          bb = b.Text;
        }
        else
        {
          aa = this.columnIndex < a.SubItems.Count && a.SubItems[this.columnIndex] != null ? a.SubItems[this.columnIndex].Text : string.Empty;
          bb = this.columnIndex < b.SubItems.Count && b.SubItems[this.columnIndex] != null ? b.SubItems[this.columnIndex].Text : string.Empty;
        }

        if (this.sortOrder == SortOrder.Descending)
        {
          return bb.CompareTo(aa);
        }
        else
        {
          return aa.CompareTo(bb);
        }
      }
    }
  }
}
