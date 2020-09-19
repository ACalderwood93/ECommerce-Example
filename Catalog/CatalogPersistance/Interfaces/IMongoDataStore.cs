using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatalogPersistance.Interfaces
{
    public interface IMongoDataStore<T>
    {
        Task<IList<T>> GetAllAsync();
    }
}
