using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BaseRepository<Model> 
        where Model :Entity.Base, new()
    {


        #region Members

        private DbContext _DbContext;
        private DbSet<Model> _DbSet;

        #endregion

        #region Properties

        public DbContext DbContext
        {
            get { return _DbContext; }
            set
            {
                _DbContext = value;
            }
        }
        public DbSet<Model> DbSet
        {
            get { return _DbSet; }
            set
            {
                _DbSet = value;
            }
        }

        #endregion

        #region Constructor

        public BaseRepository(DbContext Context)
        {
            DbContext = Context;
            DbContext.Database.CreateIfNotExists();
            DbSet = DbContext.Set<Model>();
            if(DbContext.Database.Connection.State != System.Data.ConnectionState.Open)
                DbContext.Database.Connection.Open();
        }
        public BaseRepository()
        {
            DbContext.Database.CreateIfNotExists();
            DbSet = DbContext.Set<Model>();
            if (DbContext.Database.Connection.State != System.Data.ConnectionState.Open)
                DbContext.Database.Connection.Open();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Model tipindeki nesneyi veritabına kaydeder
        /// </summary>
        /// <param name="Item"></param>
        public Entity.Result Add(Model model)
        {
            Entity.Result result;
            try
            {
                DbSet.Add(model);
                DbContext.SaveChanges();
                result = Entity.Result.set(false, 0, "Repository >> GenericRepository >> Add", typeof(Model).Name + " Eklendi","", model);

            }
            catch (DbEntityValidationException ex)
            {
                result = Entity.Result.set(true, 1, "Repository >> GenericRepository >> Add", ex.Message, ex.HelpLink, model);
            }
            return result;
        }

        /// <summary>
        /// Veritabanındaki veriyi günceller
        /// </summary>
        /// <param name="Item">Model</param>
        /// <param name="index">Model index</param>
        public Entity.Result Update(Model oldModel, Model model)
        {
            Entity.Result result;
            try
            {
                //if (oldModel != null)
                //{
                    
                    //DbContext.Entry(oldModel).CurrentValues.SetValues(model);
                    //DbContext.Entry(model).State = System.Data.Entity.EntityState.Modified;

                    //DbContext.Set<Model>().Attach(model);
                    DbContext.Entry(oldModel).State = EntityState.Deleted;

                    DbContext.SaveChanges();
                //}
                result = Entity.Result.set(false, 0, "Repository >> GenericRepository >> Update", typeof(Model).Name + " Güncellendi", "", model);

            }
            catch (DbEntityValidationException ex)
            {
                result = Entity.Result.set(true, 1, "Repository >> GenericRepository >> Update", ex.Message, ex.HelpLink, oldModel);
            }
            return result;
        }

        /// <summary>
        /// Veritabanındaki veriyi günceller
        /// </summary>
        /// <param name="Item">Model</param>
        /// <param name="index">Model index</param>
        public Entity.Result Update(Model oldModel)
        {
            Entity.Result result;
            try
            {
                //if (oldModel != null)
                //{
                    DbContext.Entry(oldModel).State = System.Data.Entity.EntityState.Modified;
                    DbContext.SaveChanges();
                //}
                result = Entity.Result.set(false, 0, "Repository >> GenericRepository >> Update", typeof(Model).Name + " Güncellendi", "", oldModel);

            }
            catch (DbEntityValidationException ex)
            {
                result = Entity.Result.set(true, 1, "Repository >> GenericRepository >> Update", ex.Message, ex.HelpLink, oldModel);
            }
            return result;
        }

        /// <summary>
        /// Veritabanında Model tipindeki nesneyi siler
        /// </summary>
        /// <param name="Item"></param>
        public Entity.Result Remove(Model model)
        {
            Entity.Result result;
            try
            {
                DbSet.Remove(model);
                DbContext.SaveChanges();
                result = Entity.Result.set(false, 0, "Repository >> GenericRepository >> Remove", typeof(Model).Name + " Silindi", "", model);

            }
            catch (DbEntityValidationException ex)
            {
                result = Entity.Result.set(true, 1, "Repository >> GenericRepository >> Remove", ex.Message, ex.HelpLink, model);
            }
            return result;
        }

        /// <summary>
        /// Tablonun hepsini dönderir
        /// </summary>
        /// <returns></returns>
        public Entity.Result GetList(Expression<Func<Model, bool>> predicate)
        {
            Entity.Result result;
            try
            {
                List<Model> modelList = DbSet.Where(predicate).ToList();
                result = Entity.Result.set(false, 0, "Repository >> GenericRepository >> GetList", typeof(Model).Name + " Listelendi", "", modelList);

            }
            catch (DbEntityValidationException ex)
            {
                result = Entity.Result.set(true, 1, "Repository >> GenericRepository >> GetList", ex.Message, ex.HelpLink, new List<Model>());
            }
            return result;
        }

        public virtual Entity.Result Get(Expression<Func<Model, bool>> predicate)
        {
            Entity.Result result;
            try
            {
                Model model = DbSet.Where(predicate).FirstOrDefault();
                result = Entity.Result.set(false, 0, "Repository >> GenericRepository >> Get", typeof(Model).Name + " Listelendi", "", model);

            }
            catch (DbEntityValidationException ex)
            {
                result = Entity.Result.set(true, 1, "Repository >> GenericRepository >> Get", ex.Message, ex.HelpLink, new List<Model>());
            }
            return result;
        }

        public Entity.Result Get(int modelID)
        {
            Entity.Result result;
            try
            {
                List<Model> modelList = DbSet.Where(model => model.ID == modelID).ToList();
                result = Entity.Result.set(false, 0, "Repository >> GenericRepository >> Get", typeof(Model).Name + " Silindi", "", modelList);

            }
            catch (Exception ex)
            {
                result = Entity.Result.set(true, 1, "Repository >> GenericRepository >> Get", ex.Message, ex.HelpLink, null);
            }
            return result;
        }

        #endregion


    }
}
