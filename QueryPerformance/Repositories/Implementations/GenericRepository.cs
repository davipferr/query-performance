using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using QueryPerformance.Repositories.Interfaces;
using QueryPerformance.Exceptions.NullExceptions;

namespace QueryPerformance.Repositories.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext       Context;
        private readonly DbSet<TEntity>  DbSet;

        public GenericRepository(DbContext context)
        {
            Context = context ?? throw new DbContextIsNullException();
            DbSet   = Context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAllRows()
        {
            return DbSet.ToList();
        }
    }
}
