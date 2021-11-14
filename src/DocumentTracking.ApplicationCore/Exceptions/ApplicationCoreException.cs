using System;

namespace DocumentTracking.ApplicationCore.Exceptions
{
    public class ApplicationCoreException : Exception
    {
        public ApplicationCoreException()
        { }

        public ApplicationCoreException(string message)
            : base(message)
        { }


        public ApplicationCoreException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
