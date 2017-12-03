using System;
using System.Collections.Generic;
using System.Text;

namespace Gmk.DDD
{
    public interface IUnitOfWorkRepository
    {
        void Insert(IEntity item);

        void Update(IEntity item);

        void Delete(IEntity item);

        void Insert(IEnumerable<IEntity> list);

        void Update(IEnumerable<IEntity> list);

        void Delete(IEnumerable<IEntity> list);

    }
}
