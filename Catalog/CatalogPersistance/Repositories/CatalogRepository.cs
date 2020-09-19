using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatalogDomain.Models;
using CatalogPersistance.Configuration;
using CatalogPersistance.Entities;
using CatalogPersistance.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CatalogPersistance.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly IMongoDataStore<ProductEntity> _dataStore;


        public CatalogRepository(IMongoDataStore<ProductEntity> dataStore)
        {
            _dataStore = dataStore;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var result = await _dataStore.GetAllAsync();
            return new List<Product>();
        } 

    }
}
