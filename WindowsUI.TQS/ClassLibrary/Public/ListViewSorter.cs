using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace WindowUI.TQS.ClassLibrary.Public
{
    class ListViewSorter : IComparer
    {
        private int sortIndex;
        private SortOrder sortMode;

        public ListViewSorter(int p_SortIndex, SortOrder p_SortMode)
        {
            this.sortIndex = p_SortIndex;

            this.sortMode = p_SortMode;
        }

        public int Compare(object x, object y)
        {
            ListViewItem item1, item2;

            item1 = (ListViewItem)x;

            item2 = (ListViewItem)y;

            string strX, strY;

            strX = item1.SubItems[this.sortIndex].ToString();

            strY = item2.SubItems[this.sortIndex].ToString();

            if (this.sortMode == SortOrder.Ascending)//增序
            {
                if (string.Compare(strX, strY) < 0)
                {
                    return -1;
                }
                else if (string.Compare(strX, strY) == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else if (this.sortMode == SortOrder.Descending)
            {
                if (string.Compare(strX, strY) < 0)
                {
                    return 1;
                }
                else if (string.Compare(strX, strY) == 0)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
