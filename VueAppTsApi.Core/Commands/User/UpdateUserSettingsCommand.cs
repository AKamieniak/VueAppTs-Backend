using System.ComponentModel.DataAnnotations;
using MediatR;
using Newtonsoft.Json;
using VueAppTsApi.Core.DTOs;

namespace VueAppTsApi.Core.Commands.User
{
    public class UpdateUserSettingsCommand : IRequest<UserDTO>
    {
        [JsonConstructor]
        public UpdateUserSettingsCommand(int id, string defaultLanguage)
        {
            Id = id;
            DefaultLanguage = defaultLanguage;
        }

        [Required]
        public int Id { get; set; }


        [Required]
        public string DefaultLanguage { get; set; }
    }
}