using System.Collections.Generic;

namespace QueryPerformance.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAllRows();
    }
}
