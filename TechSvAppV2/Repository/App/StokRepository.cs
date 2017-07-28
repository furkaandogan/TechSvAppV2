using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.App
{
    public class StokRepository : BaseRepository<Entity.App.Stok>
    {

        public StokRepository() :base(Data.TechSvAppContext.Instance)
        {

        }


    }
}
