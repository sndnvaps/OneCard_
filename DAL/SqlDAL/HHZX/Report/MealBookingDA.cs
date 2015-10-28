using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.IDAL.Report;
using Model.HHZX.Report;
using LinqToSQLModel;
using System.Data.SqlClient;
using System.Data;

namespace DAL.SqlDAL.HHZX.Report
{
    public class MealBookingDA : IMealBookingDA
    {

        #region IMainGeneralDA<MealBooking_mbk_info> 成员

        public Model.General.ReturnValueInfo InsertRecord(Model.HHZX.Report.MealBooking_mbk_info infoObject)
        {
            throw new NotImplementedException();
        }

        public Model.General.ReturnValueInfo UpdateRecord(Model.HHZX.Report.MealBooking_mbk_info infoObject)
        {
            throw new NotImplementedException();
        }

        public Model.General.ReturnValueInfo DeleteRecord(Model.IModel.IModelObject KeyObject)
        {
            throw new NotImplementedException();
        }

        public Model.HHZX.Report.MealBooking_mbk_info DisplayRecord(Model.IModel.IModelObject KeyObject)
        {
            throw new NotImplementedException();
        }

        public List<Model.HHZX.Report.MealBooking_mbk_info> SearchRecords(Model.IModel.IModelObject searchCondition)
        {
            List<MealBooking_mbk_info> returnList = new List<MealBooking_mbk_info>();

            try
            {
                MealBooking_mbk_info searchInfo = searchCondition as MealBooking_mbk_info;

                StringBuilder sbSQL = new StringBuilder();
                sbSQL.AppendLine("SELECT TOP");
                sbSQL.AppendLine(Common.DefineConstantValue.ListRecordMaxCount.ToString());
                sbSQL.AppendLine("* FROM ConsumeMachineMaster_cmm WHERE 1 = 1");

                //if (searchInfo != null)
                //{
                //    if (searchInfo.cmm_cRecordID != Guid.Empty)
                //        sbSQL.AppendLine("AND cmm_cRecordID ='" + searchInfo.cmm_cRecordID.ToString() + "'");
                //}

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<MealBooking_mbk_info> query = db.ExecuteQuery<MealBooking_mbk_info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        returnList = query.ToList<MealBooking_mbk_info>();
                    }
                }

            }
            catch
            {

            }
            return returnList;
        }

        public List<Model.HHZX.Report.MealBooking_mbk_info> AllRecords()
        {
            throw new NotImplementedException();
        }

        #endregion


        #region IMealBookingDA 成员

        public List<MealBooking_mbk_info> GetClassBookingHistory(MealBooking_mbk_info searchCondition)
        {
            List<MealBooking_mbk_info> returnList = new List<MealBooking_mbk_info>();

            try
            {
                MealBooking_mbk_info searchInfo = searchCondition as MealBooking_mbk_info;

                String startTime = searchInfo.StartTime.ToString("yyyy/MM/dd");
                String endTime = searchInfo.EndTime.ToString("yyyy/MM/dd");

                StringBuilder sbSQL = new StringBuilder();

                sbSQL.AppendLine("select csm_cClassName as className,userAmount,gdm_cGradeName as gradeName ,'" + startTime + "' as bookingDate ");
                sbSQL.AppendLine(",ISNULL(sum(jhb),0) as breakfast_Est  ");
                sbSQL.AppendLine(",ISNULL(sum(jhl),0) as lunch_Est  ");
                sbSQL.AppendLine(",ISNULL(sum(jhs),0) as dinner_Est  ");
                sbSQL.AppendLine(" ,ISNULL(SUM(sjb),0) as breakfast_Act  ");
                sbSQL.AppendLine(" ,ISNULL(SUM(sjl),0) as lunch_Act  ");
                sbSQL.AppendLine(" ,ISNULL(SUM(sjs),0) as dinner_Act  ");
                sbSQL.AppendLine(" from dbo.CardUserMaster_cus   ");
                sbSQL.AppendLine("join dbo.ClassMaster_csm on cus_cClassID = csm_cRecordID  ");
                sbSQL.AppendLine("join dbo.GradeMaster_gdm on gdm_cRecordID = csm_cGDMID  ");
                sbSQL.AppendLine("join (select Count(*) as userAmount,cus_cClassID as ClassID  ");
               sbSQL.AppendLine(" from dbo.CardUserMaster_cus  ");
                sbSQL.AppendLine("group by cus_cClassID) couc  ");
                sbSQL.AppendLine("on couc.ClassID = csm_cRecordID ");
                sbSQL.AppendLine("left join --計劃早餐  ");
                sbSQL.AppendLine("(select Sum(jhb) as jhb,Sum(jhl) as jhl,Sum(jhs) as jhs,mbh_cTargetID from ");
                sbSQL.AppendLine("(select COUNT(*) as jhb,0 as jhl,0 as jhs,mbh_cTargetID ");
                sbSQL.AppendLine("from dbo.MealBookingHistory_mbh where   ");
                sbSQL.AppendLine(" mbh_cMealType = 'Breakfast'  ");
                sbSQL.AppendLine(" and mbh_lIsSet = 1 ");
                sbSQL.AppendLine(" and mbh_dMealDate < '" + endTime + "' and mbh_dMealDate >='" + startTime + "' ");
                sbSQL.AppendLine("group by mbh_cTargetID --,mbh_dMealDate ");
                sbSQL.AppendLine("union --計劃午餐  ");
               sbSQL.AppendLine(" select 0 as jhb,COUNT(*) as jhl,0 as jhs,mbh_cTargetID ");
               sbSQL.AppendLine(" from dbo.MealBookingHistory_mbh where   ");
                sbSQL.AppendLine(" mbh_cMealType = 'Lunch'  ");
                sbSQL.AppendLine(" and mbh_lIsSet = 1 ");
                sbSQL.AppendLine(" and mbh_dMealDate < '" + endTime + "' and mbh_dMealDate >='" + startTime + "' ");
                sbSQL.AppendLine(" group by mbh_cTargetID ");
               sbSQL.AppendLine(" union --計劃晚餐  ");
               sbSQL.AppendLine(" select 0 as jhb,0 as jhl,COUNT(*) as jhs,mbh_cTargetID  ");
               sbSQL.AppendLine("  from dbo.MealBookingHistory_mbh where   ");
               sbSQL.AppendLine("  mbh_cMealType = 'Supper'  ");
               sbSQL.AppendLine(" and mbh_lIsSet = 1 ");
               sbSQL.AppendLine(" and mbh_dMealDate < '" + endTime + "' and mbh_dMealDate >='" + startTime + "' ");
               sbSQL.AppendLine(" group by mbh_cTargetID) as js group by mbh_cTargetID) jh  ");
               sbSQL.AppendLine(" on jh.mbh_cTargetID = cus_cRecordID  ");
               sbSQL.AppendLine(" left join --實際早餐  ");
                sbSQL.AppendLine("(select Sum(sjb) as sjb,Sum(sjl) as sjl,Sum(sjs) as sjs,csr_cCardUserID from ");
                sbSQL.AppendLine("(select count(*) as sjb,0 as sjl,0 as sjs,csr_cCardUserID from dbo.ConsumeRecord_csr   ");
               sbSQL.AppendLine(" join dbo.CardUserMaster_cus on csr_cCardUserID = cus_cRecordID  ");
               sbSQL.AppendLine(" where csr_cConsumeType = 'StuSetmeal' and csr_cMealType = 'Breakfast'  ");
               sbSQL.AppendLine(" and csr_dConsumeDate < '" + endTime + "' and csr_dConsumeDate >= '" + startTime + "' ");
               sbSQL.AppendLine(" group by csr_cCardUserID  ");
               sbSQL.AppendLine(" union--實際午餐  ");
               sbSQL.AppendLine(" select 0 as sjb,count(*) as sjl,0 as sjs,csr_cCardUserID from dbo.ConsumeRecord_csr   ");
               sbSQL.AppendLine(" join dbo.CardUserMaster_cus on csr_cCardUserID = cus_cRecordID  ");
              sbSQL.AppendLine("  where csr_cConsumeType = 'StuSetmeal' and csr_cMealType = 'Lunch'  ");
              sbSQL.AppendLine(" and csr_dConsumeDate < '" + endTime + "' and csr_dConsumeDate >= '" + startTime + "' ");
              sbSQL.AppendLine(" group by csr_cCardUserID  ");
               sbSQL.AppendLine(" union--實際晚餐  ");
              sbSQL.AppendLine("  select 0 as sjb,0 as sjl,count(*) as sjs,csr_cCardUserID from dbo.ConsumeRecord_csr   ");
              sbSQL.AppendLine("  join dbo.CardUserMaster_cus on csr_cCardUserID = cus_cRecordID  ");
              sbSQL.AppendLine("  where csr_cConsumeType = 'StuSetmeal' and csr_cMealType = 'Supper'  ");
              sbSQL.AppendLine(" and csr_dConsumeDate < '" + endTime + "' and csr_dConsumeDate >= '" + startTime + "' ");
              sbSQL.AppendLine(" group by csr_cCardUserID) as sj group by csr_cCardUserID) sj  ");
               sbSQL.AppendLine(" on sj.csr_cCardUserID = cus_cRecordID   ");
               sbSQL.AppendLine("where 1=1 ");

               if (searchInfo.GradeID != Guid.Empty)
               {
                   sbSQL.AppendLine("and csm_cGDMID = '" + searchInfo.GradeID.ToString() + "'");
               }

               if (searchInfo.ClassID != Guid.Empty)
               {
                   sbSQL.AppendLine("and cus_cClassID = '" + searchInfo.ClassID.ToString() + "'");
               }
               sbSQL.AppendLine(" group by csm_cClassName,gdm_cGradeName ,userAmount ");
               sbSQL.AppendLine(" order by csm_cClassName ");





                //sbSQL.AppendLine("select csm_cClassName as className,userAmount,gdm_cGradeName as gradeName ,mbh_dMealDate");
                //sbSQL.AppendLine(",ISNULL(sum(jhb),0) as breakfast_Est ");
                //sbSQL.AppendLine(",ISNULL(sum(jhl),0) as lunch_Est ");
                //sbSQL.AppendLine(",ISNULL(sum(jhs),0) as dinner_Est ");
                //sbSQL.AppendLine(" ,ISNULL(SUM(sjb),0) as breakfast_Act ");
                //sbSQL.AppendLine(" ,ISNULL(SUM(sjl),0) as lunch_Act ");
                //sbSQL.AppendLine(" ,ISNULL(SUM(sjs),0) as dinner_Act ");
                //sbSQL.AppendLine(" from ");
                //sbSQL.AppendLine("dbo.CardUserMaster_cus  ");
                //sbSQL.AppendLine("join dbo.ClassMaster_csm on cus_cClassID = csm_cRecordID ");
                //sbSQL.AppendLine("join dbo.GradeMaster_gdm on gdm_cRecordID = csm_cGDMID ");
                //sbSQL.AppendLine("join (select Count(*) as userAmount,cus_cClassID as ClassID ");
                //sbSQL.AppendLine("from dbo.CardUserMaster_cus ");
                //sbSQL.AppendLine("group by cus_cClassID) couc ");
                //sbSQL.AppendLine("on couc.ClassID = csm_cRecordID");
                //sbSQL.AppendLine("left join --計劃早餐 ");
                //sbSQL.AppendLine("(select Sum(jhb) as jhb,Sum(jhl) as jhl,Sum(jhs) as jhs,mbh_cTargetID,mbh_dMealDate from");
                //sbSQL.AppendLine("(select COUNT(*) as jhb,0 as jhl,0 as jhs,mbh_cTargetID  ,CONVERT(varchar(100), mbh_dMealDate, 111) as mbh_dMealDate");
                //sbSQL.AppendLine("from dbo.MealBookingHistory_mbh where  ");
                //sbSQL.AppendLine(" mbh_cMealType = 'Breakfast' ");
                //sbSQL.AppendLine(" and mbh_dMealDate <= '" + endTime + "' and mbh_dMealDate >='" + startTime + "' ");
                //sbSQL.AppendLine("group by mbh_cTargetID ,mbh_dMealDate");
                //sbSQL.AppendLine("union --計劃午餐 ");
                //sbSQL.AppendLine("select 0 as jhb,COUNT(*) as jhl,0 as jhs,mbh_cTargetID  ,CONVERT(varchar(100), mbh_dMealDate, 111) as mbh_dMealDate");
                //sbSQL.AppendLine("from dbo.MealBookingHistory_mbh where  ");
                //sbSQL.AppendLine(" mbh_cMealType = 'Lunch' ");
                //sbSQL.AppendLine(" and mbh_dMealDate <= '" + endTime + "' and mbh_dMealDate >='" + startTime + "' ");
                //sbSQL.AppendLine("group by mbh_cTargetID ,mbh_dMealDate");
                //sbSQL.AppendLine("union --計劃晚餐 ");
                //sbSQL.AppendLine("select 0 as jhb,0 as jhl,COUNT(*) as jhs,mbh_cTargetID  ,CONVERT(varchar(100), mbh_dMealDate, 111) as mbh_dMealDate");
                //sbSQL.AppendLine(" from dbo.MealBookingHistory_mbh where  ");
                //sbSQL.AppendLine(" mbh_cMealType = 'Supper' ");
                //sbSQL.AppendLine(" and mbh_dMealDate <= '" + endTime + "' and mbh_dMealDate >='" + startTime + "' ");
                //sbSQL.AppendLine("group by mbh_cTargetID,mbh_dMealDate) as js group by mbh_cTargetID,mbh_dMealDate) jh ");
                //sbSQL.AppendLine("on jh.mbh_cTargetID = cus_cRecordID ");
                //sbSQL.AppendLine("left join --實際晚餐 ");
                //sbSQL.AppendLine("(select Sum(sjb) as sjb,Sum(sjl) as sjl,Sum(sjs) as sjs,csr_cCardUserID from ");
                //sbSQL.AppendLine("(select count(*) as sjb,0 as sjl,0 as sjs,csr_cCardUserID from dbo.ConsumeRecord_csr  ");
                //sbSQL.AppendLine("join dbo.CardUserMaster_cus on csr_cCardUserID = cus_cRecordID ");
                //sbSQL.AppendLine("where csr_cConsumeType = 'StuSetmeal' and csr_cMealType = 'Breakfast' ");
                //sbSQL.AppendLine(" and csr_dConsumeDate <= '" + endTime + "' and csr_dConsumeDate >= '" + startTime + "' ");
                //sbSQL.AppendLine("group by csr_cCardUserID ");
                //sbSQL.AppendLine("union--實際午餐 ");
                //sbSQL.AppendLine("select 0 as sjb,count(*) as sjl,0 as sjs,csr_cCardUserID from dbo.ConsumeRecord_csr  ");
                //sbSQL.AppendLine("join dbo.CardUserMaster_cus on csr_cCardUserID = cus_cRecordID ");
                //sbSQL.AppendLine("where csr_cConsumeType = 'StuSetmeal' and csr_cMealType = 'Lunch' ");
                //sbSQL.AppendLine(" and csr_dConsumeDate <= '" + endTime + "' and csr_dConsumeDate >= '" + startTime + "' ");
                //sbSQL.AppendLine("group by csr_cCardUserID ");
                //sbSQL.AppendLine("union--實際晚餐 ");
                //sbSQL.AppendLine("select 0 as sjb,0 as sjl,count(*) as sjs,csr_cCardUserID from dbo.ConsumeRecord_csr  ");
                //sbSQL.AppendLine("join dbo.CardUserMaster_cus on csr_cCardUserID = cus_cRecordID ");
                //sbSQL.AppendLine("where csr_cConsumeType = 'StuSetmeal' and csr_cMealType = 'Supper' ");
                //sbSQL.AppendLine(" and csr_dConsumeDate <= '" + endTime + "' and csr_dConsumeDate >= '" + startTime + "' ");
                //sbSQL.AppendLine("group by csr_cCardUserID) as sj group by csr_cCardUserID) sj ");
                //sbSQL.AppendLine("on sj.csr_cCardUserID = cus_cRecordID  ");



                //sbSQL.AppendLine("where 1=1 ");

                //if (searchInfo.GradeID != Guid.Empty)
                //{
                //    sbSQL.AppendLine("and csm_cGDMID = '" + searchInfo.GradeID.ToString() + "'");
                //}

                //if(searchInfo.ClassID != Guid.Empty)
                //{
                //    sbSQL.AppendLine("and cus_cClassID = '" + searchInfo.ClassID.ToString() + "'");
                //}

                //sbSQL.AppendLine("group by gdm_cGradeName ,userAmount,mbh_dMealDate ");
                //sbSQL.AppendLine("order by csm_cClassName"); 

                //if (searchInfo != null)
                //{
                //    if (searchInfo.cmm_cRecordID != Guid.Empty)
                //        sbSQL.AppendLine("AND cmm_cRecordID ='" + searchInfo.cmm_cRecordID.ToString() + "'");
                //}

                using (SIOTSDB_HHZXDataContext db = new SIOTSDB_HHZXDataContext())
                {
                    IEnumerable<MealBooking_mbk_info> query = db.ExecuteQuery<MealBooking_mbk_info>(sbSQL.ToString(), new object[] { });
                    if (query != null)
                    {
                        returnList = query.ToList<MealBooking_mbk_info>();
                    }
                }

            }
            catch
            {

            }
            return returnList;
        }



        #endregion

        #region IMealBookingDA 成员

        public List<MealBooking_mbk_info> GetPlanBooking(MealBooking_mbk_info searchCondition)
        {
            List<MealBooking_mbk_info> returnList = new List<MealBooking_mbk_info>();
            try
            {
                if(searchCondition != null)
                {
                    string conectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LinqToSQLModel.Properties.Settings.SIOTS_HHZXDBConnectionString"].ConnectionString;
                    SqlConnection sqlconn = new SqlConnection(conectionString);
                    SqlCommand cmd = new SqlCommand("usp_GetBookingMealReport", sqlconn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300;

                    SqlParameter[] parameters = { 
                    new SqlParameter("@datetime", SqlDbType.DateTime) , 
                    new SqlParameter("@GradeID", SqlDbType.UniqueIdentifier) ,
                    new SqlParameter("@ClassID", SqlDbType.UniqueIdentifier)
                    };

                    parameters[0].Value = searchCondition.StartTime;
                    parameters[1].Value = searchCondition.GradeID;
                    parameters[2].Value = searchCondition.ClassID;

                    cmd.Parameters.Add(parameters[0]);
                    cmd.Parameters.Add(parameters[1]);
                    cmd.Parameters.Add(parameters[2]);
                    sqlconn.Open();
                    //cmd.ExecuteNonQuery();

                    SqlDataAdapter dp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    dp.Fill(dt);

                    if (dt != null)
                    {
                        for (int index = 0; index < dt.Rows.Count; index++)
                        {
                            MealBooking_mbk_info mbk = new MealBooking_mbk_info();
                            mbk.bookingDate = searchCondition.StartTime.ToString("yyyy/MM/dd");
                            mbk.breakfast_Est = Int32.Parse(dt.Rows[index]["breakfast_Est"].ToString());
                            mbk.lunch_Est = Int32.Parse(dt.Rows[index]["lunch_Est"].ToString());
                            mbk.dinner_Est = Int32.Parse(dt.Rows[index]["dinner_Est"].ToString());
                            mbk.className = dt.Rows[index]["className"].ToString();
                            mbk.gradeName = dt.Rows[index]["gradeName"].ToString();
                            mbk.userAmount = Int32.Parse(dt.Rows[index]["userAmount"].ToString());

                            returnList.Add(mbk);

                        }
                    }
                }
            }
            catch
            {

            }

            return returnList;
            
        }

        #endregion
    }
}
