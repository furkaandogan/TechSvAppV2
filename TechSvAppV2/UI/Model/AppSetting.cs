using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Model
{
    //    public class AppSettingModel
    //    {
    //        public string ExFrame_1
    //        {
    //            get
    //            {
    //                return "/UI;component/View/Controls/" + (UI.AppSetting.Default.ExFrame_1.ToString() == null ? "BrandChart" : UI.AppSetting.Default.ExFrame_1.ToString()) + ".xaml";
    //            }
    //        }

    //        public string ExFrame_2
    //        {
    //            get
    //            {
    //                return "/UI;component/View/Controls/" + (UI.AppSetting.Default.ExFrame_2.ToString() == null ? "ServiceStatus" : UI.AppSetting.Default.ExFrame_2.ToString()) + ".xaml";
    //            }
    //        }

    //        public string ExFrame_3
    //        {
    //            get
    //            {
    //                return "/UI;component/View/Controls/" + (UI.AppSetting.Default.ExFrame_3.ToString() == null ? "ServiceStatus" : UI.AppSetting.Default.ExFrame_3.ToString()) + ".xaml";
    //            }
    //        }


    //        #region Singelton

    //        private static AppSettingModel _instance;

    //        public static AppSettingModel Instance
    //        {
    //            get
    //            {
    //                if (_instance == null)
    //                    _instance = new AppSettingModel();

    //                return _instance;
    //            }
    //        }

    //        private AppSettingModel()
    //        {
    //            // <Controls:ServiceStatus Width = "504" Margin="2"/>
    //        }

    //        #endregion

    //    }
}
