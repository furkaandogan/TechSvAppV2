using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Entity.App;

namespace Bin.ActionEvent
{
    /// <summary>
    /// Generi
    /// </summary>
    public class CustomerActionEvents
        : BaseActionEvents<Entity.App.Musteri, Repository.App.MusteriRepository>
    {


        public static Entity.App.Musteri Get(string name)
        {
            return (CustomerActionEvents.GetList(model => model.Ad == name).Model as List<Entity.App.Musteri>).FirstOrDefault() ?? new Entity.App.Musteri();
        }
    }
}
