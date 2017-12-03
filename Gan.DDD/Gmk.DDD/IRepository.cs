using System;
using System.Collections.Generic;
using System.Text;

namespace Gmk.DDD
{
    public interface IRepository<TEntity>:IUnitOfWorkRepository where TEntity:class,IEntity
    {
        TEntity Find(params object[] id);

        System.Linq.IQueryable<TEntity> GetModel();

        void SetDateContext(object db);

        void Insert(TEntity item);

        void Update(TEntity item);

        void Delete(TEntity item);
    }
}
