using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogPersistance.Entities.Events
{
    class ProductUpdatedEvent : BaseEventEntity
    {
        public override string EventName => nameof(ProductUpdatedEvent);

        public ProductEntity UpdatedProduct { get; set; }
    }
}
