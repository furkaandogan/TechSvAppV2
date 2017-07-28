using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.App
{
    public class MarkaRespository :BaseRepository<Entity.App.Marka>
    {
        public MarkaRespository() :base(Data.TechSvAppContext.Instance)
        {

        }

    }
}
