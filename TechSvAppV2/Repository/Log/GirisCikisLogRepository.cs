using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Log
{
    public class GirisCikisLogRepository : BaseRepository<Entity.App.Log.GirisCikisLog>
    {
        public GirisCikisLogRepository() :base(Data.TechSvAppContext.Instance)
        {

        }

    }
}