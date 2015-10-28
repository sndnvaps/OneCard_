using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowUI.HHZX.ClassLibrary.Public
{
    /// <summary>
    /// 文本檢查類型
    /// </summary>
    public enum enmTextBoxValueType
    {
        enmInt,
        enmDecimal,
        enmDatetime
    }

    /// <summary>
    /// 檢查數值錄類型
    /// </summary>
    public enum enmNumCheckType
    {
        enmAllowZero,
        enmNotAllowZero,
    }
    
    public static class CommonFunction
    {
        /// <summary>        
        /// 檢查控制內容是否可以保存
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        /// <remarks>Add By Leothlink TonyWu On 2013/02/27</remarks>
        public static bool CheckTextBox(TextBox target)
        {
            if (target.Text.Trim() == "")
            {                
                target.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// 檢查文本框的內容是否輸入正確
        /// </summary>
        /// <param name="target"></param>
        /// <param name="textType"></param>
        /// <returns></returns>
        public static bool CheckNumTextBox(TextBox target, enmTextBoxValueType textType, enmNumCheckType checkType)
        {
            switch (textType)
            {
                case enmTextBoxValueType.enmInt:
                    int intValue = 0;
                    if(!int.TryParse(target.Text,out intValue))
                    {
                        target.SelectAll();
                        target.Focus();
                        return false;
                    }

                    if (checkType == enmNumCheckType.enmNotAllowZero && intValue == 0)
                    {
                        target.SelectAll();
                        target.Focus();
                        return false;
                    }

                    break;
                case enmTextBoxValueType.enmDecimal:
                    decimal decValue = 0;
                    if (!decimal.TryParse(target.Text, out decValue))
                    {
                        target.SelectAll();
                        target.Focus();
                        return false;
                    }

                    if (checkType == enmNumCheckType.enmNotAllowZero && decValue == 0)
                    {
                        target.SelectAll();
                        target.Focus();
                        return false;
                    }

                    break;
            }

            return true;
        }

        /// <summary>
        /// 檢查組合框是否已經選擇
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool CheckComboBox(ComboBox target)
        {
            if (target.SelectedItem == null)
            {
                target.Focus();
                return false;
            }

            if (target.Text == "")
            {
                target.Focus();
                return false;
            }

            return true;
        }
    }
}