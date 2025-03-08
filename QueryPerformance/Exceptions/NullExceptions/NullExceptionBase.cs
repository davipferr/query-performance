using System;

namespace QueryPerformance.Exceptions.NullExceptions
{
    public class NullExceptionBase : Exception
    {
        protected NullExceptionBase(string message) : base(message) { }

        protected NullExceptionBase(string message, Exception innerException) : base(message, innerException) { }
    }
}
