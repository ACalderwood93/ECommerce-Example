using System;
using System.Collections.Generic;
using System.Text;
using CatalogPersistance.Configuration;
using CatalogPersistance.Datastore;
using CatalogPersistance.Interfaces;
using CatalogPersistance.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogPersistance
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IMongoDataStore<>), typeof(MongoDataStore<>));
            services.AddScoped<ICatalogRepository, CatalogRepository>();
            services.Configure<MongoSettings>(config.GetSection("MongoDB"));
            return services;
        }
    }
}
