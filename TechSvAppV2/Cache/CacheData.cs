using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Cache
{
    public class CacheData<Model>
    {

        #region members

        private static Dictionary<string, string> content;
        private static string cacheKey;
        private static string JsonCache;
        private static Model ModelCache;
        private static List<Model> ModelListCache;
        private static Object lockObject;
        private static TimeSpan CacheTime;

        #endregion

        #region properties
        
        #endregion

        #region methods

        public static bool Set(string key,Model model)
        {
            CacheInstanceControl();
            try
            {
                JsonCache = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                if (!content.ContainsKey(key))
                {
                    content.Add(key, JsonCache);
                    return true;
                }
                content[key] = JsonCache;
                return true;
            }
            catch 
            {
                return false;
            }
            
        }
        public static bool Set(string key, Model model,TimeSpan time)
        {
            CacheInstanceControl();
            try
            {
                JsonCache = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                if (!content.ContainsKey(key))
                {
                    content.Add(key, JsonCache);
                    return true;
                }
                content[key] = JsonCache;
                return true;
            }
            catch
            {
                return false;
            }

        }
        public static Model Get(string key)
        {
            CacheInstanceControl();
            try
            {
                JsonCache = content[key];
                ModelCache = Newtonsoft.Json.JsonConvert.DeserializeObject<Model>(JsonCache);
                return ModelCache;
            }
            catch
            {
                return ModelCache;
            }
        }
        public static List<Model> GetList(string key)
        {
            CacheInstanceControl();
            try
            {
                JsonCache = content[key];
                ModelListCache = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Model>>(JsonCache);
                return ModelListCache;
            }
            catch
            {
                return ModelListCache;
            }
        }

        #endregion

        #region helpers

        private static void CacheInstanceControl()
        {
            if (content == null)
            {
                //lock(lockObject)
                    content = new Dictionary<string, string>();
            }
        }
        public static void Dispose()
        {
            content.Clear();
        }
        public static void Dispose(string key)
        {
            content.Remove(key);
        }

        #endregion



    }

    public class CacheData<Model, outType> where Model : class  where outType : List<outType>
    {
        #region members

        private static Dictionary<string, string> content;
        private static string cacheKey;
        private static string JsonCache;
        private static outType ModelCache;
        private static System.Data.Entity.DbSet<Model> DbSet;
        private static Object lockObject;
        private static TimeSpan CacheTime;

        #endregion

        #region properties

        #endregion

        #region methods

        public static bool Set(string key, List<Model> model)
        {
            CacheInstanceControl();
            try
            {
                JsonCache = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                if (!content.ContainsKey(key))
                {
                    content.Add(key, JsonCache);
                    return true;
                }
                content[key] = JsonCache;
                return true;
            }
            catch
            {
                return false;
            }

        }
        public static outType Get(string key)
        {
            CacheInstanceControl();
            try
            {
                JsonCache = content[key];
                ModelCache = Newtonsoft.Json.JsonConvert.DeserializeObject<outType>(JsonCache);
                return ModelCache;
            }
            catch
            {
                return ModelCache;
            }
        }
        public static outType Get<T>(string key, IEnumerable<T> query, Func<T, bool> expressions)
        {
            CacheInstanceControl();
            try
            {
                JsonCache = content[key];
                ModelCache = Newtonsoft.Json.JsonConvert.DeserializeObject<outType>(JsonCache);
                return ModelCache;
            }
            catch
            {
                return ModelCache;
            }
        }
        public static outType Get(string key, System.Data.Entity.DbContext Db)
        {
            CacheInstanceControl();
            try
            {
                if (!content.ContainsKey(key))
                {
                    DbSet = Db.Set<Model>();
                    Set(key, DbSet.ToList());
                }
                JsonCache = content[key];
                ModelCache = Newtonsoft.Json.JsonConvert.DeserializeObject<outType>(JsonCache);
                return ModelCache;
            }
            catch
            {
                return ModelCache;
            }
        }
        public static outType Get(string key, System.Data.Entity.DbContext Db, TimeSpan time)
        {
            CacheInstanceControl();
            try
            {
                if (!content.ContainsKey(key))
                {
                    DbSet = Db.Set<Model>();
                    Set(key, DbSet.ToList());
                }
                JsonCache = content[key];
                ModelCache = Newtonsoft.Json.JsonConvert.DeserializeObject<outType>(JsonCache);
                return ModelCache;
            }
            catch
            {
                return ModelCache;
            }
        }
        public static outType Get<T>(string key, System.Data.Entity.DbContext db, this IEnumerable<T> source, Func<T, bool> predicate)
        {
            CacheInstanceControl();
            try
            {
                if (!content.ContainsKey(key))
                {
                    DbSet = db.Set<Model>();
                    Set(key, DbSet.Where(predicate).ToList());
                }
                JsonCache = content[key];
                ModelCache = Newtonsoft.Json.JsonConvert.DeserializeObject<outType>(JsonCache);
                return ModelCache;
            }
            catch
            {
                return ModelCache;
            }
        }
        public static outType Get<T>(string key, System.Data.Entity.DbContext Db, IEnumerable<T> query, Func<T, bool> expressions, TimeSpan time)
        {
            CacheInstanceControl();
            try
            {
                if (!content.ContainsKey(key))
                {
                    DbSet = Db.Set<Model>();
                    //outType _list;
                    //foreach (outType item in DbSet.ToList())
                    //{
                            //if(expressions(item))
                            //{
                            //    _list.Add(item);
                            //}
                    //}
                    Set(key, DbSet.Where(expressions).ToList());
                }
                JsonCache = content[key];
                ModelCache = Newtonsoft.Json.JsonConvert.DeserializeObject<outType>(JsonCache);
                return ModelCache;
            }
            catch
            {
                return ModelCache;
            }
        }

        #endregion

        #region helpers

        private static void CacheInstanceControl()
        {
            if (content == null)
            {
                //lock(lockObject)
                content = new Dictionary<string, string>();
            }
        }
        public static void Dispose()
        {
            content.Clear();
        }
        public static void Dispose(string key)
        {
            content.Remove(key);
        }

        #endregion

    }

}
