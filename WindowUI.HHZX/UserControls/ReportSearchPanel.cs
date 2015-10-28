using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model.IModel;
using BLL.IBLL.General;
using BLL.Factory.General;
using BLL.IBLL.HHZX.UserInfomation.CardUserInfo;
using BLL.Factory.HHZX;
using Model.General;
using Model.HHZX.UserInfomation.CardUserInfo;
using WindowUI.HHZX.ClassLibrary.Public;

namespace WindowUI.HHZX.UserControls
{
    public partial class ReportSearchPanel : UserControl
    {
        private IGeneralBL _igBM;
        private IGradeMasterBL _igmBL;

        /// <summary>
        /// 开始月份
        /// </summary>
        public string RSP_MonthFrom
        {
            get
            {
                return cbxMonthFrom.SelectedValue.ToString();
            }
        }
        /// <summary>
        /// 结束月份
        /// </summary>
        public string RSP_MonthTo
        {
            get
            {
                return cbxMonthTo.SelectedValue.ToString();
            }
        }

        /// <summary>
        /// 单个月份选择
        /// </summary>
        public string RSP_SingleMonth
        {
            get
            {
                return cbxSingelMonth.SelectedValue.ToString();
            }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime RSP_TimeFrom
        {
            get
            {
                DateTime dt = DateTime.Parse(this.dtpFrom.Value.ToString("yyyy/MM/dd"));

                return dt;
            }
            set
            { }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime RSP_TimeTo
        {
            get
            {
                DateTime dt = DateTime.Parse(this.dtpTo.Value.ToString("yyyy/MM/dd"));

                return dt;
            }
            set { }
        }

        /// <summary>
        /// 学号
        /// </summary>
        public string RSP_StudentID
        {
            get
            {
                return this.txtStudentID.Text.Trim();
            }
            set
            {
                this.txtStudentID.Text = value;
            }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string RSP_ChaName
        {
            get
            {
                return this.txtChaName.Text;
            }
            set
            {
                this.txtChaName.Text = value;
            }
        }

        /// <summary>
        /// 卡ID
        /// </summary>
        public int RSP_CardID
        {
            get
            {
                try
                {
                    return Int32.Parse(this.nubCardNo.DecimalValue.ToString());
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                if (value == 0)
                {
                    this.nubCardNo.Text = "";
                }
                else
                {
                    this.nubCardNo.Text = value.ToString();
                }


            }
        }

        /// <summary>
        /// 年级ID
        /// </summary>
        public Guid RSP_GradeID
        {
            get
            {
                try
                {
                    return new Guid(cmbGrade.SelectedValue.ToString());
                }
                catch
                {
                    return Guid.Empty;
                }

            }
            set
            {
                cmbGrade.SelectedValue = value;
            }
        }

        /// <summary>
        /// 年级名称
        /// </summary>
        public string RSP_GradeName
        {
            get
            {
                return cmbGrade.SelectedText;
            }
            set
            {
                cmbGrade.SelectedText = value;
            }
        }

        /// <summary>
        /// 班级ID
        /// </summary>
        public Guid RSP_ClassID
        {
            get
            {
                try
                {
                    return new Guid(cmbUserClass.SelectedValue.ToString());
                }
                catch
                {
                    return Guid.Empty;
                }

            }
            set
            {
                cmbUserClass.SelectedValue = value;
            }
        }

        /// <summary>
        /// 班级名称
        /// </summary>
        public string RSP_ClassName
        {
            get
            {
                return cmbUserClass.SelectedText;
            }
            set
            {
                cmbUserClass.SelectedText = value;
            }
        }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string RSP_DepartmentName
        {
            get
            {
                return cmbDepartment.SelectedText;
            }
            set
            {
                cmbDepartment.SelectedText = value;
            }
        }
        /// <summary>
        /// 部门ID
        /// </summary>
        public Guid RSP_DepartmentID
        {
            get
            {
                try
                {
                    return new Guid(cmbDepartment.SelectedValue.ToString());
                }
                catch
                {
                    return Guid.Empty;
                }

            }
            set
            {
                cmbDepartment.SelectedValue = value;
            }
        }

        public bool RSP_IsAllTech
        {
            get
            {
                if (cmbDepartment.Text == "全部")
                {
                    return true;
                }
                return false;
            }
        }

        public bool RSP_IsAllStu
        {
            get
            {
                if (cmbUserClass.Text == "全部")
                {
                    return true;
                }
                return false;
            }
        }

        public bool RSP_SingleMonthVisible
        {
            get
            {
                return this.pnlSingleMonth.Visible;
            }
            set
            {
                this.pnlSingleMonth.Visible = value;
            }
        }

        /// <summary>
        /// 是否显示时间选择
        /// </summary>
        public bool RSP_TimeVisible
        {
            get
            {
                return this.palTime.Visible;
            }
            set
            {
                this.palTime.Visible = value;
            }
        }

        /// <summary>
        /// 是否显示学号
        /// </summary>
        public bool RSP_StudentVisible
        {
            get
            {
                return this.palStudent.Visible;
            }
            set
            {
                this.palStudent.Visible = value;
            }
        }

        /// <summary>
        /// 是否显示姓名
        /// </summary>
        public bool RSP_ChaNameVisible
        {
            get
            {
                return this.palChaName.Visible;
            }
            set
            {
                this.palChaName.Visible = value;
            }
        }

        /// <summary>
        /// 是否显示卡号
        /// </summary>
        public bool RSP_CardNoVisible
        {
            get
            {
                return this.palCardNo.Visible;
            }
            set
            {
                this.palCardNo.Visible = value;
            }
        }
        /// <summary>
        /// 是否显示年级
        /// </summary>
        public bool RSP_GradeVisible
        {
            get
            {
                return this.palGrade.Visible;
            }
            set
            {
                this.palGrade.Visible = value;
            }
        }
        /// <summary>
        /// 是否显示班级
        /// </summary>
        public bool RSP_ClassVisible
        {
            get
            {
                return this.palClass.Visible;
            }
            set
            {
                this.palClass.Visible = value;
            }
        }
        /// <summary>
        /// 是否显示部门
        /// </summary>
        public bool RSP_DepartmentVisible
        {
            get
            {
                return palDepartment.Visible;
            }
            set
            {
                this.palDepartment.Visible = value;
            }
        }

        public bool RSP_MonthVisible
        {
            get
            {
                return pnlMonth.Visible;
            }
            set
            {
                pnlMonth.Visible = value;
            }
        }

        /// <summary>
        /// 生成报表事件
        /// </summary>
        public event EventHandler OnShowReportClick;

        private void ShowReport_Click(object sender, EventArgs e)
        {
            if (this.palTime.Visible == true)
            {
                DateTime startTime = DateTime.Parse(this.dtpFrom.Value.ToString("yyyy/MM/dd"));
                DateTime endTime = DateTime.Parse(this.dtpTo.Value.ToString("yyyy/MM/dd"));

                if (endTime < startTime)
                {
                    MessageBox.Show("结束时间不能少于开始时间！", "提示");
                    return;
                }
            }


            if (this.OnShowReportClick != null)
            {
                this.OnShowReportClick(this, e);
            }
        }

        public ReportSearchPanel()
        {
            InitializeComponent();

            _igBM = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);
            _igmBL = MasterBLLFactory.GetBLL<IGradeMasterBL>(MasterBLLFactory.GradeMaster);

            initMonth();
        }

        /// <summary>
        /// 初始化月份
        /// </summary>
        private void initMonth()
        {
            List<IModelObject> cbbdList = new List<IModelObject>();
            ComboboxDataInfo cmbInfoEpt = new ComboboxDataInfo();
            cmbInfoEpt.DisplayMember = "";
            cmbInfoEpt.ValueMember = "";
            cbbdList.Add(cmbInfoEpt);

            for (int i = 1; i <= 12; i++)
            {
                ComboboxDataInfo cmbInfo = new ComboboxDataInfo();
                cmbInfo.DisplayMember = DateTime.Now.Year.ToString() + "-" + i.ToString().PadLeft(2, '0');
                cmbInfo.ValueMember = cmbInfo.DisplayMember + "-01";
                cbbdList.Add(cmbInfo);
            }

            this.cbxMonthFrom.SetDataSource(cbbdList);
            this.cbxMonthFrom.SelectedIndex = 1;

            this.cbxMonthTo.SetDataSource(cbbdList);
            this.cbxMonthTo.SelectedIndex = DateTime.Now.Month;

            for (int i = 1; i <= 6; i++)
            {
                ComboboxDataInfo cmbInfo = new ComboboxDataInfo();
                cmbInfo.DisplayMember = DateTime.Now.AddYears(1).Year.ToString() + "-" + i.ToString().PadLeft(2, '0');
                cmbInfo.ValueMember = cmbInfo.DisplayMember + "-01";
                cbbdList.Add(cmbInfo);
            }

            this.cbxSingelMonth.SetDataSource(cbbdList);
            this.cbxSingelMonth.SelectedIndex = DateTime.Now.Month;
        }

        /// <summary>
        /// 初始年級下拉框
        /// </summary>
        private void initGrade()
        {
            _igBM = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);
            List<GradeMaster_gdm_Info> list = _igmBL.AllRecords();
            if (list != null)
            {
                List<IModelObject> cbbdList = new List<IModelObject>();

                ComboboxDataInfo cmbInfo = new ComboboxDataInfo();
                cmbInfo.DisplayMember = "";
                cmbInfo.ValueMember = "";

                cbbdList.Add(cmbInfo);

                for (int index = 0; index < list.Count; index++)
                {
                    GradeMaster_gdm_Info gdmInfo = list[index];
                    ComboboxDataInfo cbbInfo = new ComboboxDataInfo();
                    cbbInfo.DisplayMember = gdmInfo.gdm_cGradeName;
                    cbbInfo.ValueMember = gdmInfo.gdm_cRecordID.ToString();

                    cbbdList.Add(cbbInfo);
                }

                this.cmbGrade.SetDataSource(cbbdList);
                this.cmbGrade.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 初始班級下位框
        /// </summary>
        private void initUserClass()
        {
            List<IModelObject> list = new List<IModelObject>();

            if (this.cmbGrade.SelectedValue != null && !String.IsNullOrEmpty(this.cmbGrade.SelectedValue.ToString()))
            {
                _igBM = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);
                list = _igBM.GetMasterDataInformations(Common.DefineConstantValue.MasterType.UserClass, new Guid(this.cmbGrade.SelectedValue.ToString()));

                if (list == null)
                {
                    list = new List<IModelObject>();
                }

                ComboboxDataInfo cmbInfo = new ComboboxDataInfo();
                cmbInfo.DisplayMember = "全部";
                cmbInfo.ValueMember = "";

                list.Add(cmbInfo);

            }
            else
            {
                ComboboxDataInfo cmbInfo = new ComboboxDataInfo();
                cmbInfo.DisplayMember = "";
                cmbInfo.ValueMember = "";

                list.Add(cmbInfo);
            }

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

            this.cmbDepartment.SetDataSource(list);
            this.cmbDepartment.SelectedIndex = list.Count() - 1;
        }

        private void cmbGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            initUserClass();
            this.cmbDepartment.SelectedIndex = -1;
        }

        private void cmbUserClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbDepartment.SelectedIndex = -1;
        }

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbGrade.SelectedIndex = -1;
            this.cmbUserClass.SelectedIndex = -1;
            this.cmbUserClass.DataSource = null;
        }


        private void cmbGrade_Click(object sender, EventArgs e)
        {
            if (cmbGrade.Items.Count == 0)
            {
                initGrade();
            }
        }

        private void cmbUserClass_Click(object sender, EventArgs e)
        {
            if (!RSP_GradeVisible)//如果年級選項是不使用，則顯示全部班級
            {
                List<IModelObject> list = new List<IModelObject>();

                _igBM = GeneralBLLFactory.GetBLL<IGeneralBL>(GeneralBLLFactory.General);
                list = _igBM.GetMasterDataInformations(Common.DefineConstantValue.MasterType.UserClass);

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
        }

        private void cmbDepartment_Click(object sender, EventArgs e)
        {
            initUserDepartment();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Now;
            dtpTo.Value = DateTime.Now;
            txtStudentID.Text = string.Empty;
            txtChaName.Text = string.Empty;
            nubCardNo.Text = string.Empty;
            cmbGrade.SelectedIndex = -1;
            cmbUserClass.SelectedIndex = -1;
            this.cmbUserClass.DataSource = null;
            initUserClass();
            cmbDepartment.SelectedIndex = -1;
            initMonth();
        }
    }
}
