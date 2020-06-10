using System.ComponentModel.DataAnnotations;
using MediatR;
using Newtonsoft.Json;
using VueAppTsApi.Core.DTOs;

namespace VueAppTsApi.Core.Authentication
{
    public class LoginCommand : IRequest<AuthResponseDTO>
    {
        [JsonConstructor]
        public LoginCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}