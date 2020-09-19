using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CatalogDomain.Enums;
using CatalogDomain.Models;
using CatalogPersistance.Interfaces;

namespace CatalogPersistance.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private List<Product> _products;
        public CatalogRepository()
        {
            _products = new List<Product>()
            {
            new Product
                {
                    Category = ProductCategory.GraphicsCards,
                    Id = Guid.NewGuid(),
                    Name = "Plain T Shirt",
                    Price = 14.99m,
                    Active = true,
                    CreatedDate = DateTime.Now
                },
                new Product
                {
                    Category = ProductCategory.GraphicsCards,
                    Id = Guid.NewGuid(),
                    Name = "Nvidia GeForce RTX 380 MSI Ventus 3X OC 10GB Graphics Card",
                    Price = 719.99m,
                    Active = true,
                    CreatedDate = DateTime.Now
                },
            };
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync() => _products;

    }
}
