using MediatR;
using SocialMediaSoln.Application.Features.CQRS.Commands;
using SocialMediaSoln.Application.Interfaces;
using SocialMediaSoln.Domain.Entities;

namespace SocialMediaSoln.Application.Features.CQRS.Handlers
{
    public class RemoveFollowerCommandHandler : IRequestHandler<RemoveFollowerCommandRequest>
    {
        private readonly IRepository<Follower> _repository;

        public RemoveFollowerCommandHandler(IRepository<Follower> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveFollowerCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await _repository.GetByIdAsync(request.Id);
            if (deletedEntity != null)
            {
                deletedEntity.Id = request.Id;
                await this._repository.Remove(deletedEntity);
            }

            return Unit.Value;
        }
    }
}
