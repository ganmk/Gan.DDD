using System;
using System.Collections.Generic;
using System.Text;

namespace Gan.DDD
{
  public  interface IOrderable<T>
    {
        IOrderable<T> Asc<Tkey>(global::System.Linq.Expressions.Expression<Func<T, Tkey>> keySelector);

         
    }
}
