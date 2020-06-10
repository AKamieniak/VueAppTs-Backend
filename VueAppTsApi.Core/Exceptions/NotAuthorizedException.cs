using System;
using System.Net;

namespace VueAppTsApi.Core.Exceptions
{
    public class NotAuthorizedException : BaseException
    {
        public NotAuthorizedException()
        {
        }

        public NotAuthorizedException(string message)
            : base(message)
        {
        }

        public NotAuthorizedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public override string Title
        {
            get { return "Not authorized"; }
        }

        public override HttpStatusCode StatusCode
        {
            get { return HttpStatusCode.Unauthorized; }
        }
    }
}