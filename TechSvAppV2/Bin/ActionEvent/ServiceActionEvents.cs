using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin.ActionEvent
{
    public class ServiceActionEvents
        : BaseActionEvents<Entity.App.Servis, Repository.App.ServisRepository>
    {
        public static Entity.Result Get(int ID)
        {
            Entity.Result result = new Entity.Result();
            try
            {
                result = new Entity.Result(message: "Servis Bulundu");
                result.Model = (ServiceActionEvents.GetList(model => model.ID == ID).Model as List<Entity.App.Servis>).FirstOrDefault();
            }
            catch (Exception ex)
            {
                result = Entity.Result.set(true, 1, "Bin.ActionEvent >> UserActionEvents >> Get", ex.Message, ex.HelpLink, null);
            }
            return result;
        }
    }
}
