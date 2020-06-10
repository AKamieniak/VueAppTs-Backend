using System.ComponentModel.DataAnnotations;
using MediatR;
using Newtonsoft.Json;

namespace VueAppTsApi.Core.Commands
{
    public class SaveImageCommand : IRequest
    {
        [JsonConstructor]
        public SaveImageCommand(int userId, int imageId)
        {
            UserId = userId;
            ImageId = imageId;
        }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ImageId { get; set; }
    }
}