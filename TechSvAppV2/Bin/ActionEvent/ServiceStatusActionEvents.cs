using System;
using System.Collections.Generic;
using System.Linq;

namespace Bin.ActionEvent
{
    public class ServiceStatusActionEvents :BaseActionEvents<Entity.App.ServisDurumu,Repository.App.ServisDurumuRespository>
    {
        private static Entity.Result result;
        private static Common.FtpManager ftpManager;
        public static Entity.Result UplaoadImage(string fileName,string localFileAddress)
        {
            result = new Entity.Result(false, 0, "Bin >> ServiceStatusActionEvents >> UplaoadImage", typeof(Entity.App.ServisDurumu).Name + " Eklendi.", null);
            try
            {
                ftpManager = new Common.FtpManager(new Common.FtpEntity()
                {
                    Server = Bin.AppSetting.GetAppConfig().FtpServer+"/Images",
                    User = Bin.AppSetting.GetAppConfig().FtpUser,
                    Password = Bin.AppSetting.GetAppConfig().FtpPassword,
                });
                if(!ftpManager.Upload(fileName, localFileAddress))
                    result = Entity.Result.set(true, 1, "Bin >> ServiceStatusActionEvents >> UplaoadImage", "Sunucuya resim yüklenirken hata oluştu daha sonra tekrar deneyiniz", "", null);
            }
            catch (Exception ex)
            {
                result = Entity.Result.set(true, 1, "Bin >> ServiceStatusActionEvents >> UplaoadImage", ex.Message, ex.HelpLink, null);
            }
            return result;
        }
        
        public static List<string> GetNames()
        {
            IEnumerable<string> serviceStatusList = from serviceStatus in (ServiceStatusActionEvents.GetList().Model as List<Entity.App.ServisDurumu>)
                                         select serviceStatus.Ad;
            return serviceStatusList.ToList();
        }
        public static Entity.App.ServisDurumu Get(string name)
        {
            return (ServiceStatusActionEvents.GetList(model => model.Ad == name).Model as List<Entity.App.ServisDurumu>).FirstOrDefault() ?? new Entity.App.ServisDurumu();
        }

    }
}
