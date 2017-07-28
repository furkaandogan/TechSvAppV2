using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Repository
{
    public class AppConfigRespository : BaseRepository<Entity.AppConfig>
    {
        public AppConfigRespository() :base(Data.TechSvAppContext.Instance)
        {

        }
    }
}
