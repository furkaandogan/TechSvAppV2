using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.App
{
    public class ServisDurumuRespository :BaseRepository<Entity.App.ServisDurumu>
    {
        public ServisDurumuRespository() :base(Data.TechSvAppContext.Instance)
        {

        }

    }
}
