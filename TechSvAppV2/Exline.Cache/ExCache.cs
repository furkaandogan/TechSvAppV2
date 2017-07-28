using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exline.Cache
{
    #region model

    ///// <summary>
    ///// Exline CacheData Modül v1
    ///// </summary>
    ///// <typeparam name="Model">Cache yazılacak model</typeparam>
    //public class CacheData<Model>
    //{

    //    #region members

    //    private static Dictionary<string, CacheModel<Model>> content;
    //    private static string cacheKey;
    //    //private static string JsonCache;
    //    private static Model ModelCache;
    //    private static List<Model> ModelListCache;
    //    private static Object lockObject;

    //    #endregion

    //    #region properties

    //    #endregion

    //    #region methods

    //    /// <summary>
    //    /// Cache veriyi yazar
    //    /// </summary>
    //    /// <param name="key">cache keyi</param>
    //    /// <param name="model">cache yazılacak veri</param>
    //    /// <returns>Bool => true=yazıldı false=yazılamadı</returns>
    //    public static bool Set(string key, Model model)
    //    {
    //        CacheInstanceControl();
    //        try
    //        {
    //            if (!content.ContainsKey(key))
    //            {
    //                content.Add(key, new CacheModel<Model>(model, null));
    //                return true;
    //            }
    //            content[key] = new CacheModel<Model>(model, null);
    //            return true;
    //        }
    //        catch
    //        {
    //            return false;
    //        }

    //    }

    //    /// <summary>
    //    /// belirtilenen süre kadar Cache veriyi tutra sonra siler 
    //    /// </summary>
    //    /// <param name="key">cache keyi</param>
    //    /// <param name="model">cache yazılacak veri</param>
    //    /// <param name="time">bu süre cachede tutar</param>
    //    /// <returns></returns>
    //    public static bool Set(string key, Model model, TimeSpan time)
    //    {
    //        CacheInstanceControl();
    //        try
    //        {
    //            DateTime DateTime = DateTime.Today + time;
    //            if (!content.ContainsKey(key))
    //            {
    //                content.Add(key, new CacheModel<Model>(model, DateTime.ToString()));
    //                return true;
    //            }
    //            content[key] = new CacheModel<Model>(model, DateTime.ToString());
    //            return true;
    //        }
    //        catch
    //        {
    //            return false;
    //        }

    //    }

    //    /// <summary>
    //    /// Cachedeki kayıtlı veriyi çeker
    //    /// </summary>
    //    /// <param name="key">cache deki keyi</param>
    //    /// <returns>Model tipinde veri gelir</returns>
    //    public static Model Get(string key)
    //    {
    //        CacheInstanceControl();
    //        try
    //        {
    //            return content[key].Data;
    //        }
    //        catch
    //        {
    //            return ModelCache;
    //        }
    //    }

    //    /// <summary>
    //    /// Cache deki veriyi list olarak döndürür
    //    /// </summary>
    //    /// <param name="key">cache deki keyi</param>
    //    /// <returns>List => Model olarak döner</returns>
    //    public static List<Model> GetList(string key)
    //    {
    //        CacheInstanceControl();
    //        try
    //        {
    //            return content[key].Data as List<Model>;
    //        }
    //        catch
    //        {
    //            return null;
    //        }
    //    }

    //    #endregion

    //    #region helpers

    //    private static void CacheInstanceControl()
    //    {
    //        //JsonCache = null;
    //        if (content == null)
    //        {
    //            //lock(lockObject)
    //            content = new Dictionary<string, CacheModel<Model>>();
    //        }
    //    }

    //    /// <summary>
    //    /// Cache komple sıfırlar
    //    /// </summary>
    //    public static void Dispose()
    //    {
    //        content.Clear();
    //    }

    //    /// <summary>
    //    /// Cacheden isteline keydeki veriyi isler
    //    /// </summary>
    //    /// <param name="key">Cache key</param>
    //    public static void Dispose(string key)
    //    {
    //        if (content.ContainsKey(key))
    //            content.Remove(key);
    //    }

    //    #endregion

    //}

    ///// <summary>
    ///// Exline CacheData Modül v1
    ///// </summary>
    ///// <typeparam name="Model">Db için alınacak model (tablo)</typeparam>
    ///// <typeparam name="outType">dbden çekilen verilerin gönderilecek çıkış hali</typeparam>
    //public class CacheData<Model, outType>
    //    where Model : class
    //    where outType : List<Model>
    //{
    //    #region members

    //    private static Dictionary<string, CacheModel<outType>> content;
    //    private static string cacheKey;
    //    private static string JsonCache;
    //    private static outType ModelCache;
    //    private static System.Data.Entity.DbSet<Model> DbSet;
    //    private static Object lockObject;

    //    #endregion

    //    #region properties

    //    #endregion

    //    #region methods
        
    //    /// <summary>
    //    /// List Tipindeki veriyi Cache veriyi yazar
    //    /// </summary>
    //    /// <param name="key">cache keyi</param>
    //    /// <param name="model">cache yazılacak Liste</param>
    //    /// <returns>Bool => true=yazıldı false=yazılamadı</returns>
    //    public static bool Set(string key, outType model)
    //    {
    //        CacheInstanceControl();
    //        try
    //        {
    //            if (!content.ContainsKey(key))
    //            {
    //                content.Add(key, new CacheModel<outType>(model, null));
    //                return true;
    //            }
    //            content[key] = new CacheModel<outType>(model, null);
    //            return true;
    //        }
    //        catch
    //        {
    //            return false;
    //        }

    //    }

    //    /// <summary>
    //    /// List Tipindeki veriyi Cache veriyi yazar belirlenene süre kadar tutar sonra cacheden siler
    //    /// </summary>
    //    /// <param name="key">cache keyi</param>
    //    /// <param name="model">cache yazılacak Liste</param>
    //    /// <param name="time">cache de tutma süresi</param>
    //    /// <returns>Bool => true=yazıldı false=yazılamadı</returns>
    //    public static bool Set(string key, outType model, TimeSpan time)
    //    {
    //        CacheInstanceControl();
    //        try
    //        {
    //            DateTime DateTime = DateTime.Now + time;
    //            if (!content.ContainsKey(key))
    //            {
    //                content.Add(key, new CacheModel<outType>(model, DateTime.ToString()));
    //                return true;
    //            }
    //            content[key] = new CacheModel<outType>(model, DateTime.ToString());
    //            return true;
    //        }
    //        catch
    //        {
    //            return false;
    //        }

    //    }



    //    /// <summary>
    //    /// Cachdeki verinizin içindeki değiştirmek istediğiniz veriyi günceller
    //    /// </summary>
    //    /// <param name="key">cache keyi</param>
    //    /// <param name="oldModel">Cachedeki verinin  güncellenecek modeli</param>
    //    /// <param name="newModel">Verinin yeni hali</param>
    //    /// <returns>Bool => true=güncellendi false=güncellenemedi</returns>
    //    public static bool UpdateObject(string key, Model oldModel, Model newModel)
    //    {
    //        CacheInstanceControl();
    //        try
    //        {
    //            ModelCache = Get(key);
    //            string jsonOld = Newtonsoft.Json.JsonConvert.SerializeObject(oldModel);
    //            string jsonNew = Newtonsoft.Json.JsonConvert.SerializeObject(newModel);
    //            string json = Newtonsoft.Json.JsonConvert.SerializeObject(ModelCache);
    //            json = json.Replace(jsonOld, jsonNew);
    //            ModelCache = Newtonsoft.Json.JsonConvert.DeserializeObject<outType>(json);
    //            Set(key, ModelCache);
    //            return true;
    //        }
    //        catch
    //        {
    //            return false;
    //        }
    //    }

    //    /// <summary>
    //    /// Cachdeki verinizin içindeki değiştirmek istediğiniz toplu veriyi günceller
    //    /// </summary>
    //    /// <param name="key">cache keyi</param>
    //    /// <param name="oldModel">Cachedeki verinin  güncellenecek list => modeli</param>
    //    /// <param name="newModel">Verinin yeni hali list => model</param>
    //    /// <returns>Bool => true=güncellendi false=güncellenemedi</returns>
    //    public static bool UpdateObject(string key, List<Model> oldModels, List<Model> newModels)
    //    {
    //        CacheInstanceControl();
    //        try
    //        {
    //            ModelCache = Get(key);
    //            string jsonOld = Newtonsoft.Json.JsonConvert.SerializeObject(oldModels);
    //            jsonOld = jsonOld.Substring(1, jsonOld.Length - 2);
    //            string jsonNew = Newtonsoft.Json.JsonConvert.SerializeObject(newModels);
    //            jsonNew = jsonNew.Substring(1, jsonNew.Length - 2);
    //            string json = Newtonsoft.Json.JsonConvert.SerializeObject(ModelCache);
    //            json = json.Replace(jsonOld, jsonNew);
    //            ModelCache = Newtonsoft.Json.JsonConvert.DeserializeObject<outType>(json);
    //            Set(key, ModelCache);
    //            return true;
    //        }
    //        catch
    //        {
    //            return false;
    //        }
    //    }
    //    /// <summary>
    //    /// Cachedeki veriyi getiri
    //    /// </summary>
    //    /// <param name="key">cache keyi</param>
    //    /// <returns>outType</returns>
    //    public static outType Get(string key)
    //    {
    //        CacheInstanceControl();
    //        try
    //        {
    //            return content[key].Data;
    //        }
    //        catch
    //        {
    //            return null;
    //        }
    //    }
    //    public static outType Get<T>(string key, IEnumerable<Model> source, Func<Model, bool> expressions)
    //    {
    //        CacheInstanceControl();
    //        try
    //        {
    //            List<Model> _list = new List<Model>();
    //            foreach (Model item in source)
    //            {
    //                if (expressions(item))
    //                {
    //                    _list.Add(item);
    //                }
    //            }
    //            return content[key].Data;
    //        }
    //        catch
    //        {
    //            return content[key].Data;
    //        }
    //    }
    //    public static outType GetOrSet(string key, System.Data.Entity.DbContext Db)
    //    {
    //        CacheInstanceControl();
    //        try
    //        {
    //            if (!content.ContainsKey(key))
    //            {
    //                DbSet = Db.Set<Model>();
    //                //Set(key, DbSet.ToList());
    //            }
    //            return content[key].Data;
    //        }
    //        catch
    //        {
    //            return null;
    //        }
    //    }
    //    public static outType GetOrSet(string key, System.Data.Entity.DbContext Db, TimeSpan time)
    //    {
    //        CacheInstanceControl();
    //        try
    //        {
    //            if (!content.ContainsKey(key))
    //            {
    //                DbSet = Db.Set<Model>();
    //                //Set(key, DbSet.ToList());
    //            }
    //            return content[key].Data;
    //        }
    //        catch
    //        {
    //            return null;
    //        }
    //    }
    //    public static outType GetOrSet<T>(string key, System.Data.Entity.DbContext db, IEnumerable<Model> source, Func<Model, bool> expressions)
    //    {
    //        CacheInstanceControl();
    //        try
    //        {
    //            if (!content.ContainsKey(key))
    //            {
    //                DbSet = db.Set<Model>();
    //                List<Model> _list = new List<Model>();
    //                foreach (Model item in source)
    //                {
    //                    if (expressions(item))
    //                    {
    //                        _list.Add(item);
    //                    }
    //                }
    //                //Set(key, DbSet.Where(predicate).ToList());
    //            }
    //            return content[key].Data;
    //        }
    //        catch
    //        {
    //            return null;
    //        }
    //    }
    //    public static outType Get<T>(string key, System.Data.Entity.DbContext Db, IEnumerable<Model> source, Func<Model, bool> expressions, TimeSpan time)
    //    {
    //        CacheInstanceControl();
    //        try
    //        {
    //            if (!content.ContainsKey(key))
    //            {
    //                DbSet = Db.Set<Model>();
    //                List<Model> _list = new List<Model>();
    //                foreach (Model item in source)
    //                {
    //                    if (expressions(item))
    //                    {
    //                        _list.Add(item);
    //                    }
    //                }
    //                //Set(key, DbSet.Where(expressions));
    //            }
    //            return content[key].Data;
    //        }
    //        catch
    //        {
    //            return null;
    //        }
    //    }

    //    #endregion

    //    #region helpers

    //    private static void CacheInstanceControl()
    //    {
    //        JsonCache = null;
    //        ModelCache = null;
    //        if (content == null)
    //        {
    //            //lock(lockObject)
    //            content = new Dictionary<string, CacheModel<outType>>();
    //        }
    //        CacheTimeSpan();
    //    }
    //    internal static void CacheTimeSpan()
    //    {
    //        if (content.Count > 0)
    //        {
    //            foreach (var item in content)
    //            {
    //                if (content.Count == 0)
    //                    return;
    //                if (item.Value.Date != null)
    //                {
    //                    if (DateTime.Parse(item.Value.Date) < DateTime.Now)
    //                    {
    //                        Dispose(item.Key);
    //                        if (content.Count == 0)
    //                            return;
    //                    }
    //                }
    //            }
    //        }
    //    }
    //    public static void Dispose()
    //    {
    //        if(content!=null)
    //            content.Clear();
    //        //if (ModelCache != null)
    //            //ModelCache = null;
    //    }
    //    public static void Dispose(string key)
    //    {
    //        if (content.ContainsKey(key))
    //        {
    //            content.Remove(key);
    //            //ModelCache = null;
    //        }
    //    }

    //    #endregion

    //}

    #endregion

    #region object
    /// <summary>
    /// Exline CacheData Modül v1
    /// </summary>
    /// <typeparam name="Model">Cache yazılacak model</typeparam>
    public class ExCache<Model>
    {

        #region members

        private static Dictionary<string, ExCacheModel> content;
        private static string cacheKey;
        private static Model ModelCache;
        private static List<Model> ModelListCache;
        private static Object lockObject;

        #endregion

        #region properties

        #endregion

        #region methods

        /// <summary>
        /// Cache veriyi yazar
        /// </summary>
        /// <param name="key">cache keyi</param>
        /// <param name="model">cache yazılacak veri</param>
        /// <returns>Bool => true=yazıldı false=yazılamadı</returns>
        public static bool Set(string key, Model model)
        {
            CacheInstanceControl();
            try
            {
                if (!content.ContainsKey(key))
                {
                    content.Add(key, new ExCacheModel(model, null));
                    return true;
                }
                content[key] = new ExCacheModel(model, null);
                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// belirtilenen süre kadar Cache veriyi tutra sonra siler 
        /// </summary>
        /// <param name="key">cache keyi</param>
        /// <param name="model">cache yazılacak veri</param>
        /// <param name="time">bu süre cachede tutar</param>
        /// <returns></returns>
        public static bool Set(string key, Model model, TimeSpan time)
        {
            CacheInstanceControl();
            try
            {
                DateTime DateTime = DateTime.Today + time;
                if (!content.ContainsKey(key))
                {
                    content.Add(key, new ExCacheModel(model, DateTime.ToString()));
                    return true;
                }
                content[key] = new ExCacheModel(model, DateTime.ToString());
                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// Cachedeki kayıtlı veriyi çeker
        /// </summary>
        /// <param name="key">cache deki keyi</param>
        /// <returns>Model tipinde veri gelir</returns>
        public static Model Get(string key)
        {
            CacheInstanceControl();
            try
            {
                return (Model)content[key].Data;
            }
            catch
            {
                return ModelCache;
            }
        }

        /// <summary>
        /// Cache deki veriyi list olarak döndürür
        /// </summary>
        /// <param name="key">cache deki keyi</param>
        /// <returns>List => Model olarak döner</returns>
        public static List<Model> GetList(string key)
        {
            CacheInstanceControl();
            try
            {
                return content[key].Data as List<Model>;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region helpers

        private static void CacheInstanceControl()
        {
            //JsonCache = null;
            if (content == null)
            {
                //lock(lockObject)
                content = new Dictionary<string, ExCacheModel>();
            }
        }

        /// <summary>
        /// Cache komple sıfırlar
        /// </summary>
        public static void Dispose()
        {
            content.Clear();
        }

        /// <summary>
        /// Cacheden isteline keydeki veriyi isler
        /// </summary>
        /// <param name="key">Cache key</param>
        public static void Dispose(string key)
        {
            if (content.ContainsKey(key))
                content.Remove(key);
        }

        #endregion

    }

    /// <summary>
    /// Exline CacheData Modül v1
    /// </summary>
    /// <typeparam name="Model">Db için alınacak model (tablo)</typeparam>
    /// <typeparam name="outType">dbden çekilen verilerin gönderilecek çıkış hali</typeparam>
    public class ExCache<Model, outType>
        where Model : new()
        where outType : List<Model>
    {
        #region members

        private static Dictionary<string, ExCacheModel> content;
        private static string cacheKey;
        private static string JsonCache;
        private static outType ModelCache;
        //private static System.Data.Entity.DbSet<Model> DbSet;
        private static List<Model> _list;
        private static DateTime CacheDate;
        private static string jsonOld, jsonNew, json;

        #endregion

        #region properties

        #endregion

        #region methods

        /// <summary>
        /// List Tipindeki veriyi Cache veriyi yazar
        /// </summary>
        /// <param name="key">cache keyi</param>
        /// <param name="model">cache yazılacak Liste</param>
        /// <returns>Bool => true=yazıldı false=yazılamadı</returns>
        public static bool Set(string key, outType model)
        {
            CacheInstanceControl();
            try
            {
                if (!content.ContainsKey(key))
                {
                    content.Add(key, new ExCacheModel(model, null));
                    return true;
                }
                content[key] = new ExCacheModel(model, null);
                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// List Tipindeki veriyi Cache veriyi yazar belirlenene süre kadar tutar sonra cacheden siler
        /// </summary>
        /// <param name="key">cache keyi</param>
        /// <param name="model">cache yazılacak Liste</param>
        /// <param name="time">cache de tutma süresi</param>
        /// <returns>Bool => true=yazıldı false=yazılamadı</returns>
        public static bool Set(string key, outType model, TimeSpan time)
        {
            CacheInstanceControl();
            try
            {
                CacheDate= DateTime.Now + time;
                if (!content.ContainsKey(key))
                {
                    content.Add(key, new ExCacheModel(model, CacheDate.ToString()));
                    return true;
                }
                content[key] = new ExCacheModel(model, CacheDate.ToString());
                return true;
            }
            catch
            {
                return false;
            }

        }



        /// <summary>
        /// Cachdeki verinizin içindeki değiştirmek istediğiniz veriyi günceller
        /// </summary>
        /// <param name="key">cache keyi</param>
        /// <param name="oldModel">Cachedeki verinin  güncellenecek modeli</param>
        /// <param name="newModel">Verinin yeni hali</param>
        /// <returns>Bool => true=güncellendi false=güncellenemedi</returns>
        public static bool UpdateObject(string key, Model oldModel, Model newModel)
        {
            CacheInstanceControl();
            try
            {
                ModelCache = Get(key);
                jsonOld = Newtonsoft.Json.JsonConvert.SerializeObject(oldModel);
                jsonNew = Newtonsoft.Json.JsonConvert.SerializeObject(newModel);
                json = Newtonsoft.Json.JsonConvert.SerializeObject(ModelCache);
                json = json.Replace(jsonOld, jsonNew);
                ModelCache = Newtonsoft.Json.JsonConvert.DeserializeObject<outType>(json);
                Set(key, ModelCache);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Cachdeki verinizin içindeki değiştirmek istediğiniz toplu veriyi günceller
        /// </summary>
        /// <param name="key">cache keyi</param>
        /// <param name="oldModel">Cachedeki verinin  güncellenecek list => modeli</param>
        /// <param name="newModel">Verinin yeni hali list => model</param>
        /// <returns>Bool => true=güncellendi false=güncellenemedi</returns>
        public static bool UpdateObject(string key, List<Model> oldModels, List<Model> newModels)
        {
            CacheInstanceControl();
            try
            {
                ModelCache = Get(key);
                jsonOld = Newtonsoft.Json.JsonConvert.SerializeObject(oldModels);
                jsonOld = jsonOld.Substring(1, jsonOld.Length - 2);
                jsonNew = Newtonsoft.Json.JsonConvert.SerializeObject(newModels);
                jsonNew = jsonNew.Substring(1, jsonNew.Length - 2);
                json = Newtonsoft.Json.JsonConvert.SerializeObject(ModelCache);
                json = json.Replace(jsonOld, jsonNew);
                ModelCache = Newtonsoft.Json.JsonConvert.DeserializeObject<outType>(json);
                Set(key, ModelCache);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Cachedeki veriyi getiri
        /// </summary>
        /// <param name="key">cache keyi</param>
        /// <returns>outType</returns>
        public static outType Get(string key)
        {
            CacheInstanceControl();
            try
            {
                return (outType)content[key].Data;
            }
            catch
            {
                return null;
            }
        }
        public static outType Get<T>(string key, IEnumerable<Model> source, Func<Model, bool> expressions)
        {
            CacheInstanceControl();
            try
            {
                _list = new List<Model>();
                foreach (Model item in source)
                {
                    if (expressions(item))
                    {
                        _list.Add(item);
                    }
                }
                return (outType)content[key].Data;
            }
            catch
            {
                return null;
            }
        }
        public static outType GetOrSet(string key, System.Data.Entity.DbContext Db)
        {
            CacheInstanceControl();
            try
            {
                if (!content.ContainsKey(key))
                {
                   // DbSet = Db.Set<Model>();
                    //Set(key, DbSet.ToList());
                }
                return (outType)content[key].Data;
            }
            catch
            {
                return null;
            }
        }
        public static outType GetOrSet(string key, System.Data.Entity.DbContext Db, TimeSpan time)
        {
            CacheInstanceControl();
            try
            {
                if (!content.ContainsKey(key))
                {
                    //DbSet = Db.Set<Model>();
                    //Set(key, DbSet.ToList());
                }
                return (outType)content[key].Data;
            }
            catch
            {
                return null;
            }
        }
        public static outType GetOrSet<T>(string key, System.Data.Entity.DbContext db, IEnumerable<Model> source, Func<Model, bool> expressions)
        {
            CacheInstanceControl();
            try
            {
                if (!content.ContainsKey(key))
                {
                    //DbSet = db.Set<Model>();
                    _list = new List<Model>();
                    foreach (Model item in source)
                    {
                        if (expressions(item))
                        {
                            _list.Add(item);
                        }
                    }
                    //Set(key, DbSet.Where(predicate).ToList());
                }
                return (outType)content[key].Data;
            }
            catch
            {
                return null;
            }
        }
        public static outType Get<T>(string key, System.Data.Entity.DbContext Db, IEnumerable<Model> source, Func<Model, bool> expressions, TimeSpan time)
        {
            CacheInstanceControl();
            try
            {
                if (!content.ContainsKey(key))
                {
                    //DbSet = Db.Set<Model>();
                    _list = new List<Model>();
                    foreach (Model item in source)
                    {
                        if (expressions(item))
                        {
                            _list.Add(item);
                        }
                    }
                    //Set(key, DbSet.Where(expressions));
                }
                return (outType)content[key].Data;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region helpers

        private static void CacheInstanceControl()
        {
            JsonCache = null;
            ModelCache = null;
            if (content == null)
            {
                //lock(lockObject)
                content = new Dictionary<string, ExCacheModel>();
            }
            CacheTimeSpan();
        }
        internal static void CacheTimeSpan()
        {
            if (content.Count > 0)
            {
                foreach (var item in content)
                {
                    if (content.Count == 0)
                        return;
                    if (item.Value.Date != null)
                    {
                        if (DateTime.Parse(item.Value.Date) < DateTime.Now)
                        {
                            Dispose(item.Key);
                            if (content.Count == 0)
                                return;
                        }
                    }
                }
            }
        }
        public static void Dispose()
        {
            if (content != null)
                content.Clear();
        }
        public static void Dispose(string key)
        {
            if (content.ContainsKey(key))
            {
                content.Remove(key);
            }
        }

        #endregion

    }



    #endregion

}
