using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.App
{
    public class ServisRepository :BaseRepository<Entity.App.Servis>
    {
        public ServisRepository() :base(Data.TechSvAppContext.Instance)
        {

        }

    }
}
