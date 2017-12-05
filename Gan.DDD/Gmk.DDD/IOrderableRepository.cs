using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gan.DDD
{
    
    public interface IOrderableRepository<TEntity>where TEntity:class,IEntity
    {
        IQueryable<TEntity> GetModel(Action<IOrderable<TEntity>> orderBy);

    }
}
