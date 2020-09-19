using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogPersistance.Attributes
{
    public class CollectionName : Attribute
    {
        public string MongoCollectionName { get; }

        public CollectionName(string collectionName)
        {
            MongoCollectionName = collectionName;
        }
    }
}
