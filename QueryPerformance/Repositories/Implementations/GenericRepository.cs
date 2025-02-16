using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using QueryPerformance.Repositories.Interfaces;

namespace QueryPerformance.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<T> DbSet;

        public GenericRepository(DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            DbSet = Context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }
    }
}