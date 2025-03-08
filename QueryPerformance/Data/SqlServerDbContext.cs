using System.Data.Entity;
using QueryPerformance.Models;

namespace QueryPerformance.Data
{
    public class SqlServerDbContext : DbContext
    {
        public DbSet<OneThousandRows> OneThousandRows { get; set; }

        public SqlServerDbContext() : base("name=SqlServer") 
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }
    }
}
