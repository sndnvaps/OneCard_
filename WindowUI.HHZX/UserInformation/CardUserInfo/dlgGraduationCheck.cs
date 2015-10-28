using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.HHZX.UserInfomation.CardUserInfo;
using WindowUI.HHZX.ClassLibrary.Public;

namespace WindowUI.HHZX.UserInformation.CardUserInfo
{
    public partial class dlgGraduationCheck : BaseForm
    {
        List<CardUserMaster_cus_Info> _UserInfos;

        public dlgGraduationCheck()
        {
            InitializeComponent();
        }

        public dlgGraduationCheck(List<CardUserMaster_cus_Info> UserInfos)
        {
            InitializeComponent();

            this._UserInfos = UserInfos;
        }

        public dlgGraduationCheck(CardUserMaster_cus_Info UserInfo)
        {
            InitializeComponent();

            List<CardUserMaster_cus_Info> listUserInfos = new List<CardUserMaster_cus_Info>();
            listUserInfos.Add(UserInfo);
            this._UserInfos = listUserInfos;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            List<CardUserMaster_cus_Info> listChkRes = cardPairCheck(this._UserInfos);
            lvStudentList.SetDataSource<CardUserMaster_cus_Info>(listChkRes);
            if (listChkRes != null && listChkRes.Count > 0)
            {
                foreach (ListViewItem item in lvStudentList.Items)
                {
                    bool res = Convert.ToBoolean(item.SubItems[1].Text);
                    if (res)
                    {
                        item.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        item.BackColor = Color.Tomato;
                    }
                }
            }
        }

        /// <summary>
        /// 用户发卡信息检查
        /// </summary>
        /// <param name="UserInfos">用户信息</param>
        /// <returns></returns>
        List<CardUserMaster_cus_Info> cardPairCheck(List<CardUserMaster_cus_Info> UserInfos)
        {
            if (UserInfos != null)
            {
                List<CardUserMaster_cus_Info> listChkInfos = new List<CardUserMaster_cus_Info>();
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    bool res = true;
                    foreach (CardUserMaster_cus_Info userItem in UserInfos)
                    {
                        if (userItem.PairInfo != null)
                        {
                            userItem.CheckBool = false;
                            res = res && false;
                            userItem.CheckString = "用户未退卡";
                        }
                        else
                        {
                            userItem.CheckBool = true;
                            userItem.CheckString = "检查通过";
                        }

                        if (userItem.ClassInfo != null)
                        {
                            userItem.ClassName = userItem.ClassInfo.csm_cClassName;
                        }
                        listChkInfos.Add(userItem);
                    }
                    btnConfirm.Enabled = res;
                }
                catch (Exception ex)
                {
                    ShowErrorMessage(ex);
                }
                this.Cursor = Cursors.Default;
                return listChkInfos;
            }
            else
            {
                base.ShowWarningMessage("用户信息为空，请检查后重试。");
                return null;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
