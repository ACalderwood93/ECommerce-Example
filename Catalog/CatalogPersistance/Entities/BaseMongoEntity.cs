using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace CatalogPersistance.Entities
{
    public abstract class BaseMongoEntity
    {
        public BsonObjectId id { get; set; }
    }
}
