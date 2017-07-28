using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.App
{
    public class ServisDetayRespository : BaseRepository<Entity.App.ServisDetay>
    {

        public ServisDetayRespository() :base(Data.TechSvAppContext.Instance)
        {

        }


    }
}