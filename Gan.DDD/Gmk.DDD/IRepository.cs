using System;
using System.Collections.Generic;
using System.Text;

namespace Gan.DDD
{
    public interface IRepository<TEntity>:IUnitOfWorkRepository where TEntity:class,IEntity
    {
        TEntity Find(params object[] id);

        System.Linq.IQueryable<TEntity> GetModel();

        void SetDataContext(object db);

        void Insert(TEntity item);

        void Update(TEntity item);

        void Delete(TEntity item);
    }
}
