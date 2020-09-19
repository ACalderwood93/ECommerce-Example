using CatalogDomain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogPersistance.Entities
{
    public class ProductAddedEvent : BaseEventEntity
    {
        public override string EventName => nameof(ProductAddedEvent);

        public ProductEntity NewProduct { get; set; }
    }
}
