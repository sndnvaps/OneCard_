using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.General;
using System.Windows.Forms;

namespace WindowUI.HHZX.ClassLibrary.Public
{
    class GeneralTools
    {
        /// <summary>
        /// 改變ComboBox選中值
        /// </summary>
        /// <param name="strRecordID">Value对应值</param>
        /// <param name="cbxTarget">源控件</param>
        public static void ExchangeComboValue(string strRecordID, ComboBox cbxTarget)
        {
            if (string.IsNullOrEmpty(strRecordID))
            {
                return;
            }
            if (cbxTarget == null)
            {
                return;
            }
            for (int i = 0; i < cbxTarget.Items.Count; i++)
            {
                ComboboxDataInfo cboItem = cbxTarget.Items[i] as ComboboxDataInfo;
                if (cboItem.ValueMember == strRecordID)
                {
                    cbxTarget.SelectedIndex = i;
                    break;
                }
            }
        }
    }
}
