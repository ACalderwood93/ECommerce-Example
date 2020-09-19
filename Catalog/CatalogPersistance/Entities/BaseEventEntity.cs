using CatalogDomain.Models;
using CatalogPersistance.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogPersistance.Entities
{
    [CollectionName("Events")]
    public class BaseEventEntity : BaseMongoEntity
    {
        [BsonRepresentation(BsonType.String)]
        public Guid AggregateId { get; set; }
        public virtual string EventName { get; set; }
    }
}
