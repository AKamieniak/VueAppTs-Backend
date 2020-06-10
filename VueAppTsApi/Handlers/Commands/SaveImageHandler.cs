using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VueAppTsApi.Core.Commands;
using VueAppTsApi.Core.Entities;
using VueAppTsApi.Core.Exceptions;
using VueAppTsApi.Core.Interfaces;

namespace VueAppTsApi.Handlers
{
    public class SaveImageHandler : IRequestHandler<SaveImageCommand>
    {
        private readonly IRepository _repository;

        public SaveImageHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(SaveImageCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetById<User>(request.UserId);

            if (user == null)
            {
                throw new NotFoundException($"User not found: [UserId]={request.UserId}");
            }

            var image = await _repository.GetById<Image>(request.ImageId);

            if (image == null)
            {
                throw new NotFoundException($"Image not found: [ImageId]={request.ImageId}");
            }

            user.SaveImage(request);

            await _repository.SaveAsync();

            return Unit.Value;
        }
    }
}