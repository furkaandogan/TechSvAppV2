using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin.Model.Pages
{
    public class DashboardModel : ICopyMembers<DashboardModel>
    {
        public AppSettingModel AppSettings { get { return AppSettingModel.Instance; } }
        public int CustomerCount
        {
            get
            {
                return Exline.Cache.ExCache<CustomerModel, List<CustomerModel>>.Get(typeof(CustomerModel).Name + "_List").Count;
            }
        }


    }
}
