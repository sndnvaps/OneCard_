using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.HHZX.UserInfomation.CardUserInfo;
using Model.HHZX.ComsumeAccount;
using BLL.IBLL.HHZX.ConsumeAccount;
using BLL.Factory.HHZX;
using WindowUI.TQS.ClassLibrary.Public;
using Model.IModel;

namespace WindowsUI.TQS.UserCard
{
    public partial class dlgPreCostDetail : BaseForm
    {
        IPreConsumeRecordBL _IPreConsumeRecordBL;
        CardUserMaster_cus_Info _UserInfo;

        class PreCostDetailInfo
        {
            public Guid RecordID { get; set; }
            public decimal Cost { get; set; }
            public string ConsumeType { get; set; }
            public DateTime ConsumeDate { get; set; }
            public string UserName { get; set; }

            public PreCostDetailInfo(PreConsumeRecord_pcs_Info PreCostInfo)
            {
                RecordID = PreCostInfo.pcs_cRecordID;
                Cost = Math.Round(PreCostInfo.pcs_fCost, 2);
                if (PreCostInfo.pcs_cConsumeType == Common.DefineConstantValue.ConsumeMoneyFlowType.Recharge_AdvanceMoney.ToString())
                {
                    ConsumeType = "透支款补扣";
                }
                else
                {
                    ConsumeType = Common.DefineConstantValue.GetMoneyFlowDesc(PreCostInfo.pcs_cConsumeType);
                }
                ConsumeDate = PreCostInfo.pcs_dConsumeDate;
            }
        }

        public dlgPreCostDetail()
        {
            InitializeComponent();
        }

        public dlgPreCostDetail(CardUserMaster_cus_Info UserInfo)
        {
            InitializeComponent();

            this._UserInfo = UserInfo;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                this._IPreConsumeRecordBL = MasterBLLFactory.GetBLL<IPreConsumeRecordBL>(MasterBLLFactory.PreConsumeRecord);
                if (this._UserInfo != null)
                {
                    List<PreConsumeRecord_pcs_Info> listPreCost = this._IPreConsumeRecordBL.SearchRecords(new PreConsumeRecord_pcs_Info() { pcs_cUserID = this._UserInfo.cus_cRecordID });
                    listPreCost = listPreCost.Where(x => x.pcs_lIsSettled == false
                        && x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.HedgeFund.ToString()
                        && x.pcs_cConsumeType != Common.DefineConstantValue.ConsumeMoneyFlowType.AdvanceMealCost.ToString()
                        ).ToList();
                    if (listPreCost != null && listPreCost.Count > 0)
                    {
                        List<PreCostDetailInfo> listPreCostDetail = new List<PreCostDetailInfo>();
                        foreach (PreConsumeRecord_pcs_Info preItem in listPreCost)
                        {
                            PreCostDetailInfo preDetail = new PreCostDetailInfo(preItem);
                            //2014-02-25 Add 添加定餐消费的餐类型描述
                            if (!string.IsNullOrEmpty(preItem.MealType))
                            {
                                string strMealTypeDesc = Common.DefineConstantValue.GetMealTypeDesc(preItem.MealType);
                                if (!string.IsNullOrEmpty(strMealTypeDesc))
                                {
                                    preDetail.ConsumeType += "--" + strMealTypeDesc;
                                }
                            }
                            //2014-02-25 End Add
                            preDetail.UserName = this._UserInfo.cus_cChaName;
                            listPreCostDetail.Add(preDetail);
                        }
                        listPreCostDetail = listPreCostDetail.OrderBy(x => x.ConsumeDate).ToList();
                        if (listPreCostDetail != null && listPreCostDetail.Count > 0)
                        {
                            listPreCostDetail = listPreCostDetail.OrderByDescending(x => x.ConsumeDate).ToList();
                            labPreCost.Text = Math.Round(listPreCostDetail.Sum(x => x.Cost), 2).ToString();
                        }

                        lvPreCostDetail.SetDataSource<PreCostDetailInfo>(listPreCostDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex);
            }
        }

        private void lvPreCostDetail_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvPreCostDetail.Sorting == SortOrder.Ascending)
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Descending);
                lvPreCostDetail.ListViewItemSorter = sorter;
                lvPreCostDetail.Sorting = SortOrder.Descending;
            }
            else
            {
                ListViewSorter sorter = new ListViewSorter(e.Column, SortOrder.Ascending);
                lvPreCostDetail.ListViewItemSorter = sorter;
                lvPreCostDetail.Sorting = SortOrder.Ascending;
            }
        }
    }
}
