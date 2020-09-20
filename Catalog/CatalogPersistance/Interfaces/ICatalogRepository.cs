using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CatalogDomain.Models;

namespace CatalogPersistance.Interfaces
{
    public interface ICatalogRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<IEnumerable<Product>> GetAllActive();

        Task InsertAsync(Product product);

        Task<Product> GetByIdAsync(Guid productId);

        Task ReplaceAsync(Product product);
    }
}
