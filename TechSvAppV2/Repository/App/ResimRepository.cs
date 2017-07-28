using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Repository.App
{
    public class ResimRepository :BaseRepository<Entity.App.Resim>
    {

        public ResimRepository() :base(Data.TechSvAppContext.Instance)
        {

        }
    }
}
