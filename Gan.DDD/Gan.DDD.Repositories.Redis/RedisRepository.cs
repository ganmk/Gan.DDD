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
            List<TEntity> list = new List<TEntity>();
            var hashVals = _db.HashValues(tableName).ToArray();
            foreach (var item in hashVals)
            {
                list.Add(SerializeMemoryHelper.DeserializeFromBinary(item) as TEntity);

            }
            return list.AsQueryable();
        }

        public void Insert(TEntity item)
        {
            if (item != null)
            {
                _db.HashSet(tableName, item.Id, SerializeMemoryHelper.SerializeToBinary(item));
            }
        }

        public void Insert(IEntity item)
        {
            this.Insert(item as TEntity);
        }

        public void Insert(IEnumerable<IEntity> list)
        {
            foreach (var item in list)
            {
                this.Insert(item as TEntity);
            }
        }

        public void SetDateContext(object db)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity item)
        {
            if (item != null)
            {
                var old = Find(item.Id);
                if (old != null)
                {
                    _db.HashDelete(tableName, item.Id);
                    _db.HashSet(tableName, item.Id, SerializeMemoryHelper.SerializeToBinary(item));

                }
            }
        }

        public void Update(IEntity item)
        {
            this.Update(item as TEntity);
        }

        public void Update(IEnumerable<IEntity> list)
        {
            foreach (var item in list)
            {
                this.Delete(item as TEntity);
            }
        }
    }
}
