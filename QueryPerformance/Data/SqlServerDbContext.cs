using System.Data.Entity;

namespace QueryPerformance.Data
{
    public class SqlServerDbContext : DbContext
    {
        public SqlServerDbContext() : base("name=SqlServer") 
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }
    }
}
