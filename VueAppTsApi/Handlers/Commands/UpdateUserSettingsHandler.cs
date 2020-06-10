using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using VueAppTsApi.Core.Commands.User;
using VueAppTsApi.Core.DTOs;
using VueAppTsApi.Core.Entities;
using VueAppTsApi.Core.Exceptions;
using VueAppTsApi.Core.Interfaces;

namespace VueAppTsApi.Handlers
{
    public class UpdateUserSettingsHandler : IRequestHandler<UpdateUserSettingsCommand, UserDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdateUserSettingsHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(UpdateUserSettingsCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetById<User>(request.Id);

            if (user == null)
            {
                throw new NotFoundException($"User not found: [UserId]={request.Id}");
            }

            user.UpdateSettings(request);

            await _repository.SaveAsync();

            return _mapper.Map<UserDTO>(user);
        }
    }
}