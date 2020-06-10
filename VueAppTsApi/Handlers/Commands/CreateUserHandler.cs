using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using VueAppTsApi.Core.Commands;
using VueAppTsApi.Core.DTOs;
using VueAppTsApi.Core.Entities;
using VueAppTsApi.Core.Interfaces;

namespace VueAppTsApi.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDTO>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public CreateUserHandler(IRepository repository, IMapper mapper) 
        { 
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.Build(request);

            await _repository.Add(user);
            await _repository.SaveAsync();

            return _mapper.Map<UserDTO>(user);
        }
    }
}