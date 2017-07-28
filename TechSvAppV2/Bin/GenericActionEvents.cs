using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Repository;
using System.Data.Entity.Validation;

namespace Bin
{
    ///// <summary>
    ///// genel ekleme methodları static olarak erişim
    ///// </summary>
    ///// <typeparam name="Entity"></typeparam>
    ///// <typeparam name="DbSet"></typeparam>
    ////public class GenericActionEvents<Entity,DbSet> where Entity :class where DbSet : DbSet<Entity>



    // içindeki propertyde bir clas eklenince set etmede patlıyor çözüleceke
    #region üstsürüm için geliştiriyorum

    ///// <summary>
    /////// genel methodları static olarak erişim
    ///// </summary>
    ///// <typeparam name="TEntity">Database modelimin class hali</typeparam>
    ///// <typeparam name="TRepository">Data Access layer sınıfım</typeparam>
    ///// <typeparam name="EntityModel"> Database modelimin constructor lı hali</typeparam>
    ///// <typeparam name="TModel">UI Access modelimin constructor lı</typeparam>
    //public class GenericActionEvents<TEntity, TRepository, TModel>
    //    where TEntity : class, new()
    //    where TRepository : Repository.GenericRepository<TEntity>, new()
    //    where TModel : new()
    //{


    //    #region Members

    //    private static List<TModel> CacheList;
    //    private static TRepository Repository = new TRepository();

    //    #endregion

    //    //private static TRepository _repositor = default(TRepository);

    //    #region Properties

    //    //public static int Count
    //    //{
    //    //    get
    //    //    {
    //    //        return (GetList().Model as List<TModel>).Count;
    //    //    }
    //    //}

    //    #endregion

    //    #region Methods


    //    /// <summary>
    //    /// TModel tipinde gelen modeli Tentity(database tablo clası) ye set eder Tentity tipindeki entity 
    //    /// veri tabanına ekler ve modeli cacheler
    //    /// </summary>
    //    /// <param name="model">uı daki model</param>
    //    /// <returns>entity.result tipi döner içerisinde mesaj ve modelim döner</returns>
    //    public static Entity.Result Add(TModel model)
    //    {
    //        Entity.Result result = new Entity.Result(false, 0, "Bin >> GenericActionEvents >> Update", typeof(TModel).Name + " Eklendi.", null);
    //        try
    //        {
    //            result = Repository.Add(Exline.Property.PropertyConverter<TModel, TEntity>.DataSet(model));
    //            if (result.IsError)
    //            {
    //                CacheList = Exline.Cache.ExCache<TModel, List<TModel>>.Get(typeof(TModel).Name + "_List");
    //                if (CacheList != null)
    //                {
    //                    CacheList.Add(model);
    //                    Exline.Cache.ExCache<TModel, List<TModel>>.Set(typeof(TModel).Name + "_List", CacheList);
    //                }
    //            }
    //            result.Model = model;
    //        }
    //        catch (Exception ex)
    //        {
    //            result = Entity.Result.set(true, 1, "Bin >> GenericActionEvents >> Add", ex.Message, ex.HelpLink, null);
    //        }
    //        return result;
    //    }

    //    /// <summary>
    //    /// TModel tipinde gelen modeli Tentity(database tablo clası) ye set eder Tentity 
    //    /// tipindeki entity veri tabanından siler ve modeli cacheler
    //    /// </summary>
    //    /// <param name="model">uı daki model</param>
    //    /// <returns>entity.result tipi döner içerisinde mesaj ve modelim döner</returns>
    //    public static Entity.Result Remove(TModel model)
    //    {
    //        Entity.Result result = new Entity.Result(false, 0, "Bin >> GenericActionEvents >> Update", typeof(TModel).Name + " Silindi.", null);
    //        try
    //        {
    //            result = Repository.Remove(Exline.Property.PropertyConverter<TModel, TEntity>.DataSet(model));
    //            if (!result.IsError)
    //            {
    //                CacheList = Exline.Cache.ExCache<TModel, List<TModel>>.Get(typeof(TModel).Name + "_List");
    //                if (CacheList != null)
    //                {
    //                    CacheList.Remove(model);
    //                    Exline.Cache.ExCache<TModel, List<TModel>>.Set(typeof(TModel).Name + "_List", CacheList);
    //                }
    //            }
    //            result.Model = model;
    //        }
    //        catch (Exception ex)
    //        {
    //            result = Entity.Result.set(true, 1, "Bin >> GenericActionEvents >> Remove", ex.Message, ex.HelpLink, null);
    //        }
    //        return result;
    //    }

    //    /// <summary>
    //    /// TModel tipinde gelen modeli Tentity(database tablo clası) ye set eder Tentity 
    //    /// tipindeki entity veri verilen ıd siler tabanında günceller ve modeli cacheler
    //    /// </summary>
    //    /// <param name="model">uı daki model</param>
    //    /// <returns>entity.result tipi döner içerisinde mesaj ve modelim döner</returns>
    //    public static Entity.Result Update(TModel Model)
    //    {
    //        Entity.Result result = new Entity.Result(false, 0, "Bin >> GenericActionEvents >> Update", typeof(TModel).Name + " Güncellendi.", null);
    //        try
    //        {
    //            result = Repository.Update(Exline.Property.PropertyConverter<TModel, TEntity>.DataSet(Model));
    //            if (!result.IsError)
    //            {
    //                CacheList = Exline.Cache.ExCache<TModel, List<TModel>>.Get(typeof(TModel).Name + "_List");
    //                if (CacheList != null)
    //                {

    //                    CacheList.Remove(Model);
    //                    CacheList.Add(Model);
    //                    Exline.Cache.ExCache<TModel, List<TModel>>.Set(typeof(TModel).Name + "_List", CacheList);
    //                }
    //            }

    //            result.Model = Model;
    //        }
    //        catch (Exception ex)
    //        {
    //            result = Entity.Result.set(true, 1, "Bin >> GenericActionEvents >> Update", ex.Message, ex.HelpLink, null);
    //        }
    //        return result;
    //    }


    //    /// <summary>
    //    /// koşuluma göre veritabınan verileri list olarak resultın içinde döner ve modeli cacheler
    //    /// </summary>
    //    /// <param name="predicate">koşulum</param>
    //    /// <returns>entity.result tipi döner içerisinde mesaj ve modelim döner</returns>
    //    public static Entity.Result GetList(Expression<Func<TEntity, bool>> predicate)
    //    {
    //        Entity.Result result = new Entity.Result(false, 0, "Bin >> GenericActionEvents >> GetList", typeof(TModel).Name + " Listelendi.", null);
    //        try
    //        {
    //            CacheList = Exline.Cache.ExCache<TModel, List<TModel>>.Get(typeof(TModel).Name + "_List");
    //            if (CacheList == null)
    //            {
    //                result = Repository.GetList(predicate);
    //                if (!result.IsError)
    //                {
    //                    CacheList = new List<TModel>();
    //                    foreach (TEntity item in result.Model as List<TEntity>)
    //                    {
    //                        CacheList.Add(Exline.Property.PropertyConverter<TEntity, TModel>.DataSet(item));
    //                    }
    //                    // CacheList = ;
    //                    Exline.Cache.ExCache<TModel, List<TModel>>.Set(typeof(TModel).Name + "_List", CacheList);
    //                }
    //            }
    //            result.Model = CacheList;
    //        }
    //        catch (Exception ex)
    //        {
    //            result = Entity.Result.set(true, 1, "Bin >> GenericActionEvents >> GetList", ex.Message, ex.HelpLink, null);
    //        }
    //        return result;
    //    }

    //    /// <summary>
    //    /// koşuluma göre veritabınan verileri list olarak resultın içinde döner ve cacheler time spana süresi kadar cache tutar
    //    /// </summary>
    //    /// <param name="predicate">koşulum</param>
    //    /// <param name="CacheTime">modelimi cachede tutma surem</param>
    //    /// <returns>entity.result tipi döner içerisinde mesaj ve modelim döner</returns>
    //    public static Entity.Result GetList(Expression<Func<TEntity, bool>> predicate, TimeSpan CacheTime)
    //    {
    //        Entity.Result result = new Entity.Result(false, 0, "Bin >> GenericActionEvents >> Update", typeof(TModel).Name + " Listelendi", null);

    //        try
    //        {
    //            CacheList = Exline.Cache.ExCache<TModel, List<TModel>>.Get(typeof(TModel).Name + "_List");
    //            if (CacheList == null)
    //            {
    //                result = Repository.GetList(predicate);
    //                if (!result.IsError)
    //                {
    //                    CacheList = new List<TModel>();
    //                    foreach (TEntity item in result.Model as List<TEntity>)
    //                    {
    //                        CacheList.Add(Exline.Property.PropertyConverter<TEntity, TModel>.DataSet(item));
    //                    }
    //                    // CacheList = ;
    //                    Exline.Cache.ExCache<TModel, List<TModel>>.Set(typeof(TModel).Name + "_List", CacheList);
    //                }
    //            }
    //            result.Model = CacheList;
    //        }
    //        catch (Exception ex)
    //        {
    //            result = Entity.Result.set(true, 1, "Bin >> GenericActionEvents >> GetList", ex.Message, ex.HelpLink, null);
    //        }
    //        return result;
    //    }

    //    #endregion
    //}


    #endregion


    #region Eski sürüm


    /// <summary>
    ///// genel methodları static olarak erişim
    /// </summary>
    /// <typeparam name="TEntity">Database modelimin class hali</typeparam>
    /// <typeparam name="TRepository">Data Access layer sınıfım</typeparam>
    /// <typeparam name="EntityModel"> Database modelimin constructor lı hali</typeparam>
    /// <typeparam name="TModel">UI Access modelimin constructor lı</typeparam>
    public class GenericActionEvents<TEntity, TRepository>
        where TEntity : class, new()
        where TRepository : Repository.GenericRepository<TEntity>, new()
    {


        #region Members

        private static List<TEntity> CacheList;
        private static TRepository Repository = new TRepository();
        private static Entity.Result result;

        #endregion


        #region Properties


        #endregion

        #region Methods


        /// <summary>
        /// TModel tipinde gelen modeli Tentity(database tablo clası) ye set eder Tentity tipindeki entity 
        /// veri tabanına ekler ve modeli cacheler
        /// </summary>
        /// <param name="model">uı daki model</param>
        /// <returns>entity.result tipi döner içerisinde mesaj ve modelim döner</returns>
        public static Entity.Result Add(TEntity model)
        {
            result = new Entity.Result(false, 0, "Bin >> GenericActionEvents >> Add", typeof(TEntity).Name + " Eklendi.", null);
            try
            {
                result = Repository.Add(model);
                if (!result.IsError)
                {
                    CacheList = Exline.Cache.ExCache<TEntity, List<TEntity>>.Get(typeof(TEntity).Name + "_List");
                    if (CacheList != null)
                    {
                        CacheList.Add(model);
                        Exline.Cache.ExCache<TEntity, List<TEntity>>.Set(typeof(TEntity).Name + "_List", CacheList);
                    }
                    result = Entity.Result.set(false, 1, "Bin >> GenericActionEvents >> Add", typeof(TEntity).Name + " Eklendi.", "", model);
                }
            }
            catch (DbEntityValidationException ex)
            {
                result = Entity.Result.set(true, 1, "Bin >> GenericActionEvents >> Add", ex.Message, ex.HelpLink, null);
            }
            return result;
        }

        /// <summary>
        /// TModel tipinde gelen modeli Tentity(database tablo clası) ye set eder Tentity 
        /// tipindeki entity veri tabanından siler ve modeli cacheler
        /// </summary>
        /// <param name="model">uı daki model</param>
        /// <returns>entity.result tipi döner içerisinde mesaj ve modelim döner</returns>
        public static Entity.Result Delete(TEntity model)
        {
            result = new Entity.Result(false, 0, "Bin >> GenericActionEvents >> Delete", typeof(TEntity).Name + " Silindi.", null);
            try
            {
                result = Repository.Update(model);
                if (!result.IsError)
                {
                    CacheList = Exline.Cache.ExCache<TEntity, List<TEntity>>.Get(typeof(TEntity).Name + "_List");
                    if (CacheList != null)
                    {
                        CacheList.Remove(model);
                        Exline.Cache.ExCache<TEntity, List<TEntity>>.Set(typeof(TEntity).Name + "_List", CacheList);
                    }
                    result = Entity.Result.set(false, 0, "Bin >> GenericActionEvents >> Delete", typeof(TEntity).Name + " Silindi.", "", model);
                }
            }
            catch (DbEntityValidationException ex)
            {
                result = Entity.Result.set(true, 1, "Bin >> GenericActionEvents >> Delete", ex.Message, ex.HelpLink, model);
            }
            return result;
        }

        /// <summary>
        /// TModel tipinde gelen modeli Tentity(database tablo clası) ye set eder Tentity 
        /// tipindeki entity veri tabanından siler ve modeli cacheler
        /// </summary>
        /// <param name="model">uı daki model</param>
        /// <returns>entity.result tipi döner içerisinde mesaj ve modelim döner</returns>
        public static Entity.Result Remove(TEntity model)
        {
            result = new Entity.Result(false, 0, "Bin >> GenericActionEvents >> Remove", typeof(TEntity).Name + " Silindi.", null);
            try
            {
                result = Repository.Remove(model);
                if (!result.IsError)
                {
                    CacheList = Exline.Cache.ExCache<TEntity, List<TEntity>>.Get(typeof(TEntity).Name + "_List");
                    if (CacheList != null)
                    {
                        CacheList.Remove(model);
                        Exline.Cache.ExCache<TEntity, List<TEntity>>.Set(typeof(TEntity).Name + "_List", CacheList);
                    }
                    result = Entity.Result.set(false, 1, "Bin >> GenericActionEvents >> Remove", typeof(TEntity).Name + " Silindi.", "", model);
                }
            }
            catch (DbEntityValidationException ex)
            {
                result = Entity.Result.set(true, 1, "Bin >> GenericActionEvents >> Remove", ex.Message, ex.HelpLink, model);
            }
            return result;
        }

        /// <summary>
        /// TModel tipinde gelen modeli Tentity(database tablo clası) ye set eder Tentity 
        /// tipindeki entity veri verilen ıd siler tabanında günceller ve modeli cacheler
        /// </summary>
        /// <param name="model">uı daki model</param>
        /// <returns>entity.result tipi döner içerisinde mesaj ve modelim döner</returns>
        public static Entity.Result Update(TEntity model)
        {
            result = new Entity.Result(false, 0, "Bin >> GenericActionEvents >> Update", typeof(TEntity).Name + " Güncellendi.", null);
            try
            {
                result = Repository.Update(model);
                if (!result.IsError)
                {
                    CacheList = Exline.Cache.ExCache<TEntity, List<TEntity>>.Get(typeof(TEntity).Name + "_List");
                    if (CacheList != null)
                    {

                        CacheList.Remove(model);
                        CacheList.Add(model);
                        Exline.Cache.ExCache<TEntity, List<TEntity>>.Set(typeof(TEntity).Name + "_List", CacheList);
                    }
                    result = Entity.Result.set(false, 1, "Bin >> GenericActionEvents >> Update", typeof(TEntity).Name + " Güncellendi.", "", model);

                }
                result.Model = model;
            }
            catch (DbEntityValidationException ex)
            {
                result = Entity.Result.set(true, 1, "Bin >> GenericActionEvents >> Update", ex.Message, ex.HelpLink, model);
            }
            return result;
        }


        /// <summary>
        /// koşuluma göre veritabınan verileri list olarak resultın içinde döner ve modeli cacheler
        /// </summary>
        /// <param name="predicate">koşulum</param>
        /// <returns>entity.result tipi döner içerisinde mesaj ve modelim döner</returns>
        public static Entity.Result GetList(Expression<Func<TEntity, bool>> predicate)
        {
            result = new Entity.Result(false, 0, "Bin >> GenericActionEvents >> GetList", typeof(TEntity).Name + " Listelendi.", null);
            try
            {
                CacheList = Exline.Cache.ExCache<TEntity, List<TEntity>>.Get(typeof(TEntity).Name + "_List");
                if (CacheList == null)
                {
                    result = Repository.GetList(predicate);
                    if (!result.IsError)
                    {
                        CacheList = new List<TEntity>();
                        foreach (TEntity item in result.Model as List<TEntity>)
                        {
                            CacheList.Add(item);
                        }
                        // CacheList = ;
                        Exline.Cache.ExCache<TEntity, List<TEntity>>.Set(typeof(TEntity).Name + "_List", CacheList);
                    }
                    else
                    {
                        CacheList = result.Model as List<TEntity>;
                    }
                }
                result.Model = CacheList;
            }
            catch (DbEntityValidationException ex)
            {
                result = Entity.Result.set(true, 1, "Bin >> GenericActionEvents >> GetList", ex.Message, ex.HelpLink, new List<TEntity>());
            }
            return result;
        }

        /// <summary>
        /// koşuluma göre veritabınan verileri list olarak resultın içinde döner ve cacheler time spana süresi kadar cache tutar
        /// </summary>
        /// <param name="predicate">koşulum</param>
        /// <param name="CacheTime">modelimi cachede tutma surem</param>
        /// <returns>entity.result tipi döner içerisinde mesaj ve modelim döner</returns>
        public static Entity.Result GetList(Expression<Func<TEntity, bool>> predicate, TimeSpan CacheTime)
        {
            result = new Entity.Result(false, 0, "Bin >> GenericActionEvents >> GetList", typeof(TEntity).Name + " Listelendi", null);

            try
            {
                CacheList = Exline.Cache.ExCache<TEntity, List<TEntity>>.Get(typeof(TEntity).Name + "_List");
                if (CacheList == null)
                {
                    result = Repository.GetList(predicate);
                    if (!result.IsError)
                    {
                        CacheList = new List<TEntity>();
                        foreach (TEntity item in result.Model as List<TEntity>)
                        {
                            CacheList.Add(item);
                        }
                        // CacheList = ;
                        Exline.Cache.ExCache<TEntity, List<TEntity>>.Set(typeof(TEntity).Name + "_List", CacheList);
                    }
                    else
                    {
                        CacheList = result.Model as List<TEntity>;
                    }
                }
                result.Model = CacheList;
            }
            catch (DbEntityValidationException ex)
            {
                result = Entity.Result.set(true, 1, "Bin >> GenericActionEvents >> GetList", ex.Message, ex.HelpLink, new List<TEntity>());
            }
            return result;
        }

        #endregion
    }

    #endregion



}
