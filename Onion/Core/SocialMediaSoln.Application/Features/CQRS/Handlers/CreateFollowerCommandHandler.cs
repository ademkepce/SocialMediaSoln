using AutoMapper;
using MediatR;
using SocialMediaSoln.Application.Dto;
using SocialMediaSoln.Application.Features.CQRS.Commands;
using SocialMediaSoln.Application.Interfaces;
using SocialMediaSoln.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaSoln.Application.Features.CQRS.Handlers
{
    public class CreateFollowerCommandHandler : IRequestHandler<CreateFollowerCommandRequest>
    {
        private readonly IRepository<Follower> _repository;
        private readonly IRepository<Following> _repositoryFollowing;
        private readonly IMapper _mapper;

        public CreateFollowerCommandHandler(IRepository<Follower> repository, IRepository<Following> repositoryFollowing, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryFollowing = repositoryFollowing;
        }

        public async Task<Unit> Handle(CreateFollowerCommandRequest request, CancellationToken cancellationToken)
        {
            var follower = new Follower
            {
                FollowerId = request.FollowerId,
                AppUserId = request.AppUserId
            };

            var following = new Following
            {
                FollowingId = request.AppUserId,
                AppUserId = request.FollowerId
            };

            await _repositoryFollowing.CreateAsync(following);
            await _repository.CreateAsync(follower);

            return Unit.Value;
        }
    }
}
