using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gan.DDD
{
    public abstract class NoSqlEntity : EntityBase
    {
        public NoSqlEntity()
        {
            this.Id = ObjectId.GenerateNewId().ToString();
        }

        public string Id { get; set; }


    }
}
