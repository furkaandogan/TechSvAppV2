using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.App
{
    public class MailSablonRepository :BaseRepository<Entity.App.MailSablon>
    {
        public MailSablonRepository() :base(Data.TechSvAppContext.Instance)
        {

        }

    }
}
