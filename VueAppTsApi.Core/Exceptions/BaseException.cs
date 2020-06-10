using System;
using System.Net;
using VueAppTsApi.Core.Interfaces;

namespace VueAppTsApi.Core.Exceptions
{
    public abstract class BaseException : ApplicationException, IBaseException
    {
        protected BaseException()
        {
        }

        protected BaseException(string message)
            : base(message)
        {
        }

        protected BaseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public abstract string Title { get; }

        public abstract HttpStatusCode StatusCode { get; }
    }
}