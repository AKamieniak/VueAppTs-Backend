using System;
using System.Net;

namespace VueAppTsApi.Core.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException()
        {
        }

        public BadRequestException(string message)
            : base(message)
        {
        }

        public BadRequestException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public override string Title
        {
            get
            {
                return "Invalid request data";
            }
        }

        public override HttpStatusCode StatusCode
        {
            get
            {
                return HttpStatusCode.BadRequest;
            }
        }
    }
}