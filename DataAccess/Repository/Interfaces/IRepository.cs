using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken);
        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
    }
}