using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.App
{
    public class KullaniciRespository :BaseRepository<Entity.App.Kullanici>
    {
        public KullaniciRespository() :base(Data.TechSvAppContext.Instance)
        {

        }


    }
}
