using System.Collections.Generic;
using MediatR;
using Newtonsoft.Json;
using VueAppTsApi.Core.DTOs;

namespace VueAppTsApi.Core.Queries
{
    public class GetAllImagesQuery : IRequest<ICollection<ImageDTO>>
    {
        [JsonConstructor]
        public GetAllImagesQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set; }
    }
}