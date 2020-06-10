using System.Net;

namespace VueAppTsApi.Core.Interfaces
{
    public interface IBaseException
    {
        string Message { get; }
        string Title { get; }
        HttpStatusCode StatusCode { get; }
    }
}