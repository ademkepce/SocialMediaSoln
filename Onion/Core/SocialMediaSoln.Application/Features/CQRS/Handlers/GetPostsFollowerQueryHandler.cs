using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialMediaSoln.Application.Dto;
using SocialMediaSoln.Application.Features.CQRS.Queries;
using SocialMediaSoln.Application.Interfaces;
using SocialMediaSoln.Domain.Entities;

namespace SocialMediaSoln.Application.Features.CQRS.Handlers
{
    public class GetPostsFollowerQueryHandler : IRequestHandler<GetPostsFollowerQueryRequest, List<PostsListDto>>
    {
        private readonly IRepository<Post> _repository;
        private readonly IRepository<Follower> _repositoryFollower;
        private readonly IMapper _mapper;

        public GetPostsFollowerQueryHandler(IRepository<Post> repository, IMapper mapper, IRepository<Follower> repositoryFollower)
        {
            _repository = repository;
            _repositoryFollower = repositoryFollower;
            _mapper = mapper;
        }

        public async Task<List<PostsListDto>> Handle(GetPostsFollowerQueryRequest request, CancellationToken cancellationToken)
        {
            var follower = await _repositoryFollower.GetQueryable().Where(x => x.FollowerId == request.AppUserId).ToListAsync();
            var appUserIds = follower.Select(f => f.AppUserId).ToArray();

            var posts = await _repository.GetQueryable().Where(p => appUserIds.Contains(p.AppUserId)).Include(x => x.AppUser).Include(x => x.Comments).ThenInclude(x => x.AppUser).Include(x => x.Likes).ToListAsync();

            return _mapper.Map<List<PostsListDto>>(posts);
        }
    }
}
