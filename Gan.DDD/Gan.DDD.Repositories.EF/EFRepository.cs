using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace Gan.DDD.Repositories.EF
{
    public class EFRepository<TEntity> : IExtensionRepository<TEntity>
        where TEntity:class,IEntity
    {
        public EFRepository()
            : this(null)
        {

        }

        private DbContext Db;
        protected virtual int DataPageSize { get; set; }

        public EFRepository(DbContext db)
        {
            Db = db;
            this.DataPageSize = 10000;

        }

        protected virtual void SaveChanges()
        {
            try
            {
                Db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {

               
            }
        }

        public void Delete(TEntity item)
        {
            if (item != null)
            {
                Db.Set<TEntity>().Attach(item as TEntity);
                Db.Entry(item).State = EntityState.Deleted;
                Db.Set<TEntity>().Remove(item as TEntity);
                this.SaveChanges();
            }
        }

        public void Delete(IEntity item)
        {
            if (item != null)
            {
                Db.Set<TEntity>().Attach(item as TEntity);
                Db.Set<TEntity>().Remove(item as TEntity);
                this.SaveChanges();
            }
        }

        public void Delete(IEnumerable<IEntity> list)
        {
            foreach (var item in list)
            {
                Db.Set<TEntity>().Attach(item as TEntity);
                Db.Set<TEntity>().Remove(item as TEntity);
            }
            this.SaveChanges();
        }

        public TEntity Find(params object[] id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetModel()
        {
            return Db.Set<TEntity>();
        }

        public IQueryable<TEntity> GetModel(Action<IOrderable<TEntity>> orderBy)
        {
            //var linq=new Orderable
        }

        public void Insert(TEntity item)
        {
            throw new NotImplementedException();
        }

        public void Insert(IEntity item)
        {
            throw new NotImplementedException();
        }

        public void Insert(IEnumerable<IEntity> list)
        {
            throw new NotImplementedException();
        }

        public void SetDateContext(object db)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity item)
        {
            throw new NotImplementedException();
        }

        public void Update(IEntity item)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<IEntity> list)
        {
            throw new NotImplementedException();
        }
    }
}
