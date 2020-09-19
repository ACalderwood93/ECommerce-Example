using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CatalogPersistance.Attributes;
using CatalogPersistance.Configuration;
using CatalogPersistance.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Core.Operations;

namespace CatalogPersistance.Datastore
{
    public class MongoDataStore<T> : IMongoDataStore<T>
    {
        private readonly MongoSettings _mongoSettings;
        private IMongoCollection<T> _collection;

        public MongoDataStore(IOptions<MongoSettings> mongoSettings)
        {
            _mongoSettings = mongoSettings.Value;
            var client = new MongoClient(_mongoSettings.ConnectionString);
            var database = client.GetDatabase(_mongoSettings.DatabaseName);
            _collection = database.GetCollection<T>(GetCollectionName());

        }

        public async Task<IList<T>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

        private string GetCollectionName()
        {
            var type = typeof(T);
            var attrib = type.GetCustomAttribute(typeof(CollectionName)) as CollectionName;
            return attrib.MongoCollectionName;

        }
    }
}
