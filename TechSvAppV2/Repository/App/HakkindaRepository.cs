using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.App
{
    public class HakkindaRepository : BaseRepository<Entity.App.Hakkinda>
    {
        public HakkindaRepository() : base(Data.TechSvAppContext.Instance)
        {

        }
    }
}