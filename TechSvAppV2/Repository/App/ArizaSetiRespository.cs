using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.App
{
    public class ArizaSetiRespository :BaseRepository<Entity.App.ArizaSeti>
    {
        public ArizaSetiRespository() :base(Data.TechSvAppContext.Instance)
        {
            //base.DbContext.Database.Connection.Open();
        }

    }
}
