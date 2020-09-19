using System;
using System.Collections.Generic;
using System.Text;
using CatalogDomain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace CatalogDomain.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductCategory Category { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
