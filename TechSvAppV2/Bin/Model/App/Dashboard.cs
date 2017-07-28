using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin.Model.App
{
    public class Dashboard : Entity.ICopyMembers<Dashboard>
    {
        public AppSettingModel AppSettings { get { return AppSettingModel.Instance; } }
        public int CustomerCount
        {
            get
            {
                return (ActionEvent.CustomerActionEvents.GetList().Model as List<Entity.App.Musteri>).Count;
            }
        }
        public int ServiceCount
        {
            get
            {
                return (ActionEvent.ServiceActionEvents.GetList().Model as List<Entity.App.Servis>).Count;
            }
        }

        public double TotalChage
        {
            get
            {
                return ActionEvent.ChargeActionEvents.totalCharge();
            }
        }


    }
}
