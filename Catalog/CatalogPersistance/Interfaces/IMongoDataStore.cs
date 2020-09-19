using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CatalogPersistance.Interfaces
{
    public interface IMongoDataStore<T>
    {
        Task<IList<T>> GetAllAsync();

        Task<IList<T>> FindAsync(Expression<Func<T, bool>> filter);

        Task InsertAsync(T aggregate);

    }
}
