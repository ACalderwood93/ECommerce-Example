using CatalogPersistance.Entities.Events;
using CatalogPersistance.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatalogPersistance.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        private readonly IMongoDataStore<BaseEventEntity> _datastore;

        public EventsRepository(IMongoDataStore<BaseEventEntity> datastore)
        {
            _datastore = datastore;
        }

        public async Task InsertAsync(BaseEventEntity entity) => await _datastore.InsertAsync(entity);
    }
}
