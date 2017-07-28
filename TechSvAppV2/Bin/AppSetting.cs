using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin
{
    public class AppSetting
    {

        private static string _codeKey;
        private static string _date;
        public static bool AppIDControl(string AppID)
        {
            try
            {
                if (AppID == ConfigurationSettings.AppSettings["AppID"].ToString())
                    if (Data.AppSettingsData.AppID == ConfigurationSettings.AppSettings["AppID"].ToString())
                        return true;
            }
            catch 
            {
                return false;
            }
            return false;
        }
        public static bool CustomerIDControl(string CustomerID)
        {
            try
            {
                if (CustomerID == ConfigurationSettings.AppSettings["CustomerID"].ToString())
                    if (Data.AppSettingsData.CustomerID == ConfigurationSettings.AppSettings["CustomerID"].ToString())
                        return true;
            }
            catch
            {
                return false;
            }
            return false;
        }
        public static string GetAppID()
        {
            if (AppIDControl(ConfigurationSettings.AppSettings["AppID"].ToString()))
                return ConfigurationSettings.AppSettings["AppID"].ToString();

            return "Demo";
        }
        public static string GetCustomerID()
        {
            if (AppIDControl(ConfigurationSettings.AppSettings["CustomerID"].ToString()))
                return ConfigurationSettings.AppSettings["CustomerID"].ToString();

            return "Demo";

        }
        public static string GetCodeKey()
        {
            return ConfigurationSettings.AppSettings["CodeKey"].ToString();
        }
        public static string CreatCodeKey()
        {
            _date = DateTime.Now.ToShortDateString();
            return GetCodeKey() + _date.Split('.')[0] + _date.Split('.')[1] + _date.Split('.')[2];
        }
        public static string CreatCodeKey(int Count)
        {
            _codeKey = string.Empty;
            _date = DateTime.Now.ToShortDateString();
            for (int i = Count.ToString().Length; i < 4 ; i++)
            {
                _codeKey += "0";

            }
            return GetCodeKey() + _date.Split('.')[0] + _date.Split('.')[1]+ _date.Split('.')[2]+_codeKey + Count.ToString();
        }
        public static string GetAppID(string AppID)
        {
            if (AppIDControl(AppID))
                return ConfigurationSettings.AppSettings["AppID"].ToString();

            return "Demo";
        }
        public static string GetCustomerID(string CustomerID)
        {
            if (AppIDControl(CustomerID))
                return ConfigurationSettings.AppSettings["CustomerID"].ToString();

            return "Demo";
        }


        public static Entity.AppConfig GetAppConfig()
        {
            return (Bin.ActionEvent.AppConfigActionEvents.GetList().Model as List<Entity.AppConfig>).FirstOrDefault();
        }

    }
}
