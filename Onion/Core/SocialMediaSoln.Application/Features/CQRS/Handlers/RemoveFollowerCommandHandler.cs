using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialMediaSoln.Application.Features.CQRS.Commands;
using SocialMediaSoln.Application.Interfaces;
using SocialMediaSoln.Domain.Entities;

namespace SocialMediaSoln.Application.Features.CQRS.Handlers
{
    public class RemoveFollowerCommandHandler : IRequestHandler<RemoveFollowerCommandRequest>
    {
        private readonly IRepository<Follower> _repository;
        private readonly IRepository<Following> _repositoryFollowing;
        public RemoveFollowerCommandHandler(IRepository<Follower> repository, IRepository<Following> repositoryFollowing)
        {
            _repository = repository;
            _repositoryFollowing = repositoryFollowing;
        }

        public async Task<Unit> Handle(RemoveFollowerCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedFollower = await _repository.GetQueryable().Where(x => x.FollowerId == request.FollowerId && x.AppUserId == request.AppUserId).FirstOrDefaultAsync();
            var deletedFollowing = await _repositoryFollowing.GetQueryable().Where(x => x.FollowingId == request.AppUserId && x.AppUserId == request.FollowerId).FirstOrDefaultAsync();
            if (deletedFollower != null)
            {
                deletedFollower.FollowerId = request.FollowerId;
                deletedFollower.AppUserId = request.AppUserId;
                await this._repository.Remove(deletedFollower);
            }

            if(deletedFollowing != null)
            {
                deletedFollowing.FollowingId = request.AppUserId;
                deletedFollowing.AppUserId = request.FollowerId;
                await this._repositoryFollowing.Remove(deletedFollowing);
            }

            return Unit.Value;
        }
    }
}
