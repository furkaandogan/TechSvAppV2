using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.App
{
    public class MusteriRepository :BaseRepository<Entity.App.Musteri>
    {

        public MusteriRepository() :base(Data.TechSvAppContext.Instance)
        {

        }


    }
}
