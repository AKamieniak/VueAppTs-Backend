using System.Threading.Tasks;
using VueAppTsApi.Core.DTOs;

namespace VueAppTsApi.Core.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AuthResponseDTO> Authenticate(string username, string password);
    }
}