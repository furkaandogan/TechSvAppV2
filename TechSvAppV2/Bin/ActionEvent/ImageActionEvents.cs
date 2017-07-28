using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin.ActionEvent
{
    public class ImageActionEvents :BaseActionEvents<Entity.App.Resim,Repository.App.ResimRepository>
    {


        public static Entity.App.Resim Get(string Url)
        {
            return (ImageActionEvents.GetList().Model as List<Entity.App.Resim>).Where(model => model.Url == Url).FirstOrDefault() ?? new Entity.App.Resim();
        }

    }
}
