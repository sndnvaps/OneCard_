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
    public class AccoumtBalanceDA : IAccoumtBalanceDA
    {

        #region IAccoumtBalanceDA 成员

        public List<Model.HHZX.Report.AccoumtBalance_atb_info> GetRecord(Model.HHZX.Report.AccoumtBalance_atb_info infoObject)
        {
            List<AccoumtBalance_atb_info> returnList = new List<AccoumtBalance_atb_info>();
            try
            {
                string conectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LinqToSQLModel.Properties.Settings.SIOTS_HHZXDBConnectionString"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(conectionString);
                SqlCommand cmd = new SqlCommand("usp_GetAccoumtBalanceReport", sqlconn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;

                SqlParameter[] parameters = { 
                    new SqlParameter("@dTimeFrom", SqlDbType.DateTime) , 
                    new SqlParameter("@dTimeTo", SqlDbType.DateTime) ,
                    new SqlParameter("@GradeID", SqlDbType.UniqueIdentifier) ,
                    new SqlParameter("@ClassID", SqlDbType.UniqueIdentifier)
                };

                parameters[0].Value = infoObject.AccountDate_From;
                parameters[1].Value = infoObject.AccountDate_To;
                parameters[2].Value = infoObject.GradeID;
                parameters[3].Value = infoObject.ClassID;

                cmd.Parameters.Add(parameters[0]);
                cmd.Parameters.Add(parameters[1]);
                cmd.Parameters.Add(parameters[2]);
                cmd.Parameters.Add(parameters[3]);
                sqlconn.Open();
                //cmd.ExecuteNonQuery();

                SqlDataAdapter dp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                dp.Fill(dt);

                if (dt != null)
                {
                    for (int index = 0; index < dt.Rows.Count; index++)
                    {
                        AccoumtBalance_atb_info atbInfo = new AccoumtBalance_atb_info();
                        atbInfo.AccountDate = (DateTime)(dt.Rows[index]["AccountDate"] != null ? dt.Rows[index]["AccountDate"] : 0);//统计日期                        
                        atbInfo.BookingMoney = Decimal.Parse(dt.Rows[index]["BookingMoney"].ToString());//定餐统计
                        atbInfo.MealPayMoney = Decimal.Parse(dt.Rows[index]["MealPayMoney"].ToString());//加菜消费
                        atbInfo.HotWaterMoney = Decimal.Parse(dt.Rows[index]["HotWaterMoney"].ToString());//热水消费统计 
                        atbInfo.DrinkMoney = Decimal.Parse(dt.Rows[index]["DrinkMoney"].ToString());//饮料消费统计
                        atbInfo.NightMealMoney = Decimal.Parse(dt.Rows[index]["NightMealMoney"].ToString());//宵夜统计
                        atbInfo.ExpendMoney = Decimal.Parse(dt.Rows[index]["ExpendMoney"].ToString());//部门支出统计
                        atbInfo.BankSavings = Decimal.Parse(dt.Rows[index]["BankSavings"].ToString());//充值额
                        atbInfo.Breakfast_Act = Int32.Parse(dt.Rows[index]["Breakfast_Act"].ToString());//早餐实际数
                        atbInfo.Breakfast_Est = Int32.Parse(dt.Rows[index]["Breakfast_Est"].ToString());//早餐计划数
                        atbInfo.Lunch_Act = Int32.Parse(dt.Rows[index]["Lunch_Act"].ToString());//午餐实际数
                        atbInfo.Lunch_Est = Int32.Parse(dt.Rows[index]["Lunch_Est"].ToString());//午餐计划数
                        atbInfo.Dinner_Act = Int32.Parse(dt.Rows[index]["Dinner_Act"].ToString());//晚餐实际数
                        atbInfo.Dinner_Est = Int32.Parse(dt.Rows[index]["Dinner_Est"].ToString());//晚餐计划数                        
                        atbInfo.TotalMoney = Decimal.Parse(dt.Rows[index]["TotalMoney"].ToString());//账户余额

                        returnList.Add(atbInfo);
                    }
                }


                sqlconn.Close();
            }
            catch
            {

            }
            return returnList;
        }

        #endregion
    }
}
