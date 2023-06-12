using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialMediaSoln.Application.Features.CQRS.Commands;
using SocialMediaSoln.Application.Interfaces;
using SocialMediaSoln.Domain.Entities;

namespace SocialMediaSoln.Application.Features.CQRS.Handlers
{
    public class RemoveLikeCommandHandler : IRequestHandler<RemoveLikeCommandRequest>
    {
        private readonly IRepository<Like> _repository;

        public RemoveLikeCommandHandler(IRepository<Like> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveLikeCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await _repository.GetQueryable().Where(x => x.AppUserId == request.AppUserId && x.PostId == request.PostId).FirstOrDefaultAsync();
            if (deletedEntity != null)
            {
                deletedEntity.AppUserId = request.AppUserId;
                deletedEntity.PostId = request.PostId;
                await this._repository.Remove(deletedEntity);
            }

            return Unit.Value;
        }
    }
}
