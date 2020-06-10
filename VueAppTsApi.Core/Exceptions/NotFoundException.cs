using System;
using System.Net;

namespace VueAppTsApi.Core.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public override string Title
        {
            get
            {
                return "Not found";
            }
        }

        public override HttpStatusCode StatusCode
        {
            get
            {
                return HttpStatusCode.NotFound;
            }
        }
    }
}