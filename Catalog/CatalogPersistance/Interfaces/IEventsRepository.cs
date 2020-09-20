using CatalogPersistance.Entities.Events;
using System.Threading.Tasks;

namespace CatalogPersistance.Repositories
{
    public interface IEventsRepository
    {
        Task InsertAsync(BaseEventEntity entity);
    }
}