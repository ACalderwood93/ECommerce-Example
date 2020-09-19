using System;
using System.Collections.Generic;
using System.Text;
using CatalogPersistance.Interfaces;
using CatalogPersistance.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogPersistance
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            services.AddScoped<ICatalogRepository, CatalogRepository>();
            return services;
        }
    }
}
