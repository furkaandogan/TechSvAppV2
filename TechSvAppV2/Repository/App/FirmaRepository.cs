using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.App
{
    public class FirmaRepository : BaseRepository<Entity.App.Firma>
    {
        public FirmaRepository() :base(Data.TechSvAppContext.Instance)
        {

        }
    }
}
