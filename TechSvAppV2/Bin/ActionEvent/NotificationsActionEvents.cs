using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin.ActionEvent
{
    public class NotificationsActionEvents
        : BaseActionEvents<Entity.App.Hatirlatma,Repository.App.HatirlatmaRepository>
    {

        public static Entity.App.Hatirlatma Get(string followCode)
        {
            return (GetList().Model as List<Entity.App.Hatirlatma>).Where(model => model.TakipKodu == followCode).FirstOrDefault() ?? new Entity.App.Hatirlatma();
        }

    }
}
