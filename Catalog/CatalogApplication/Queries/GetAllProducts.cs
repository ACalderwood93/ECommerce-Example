using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CatalogDomain.Enums;
using CatalogDomain.Models;
using CatalogPersistance.Interfaces;
using MediatR;

namespace CatalogApplication.Queries
{
    public class GetAllProducts : IRequest<IEnumerable<Product>>
    {

    }

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProducts, IEnumerable<Product>>
    {
        private readonly ICatalogRepository _catalogRepository;

        public GetAllProductsQueryHandler(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProducts request, CancellationToken cancellationToken) =>
            await _catalogRepository.GetAllProductsAsync();

    }
}
