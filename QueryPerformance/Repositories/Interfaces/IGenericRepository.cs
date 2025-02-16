using System.Collections.Generic;

namespace QueryPerformance.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Retrieves all entities
        /// </summary>
        /// <returns>An IEnumerable of entities.</returns>
        IEnumerable<T> GetAll();
    }
}