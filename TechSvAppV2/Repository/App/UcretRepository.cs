using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.App
{
    public class UcretRepository :BaseRepository<Entity.App.Ucret>
    {
        public UcretRepository() :base(Data.TechSvAppContext.Instance)
        {

        }

    }
}
