using CatalogDomain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using CatalogPersistance.Interfaces;
using CatalogDomain.Models;
using CatalogPersistance.Repositories;
using CatalogPersistance.Entities;

namespace CatalogApplication.Commands
{
    public class AddProductCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductCategory Category { get; set; }
        public bool Active { get; set; }
    }

    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Guid>
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IEventsRepository _eventsRepository;

        public AddProductCommandHandler(ICatalogRepository catalogRepo, IEventsRepository eventsRepository)
        {
            _catalogRepository = catalogRepo;
            _eventsRepository = eventsRepository;
        }
        public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var newProduct = new Product
            {
                Active = true,
                Category = request.Category,
                CreatedDate = DateTime.Now,
                Name = request.Name,
                Price = request.Price,
                ProductId = Guid.NewGuid()
            };

            await _catalogRepository.InsertAsync(newProduct);
            return newProduct.ProductId;
        }
    }
}
