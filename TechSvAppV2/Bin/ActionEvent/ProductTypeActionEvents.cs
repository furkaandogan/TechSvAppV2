using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin.ActionEvent
{
    public class ProductTypeActionEvents
        : BaseActionEvents<Entity.App.UrunTipi, Repository.App.UrunTipiRepository>
    {

        public int Count
        {
            get { return (ProductTypeActionEvents.GetList().Model as List<Entity.App.UrunTipi>).Count; }
        }

        public static List<string> GetNames()
        {
            IEnumerable<string> brands = from brand in (GetList().Model as List<Entity.App.UrunTipi>)
                                         select brand.Ad;
            return brands.ToList();
        }

        public static Entity.Result Get(string name)
        {
            Entity.Result result = new Entity.Result(source: "Ürün tipi bulundu", model: ((GetList(model => model.Ad == name).Model as List<Entity.App.UrunTipi>).FirstOrDefault() ?? new Entity.App.UrunTipi()));
            return result;
        }
        public static Entity.Result Get(int ID)
        {
            Entity.Result result = new Entity.Result(source: "Ürün tipi bulundu", model: ((GetList(model => model.ID == ID).Model as List<Entity.App.UrunTipi>).FirstOrDefault() ?? new Entity.App.UrunTipi()));
            return result;
        }

    }
}
