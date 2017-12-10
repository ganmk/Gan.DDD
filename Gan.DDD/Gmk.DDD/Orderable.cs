using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Gan.DDD
{
    public class Orderable<T>:IOrderable<T>
    {
        private IQueryable<T> _queryable;

        public Orderable(IQueryable<T> enumerable)
        {
            _queryable = enumerable;
        }

        public IQueryable<T> Queryable
        {
            get { return _queryable; }
        }

        public IOrderable<T> Asc<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            _queryable = (_queryable as IOrderedQueryable<T>).OrderBy(keySelector);
            return this;
        }

        public IOrderable<T> ThenAsc<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            _queryable = (_queryable as IOrderedQueryable<T>)
                .ThenBy(keySelector);
            return this;
        }

        public IOrderable<T> Desc<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            _queryable = _queryable.OrderByDescending(keySelector);
            return this;
        }

        public IOrderable<T> ThenDesc<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            _queryable = (_queryable as IOrderedQueryable<T>)
                .ThenByDescending(keySelector);
            return this;

        }



    }
}
