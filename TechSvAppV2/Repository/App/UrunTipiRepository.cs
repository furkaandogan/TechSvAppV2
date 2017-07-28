using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.App
{
    public class UrunTipiRepository : BaseRepository<Entity.App.UrunTipi>
    {
        public UrunTipiRepository() :base(Data.TechSvAppContext.Instance)
        {

        }
    }
}