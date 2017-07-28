using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.App
{
    public class UrunRepository :BaseRepository<Entity.App.Urun>
    {
        public UrunRepository() :base(Data.TechSvAppContext.Instance)
        {

        }

    }
}
