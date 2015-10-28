using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;

namespace Common
{
    public static class DefineConstantValue
    {
        //public DefineConstantValue() { }

        /// <summary>
        /// 系統信息提示描述定义
        /// </summary>
        public struct SystemMessage
        {
            public string strSystemText;
            /// <summary>
            /// 系统提示
            /// </summary>
            public string strSystemMessage;
            /// <summary>
            /// 错误
            /// </summary>
            public string strSystemError;
            /// <summary>
            /// 询问
            /// </summary>
            public string strQuestion;
            /// <summary>
            /// 信息
            /// </summary>
            public string strInformation;
            /// <summary>
            /// 警告
            /// </summary>
            public string strWarning;
            /// <summary>
            /// 密码输入框
            /// </summary>
            public string strInputBoxPassword;
            /// <summary>
            /// 标题
            /// </summary>
            public string strMessageTitle;
            /// <summary>
            /// 信息--提示记录已被删除
            /// </summary>
            public string strMessageText_I_RecordByDelete;
            /// <summary>
            /// 信息--提示记录存档失败
            /// </summary>
            public string strMessageText_I_SaveFail;
            /// <summary>
            /// 信息--提示记录新增成功
            /// </summary>
            public string strMessageText_I_AddSuccess;
            /// <summary>
            /// 信息--提示记录新增失敗
            /// </summary>
            public string strMessageText_I_AddFail;
            /// <summary>
            /// 信息--提示记录存档成功
            /// </summary>
            public string strMessageText_I_SaveSuccess;
            /// <summary>
            /// 信息--提示记录修改成功
            /// </summary>
            public string strMessageText_I_UpdateSuccess;
            /// <summary>
            /// 信息--提示记录修改失敗
            /// </summary>
            public string strMessageText_I_UpdateFail;
            /// <summary>
            /// 信息--提示文件上传失敗
            /// </summary>
            public string strMessageText_I_UploadFileFail;
            /// <summary>
            /// 信息--提示已经存在记录
            /// </summary>
            public string strMessageText_I_RecordIsExist;
            /// <summary>
            /// 信息--提示用户沒有功能权限
            /// </summary>
            public string strMessageText_I_strNotPurviewTitle;
            /// <summary>
            /// 没有找到记录
            /// </summary>
            public string strMessageText_I_strNotFindRecord;
            /// <summary>
            /// 输入密码提示
            /// </summary>
            public string strMessageText_I_strInputPassword;
            /// <summary>
            /// 信息--提示选择要打印的记录
            /// </summary>
            public string strMessageText_I_SelectRecordToPrint;
            /// <summary>
            /// 导出文件成功
            /// </summary>
            public string strMessageText_I_ExportFileSuccess;
            /// <summary>
            /// 询问--是否要取消
            /// </summary>
            public string strMessageText_Q_Cancel;
            /// <summary>
            /// 询问--是否要取消新增记录
            /// </summary>
            public string strMessageText_Q_Cancel_NR;
            /// <summary>
            /// 询问--是否要取消修改记录
            /// </summary>
            public string strMessageText_Q_Cancel_UR;
            /// <summary>
            /// 询问--是否要退出窗口
            /// </summary>
            public string strMessageText_Q_ExitWinForm;
            /// <summary>
            /// 询问--是否要退出程序
            /// </summary>
            public string strMessageText_Q_ExitApplication;
            /// <summary>
            /// 询问--是否要修改记录
            /// </summary>
            public string strMessageText_Q_RecordByUpdate;
            /// <summary>
            /// 询问--是否要删除记录
            /// </summary>
            public string strMessageText_Q_Delete;
            /// <summary>
            /// 询问--记录已存在是否要显示
            /// </summary>
            public string strMessageText_Q_RecordIsExistToDisp;
            /// <summary>
            /// 询问--是否继续新增记录
            /// </summary>
            public string strMessageText_Q_ContinueAddRecord;

            /// <summary>
            /// 询问--是否打印所选择的记录
            /// </summary>
            public string strMessageText_Q_PrintSelectedRecord;

            /// <summary>
            /// 询问--是否打印充值凭证
            /// </summary>
            public string strMessageText_Q_PrintRechargeMoneyVoucher;

            /// <summary>
            /// 询问--是否打印充值历史凭证
            /// </summary>
            public string strMessageText_Q_PrintRechargeMoneyHistoryVoucher;

            /// <summary>
            /// 警告--不可以为空，请输入
            /// </summary>
            public string strMessageText_W_CannotEmpty;
            /// <summary>
            /// 警告--搜索条件不可以为空，请输入
            /// </summary>
            public string strMessageText_W_ConditionCannotEmpty;
            /// <summary>
            /// 警告--要保存的记录为空
            /// </summary>
            public string strMessageText_W_RecordIsEmpty;
            /// <summary>
            /// 警告--对象不能为空对象
            /// </summary>
            public string strMessageText_W_ObjectCannotNull;
            /// <summary>
            /// 错误--发生未知错误
            /// </summary>
            public string strMessageText_E_UnknownError;
            /// <summary>
            /// 错误--对象为空
            /// </summary>
            public string strMessageText_E_ObjectNull;
            /// <summary>
            ///  错误--更新对象为空
            /// </summary>
            public string strMessageText_E_UpdateDataNull;
            /// <summary>
            /// 错误--删除对象为空
            /// </summary>
            public string strMessageText_E_DeleteDataNull;
            /// <summary>
            /// 错误--删除对象存在有关链字记录
            /// </summary>
            public string strMessageText_E_DeleteObjectHaveContectData;


            public SystemMessage(string str)
            {
                this.strSystemText = "江门利奥信领科技有限公司";
                this.strSystemMessage = "系统提示";
                this.strSystemError = "错误: ";
                this.strQuestion = "询问: ";
                this.strInformation = "信息: ";
                this.strWarning = "警告: ";
                this.strInputBoxPassword = "密码输入框:";
                this.strMessageTitle = "系统--";
                this.strMessageText_I_RecordByDelete = "记录已被删除!";
                this.strMessageText_I_SaveSuccess = "保存成功。";
                this.strMessageText_I_SaveFail = "保存不成功。";
                this.strMessageText_I_AddSuccess = "新增记录成功。";
                this.strMessageText_I_AddFail = "新增记录失败。";
                this.strMessageText_I_UpdateSuccess = "修改成功。";
                this.strMessageText_I_UpdateFail = "修改失败。";
                this.strMessageText_I_UploadFileFail = "文件上传失败。";
                this.strMessageText_I_RecordIsExist = "记录已存在。";
                this.strMessageText_I_strNotPurviewTitle = "您没有权限使用此功能。";
                this.strMessageText_I_strInputPassword = "请输入密码。";
                this.strMessageText_I_strNotFindRecord = "没有找到符合条件的记录。";
                this.strMessageText_I_SelectRecordToPrint = "请选择要进行打印的记录。";
                this.strMessageText_I_ExportFileSuccess = "导出文件成功。";
                this.strMessageText_Q_Delete = "是否确认需要删除此记录？";
                this.strMessageText_Q_Cancel = "是否确认要取消？";
                this.strMessageText_Q_Cancel_NR = "是否确认需要取消新增记录?";
                this.strMessageText_Q_Cancel_UR = "是否确认需要取消修改记录?";
                this.strMessageText_Q_ExitWinForm = "是否确定需要退出?";
                this.strMessageText_Q_ExitApplication = "是否确定需要关闭程序?";
                this.strMessageText_Q_RecordByUpdate = "记录已被修改，要继续存档吗?";
                this.strMessageText_Q_RecordIsExistToDisp = "记录已存在，要显示此记录吗?";
                this.strMessageText_Q_ContinueAddRecord = "是否继续新增记录?";
                this.strMessageText_Q_PrintSelectedRecord = "是否打印所选择的记录？";
                this.strMessageText_Q_PrintRechargeMoneyVoucher = "是否打印充值凭证？";
                this.strMessageText_Q_PrintRechargeMoneyHistoryVoucher = "是否打印所选的历史充值记录凭证？";
                this.strMessageText_W_CannotEmpty = "不可以为空，请输入。";
                this.strMessageText_W_ConditionCannotEmpty = "搜索条件不可以为空，请输入。";
                this.strMessageText_W_RecordIsEmpty = "记录为空。";
                this.strMessageText_W_ObjectCannotNull = "对象不能为空。";
                this.strMessageText_E_UnknownError = "发生未知错误。";

                this.strMessageText_E_ObjectNull = "对象为空。";
                this.strMessageText_E_UpdateDataNull = "更新对象为空。";
                this.strMessageText_E_DeleteDataNull = "删除对象为空。";
                this.strMessageText_E_DeleteObjectHaveContectData = "删除对象存在有关链字记录。";
            }
        }
        /// <summary>
        /// 系統信息提示描述定义
        /// </summary>
        public static readonly SystemMessage SystemMessageText = new SystemMessage(string.Empty);

        /// <summary>
        ///发送通知服务消息类型
        /// </summary>
        public enum SendMessageType
        {
            SMS = 0,
            EMAIL = 1,
            SMSandEMAIL = 2,
            SMSorEMAIL = 3
        }

        /// <summary>
        /// 标识Class对数据库的操作(用过位运算保存Object的操作)
        /// </summary>
        public enum EditStateEnum
        {
            OE_Insert = 1,
            OE_Update = 2,
            OE_Delete = 4,
            OE_ReaOnly = 8,
        }

        /// <summary>
        /// 标识Class对数据库的操作(用过位运算保存Object的操作)
        /// </summary>
        public enum GetReocrdEnum
        {
            GR_First = 1,
            GR_Next = 2,
            GR_Middle = 3,
            GR_Previous = 4,
            GR_Last = 8,
            GR_Null = 10
        }

        /// <summary>
        /// 星期，中文对应数字
        /// </summary>
        public enum Week
        {
            星期一 = 1,
            星期二 = 2,
            星期三 = 3,
            星期四 = 4,
            星期五 = 5,
            星期六 = 6,
            星期日 = 0
        }

        /// <summary>
        /// 主档类型
        /// </summary>
        public enum MasterType
        {
            /// <summary>
            /// 卡用户性別
            /// </summary>
            CardUserSex,

            /// <summary>
            /// 卡用户身份
            /// </summary>
            CardUserIdentity,

            /// <summary>
            /// 教师信息
            /// </summary>
            TeacherInfo,

            /// <summary>
            /// CodeMasterKey1
            /// </summary>
            CodeMaster_Key1,

            /// <summary>
            /// CodeMasterKey2
            /// </summary>
            CodeMaster_Key2,

            /// <summary>
            /// 卡用户主档
            /// </summary>
            CardUser,

            /// <summary>
            /// 年级主档
            /// </summary>
            Grade,

            /// <summary>
            /// 系统定义_班级定义
            /// </summary>
            CodeMaster_Class,

            /// <summary>
            /// 用户班级主档
            /// </summary>
            UserClass,

            /// <summary>
            /// 用户部门主档
            /// </summary>
            UserDepartment,

            /// <summary>
            /// 教师信息
            /// </summary>
            Staff,

            /// <summary>
            /// 支出费用类型
            /// </summary>
            CostType,

            /// <summary>
            /// 用户有效性
            /// </summary>
            UserValid
        }

        /// <summary>
        /// 报表文件根目录
        /// </summary>
        public static string ReportFileBasePath = Application.StartupPath + @"\Report\RDLC\";

        /// <summary>
        /// 日期格式  yyyy/MM/dd
        /// </summary>
        public const string gc_DateFormat = "yyyy/MM/dd";

        /// <summary>
        /// 日期格式  yyyy-MM-dd
        /// </summary>
        public const string gc_DateFormat2 = "yyyy-MM-dd";

        /// <summary>
        /// 密码日期格式 "yyyy,MM,dd"
        /// </summary>
        public const string gc_PwdDateFormat = "yyyy,MM,dd";

        /// <summary>
        /// 查询后返回最大行数
        /// </summary>
        public const int ListRecordMaxCount = 10000;

        /// <summary>
        /// 充值时允许充值的最大额
        /// </summary>
        public const decimal MaxRechargeVal = 1000;

        /// <summary>
        /// 批量充值时允许单次充值的最大记录数
        /// </summary>
        public const decimal MaxRechargeCount = 5000;

        /// <summary>
        /// 自动系统通知几个小时内有效
        /// </summary>
        public const int AutoMessageNowSendEffectiveHour = 2;

        /// <summary>
        /// 长日期時間格式
        /// </summary>
        public const string gc_DateTimeFormat = "yyyy/MM/dd HH:mm:ss";

        public const string gc_DateTimeFormat2 = "HH:mm";

        /// <summary>
        /// 锁记录的最大时间（小时）
        /// </summary>
        public const short LockRecordMaxTime = 5;

        /// <summary>
        /// 系统文件路径
        /// </summary>
        public static string FilesPath = Application.StartupPath + @"\Files\";

        /// <summary>
        /// 系统类型主档记录中的编号与名称的分隔符号定义
        /// </summary>
        public static string SystemTypeMasterRecordNumAndNameSeparator = "-";

        /// <summary>
        /// 功能描述
        /// </summary>
        public struct stuSysFunction
        {
            /// <summary>
            /// 新增
            /// </summary>
            public string INSERT;
            /// <summary>
            /// 修改
            /// </summary>
            public string UPDATE;
            /// <summary>
            /// 删除
            /// </summary>
            public string DELETE;
            /// <summary>
            /// 浏览
            /// </summary>
            public string BROWSE;

            public stuSysFunction(string str)
            {
                this.INSERT = "INSERT";
                this.UPDATE = "UPDATE";
                this.DELETE = "DELETE";
                this.BROWSE = "BROWSE";
            }
        }

        /// <summary>
        /// 导入文件类型筛选内容
        /// </summary>
        public struct ImportFileFilterStruct
        {
            /// <summary>
            /// 97-2003 版Excel
            /// </summary>
            public string ExExcel;

            public ImportFileFilterStruct(string strParam)
            {
                ExExcel = "Microsoft Excel 97 - 2003 文件(*.xls)|*.xls|所有文件(*.*)|*.*";
            }
        }
        /// <summary>
        /// 导入文件类型筛选内容
        /// </summary>
        public static readonly ImportFileFilterStruct ImportFileFilter = new ImportFileFilterStruct(string.Empty);

        public struct CodeMasterDefineStruct
        {
            /// <summary>
            /// Key1值定义--卡用户管理主档.性別
            /// </summary>
            public string KEY1_SIOT_CardUserSex;

            /// <summary>
            /// KEY2值定义--卡用户管理主档.性别.男性
            /// </summary>
            public string KEY2_SIOT_CardUserSex_MALE;

            /// <summary>
            /// KEY2值定义--卡用户管理主档.性别.女性
            /// </summary>
            public string KEY2_SIOT_CardUserSex_FEMALE;

            /// <summary>
            /// Key1值定义--卡用户管理主档.身份
            /// </summary>
            public string KEY1_SIOT_CardUserIdentity;

            /// <summary>
            /// Key2值定义--卡用户身份--学生
            /// </summary>
            public string KEY2_SIOT_CardUserIdentity_Student;

            /// <summary>
            /// Key2值定义--卡用户身份--教职人員
            /// </summary>
            public string KEY2_SIOT_CardUserIdentity_Staff;

            /// <summary>
            /// Key1值定义--卡用户管理主档.班級
            /// </summary>
            public string KEY1_SIOT_CardUserClass;

            /// <summary>
            /// 系统固定费用
            /// </summary>
            public string KEY1_ConstantExpenses;
            /// <summary>
            /// 新卡工本费
            /// </summary>
            public string KEY2_NewCardCost;
            /// <summary>
            /// 换卡费用
            /// </summary>
            public string KEY2_ExchangeCardCost;
            /// <summary>
            /// 预支费用
            /// </summary>
            public string KEY2_AdvanceCost;
            /// <summary>
            /// 定餐金额-早餐
            /// </summary>
            public string KEY2_SetBreakfast;
            /// <summary>
            /// 定餐金额-午餐
            /// </summary>
            public string KEY2_SetLunch;
            /// <summary>
            /// 定餐金额-晚餐
            /// </summary>
            public string KEY2_SetSupper;

            /// <summary>
            /// 消费数据收集时间
            /// </summary>
            public string KEY1_RecordCollectInterval;
            /// <summary>
            /// 黑名单上传时间
            /// </summary>
            public string KEY1_BWListUploadInterval;
            /// <summary>
            /// 就餐时段
            /// </summary>
            public string KEY1_MealTimeSpan;

            /// <summary>
            /// 支出费用类型
            /// </summary>
            public string KEY1_SIOT_CostType;

            public CodeMasterDefineStruct(string str)
            {
                this.KEY1_SIOT_CardUserSex = "SIOT_CARDUSERSEX";
                this.KEY2_SIOT_CardUserSex_MALE = "MALE";
                this.KEY2_SIOT_CardUserSex_FEMALE = "FEMALE";

                this.KEY1_SIOT_CardUserIdentity = "SIOT_CARDUSERIDENTITY";
                this.KEY2_SIOT_CardUserIdentity_Student = "STUDENT";
                this.KEY2_SIOT_CardUserIdentity_Staff = "STAFF";

                this.KEY1_ConstantExpenses = "CONSTANTEXPENSES";
                this.KEY2_NewCardCost = "NEWCARDCOST";
                this.KEY2_ExchangeCardCost = "EXCHANGECARDCOST";
                this.KEY2_AdvanceCost = "ADVANCECOST";
                this.KEY2_SetBreakfast = "SETBREAKFAST";
                this.KEY2_SetLunch = "SETLUNCH";
                this.KEY2_SetSupper = "SETSUPPER";

                this.KEY1_SIOT_CardUserClass = "SIOT_CARDUSERCLASS";

                this.KEY1_SIOT_CostType = "SIOT_COSTTYPE";

                this.KEY1_RecordCollectInterval = "RECORDCOLLECTINTERVAL";

                this.KEY1_BWListUploadInterval = "BWLISTUPLOADINTERVAL";

                this.KEY1_MealTimeSpan = "MEALTIMESPAN";
            }
        }
        /// <summary>
        /// 字码主档定义
        /// </summary>
        public static readonly CodeMasterDefineStruct CodeMasterDefine = new CodeMasterDefineStruct(string.Empty);

        #region **************************************未启用********************************************************

        public struct FormFunctionNum
        {
            /// <summary>
            /// 新增
            /// </summary>
            public string New;

            /// <summary>
            /// 修改
            /// </summary>
            public string Modify;

            /// <summary>
            /// 刪除
            /// </summary>
            public string Delete;

            /// <summary>
            /// 发卡
            /// </summary>
            public string CardIssuance;

            /// <summary>
            /// 导入
            /// </summary>
            public string DataInput;

            /// <summary>
            /// 导出
            /// </summary>
            public string DataExport;

            /// <summary>
            /// 退卡
            /// </summary>
            public string CardReturn;

            /// <summary>
            /// 掛失
            /// </summary>
            public string CardMissing;

            /// <summary>
            /// 解掛
            /// </summary>
            public string CardRecovery;

            /// <summary>
            /// 報廢
            /// </summary>
            public string CardScrap;

            /// <summary>
            /// 浏览
            /// </summary>
            public string BROWSE;

            /// <summary>
            /// 查询
            /// </summary>
            public string SEARCH;

            /// <summary>
            /// 导出卡用户数据
            /// </summary>
            public string ExpCusData;

            /// <summary>
            /// 导出卡用户数据模板
            /// </summary>
            public string ExportTemplate;

            /// <summary>
            /// 导出相片
            /// </summary>
            public string ExportCardUserPhoto;

            /// <summary>
            /// 导入卡用户数据相片
            /// </summary>
            public string ImportCardUserPhoto;

            /// <summary>
            /// 导入卡用户数据
            /// </summary>
            public string ImportCardUserData;

            /// <summary>
            /// 卡用户 用户监控事项组别设定
            /// </summary>
            public string GroupPersonSetting;

            /// <summary>
            /// 职工请假
            /// </summary>
            public string StaffAbsence;

            /// <summary>
            /// 学生请假
            /// </summary>
            public string StudentAbsence;

            /// <summary>
            /// 导入题库
            /// </summary>
            public string ImportTheme;

            /// <summary>
            /// 导出题库
            /// </summary>
            public string ExportTheme;

            public FormFunctionNum(string txt)
            {
                this.New = "NEW";
                this.Modify = "MODIFY";
                this.Delete = "DELETE";
                this.CardIssuance = "CARDISSUANCE";
                this.DataInput = "DATAINPUT";
                this.CardReturn = "CARDRETURN";
                this.CardMissing = "CARDMISSING";
                this.CardRecovery = "CARDRECOVERY";
                this.CardScrap = "CARDSCRAP";
                this.BROWSE = "BROWSE";
                this.SEARCH = "SEARCH";
                this.DataExport = "DATAEXPORT";
                this.ExpCusData = "EXPCUSDATA";
                this.ExportTemplate = "EXPROTTEMPLATE";
                this.ExportCardUserPhoto = "EXPROTCARDUSERPHOTO";
                this.ImportCardUserPhoto = "IMPORTCARDUSERPHOTO";
                this.ImportCardUserData = "IMPORTCARDUSERDATA";
                this.GroupPersonSetting = "GROUPPERSONSETTING";

                this.StaffAbsence = "STAFFABSENCE";
                this.StudentAbsence = "STUDENTABSENCE";

                this.ImportTheme = "IMPORTTHEME";
                this.ExportTheme = "EXPORTTHEME";
            }
        }
        /// <summary>
        /// 界面功能编号
        /// </summary>
        public static readonly FormFunctionNum Sys_FormFunctionNum = new FormFunctionNum(string.Empty);

        /// <summary>
        ///日志内容类型
        /// </summary>
        public struct SIOT_LogDetailType
        {
            /// <summary>
            /// 异常型记录
            /// </summary>
            public string TypeError;
            /// <summary>
            /// 特殊型记录
            /// </summary>
            public string TypeWarning;
            /// <summary>
            /// 普通型记录
            /// </summary>
            public string TypeTrace;

            public SIOT_LogDetailType(string str)
            {
                this.TypeError = "Error";
                this.TypeWarning = "Warning";
                this.TypeTrace = "Trace";
            }
        }
        /// <summary>
        /// 日志内容类型
        /// </summary>
        public static readonly SIOT_LogDetailType SIOT_LogDetailTypeDefine = new SIOT_LogDetailType(string.Empty);

        /// <summary>
        /// 短信息自动发送平台数据类型
        /// </summary>
        public struct SIOT_AutoSendMessageFuctionName
        {
            public SIOT_AutoSendMessageFuctionName(string str)
            {
            }
        }
        /// <summary>
        /// 短信息自动发送平台数据类型
        /// </summary>
        public static readonly SIOT_AutoSendMessageFuctionName SIOT_AutoSendMessageFuctionNameDefine = new SIOT_AutoSendMessageFuctionName(string.Empty);

        #endregion

        /// <summary>
        /// 消费现金流类型
        /// </summary>
        public enum ConsumeMoneyFlowType
        {
            #region 充值类型集合

            /// <summary>
            /// 可透支款
            /// </summary>
            Recharge_AdvanceMoney,
            /// <summary>
            /// 个人实时卡充值
            /// </summary>
            Recharge_PersonalRealTime,
            /// <summary>
            /// 个人转账卡充值
            /// </summary>
            Recharge_PersonalTransfer,
            /// <summary>
            /// 批量转账卡充值
            /// </summary>
            Recharge_BatchTransfer,

            #endregion

            #region  退款类型集合

            /// <summary>
            /// 个人现金退款
            /// </summary>
            Refund_PersonalCash,
            /// <summary>
            /// 个人实时卡退款
            /// </summary>
            Refund_CardPersonalRealTime,
            /// <summary>
            /// 个人转账卡退款
            /// </summary>
            Refund_PersonalTransfer,
            /// <summary>
            /// 批量转账卡退款
            /// </summary>
            Refund_BatchTransfer,

            #endregion

            /// <summary>
            /// 对冲金额
            /// </summary>
            HedgeFund,

            /// <summary>
            /// 新卡工本费
            /// </summary>
            NewCardCost,

            /// <summary>
            /// 换卡工本费
            /// </summary>
            ReplaceCardCost,

            /// <summary>
            /// 定餐消费
            /// </summary>
            SetMealCost,

            /// <summary>
            /// 普通金额消费
            /// </summary>
            FreeMealCost,

            /// <summary>
            /// 定餐待扣款
            /// </summary>
            AdvanceMealCost,

            /// <summary>
            /// 预扣费款项还款
            /// </summary>
            PreCostRecharge,

            /// <summary>
            /// 定餐未确定扣款
            /// </summary>
            IndeterminateCost,
        }
        #region  消费现金流类型中文描述
        /// <summary>
        /// 获取消费现金流类型描述
        /// </summary>
        /// <param name="flowType"></param>
        /// <returns></returns>
        public static string GetMoneyFlowDesc(ConsumeMoneyFlowType flowType)
        {
            string strName = string.Empty;
            switch (flowType)
            {
                case ConsumeMoneyFlowType.Recharge_AdvanceMoney:
                    strName = "可透支款";
                    break;
                case ConsumeMoneyFlowType.Recharge_PersonalRealTime:
                    strName = "个人实时卡充值";
                    break;
                case ConsumeMoneyFlowType.Recharge_PersonalTransfer:
                    strName = "个人转账卡充值";
                    break;
                case ConsumeMoneyFlowType.Recharge_BatchTransfer:
                    strName = "批量转账卡充值";
                    break;
                case ConsumeMoneyFlowType.Refund_PersonalCash:
                    strName = "个人现金退款";
                    break;
                case ConsumeMoneyFlowType.Refund_CardPersonalRealTime:
                    strName = "个人实时卡退款";
                    break;
                case ConsumeMoneyFlowType.Refund_PersonalTransfer:
                    strName = "个人转账卡退款";
                    break;
                case ConsumeMoneyFlowType.Refund_BatchTransfer:
                    strName = "批量转账卡退款";
                    break;
                case ConsumeMoneyFlowType.HedgeFund:
                    strName = "对冲金额";
                    break;
                case ConsumeMoneyFlowType.NewCardCost:
                    strName = "新卡工本费";
                    break;
                case ConsumeMoneyFlowType.ReplaceCardCost:
                    strName = "换卡工本费";
                    break;
                case ConsumeMoneyFlowType.SetMealCost:
                    strName = "定餐消费";
                    break;
                case ConsumeMoneyFlowType.FreeMealCost:
                    strName = "普通金额消费";
                    break;
                case ConsumeMoneyFlowType.AdvanceMealCost:
                    strName = "定餐待扣费";
                    break;
                //case ConsumeMoneyFlowType.PreCostRecharge:
                //    strName = "预扣费款项还款";
                //    break;
                case ConsumeMoneyFlowType.IndeterminateCost:
                    strName = "定餐未确定扣款";
                    break;
                default:
                    break;
            }

            return strName;
        }
        /// <summary>
        /// 获取消费现金流类型描述
        /// </summary>
        /// <param name="macType"></param>
        /// <returns></returns>
        public static string GetMoneyFlowDesc(string strFlowType)
        {
            string strName = string.Empty;
            if (strFlowType == ConsumeMoneyFlowType.AdvanceMealCost.ToString())
                strName = "定餐待扣款";
            else if (strFlowType == ConsumeMoneyFlowType.FreeMealCost.ToString())
                strName = "普通金额消费";
            else if (strFlowType == ConsumeMoneyFlowType.HedgeFund.ToString())
                strName = "对冲金额";
            else if (strFlowType == ConsumeMoneyFlowType.NewCardCost.ToString())
                strName = "新卡工本费";
            //else if (strFlowType == ConsumeMoneyFlowType.PreCostRecharge.ToString())
            //    strName = "预扣费款项还款";
            else if (strFlowType == ConsumeMoneyFlowType.Recharge_AdvanceMoney.ToString())
                strName = "可透支款";
            else if (strFlowType == ConsumeMoneyFlowType.Recharge_BatchTransfer.ToString())
                strName = "批量转账卡充值";
            else if (strFlowType == ConsumeMoneyFlowType.Recharge_PersonalRealTime.ToString())
                strName = "个人实时卡充值";
            else if (strFlowType == ConsumeMoneyFlowType.Recharge_PersonalTransfer.ToString())
                strName = "个人转账卡充值";
            else if (strFlowType == ConsumeMoneyFlowType.Refund_BatchTransfer.ToString())
                strName = "批量转账卡退款";
            else if (strFlowType == ConsumeMoneyFlowType.Refund_CardPersonalRealTime.ToString())
                strName = "个人实时卡退款";
            else if (strFlowType == ConsumeMoneyFlowType.Refund_PersonalCash.ToString())
                strName = "个人现金退款";
            else if (strFlowType == ConsumeMoneyFlowType.Refund_PersonalTransfer.ToString())
                strName = "个人转账卡退款";
            else if (strFlowType == ConsumeMoneyFlowType.ReplaceCardCost.ToString())
                strName = "换卡工本费";
            else if (strFlowType == ConsumeMoneyFlowType.SetMealCost.ToString())
                strName = "定餐消费";
            else if (strFlowType == ConsumeMoneyFlowType.IndeterminateCost.ToString())
                strName = "定餐未确定扣费";

            return strName;
        }

        #endregion

        /// <summary>
        /// 消费现金流状态
        /// </summary>
        public enum ConsumeMoneyFlowStatus
        {
            /// <summary>
            /// 已完成
            /// </summary>
            Finished,
            /// <summary>
            /// 等待转账
            /// </summary>
            WaitForAcceptTransfer
        }

        /// <summary>
        /// 卡使用状态
        /// </summary>
        public enum CardUseState
        {
            /// <summary>
            /// 未使用
            /// </summary>
            NotUsed,
            /// <summary>
            /// 使用中
            /// </summary>
            InUse
        }

        /// <summary>
        /// 消费卡状态
        /// </summary>
        public enum ConsumeCardStatus
        {
            /// <summary>
            /// 正常
            /// </summary>
            Normal,
            /// <summary>
            /// 挂失中
            /// </summary>
            LoseReporting,
            ///// <summary>
            ///// 已损坏
            ///// </summary>
            //Damaged,
            ///// <summary>
            ///// 已丢失
            ///// </summary>
            //Lost,
            /// <summary>
            /// 已退卡
            /// </summary>
            Returned
        }

        /// <summary>
        /// 消费机类别
        /// </summary>
        public enum ConsumeMachineType
        {
            /// <summary>
            /// 未知类型消费机
            /// </summary>
            Unknown,
            /// <summary>
            /// 学生定餐机
            /// </summary>
            StuSetmeal,
            /// <summary>
            /// 学生加菜机
            /// </summary>
            StuPay,
            /// <summary>
            /// 老师就餐机
            /// </summary>
            TeachPay,
            /// <summary>
            /// 热水计费机
            /// </summary>
            HotWaterPay,
            /// <summary>
            /// 饮料售卖机
            /// </summary>
            DrinkPay,
            /// <summary>
            /// 医疗消费机
            /// </summary>
            MedicalPay
        }
        #region 消费机类别中文说明
        /// <summary>
        /// 获取消费机类型中文说明
        /// </summary>
        /// <param name="macType"></param>
        /// <returns></returns>
        public static string GetMacTypeDesc(ConsumeMachineType macType)
        {
            string strName = string.Empty;
            switch (macType)
            {
                case ConsumeMachineType.Unknown:
                    strName = "未知类型消费机";
                    break;
                case ConsumeMachineType.StuSetmeal:
                    strName = "学生定餐机";
                    break;
                case ConsumeMachineType.StuPay:
                    strName = "学生加菜机";
                    break;
                case ConsumeMachineType.TeachPay:
                    strName = "老师就餐机";
                    break;
                case ConsumeMachineType.HotWaterPay:
                    strName = "热水计费机";
                    break;
                case ConsumeMachineType.DrinkPay:
                    strName = "饮料售卖机";
                    break;
                case ConsumeMachineType.MedicalPay:
                    strName = "医务消费机";
                    break;
                default:
                    break;
            }
            return strName;
        }
        /// <summary>
        /// 获取消费机类型中文说明
        /// </summary>
        /// <param name="macType"></param>
        /// <returns></returns>
        public static string GetMacTypeDesc(string macType)
        {
            string strName = string.Empty;
            if (macType == ConsumeMachineType.StuSetmeal.ToString())
            {
                strName = "学生定餐机";
            }
            else if (macType == ConsumeMachineType.Unknown.ToString())
            {
                strName = "未知类型消费机";
            }
            else if (macType == ConsumeMachineType.StuPay.ToString())
            {
                strName = "学生加菜机";
            }
            else if (macType == ConsumeMachineType.TeachPay.ToString())
            {
                strName = "老师就餐机";
            }
            else if (macType == ConsumeMachineType.HotWaterPay.ToString())
            {
                strName = "热水计费机";
            }
            else if (macType == ConsumeMachineType.DrinkPay.ToString())
            {
                strName = "饮料售卖机";
            }
            else if (macType == ConsumeMachineType.MedicalPay.ToString())
            {
                strName = "医务消费机";
            }
            else
            {
                strName = "未知类型消费机";
            }
            return strName;
        }

        #endregion

        /// <summary>
        /// 消费机状态
        /// </summary>
        public enum ConsumeMachineStatus
        {
            /// <summary>
            /// 使用中
            /// </summary>
            Using,
            /// <summary>
            /// 停用
            /// </summary>
            Stop,
            /// <summary>
            /// 维修中
            /// </summary>
            Repair
        }
        /// <summary>
        /// 消费机使用状态
        /// </summary>
        /// <param name="usingType"></param>
        /// <returns></returns>
        public static string GetMacUsingDesc(ConsumeMachineStatus usingType)
        {
            string strName = string.Empty;
            switch (usingType)
            {
                case ConsumeMachineStatus.Repair:
                    strName = "维修中";
                    break;
                case ConsumeMachineStatus.Stop:
                    strName = "停用";
                    break;
                case ConsumeMachineStatus.Using:
                    strName = "使用中";
                    break;
                default:
                    break;
            }
            return strName;
        }
        /// <summary>
        /// 消费机使用状态
        /// </summary>
        /// <param name="usingType"></param>
        /// <returns></returns>
        public static string GetMacUsingDesc(string usingType)
        {
            string strName = string.Empty;
            if (usingType == ConsumeMachineStatus.Repair.ToString())
            {
                strName = "维修中";
            }
            else if (usingType == ConsumeMachineStatus.Repair.ToString())
            {
                strName = "停用";
            }
            else if (usingType == ConsumeMachineStatus.Using.ToString())
            {
                strName = "使用中";
            }
            else
            {
                strName = "未知使用状态";
            }
            return strName;
        }

        /// <summary>
        /// 就餐类型
        /// </summary>
        public enum MealType
        {
            /// <summary>
            /// 未知
            /// </summary>
            UnKnown = -1,
            /// <summary>
            /// 早餐
            /// </summary>
            Breakfast = 1,
            /// <summary>
            /// 午餐
            /// </summary>
            Lunch = 2,
            /// <summary>
            /// 晚餐
            /// </summary>
            Supper = 3,
            /// <summary>
            /// 学生加菜餐
            /// </summary>
            StuFreeMeal = 4,
            /// <summary>
            /// 老师加菜餐
            /// </summary>
            TechFreeMeal = 5,
            /// <summary>
            /// 热水消费
            /// </summary>
            HotWaterRent = 6,
            /// <summary>
            /// 饮料消费
            /// </summary>
            DrinkCost = 7,
            /// <summary>
            /// 欠费自动停餐
            /// </summary>
            DebtAuto = 8,
            /// <summary>
            /// 医疗消费
            /// </summary>
            MedicalCost = 9
        }
        #region 就餐类型中文描述
        /// <summary>
        /// 获取就餐类型中文说明
        /// </summary>
        /// <param name="mealType"></param>
        /// <returns></returns>
        public static string GetMealTypeDesc(MealType mealType)
        {
            string strName = string.Empty;
            switch (mealType)
            {
                case MealType.Breakfast:
                    strName = "早餐";
                    break;
                case MealType.Lunch:
                    strName = "午餐";
                    break;
                case MealType.Supper:
                    strName = "晚餐";
                    break;
                case MealType.StuFreeMeal:
                    strName = "学生加菜";
                    break;
                case MealType.TechFreeMeal:
                    strName = "老师普通就餐";
                    break;
                case MealType.HotWaterRent:
                    strName = "热水消费";
                    break;
                case MealType.DrinkCost:
                    strName = "饮料消费";
                    break;
                case MealType.MedicalCost:
                    strName = "医疗消费";
                    break;
                default:
                    break;
            }
            return strName;
        }
        /// <summary>
        /// 获取就餐类型中文说明
        /// </summary>
        /// <param name="mealType"></param>
        /// <returns></returns>
        public static string GetMealTypeDesc(string mealType)
        {
            string strName = string.Empty;
            if (mealType == MealType.Breakfast.ToString())
                strName = "早餐";
            else if (mealType == MealType.Lunch.ToString())
                strName = "午餐";
            else if (mealType == MealType.Supper.ToString())
                strName = "晚餐";
            else if (mealType == MealType.StuFreeMeal.ToString())
                strName = "学生加菜";
            else if (mealType == MealType.TechFreeMeal.ToString())
                strName = "老师普通就餐";
            else if (mealType == MealType.TechFreeMeal.ToString())
                strName = "热水消费";
            else if (mealType == MealType.DrinkCost.ToString())
                strName = "饮料消费";
            else if (mealType == MealType.MedicalCost.ToString())
                strName = "医疗消费";
            return strName;
        }

        #endregion

        /// <summary>
        /// 学生定餐设置类型
        /// </summary>
        public enum StuMealBookingType
        {
            /// <summary>
            /// 未知设置
            /// </summary>
            Unknown = -1,
            /// <summary>
            /// 学生自定义设置
            /// </summary>
            StudentCustom = 0,
            /// <summary>
            /// 学生默认设置
            /// </summary>
            StudentDefault = 1,
            /// <summary>
            /// 班级自定义设置
            /// </summary>
            ClassCustom = 2,
            /// <summary>
            /// 班级默认设置
            /// </summary>
            ClassDefault = 3,
            /// <summary>
            /// 年级自定义设置
            /// </summary>
            GradeCustom = 4,
            /// <summary>
            /// 年级默认设置
            /// </summary>
            GradeDefault = 5
        }

        /// <summary>
        /// 计算实际值正负类型枚举
        /// </summary>
        public enum EnumFormulaKey
        {
            /// <summary>
            /// 系统账户公式
            /// </summary>
            ACCOUNTFORMULA_SYS,
            /// <summary>
            /// 用户账户公式
            /// </summary>
            ACCOUNTFORMULA_USER,
            /// <summary>
            /// 预消费记录公式
            /// </summary>
            PRECOSTFORMULA
        }

        /// <summary>
        /// 系统自动编号--学生前缀
        /// </summary>
        public static readonly string UserAutoCode_Student = "STU";

        /// <summary>
        /// 系统自动编号--教师前缀
        /// </summary>
        public static readonly string USerAutoCode_Teacher = "TCH";

        /// <summary>
        /// 黑名单卡操作
        /// </summary>
        public enum EnumBlacklistCardOpt
        {
            /// <summary>
            /// 添加名单
            /// </summary>
            AddList,
            /// <summary>
            /// 移除名单
            /// </summary>
            RemoveList
        }

        /// <summary>
        /// 黑名单操作产生原因
        /// </summary>
        public enum EnumBlacklistReason
        {
            /// <summary>
            /// 解挂/挂失黑名单
            /// </summary>
            BlacklistOpt,
            /// <summary>
            /// 重置定餐计划（欠费停餐的重开餐）
            /// </summary>
            ResetMealBooking,
            /// <summary>
            /// 换卡
            /// </summary>
            CardReplace,
            /// <summary>
            /// 退卡
            /// </summary>
            CardReturned
        }
    }
}
