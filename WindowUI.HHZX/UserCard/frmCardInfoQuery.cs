using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL.IBLL.HHZX.UserInfomation.UserCard;
using BLL.Factory.HHZX;
using Model.HHZX.UserCard;
using WindowUI.HHZX.ClassLibrary.Public;
using BLL.IBLL.General;
using BLL.Factory.General;
using Model.HHZX.UserInfomation.CardUserInfo;
using Model.IModel;
using Model.General;
using PaymentEquipment.Entity;
using Common;

namespace WindowUI.HHZX.UserCard
{
    /// <summary>
    /// 新增白卡
    /// </summary>
    public partial class frmCardInfoQuery : BaseReaderForm
    {
        List<ConsumeCardMaster_ccm_Info> _infoList;

        IConsumeCardMasterBL _iccmBL;
        IGeneralBL _igBM;

        public frmCardInfoQuery()
        {
            InitializeComponent();

            _iccmBL = MasterBLLFactory.GetBLL<IConsumeCardMasterBL>(MasterBLLFactory.ConsumeCardMaster);
            _igBM = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);
            initUserDepartment();
            initUserClass();
            initReader();
            initCardUseState();
        }

        private void initReader()
        {
            this.btnReaderCon.Click += btnReaderState_Click;
            btnReaderState_Click(this.btnReaderCon, null);
        }

        /// <summary>
        /// 獲取查詢條件
        /// </summary>
        /// <returns></returns>
        private UserCardPair_ucp_Info GetSearchObj()
        {
            if (nudCardNo.DecimalValue == 0 && String.IsNullOrEmpty(this.txtCardID.Text)
                && String.IsNullOrEmpty(txbChaName.Text)
                &&( cmbUserClass.SelectedValue == null
                || String.IsNullOrEmpty(cmbUserClass.SelectedValue.ToString()))
                &&( cmbUserDepartment.SelectedValue == null
                || String.IsNullOrEmpty(cmbUserDepartment.SelectedValue.ToString()))
                )
            {
                MessageBox.Show("请输入一个查询条件");
                return null;
            }


            CardUserMaster_cus_Info cusInfo = new CardUserMaster_cus_Info();
            ConsumeCardMaster_ccm_Info ccmInfo = new ConsumeCardMaster_ccm_Info();

            UserCardPair_ucp_Info ucpInfo = new UserCardPair_ucp_Info();
            ucpInfo.ucp_lIsActive = true;

            ucpInfo.CardOwner = cusInfo;
            ucpInfo.CardInfo = ccmInfo;

            ucpInfo.ucp_iCardNo = Int32.Parse(nudCardNo.DecimalValue.ToString());

            ucpInfo.ucp_cCardID = this.txtCardID.Text;

            ucpInfo.CardOwner.cus_cChaName = txbChaName.Text.ToString().Trim();

            if (cmbUserClass.SelectedValue != null && !String.IsNullOrEmpty(cmbUserClass.SelectedValue.ToString()))
            {
                ucpInfo.CardOwner.cus_cClassID = new Guid(cmbUserClass.SelectedValue.ToString());
            }

            if (cmbUserDepartment.SelectedValue != null && !String.IsNullOrEmpty(cmbUserDepartment.SelectedValue.ToString()))
            {
                ucpInfo.CardOwner.cus_cClassID = new Guid(cmbUserDepartment.SelectedValue.ToString());
            }

            ucpInfo.CardInfo.ccm_cCardState = this.cmbCardState.SelectedValue.ToString();

            if (this.chbPairTime.Checked)
            {
                ucpInfo.PairTime_To = this.dtpPairTime_To.Value.AddDays(1);
                ucpInfo.PairTime_From = this.dtpPairTime_From.Value;
            }

            return ucpInfo;
        }


        private void ShowView()
        {
            UserCardPair_ucp_Info ucpInfo = GetSearchObj();

            if (ucpInfo == null)
            {
                return;
            }
            _infoList = _iccmBL.SearchDisplayRecords(ucpInfo);

            List<ViewInfo> showList = new List<ViewInfo>();

            if (_infoList != null && _infoList.Count > 0)
            {
                for (int index = 0; index < _infoList.Count; index++)
                {
                    ViewInfo vi = new ViewInfo();
                    vi.Add = _infoList[index].ccm_cAdd;
                    vi.AddTime = _infoList[index].ccm_dAddDate.ToString("yyyy/MM/dd HH:mm:ss");
                    vi.Last = _infoList[index].ccm_cLast;
                    vi.LastTime = _infoList[index].ccm_dLastDate.ToString("yyyy/MM/dd HH:mm:ss");
                    vi.CardID = _infoList[index].ccm_cCardID;
                    vi.number = index + 1;

                    if (_infoList[index].UCPInfo != null)
                    {
                        vi.CardNo = _infoList[index].UCPInfo.ucp_iCardNo.ToString();
                    }

                    if (_infoList[index].CardOwner != null)
                    {
                        vi.ChaName = _infoList[index].CardOwner.cus_cChaName;
                    }

                    if (_infoList[index].UCPInfo != null)
                    {
                        vi.PairTime = _infoList[index].UCPInfo.ucp_dPairTime.ToString("yyyy/MM/dd HH:mm:ss");
                    }
                    vi.CardState = _infoList[index].ccm_cCardState;

                    switch (_infoList[index].ccm_cCardState)
                    {
                        case "InUse":
                            vi.CardState = "使用中";
                            break;
                        case "NotUsed":
                            vi.CardState = "未使用";
                            break;
                    }

                    showList.Add(vi);
                }
            }
            else
            {
                this.ShowInformationMessage("无符合条件的记录。");
            }

            lvCardList.SetDataSource(showList);
        }

        class ViewInfo
        {
            public int number { get; set; }//序號
            public string CardNo { get; set; }//卡編號
            public string ChaName { get; set; }//持卡人
            public string CardState { get; set; }//卡狀態
            public string PairTime { get; set; }//發卡時間
            public string Add { get; set; }//添加人
            public string AddTime { get; set; }//添加時間
            public string Last { get; set; }//修改人
            public string LastTime { get; set; }//修改時間
            public string CardID { get; set; }//卡原始ID

        }

        private void initCardUseState()
        {
            List<IModelObject> list = new List<IModelObject>();

            ComboboxDataInfo cmbInfo1 = new ComboboxDataInfo();
            cmbInfo1.DisplayMember = "使用中";
            cmbInfo1.ValueMember = DefineConstantValue.CardUseState.InUse.ToString();

            list.Add(cmbInfo1);

            ComboboxDataInfo cmbInfo2 = new ComboboxDataInfo();
            cmbInfo2.DisplayMember = "未使用";
            cmbInfo2.ValueMember = DefineConstantValue.CardUseState.NotUsed.ToString();

            list.Add(cmbInfo2);

            ComboboxDataInfo cmbInfo = new ComboboxDataInfo();
            cmbInfo.DisplayMember = "全部";
            cmbInfo.ValueMember = "";

            list.Add(cmbInfo);

            this.cmbCardState.SetDataSource(list);
            this.cmbCardState.SelectedIndex = list.Count - 1;
        }

        /// <summary>
        /// 初始班級下位框
        /// </summary>
        private void initUserClass()
        {
            List<IModelObject> list = _igBM.GetMasterDataInformations(Common.DefineConstantValue.MasterType.UserClass);

            if (list == null)
            {
                list = new List<IModelObject>();
            }

            ComboboxDataInfo cmbInfo = new ComboboxDataInfo();
            cmbInfo.DisplayMember = "全部";
            cmbInfo.ValueMember = "";

            list.Add(cmbInfo);

            this.cmbUserClass.SetDataSource(list);
            this.cmbUserClass.SelectedIndex = list.Count() - 1;

        }

        /// <summary>
        /// 初始部門下拉框
        /// </summary>
        private void initUserDepartment()
        {
            List<IModelObject> list = _igBM.GetMasterDataInformations(Common.DefineConstantValue.MasterType.UserDepartment);

            if (list == null)
            {
                list = new List<IModelObject>();
            }

            ComboboxDataInfo cmbInfo = new ComboboxDataInfo();
            cmbInfo.DisplayMember = "全部";
            cmbInfo.ValueMember = "";

            list.Add(cmbInfo);

            this.cmbUserDepartment.SetDataSource(list);
            this.cmbUserDepartment.SelectedIndex = list.Count() - 1;
        }

        private void tlpCardList_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sysToolBar_OnItemNew_Click(object sender, EventArgs e)
        {
            frmAddNewCard dlgNewCard = new frmAddNewCard();
            dlgNewCard.UserInformation = this.UserInformation;
            dlgNewCard.ShowDialog();
            //if (dlgNewCard.ShowDialog() == DialogResult.Yes)
            //{

            //}

            _Reader.Conn();
        }

        private void sysToolBar_OnItemDetail_Click(object sender, EventArgs e)
        {
            if (this.lvCardList.SelectedItems.Count > 0)
            {
                CardUserMaster_cus_Info cusInfo = new CardUserMaster_cus_Info();
                cusInfo.cus_cChaName = this.lvCardList.SelectedItems[0].SubItems[2].Text;

                UserCardPair_ucp_Info ucpInfo = new UserCardPair_ucp_Info();

                if (!String.IsNullOrEmpty(this.lvCardList.SelectedItems[0].SubItems[1].Text))
                {
                    ucpInfo.ucp_iCardNo = Int32.Parse(this.lvCardList.SelectedItems[0].SubItems[1].Text);
                }
                ucpInfo.ucp_cUseStatus = this.lvCardList.SelectedItems[0].SubItems[3].Text;
                ucpInfo.ucp_cCardID = this.lvCardList.SelectedItems[0].SubItems[5].Text;

                ucpInfo.CardOwner = cusInfo;

                frmCardInfoDetail dlgDetail = new frmCardInfoDetail(ucpInfo);
                if (dlgDetail.ShowDialog() == DialogResult.Yes)
                {

                }
            }
            else
            {
                this.ShowInformationMessage("请先选择一条记录！");
                lvCardList.Focus();
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sysToolBar_OnItemRefresh_Click(object sender, EventArgs e)
        {
            ShowView();
        }

        private void lvCardList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            sysToolBar.BtnDetail_IsEnabled = true;
        }

        private void btnReadCard_Click(object sender, EventArgs e)
        {
            try
            {
                bool resUkey = base.CheckUKey();
                if (!resUkey)
                {
                    return;
                }

                btnReaderState_Click(this.btnReaderCon, null);
                if (_IsConnected)
                {
                    this.Cursor = Cursors.WaitCursor;

                    ConsumeCardInfo cardInfo = _Reader.ReadCardInfo(_CardInfoSection, _SectionPwd);
                    if (cardInfo != null)
                    {
                        this.nudCardNo.Text = cardInfo.CardNo;
                        this.txtCardID.Text = cardInfo.CardSourceID;
                    }
                    else
                    {
                        base.ShowErrorMessage("找不到卡片，请确认读卡器是否已连接或是否将卡片放在读卡器的感应区内。");
                    }
                }
                else
                {
                    base.ShowErrorMessage("找不到读卡器，请确认读卡器是否已连接。");
                }
            }
            catch
            {
                base.ShowErrorMessage("找不到卡片，请确认读卡器是否已连接或是否将卡片放在读卡器的感应区内。");

            }

            ShowView();

            this.Cursor = Cursors.Default;
        }

        private void cmbUserClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbUserClass.SelectedIndex != -1)
            {
                this.cmbUserDepartment.SelectedIndex = -1;
            }
        }

        private void cmbUserDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbUserDepartment.SelectedIndex != -1)
            {
                this.cmbUserClass.SelectedIndex = -1;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowView();
        }

        private void chbPairTime_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;

            if (cb.Checked)
            {
                this.dtpPairTime_From.Enabled = true;
                this.dtpPairTime_To.Enabled = true;
            }
            else
            {
                this.dtpPairTime_From.Enabled = false;
                this.dtpPairTime_To.Enabled = false;
            }

        }

        private void nudCardNo_TextChanged(object sender, EventArgs e)
        {
            this.txtCardID.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lvCardList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvCardList.Sorting == SortOrder.Ascending)
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Descending);
                lvCardList.ListViewItemSorter = sorter;
                lvCardList.Sorting = SortOrder.Descending;
            }
            else
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Ascending);
                lvCardList.ListViewItemSorter = sorter;
                lvCardList.Sorting = SortOrder.Ascending;
            }
        }

        private void sysToolBar_OnItemDelete_Click(object sender, EventArgs e)
        {
            if (lvCardList.SelectedItems.Count > 0)
            {
                if (_infoList != null)
                {
                    string cardID = lvCardList.SelectedItems[0].SubItems[5].Text;

                    for (int index = 0; index < _infoList.Count; index ++ )
                    {
                        if (_infoList[index].ccm_cCardID == cardID)
                        {
                            ReturnValueInfo returnInfo = _iccmBL.DeleteRecord(_infoList[index]);

                            if (returnInfo.boolValue)
                            {
                                MessageBox.Show("已删除","提示");

                                ShowView();
                            }
                            else
                            {
                                MessageBox.Show("删除失败。", "提示");
                            } 
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择一条记录。","提示");
            }
        }

        private void lvCardList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCardList.SelectedItems.Count > 0)
            {
                if (lvCardList.SelectedItems[0].SubItems[3].Text == "未使用")
                {
                    sysToolBar.BtnDelete_IsEnabled = true;
                }
            }
            else
            {
                sysToolBar.BtnDelete_IsEnabled = false;
            }
        }

        
    }
}
