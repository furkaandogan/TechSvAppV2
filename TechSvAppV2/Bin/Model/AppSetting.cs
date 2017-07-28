using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin.Model
{
    public class AppSettingModel
    {

        public static string AppID= AppID==null?Bin.AppSetting.GetAppID():AppID;
        public static string CustomerID;
        public static string FtpServer;
        public static string FtpUser;
        public static string FtpPassword;

        public string ExFrame_1
        {
            get
            {
                return "/UI;component/View/Controls/" + (Data.AppSetting.Default.ExFrame_1.ToString() == null ? "BrandChart" : Data.AppSetting.Default.ExFrame_1.ToString()) + ".xaml";
            }
        }

        public string ExFrame_2
        {
            get
            {
                return "/UI;component/View/Controls/" + (Data.AppSetting.Default.ExFrame_2.ToString() == null ? "ServiceStatus" : Data.AppSetting.Default.ExFrame_2.ToString()) + ".xaml";
            }
        }

        public string ExFrame_3
        {
            get
            {
                return "/UI;component/View/Controls/" + (Data.AppSetting.Default.ExFrame_3.ToString() == null ? "Notification" : Data.AppSetting.Default.ExFrame_3.ToString()) + ".xaml";
            }
        }
        public string ExFrame_4
        {
            get
            {
                return "/UI;component/View/Controls/" + (Data.AppSetting.Default.ExFrame_4.ToString() == null ? "UseResource" : Data.AppSetting.Default.ExFrame_4.ToString()) + ".xaml";
            }
        }


        #region Singelton

        private static AppSettingModel _instance;

        public static AppSettingModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AppSettingModel();

                return _instance;
            }
        }

        private AppSettingModel()
        {
            AppID = Bin.AppSetting.GetAppID();
            CustomerID = Bin.AppSetting.GetCustomerID();
        }

        #endregion

    }
}
