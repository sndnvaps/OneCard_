using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DAL
{
    public class Constant
    {

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string SQLConnectionString
        {
           
            get
            {
                string connectionString = ConfigurationManager.AppSettings["SQLConnectionString"];
                return connectionString;
            }
        }


        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string SQLiteConnectionString
        {
            get
            {
                string connectionString = ConfigurationManager.AppSettings["SQLiteConnectionString"];
                return connectionString;
            }
        }
    }
}
