using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.App
{
    public class AppConfigRespository :BaseRepository<Entity.AppConfig>
    {

        public AppConfigRespository() 
            : base(Data.TechSvAppContext.Instance)
        {

        }

    }
}
