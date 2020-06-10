using System.Linq;
using AutoMapper;
using VueAppTsApi.Core.DTOs;
using VueAppTsApi.Core.Entities;

namespace VueAppTsApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(x => x.SavedImages, opts => opts.MapFrom(x => x.SavedImages.Select(xi => xi.Image)));

            CreateMap<Image, ImageDTO>();

            CreateMap<UserImage, ImageDTO>()
                .ForMember(x => x.Description, opts => opts.MapFrom(x => x.Image.Description))
                .ForMember(x => x.Id, opts => opts.MapFrom(x => x.Image.Id))
                .ForMember(x => x.Likes, opts => opts.MapFrom(x => x.Image.Likes))
                .ForMember(x => x.Name, opts => opts.MapFrom(x => x.Image.Name));
        }
    }
}