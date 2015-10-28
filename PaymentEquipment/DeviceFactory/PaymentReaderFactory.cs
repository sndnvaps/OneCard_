using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaymentEquipment.IDevice;
using System.Reflection;
using System.Configuration;

namespace PaymentEquipment.DeviceFactory
{
    public sealed class PaymentReaderFactory
    {
        public static string EastRiverReader906 = "PaymentEquipment.DeviceImplement.EastRiverReader";

        /// <summary>
        /// 获得读写器实现类
        /// </summary>
        /// <returns></returns>
        public static AbstractReader CreateWriter()
        {
            try
            {
                string strClassName = ConfigurationSettings.AppSettings["PaymentWriterLab"];
                if (string.IsNullOrEmpty(strClassName))
                {
                    return null;
                }

                Type accessorType = Type.GetType(strClassName, false);
                return (AbstractReader)Activator.CreateInstance(accessorType);
            }
            catch (Exception ex)
            {
                Common.General.WriteLocalLogs(Common.General.GetCurrentFuncName(), ex.Message, string.Empty, SystemLog.SystemLog.LogType.Error, SystemLog.SystemLog.FileType.LogFile);
                return null;
            }
        }

        /// <summary>
        /// 获得读写器实现类
        /// </summary>
        /// <returns></returns>
        public static AbstractReader CreateWriter(string strClassName)
        {
            try
            {
                if (string.IsNullOrEmpty(strClassName))
                {
                    return null;
                }

                Type accessorType = Type.GetType(strClassName, false);
                return (AbstractReader)Activator.CreateInstance(accessorType);
            }
            catch (Exception ex)
            {
                Common.General.WriteLocalLogs(Common.General.GetCurrentFuncName(), ex.Message, string.Empty, SystemLog.SystemLog.LogType.Error, SystemLog.SystemLog.FileType.LogFile);
                return null;
            }

        }
    }
}
