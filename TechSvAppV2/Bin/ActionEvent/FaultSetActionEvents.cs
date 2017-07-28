using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin.ActionEvent
{
    public class FaultSetActionEvents
        : BaseActionEvents<Entity.App.ArizaSeti,Repository.App.ArizaSetiRespository>
    {
        public static Entity.App.ArizaSeti Get(string name)
        {
            return (FaultSetActionEvents.GetList(model => model.Aciklama == name).Model as List<Entity.App.ArizaSeti>).FirstOrDefault() ?? new Entity.App.ArizaSeti();
        }
    }
}
