using System.ComponentModel.DataAnnotations;
using MediatR;
using Newtonsoft.Json;
using VueAppTsApi.Core.DTOs;

namespace VueAppTsApi.Core.Commands
{
    public class CreateUserCommand : IRequest<UserDTO>
    {
        [JsonConstructor]
        public CreateUserCommand(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string DefaultLanguage { get; set; }

        [Required]
        //[RegularExpression(ApplicationConstants.RegexExpressions.Password, ErrorMessage = ApplicationConstants.RegexExpressions.PasswordError)]
        public string Password { get; set; }
    }
}