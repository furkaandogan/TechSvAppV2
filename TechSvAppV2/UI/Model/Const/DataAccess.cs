using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Model.Const
{
    public partial class DataAccess :BaseModel
    {

        public static Entity.App.Musteri Customer { get; set; }

        public static Entity.App.Kullanici User { get; set; }//=(Bin.ActionEvent.UserActionEvents.GetList(model=>model.AppID==Bin.Model.AppSettingModel.AppID && model.Durum==true).Model as List<Entity.App.Kullanici>).FirstOrDefault();
        public static Entity.App.Servis Service { get; set; }

        public static Entity.App.Hatirlatma Notification { get; set; }

        public static void Dispose()
        {
            Customer = null;
            Service = null;
        }

    }
}
