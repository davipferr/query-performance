using System.Data.Entity;
using QueryPerformance.Models;

namespace QueryPerformance.Data
{
    public class SqlServerDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public SqlServerDbContext() : base("name=SqlServer") 
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                        .ToTable("1mil_rows_table");
            
            modelBuilder.Entity<Person>().Property(p => p.PersonId).HasColumnName("id");
            modelBuilder.Entity<Person>().Property(p => p.DataNasc).HasColumnName("data_nasc");
            modelBuilder.Entity<Person>().Property(p => p.TelefoneFixo).HasColumnName("telefone_fixo");
            modelBuilder.Entity<Person>().Property(p => p.TipoSanguineo).HasColumnName("tipo_sanguineo");
        }
    }
}
