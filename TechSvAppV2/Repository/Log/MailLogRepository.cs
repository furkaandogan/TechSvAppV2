using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Log
{
    public class MailLogRepository : BaseRepository<Entity.App.Log.MailLog>
    {
        public MailLogRepository() :base(Data.TechSvAppContext.Instance)
        {

        }

    }
}
