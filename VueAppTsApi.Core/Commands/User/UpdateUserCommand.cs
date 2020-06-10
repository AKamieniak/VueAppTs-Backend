using System.ComponentModel.DataAnnotations;
using MediatR;
using Newtonsoft.Json;
using VueAppTsApi.Core.DTOs;

namespace VueAppTsApi.Core.Commands
{
    public class UpdateUserCommand : IRequest<UserDTO>
    {
        [JsonConstructor]
        public UpdateUserCommand(int id, string username, string email)
        {
            Id = id;
            Username = username;
            Email = email;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}