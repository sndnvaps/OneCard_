using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using UKey;

namespace WebService.UKeyRemote
{
    /// <summary>
    /// Summary description for ServiceUKeyRemote
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ServiceUKeyRemote : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetUKeyCode(string Uid, string Pwd)
        {
            string strPwd = string.Empty;
            if (string.IsNullOrEmpty(Uid) || string.IsNullOrEmpty(Pwd))
            {
                return strPwd;
            }
            if (Uid != "Leoth" && Pwd != "!!!aaa111@@@sss222")
            {
                return strPwd;
            }
            try
            {
                AbstractUKey uKey = UKeyFactory.GetUKey();
                var rvInfo = uKey.ReadPassword();
                if (rvInfo.IsSuccess)
                {
                    strPwd = rvInfo.MessageText.ToUpper();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strPwd;
        }
    }
}
