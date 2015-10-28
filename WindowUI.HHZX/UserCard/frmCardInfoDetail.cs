using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.HHZX.UserCard;
using BLL.IBLL.HHZX.UserInfomation.UserCard;
using BLL.Factory.HHZX;
using WindowUI.HHZX.ClassLibrary.Public;
using Common;

namespace WindowUI.HHZX.UserCard
{
    public partial class frmCardInfoDetail : BaseForm
    {
        private IConsumeCardMasterBL _iccmBL;
        private UserCardPair_ucp_Info _ucpInfo;

        public frmCardInfoDetail(UserCardPair_ucp_Info ucpInfo)
        {
            InitializeComponent();

            _iccmBL = MasterBLLFactory.GetBLL<IConsumeCardMasterBL>(MasterBLLFactory.ConsumeCardMaster);
            _ucpInfo = ucpInfo;
            init();
        }

        class ViewInfo
        {
            public string UserID { get; set; }//用戶ID
            public string ChaName { get; set; } //用戶名
            public string PairTime { get; set; }//發卡時間
            public string ReturnTime { get; set; }//退卡時間
        }

        private void init()
        {
            if (_ucpInfo != null)
            {
                this.lblCardID.Text = _ucpInfo.ucp_cCardID;
                this.lblCardNo.Text = _ucpInfo.ucp_iCardNo.ToString();
                this.lblChaName.Text = _ucpInfo.CardOwner.cus_cChaName;
                this.lblUserStatuc.Text = _ucpInfo.ucp_cUseStatus;
                
                //switch (_ucpInfo.ucp_cUseStatus)
                //{
                //    case "Normal":
                //        this.lblUserStatuc.Text = "使用中"; 
                //        break;
                //    case "LoseReporting":
                //        this.lblUserStatuc.Text = "挂失中"; 
                //        break;
                //    case "Damaged":
                //        this.lblUserStatuc.Text = "已损坏";
                //        break;
                //    case "Lost":
                //        this.lblUserStatuc.Text = "已丢失";
                //        break;
                //    case "Returned":
                //        this.lblUserStatuc.Text = "已退卡";
                //        break;
                //}

                List<ConsumeCardMaster_ccm_Info> ccmList = _iccmBL.SearchHistoryRecords(_ucpInfo);

                if (ccmList != null)
                {
                    List<ViewInfo> viewList = new List<ViewInfo>();
                    for (int index = 0; index < ccmList.Count;index++ )
                    {
                        ViewInfo vi = new ViewInfo();
                        vi.UserID = ccmList[index].CardOwner.cus_cStudentID.ToString() ;
                        vi.ChaName = ccmList[index].CardOwner.cus_cChaName;
                        vi.PairTime = ccmList[index].UCPInfo.ucp_dPairTime.ToString("yyyy/MM/dd HH:mm:ss");

                        if (ccmList[index].UCPInfo.ucp_dReturnTime != null)
                        {
                            vi.ReturnTime = ((DateTime)(ccmList[index].UCPInfo.ucp_dReturnTime)).ToString("yyyy/MM/dd HH:mm:ss");
                        }
                        else
                        {
                            vi.ReturnTime = "";
                        }
                        viewList.Add(vi);
                    }

                    livHistoryRecord.SetDataSource(viewList);


                }
                else
                {

                }

            }
            else
            {
                base.ShowErrorMessage("找不到卡编号，请再次尝试。");
            }
        }

        private void livHistoryRecord_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (livHistoryRecord.Sorting == SortOrder.Ascending)
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Descending);
                livHistoryRecord.ListViewItemSorter = sorter;
                livHistoryRecord.Sorting = SortOrder.Descending;
            }
            else
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Ascending);
                livHistoryRecord.ListViewItemSorter = sorter;
                livHistoryRecord.Sorting = SortOrder.Ascending;
            }
        }



    }
}
