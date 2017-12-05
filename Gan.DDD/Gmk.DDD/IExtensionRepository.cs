using System;
using System.Collections.Generic;
using System.Text;

namespace Gan.DDD
{
    public interface IExtensionRepository<TEntity>:
        IRepository<TEntity>,
        IOrderableRepository<TEntity>
        where TEntity:class,IEntity
    {
        
    }
}
