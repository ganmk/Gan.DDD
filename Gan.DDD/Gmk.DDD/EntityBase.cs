using System;
using System.Collections.Generic;
using System.Text;

namespace Gmk.DDD
{
    public abstract class EntityBase : IEntity
    {
        public EntityBase()
            : this(Status.Normal, DateTime.Now, DateTime.Now)
        { }

        public EntityBase(Status status, DateTime updateDateTime, DateTime createDateTime)
        {
            this.DataStatus = Status.Normal;
            this.DataUpdateDateTime = DateTime.Now;
            this.DataCreateTime = DateTime.Now;

        }

        public DateTime DataCreateTime { get; set; }

        public DateTime DataUpdateDateTime { get; set; }

        public Status DataStatus { get; set; }

    }
}
