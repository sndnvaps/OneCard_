using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PaymentEquipment.IDevice;
using PaymentEquipment.DeviceFactory;
using Model.General;
using PaymentEquipment.Entity;
using System.Threading;
using BLL.IBLL.HHZX.UserInfomation.UserCard;
using BLL.Factory.HHZX;
using Model.HHZX.UserCard;
using Common;
using WindowUI.HHZX.ClassLibrary.Public;

namespace WindowUI.HHZX.UserCard
{
    public partial class frmAddNewCard : BaseReaderForm
    {
        private IConsumeCardMasterBL _iccmBL;
        private List<string> _TemCardList = new List<string>();
        private bool _isAutoRead = false;

        private string _temCardID = "";//存當前已讀卡卡號

        public frmAddNewCard()
        {
            InitializeComponent();

            _iccmBL = MasterBLLFactory.GetBLL<IConsumeCardMasterBL>(MasterBLLFactory.ConsumeCardMaster);

            this.btnReaderCon.Click += btnReaderState_Click;
            btnReaderState_Click(this.btnReaderCon, null);

            InitReader();
        }

        /// <summary>
        /// 初始化读写器
        /// </summary>
        private void InitReader()
        {
            if (this._IsConnected)
            {
                this.pnlContent.Enabled = true;
            }
            else
            {
                base.ShowErrorMessage("找不到读卡器，请确认读卡器是否已连接。");

                this.pnlContent.Enabled = false;
            }
        }

        private void btnReaderCon_Click(object sender, EventArgs e)
        {
            InitReader();
        }

        /// <summary>
        /// 轉換讀卡模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbChange_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbSingle.Checked)
            {
                this.pnlMore.Enabled = false;
                this.pnlSingle.Enabled = true;
            }
            else
            {
                this.pnlMore.Enabled = true;
                this.pnlSingle.Enabled = false;
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
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
                    ConsumeCardInfo cardInfo = _Reader.ReadCardInfo(_CardInfoSection, _SectionPwd);
                    if (cardInfo != null)
                    {
                        this.labCardID.Text = cardInfo.CardSourceID;
                    }
                    else
                    {
                        cardInfo = _Reader.ReadCardInfo(_CardInfoSection, this._OrganizeSectionPwd);
                        if (cardInfo != null)
                        {
                            this.labCardID.Text = cardInfo.CardSourceID;
                        }
                        else
                        {
                            base.ShowErrorMessage("找不到卡片，请确认读卡器是否已连接或是否将卡片放在读卡器的感应区内。");
                        }
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
        }

        private void btnTempAdd_Click(object sender, EventArgs e)
        {
            AddCard();
        }

        private bool CheckCard()
        {
            ConsumeCardMaster_ccm_Info ccmInfo = new ConsumeCardMaster_ccm_Info();
            ccmInfo.ccm_cCardID = labCardID.Text;
            ccmInfo.ccm_lIsActive = true;
            ccmInfo = _iccmBL.DisplayRecord(ccmInfo) as ConsumeCardMaster_ccm_Info;

            if (ccmInfo != null)
            {
                if (_temCardID != labCardID.Text)
                {
                    _temCardID = labCardID.Text;
                    this.lblReadMessage.Visible = true;
                    this.lblReadMessage.Text = "卡片已录入，请不要重复录入。";
                    // MessageBox.Show("卡片：" + labCardID.Text + " 已存在。");
                }
                return true;
            }
            else
            {
                this.lblReadMessage.Visible = false;
                this.lblReadMessage.Text = "";
                return false;
            }
        }

        private void AddCard()
        {
            if (CheckCard())
            {
                return;
            }

            if (_TemCardList != null)
            {
                for (int index = 0; index < _TemCardList.Count;index++ )
                {
                    if (labCardID.Text == _TemCardList[index])
                    {
                        return;
                    }
                }
            }

            _TemCardList.Add(labCardID.Text);

            ListViewItem item = new ListViewItem(_TemCardList.Count.ToString());
            item.SubItems.AddRange(new string[] { labCardID.Text });

            this.lvTempCardInfos.Items.Add(item);
            btnConfirmNewCard.Enabled = true;
        }

        /// <summary>
        /// 清空臨時表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否清空临时表?", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _TemCardList = new List<string>();
                this.lvTempCardInfos.Items.Clear();
                this.labCardID.Text = "未讀卡";
                btnConfirmNewCard.Enabled = false;
            }
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            this.btnBegin.Enabled = false;
            this.btnEnd.Enabled = true;
            this.rdbMore.Enabled = false;
            this.rdbSingle.Enabled = false;

            timer1.Enabled = true;
          //  _isAutoRead = true;
           // this.bgwAutoReadCard.RunWorkerAsync();
        }

        private void bgwAutoReadCard_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                while (_isAutoRead)
                {
                    this.bgwAutoReadCard.ReportProgress(1);
                    Thread.Sleep(1000);
                }
            }
            catch
            {

            }
        }

        private void bgwAutoReadCard_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                if (_IsConnected)
                {
                    bool resUkey = base.CheckUKey();
                    if (!resUkey)
                    {
                        return;
                    }

                    ConsumeCardInfo cardInfo = _Reader.ReadCardInfo(_CardInfoSection, _SectionPwd);
                    if (cardInfo != null)
                    {
                        this.labCardID.Text = cardInfo.CardSourceID;

                        AddCard();
                    }
                    else
                    {
                        this.labCardID.Text = "";
                        this.lblReadMessage.Text = "";
                    }
                }
            }
            catch
            {

            }
        }

        private void StopAutoRead()
        {
            timer1.Enabled = false;

            _isAutoRead = false;
            this.bgwAutoReadCard.CancelAsync();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_IsConnected)
                {
                    bool resUkey = base.CheckUKey();
                    if (!resUkey)
                    {
                        return;
                    }

                    ConsumeCardInfo cardInfo = _Reader.ReadCardInfo(_CardInfoSection, _SectionPwd);
                    if (cardInfo != null)
                    {
                        this.labCardID.Text = cardInfo.CardSourceID;
                        AddCard();
                    }
                    else
                    {
                        cardInfo = _Reader.ReadCardInfo(_CardInfoSection, this._OrganizeSectionPwd);
                        if (cardInfo != null)
                        {
                            this.labCardID.Text = cardInfo.CardSourceID;
                            AddCard();
                        }
                        else
                        {
                            base.ShowErrorMessage("找不到卡片，请确认读卡器是否已连接或是否将卡片放在读卡器的感应区内。");
                        }
                    }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 保存臨時表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmNewCard_Click(object sender, EventArgs e)
        {
            if (_TemCardList != null && _TemCardList.Count > 0)
            {
                if (MessageBox.Show("是否保存临时表?共" + _TemCardList.Count + "张卡信息。", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string message = "";

                    for (int index = 0; index < _TemCardList.Count;index++ )
                    {
                        ConsumeCardMaster_ccm_Info ccmInfo = new ConsumeCardMaster_ccm_Info();
                        ccmInfo.ccm_cCardID = _TemCardList[index];
                        
                        ccmInfo.ccm_lIsActive = false;

                        ReturnValueInfo rvInfo = new ReturnValueInfo();

                        List<ConsumeCardMaster_ccm_Info> ccmList = _iccmBL.SearchRecords(ccmInfo);

                        if (ccmList != null && ccmList.Count > 0)
                        {
                            ccmInfo.ccm_lIsActive = true;
                            ccmInfo.ccm_cLast = this.UserInformation.usm_cUserLoginID;
                            ccmInfo.ccm_dLastDate = System.DateTime.Now;
                            rvInfo = _iccmBL.UpdateRecord(ccmInfo);
                        }
                        else
                        {
                            ccmInfo.ccm_cCardState = DefineConstantValue.CardUseState.NotUsed.ToString();
                            ccmInfo.ccm_cAdd = this.UserInformation.usm_cUserLoginID;
                            ccmInfo.ccm_cLast = this.UserInformation.usm_cUserLoginID;
                            ccmInfo.ccm_dAddDate = System.DateTime.Now;
                            ccmInfo.ccm_dLastDate = System.DateTime.Now;
                            ccmInfo.ccm_lIsActive = true;
                            rvInfo = _iccmBL.SaveRecord(ccmInfo);
                        }

                        if (rvInfo.isError)
                        {
                            message +="保存卡片：" + _TemCardList[index] + "失敗！\n";
                            
                        }
                        else
                        {
                            _TemCardList.RemoveAt(index);
                            this.lvTempCardInfos.Items.RemoveAt(index);
                            index++;
                        }
                    }

                    if (message != "")
                    {
                        base.ShowErrorMessage(message);
                    }
                    else
                    {
                        MessageBox.Show("保存完成。","提示");
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            StopAutoRead();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.StopAutoRead();
            this.btnBegin.Enabled = true;
            this.btnEnd.Enabled = false;
            this.rdbMore.Enabled = true;
            this.rdbSingle.Enabled = true;
        }

        private void lvTempCardInfos_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvTempCardInfos.Sorting == SortOrder.Ascending)
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Descending);
                lvTempCardInfos.ListViewItemSorter = sorter;
                lvTempCardInfos.Sorting = SortOrder.Descending;
            }
            else
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Ascending);
                lvTempCardInfos.ListViewItemSorter = sorter;
                lvTempCardInfos.Sorting = SortOrder.Ascending;
            }
        }


    }
}
