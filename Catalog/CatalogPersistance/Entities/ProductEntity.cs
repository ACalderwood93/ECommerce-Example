using System;
using System.Collections.Generic;
using System.Text;
using CatalogDomain.Enums;
using CatalogPersistance.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CatalogPersistance.Entities
{
    [CollectionName("Products")]
    public class ProductEntity : BaseMongoEntity
    {
        [BsonRepresentation(BsonType.String)]
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ProductCategory Category { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
