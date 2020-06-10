using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using VueAppTsApi.Core.Commands;
using VueAppTsApi.Core.DTOs;
using VueAppTsApi.Core.Entities;
using VueAppTsApi.Core.Exceptions;
using VueAppTsApi.Core.Interfaces;

namespace VueAppTsApi.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public UpdateUserHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetById<User>(request.Id);

            if (user == null)
            {
                throw new NotFoundException($"User not found: [UserId]={request.Id}");
            }

            user.Update(request);

            await _repository.SaveAsync();

            return _mapper.Map<UserDTO>(user);
        }
    }
}