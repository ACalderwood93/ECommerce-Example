using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CatalogDomain.Models;
using CatalogPersistance.Entities;
using CatalogPersistance.Entities.Events;
using CatalogPersistance.Interfaces;
using System.Linq;

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
            return _mapper.Map<IEnumerable<Product>>(result);
        }

        public async Task<IEnumerable<Product>> GetAllActive()
        {
            var results = await _dataStore.FindAsync(x => x.Active);
            return _mapper.Map<IEnumerable<Product>>(results);
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

        public async Task<Product> GetByIdAsync(Guid productId)
        {
            var entityResult = (await _dataStore.FindAsync(x => x.ProductId == productId)).FirstOrDefault();
            return _mapper.Map<Product>(entityResult);
        }

        public async Task ReplaceAsync(Product product)
        {
            var existingProduct = (await _dataStore.FindAsync(x => x.ProductId == product.ProductId)).FirstOrDefault();

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Category = product.Category;
            existingProduct.Active = product.Active;

            await _dataStore.UpdateAsync(existingProduct);
            await _eventsRepository.InsertAsync(new ProductUpdatedEvent
            {
                AggregateId = product.ProductId,
                UpdatedProduct = existingProduct
            });
        }

    }
}
