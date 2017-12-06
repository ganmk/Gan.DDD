using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gan.DDD;
using StackExchange.Redis;

namespace Gan.DDD.Repositories.Redis
{
    public class RedisRepository<TEntity> : IRepository<TEntity> where TEntity : NoSqlEntity
    {
        IDatabase _db;
        string tableName;
        public void Delete(TEntity item)
        {
            if (item != null)
            {
                _db.HashDelete(tableName, item.Id);
            }
        }

        public void Delete(IEntity item)
        {
            this.Delete(item as TEntity);
        }

        public void Delete(IEnumerable<IEntity> list)
        {
            foreach (var item in list)
            {
                this.Delete(item as TEntity);
            }
        }

        public TEntity Find(params object[] id)
        {
            return GetModel().Where(i => i.Id == (string)id[0]).FirstOrDefault();
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
