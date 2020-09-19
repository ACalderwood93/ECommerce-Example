using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CatalogDomain.Models;
using CatalogPersistance.Entities;

namespace CatalogPersistance.Configuration
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration CreateConfig()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductEntity, Product>();
                cfg.CreateMap<Product, ProductEntity>();
            });
            return config;
        }
    }
}
