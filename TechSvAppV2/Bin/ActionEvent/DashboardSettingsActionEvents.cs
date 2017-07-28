using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin.ActionEvent
{
    public class DashboardSettingsActionEvents
    {

        public static void Save(Model.App.DashboardSetting model)
        {
            Data.AppSetting.Default.ExFrame_1 = Model.App.DashboardSetting.pageValue[model.ExFrema_1_Selected].ToString();
            Data.AppSetting.Default.ExFrame_2 = Model.App.DashboardSetting.pageValue[model.ExFrema_2_Selected].ToString();
            Data.AppSetting.Default.ExFrame_3 = Model.App.DashboardSetting.pageValue[model.ExFrema_3_Selected].ToString();
            Data.AppSetting.Default.ExFrame_4 = Model.App.DashboardSetting.pageValue[model.ExFrema_4_Selected].ToString();

            Data.AppSetting.Default.Save();
        }

    }
}
