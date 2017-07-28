using System.Configuration;
using System.Runtime.Serialization;

namespace Entity
{
    [DataContract]
    internal class AppSettings
    {
        private static string _codeKey;
        private static string _date;
        public static bool AppIDControl(string AppID)
        {
            try
            {
                if (AppID == ConfigurationSettings.AppSettings["AppID"].ToString())
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

    }
}
