using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gan.DDD.Repositories.Memory
{
    public class MemoryRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        List<TEntity> tb1;
        readonly static ConcurrentDictionary<string, List<TEntity>> db = new ConcurrentDictionary<string, List<TEntity>>();

        public void Delete(TEntity item)
        {
            tb1.Remove(item);
        }

        public void Delete(IEntity item)
        {
            tb1.Remove(item as TEntity);
        }

        public void Delete(IEnumerable<IEntity> list)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(params object[] id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetModel()
        {
            return db[typeof(TEntity).Name].AsQueryable();
        }

        public void Insert(TEntity item)
        {
            tb1.Add(item);
        }

        public void Insert(IEntity item)
        {
            throw new NotImplementedException();
        }

        public void Insert(IEnumerable<IEntity> list)
        {
            throw new NotImplementedException();
        }

        public void SetDataContext(object db)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity item)
        {
            tb1.Remove(item);
            tb1.Add(item);
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
