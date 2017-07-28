using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.App
{
    public class HatirlatmaRepository : BaseRepository<Entity.App.Hatirlatma>
    {
        public HatirlatmaRepository() :base(Data.TechSvAppContext.Instance)
        {

        }
    }
}
