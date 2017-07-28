using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.App
{
    public class MailGorevRepository :BaseRepository<Entity.App.MailGorev>
    {
        public MailGorevRepository() :base(Data.TechSvAppContext.Instance)
        {

        }

    }
}
