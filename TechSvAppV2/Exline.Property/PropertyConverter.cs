using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Exline.Property
{
    #region Eski

    /// <summary>
    /// Exline PropertyConvert Modül v1
    /// </summary>
    /// <typeparam name="Model">Giriş Tipiniz</typeparam>
    /// <typeparam name="SetModel">Set edilecek ve çıkış tipi</typeparam>
    public class PropertyConverter<Model, SetModel>
        where Model : new()
        where SetModel : new()
    {

        private static SetModel outModel;
        private static Model SModel;
        private static List<SetModel> outList;

        /// <summary>
        /// Gonderilen modeli istenilen moelde set edip model halinde dönderir
        /// </summary>
        /// <param name="model">Get Model Tipi</param>
        /// <param name="outModel">Set edilecek ve dönecek model tipi</param>
        /// <returns>Model => SetModel</returns>
        public static SetModel DataSet(Model model)
        {
            outModel = new SetModel();
            foreach (PropertyInfo item in (typeof(Model).GetProperties()))
            {
                if (item.Name != "Error")
                {
                    if (item.MemberType == MemberTypes.Property)
                    {
                        foreach (PropertyInfo SetItem in (typeof(SetModel).GetProperties()))
                        {
                            if (item.Name == SetItem.Name)
                            {
                                Type s = item.GetType();
                                //(typeof(SetModel).GetProperty(SetItem.Name.ToString()).SetValue(outModel, item.GetValue(model, null).ToString(), null));
                                SetItem.SetValue(outModel, item.GetValue(model, null), null);
                                break;
                            }
                        }
                    }
                }
            }
            return outModel;
        }

        /// <summary>
        /// Gönderilen Listyi istediniz modele set edip List Halinde Dönderir
        /// </summary>
        /// <param name="model">Get Model Tipi</param>
        /// <param name="setModel">Set edilecek ve dönecek model tipi </param>
        /// <returns>List => SetModel</returns>
        public static List<SetModel> DataSet(List<Model> model)
        {
            outList = new List<SetModel>();

            foreach (Model RowModel in model)
            {
                outModel = new SetModel();
                foreach (PropertyInfo item in (typeof(Model).GetProperties()))
                {
                    if (item.Name != "Error")
                    {
                        foreach (PropertyInfo SetItem in (typeof(SetModel).GetProperties()))
                        {
                            if (item.Name == SetItem.Name)
                            {
                                string s= item.GetType().Name;
                                //(typeof(SetModel).GetProperty(SetItem.Name.ToString()).SetValue(outModel, item.GetValue(model, null).ToString(), null));
                                SetItem.SetValue(outModel, item.GetValue(RowModel, null).ToString(), null);
                                break;
                            }
                        }
                    }
                }
                outList.Add(outModel);
            }
            return outList;
        }

        private static T DataSet<T>(Model model, T setModel)
        {
            setModel = default(T);
            foreach (PropertyInfo item in (typeof(Model).GetProperties()))
            {
                if (item.Name != "Error")
                {
                    if (item.MemberType == MemberTypes.Property)
                    {
                        foreach (PropertyInfo SetItem in (typeof(SetModel).GetProperties()))
                        {
                            if (item.Name == SetItem.Name)
                            {
                                //(typeof(SetModel).GetProperty(SetItem.Name.ToString()).SetValue(outModel, item.GetValue(model, null).ToString(), null));
                                SetItem.SetValue(outModel, item.GetValue(model, null), null);
                                break;
                            }
                        }
                    }
                }
            }
            return setModel;
        }
    }

    #endregion

    #region v1

    ///// <summary>
    ///// Exline PropertyConvert Modül v1
    ///// </summary>
    ///// <typeparam name="Model">Giriş Tipiniz</typeparam>
    ///// <typeparam name="SetModel">Set edilecek ve çıkış tipi</typeparam>
    //public class PropertyConverter<Model, SetModel>
    //    where Model : class
    //    where SetModel : class
    //{
    //    /// <summary>
    //    /// Gonderilen modeli istenilen moelde set edip model halinde dönderir
    //    /// </summary>
    //    /// <param name="model">Get Model Tipi</param>
    //    /// <param name="outModel">Set edilecek ve dönecek model tipi</param>
    //    /// <returns>Model => SetModel</returns>
    //    public static SetModel DataSet(Model model, SetModel outModel)
    //    {
    //        foreach (PropertyInfo item in (typeof(Model).GetProperties()))
    //        {
    //            foreach (PropertyInfo SetItem in (typeof(SetModel).GetProperties()))
    //            {
    //                if (item.Name == SetItem.Name)
    //                {
    //                    //(typeof(SetModel).GetProperty(SetItem.Name.ToString()).SetValue(outModel, item.GetValue(model, null).ToString(), null));
    //                    SetItem.SetValue(outModel, item.GetValue(model, null).ToString(), null);
    //                    break;
    //                }
    //            }
    //        }
    //        return outModel;
    //    }

    //    /// <summary>
    //    /// Gönderilen Listyi istediniz modele set edip List Halinde Dönderir
    //    /// </summary>
    //    /// <param name="model">Get Model Tipi</param>
    //    /// <param name="setModel">Set edilecek ve dönecek model tipi </param>
    //    /// <returns>List => SetModel</returns>
    //    public static List<SetModel> DataSet(List<Model> model)
    //    {
    //        List<SetModel> outList = new List<SetModel>();
    //        SetModel setModel = default(SetModel);
    //        foreach (Model RowModel in model)
    //        {
    //            foreach (PropertyInfo item in (typeof(Model).GetProperties()))
    //            {
    //                foreach (PropertyInfo SetItem in (typeof(SetModel).GetProperties()))
    //                {
    //                    if (item.Name == SetItem.Name)
    //                    {
    //                        //(typeof(SetModel).GetProperty(SetItem.Name.ToString()).SetValue(outModel, item.GetValue(model, null).ToString(), null));
    //                        SetItem.SetValue(setModel, item.GetValue(RowModel, null).ToString(), null);
    //                        break;
    //                    }
    //                }
    //            }
    //            outList.Add(setModel);
    //        }
    //        return outList;
    //    }
    //}
    #endregion

}
