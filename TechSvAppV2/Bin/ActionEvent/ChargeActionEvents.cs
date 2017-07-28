using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin.ActionEvent
{
    public class ChargeActionEvents :BaseActionEvents<Entity.App.Ucret,Repository.App.UcretRepository>
    {


        public static double totalCharge()
        {
            double total=0.0;
            foreach (Entity.App.Ucret chage in (ChargeActionEvents.GetList().Model as List<Entity.App.Ucret>).Where(model =>model.UcretTipi==Entity.App.UcretTipiEnum.Sevis))
            {
                total += chage.UcretDegeri;
            }
            return total;
        }

    }
}
