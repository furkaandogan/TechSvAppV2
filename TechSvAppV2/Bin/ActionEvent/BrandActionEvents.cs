using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin.ActionEvent
{
    public class BrandActionEvents
   // : GenericActionEvents<Entity.App.Marka, Repository.App.MarkaRespository,Bin.Model.App.Marka>
    : BaseActionEvents<Entity.App.Marka, Repository.App.MarkaRespository>
    {

        public static int Count
        {
            get
            {
                return (GetList().Model as List<Entity.App.Marka>).Count;
            }
        }

        public static List<string> GetNames()
        {
            IEnumerable<string> brands = from brand in (BrandActionEvents.GetList().Model as List<Entity.App.Marka>)
                           select brand.Ad;
            return brands.ToList();
        }
        public static Entity.Result Get(string name)
        {
            Entity.Result result = new Entity.Result(source: "Marka bulundu", model: ((BrandActionEvents.GetList().Model as List<Entity.App.Marka>).FirstOrDefault() ?? new Entity.App.Marka()));
            return result;
        }
        public static Entity.Result Get(int ID)
        {
            Entity.Result result = new Entity.Result(source: "Marka bulundu", model: ((BrandActionEvents.GetList().Model as List<Entity.App.Marka>).FirstOrDefault() ?? new Entity.App.Marka()));
            return result;
        }

    }
}
