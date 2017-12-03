using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gmk.DDD;

namespace Gan.DDD.Repositories.Redis
{
    public class RedisRepository<TEntity> : IRepository<TEntity> where TEntity : NoSqlEntity
    {
        public void Delete(TEntity item)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEntity item)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
