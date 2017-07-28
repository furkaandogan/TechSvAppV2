using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.App
{
    public class MailAdresiRepository :BaseRepository<Entity.App.MailAdres>
    {
        public MailAdresiRepository() :base(Data.TechSvAppContext.Instance)
        {

        }

    }
}
