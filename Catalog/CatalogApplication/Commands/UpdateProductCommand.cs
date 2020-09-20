using CatalogDomain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using CatalogPersistance.Interfaces;
using CatalogDomain.Models;

namespace CatalogApplication.Commands
{
    public class UpdateProductCommand : IRequest
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ProductCategory Category { get; set; }
        public bool Active { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly ICatalogRepository _catalogRepository;

        public UpdateProductCommandHandler(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                ProductId = request.ProductId,
                Active = request.Active,
                Category = request.Category,
                Price = request.Price,
                Name = request.Name
            };

            await _catalogRepository.ReplaceAsync(product);



            return Unit.Value;
        }
    }
}
