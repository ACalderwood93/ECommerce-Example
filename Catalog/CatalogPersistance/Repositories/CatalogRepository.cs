using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IEventsRepository _eventsRepository;

        public CatalogRepository(IMongoDataStore<ProductEntity> dataStore, IMapper mapper, IEventsRepository eventsRepository)
        {
            _dataStore = dataStore;
            _mapper = mapper;
            _eventsRepository = eventsRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var result = await _dataStore.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductEntity>, IEnumerable<Product>>(result);
        }

        public async Task<IEnumerable<Product>> GetAllActive()
        {
            var results = await _dataStore.FindAsync(x => x.Active);
            return _mapper.Map<IEnumerable<ProductEntity>, IEnumerable<Product>>(results);
        }

        public async Task InsertAsync(Product product)
        {
            var entity = _mapper.Map<ProductEntity>(product);
            await _dataStore.InsertAsync(entity);
            await _eventsRepository.InsertAsync(new ProductAddedEvent
            {
                AggregateId = product.ProductId,
                NewProduct = entity
            });
                
        }

    }
}
