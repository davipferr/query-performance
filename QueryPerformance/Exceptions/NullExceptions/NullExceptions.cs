using System;

namespace QueryPerformance.Exceptions.NullExceptions
{
    public class DbContextIsNullException : NullExceptionBase
    {
        public DbContextIsNullException() : base("O DbContext não pode ser nulo.") { }
    }
}
