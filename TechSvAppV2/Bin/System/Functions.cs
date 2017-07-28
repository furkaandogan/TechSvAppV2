using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bin.System
{
    public class Functions
    {
        #region members



        #endregion

        #region Arıza Seti

        public static Entity.Result ArizaSetiInsert(Entity.App.ArizaSeti Model)
        {
            Entity.Result result;
            try
            {
                result = Helpers.FunctionHelpers.Instance.ArizaSetiRespository.Add(Model);
                if (result.IsError)
                {
                    return result;
                }
                result = Entity.Result.set(false, 0, "Bin.System >> Functions >> ArizaSetiInsert", "Arıza Kayıtı Tamamlandı", "", result.Model);

            }
            catch (Exception ex)
            {
                result = Entity.Result.set(true, 1, "Bin.System >> Functions >> ArizaSetiInsert", ex.Message, ex.HelpLink, null);
            }
            return result;
        }
        public static Entity.Result ArizaSetiDelete(Entity.App.ArizaSeti Model)
        {
            Entity.Result result;
            try
            {
                result = Helpers.FunctionHelpers.Instance.ArizaSetiRespository.Remove(Model);
                if (result.IsError)
                {
                    return result;
                }
                result = Entity.Result.set(false, 0, "Bin.System >> Functions >> ArizaSetiDelete", "Arıza Kayıtı Silindi", "", result.Model);

            }
            catch (Exception ex)
            {
                result = Entity.Result.set(true, 1, "Bin.System >> Functions >> ArizaSetiDelete", ex.Message, ex.HelpLink, null);
            }
            return result;
        }
        public static Entity.Result ArizaSetiUpdate(Entity.App.ArizaSeti Model)
        {
            Entity.Result result;
            try
            {
                result = Helpers.FunctionHelpers.Instance.ArizaSetiRespository.Update(Model,Model.ID);
                if (result.IsError)
                {
                    return result;
                }
                result = Entity.Result.set(false, 0, "Bin.System >> Functions >> ArizaSetiUpdate", "Arıza Kayıtı Güncellendi", "", result.Model);

            }
            catch (Exception ex)
            {
                result = Entity.Result.set(true, 1, "Bin.System >> Functions >> ArizaSetiUpdate", ex.Message, ex.HelpLink, null);
            }
            return result;
        }
        public static Entity.Result getArizaSetiList()
        {
            Entity.Result result;
            try
            {
                result = Helpers.FunctionHelpers.Instance.ArizaSetiRespository.GetList();
                if (result.IsError)
                {
                    return result;
                }
                result = Entity.Result.set(false, 0, "Bin.System >> Functions >> getArizaSetiList", "Arıza Kayıtları Listelendi", "", result.Model);

            }
            catch (Exception ex)
            {
                result = Entity.Result.set(true, 1, "Bin.System >> Functions >> getArizaSetiList", ex.Message, ex.HelpLink, null);
            }
            return result;
        }
        public static Entity.Result getArizaSeti()
        {
            Entity.Result result;
            try
            {
                result = Helpers.FunctionHelpers.Instance.ArizaSetiRespository.GetList();
                if (result.IsError)
                {
                    return result;
                }
                result = Entity.Result.set(false, 0, "Bin.System >> Functions >> getArizaSetiList", "Arıza Kayıtları Listelendi", "", result.Model);

            }
            catch (Exception ex)
            {
                result = Entity.Result.set(true, 1, "Bin.System >> Functions >> getArizaSetiList", ex.Message, ex.HelpLink, null);
            }
            return result;
        }
        #endregion

    }
}
