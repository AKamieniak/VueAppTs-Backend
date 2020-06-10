using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using VueAppTsApi.Core.DTOs;
using VueAppTsApi.Core.Entities;
using VueAppTsApi.Core.Exceptions;
using VueAppTsApi.Core.Interfaces;
using VueAppTsApi.Core.Queries;

namespace VueAppTsApi.Handlers
{
    public class GetAllImagesHandler : IRequestHandler<GetAllImagesQuery, ICollection<ImageDTO>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetAllImagesHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<ImageDTO>> Handle(GetAllImagesQuery request, CancellationToken cancellationToken)
        {
            var user = (await _repository.GetByCondition<User>(x => x.Id.Equals(request.UserId))).FirstOrDefault();

            if (user == null)
            {
                throw new NotFoundException($"User not found: [UserId]={request.UserId}");
            }

            var images = await _repository.GetAll<Image>();
            var imagesDto = _mapper.Map<ICollection<ImageDTO>>(images);

            foreach (var imageDto in imagesDto)
            {
                imageDto.IsSaved = user.SavedImages.Any(x => x.ImageId.Equals(imageDto.Id));
            }

            return imagesDto;
        }
    }
}