using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialMediaSoln.Application.Dto;
using SocialMediaSoln.Application.Features.CQRS.Queries;
using SocialMediaSoln.Application.Interfaces;
using SocialMediaSoln.Domain.Entities;

namespace SocialMediaSoln.Application.Features.CQRS.Handlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQueryRequest, UserListDto>
    {
        private readonly IRepository<AppUser> _repositoryAppUser;
        private readonly IRepository<Post> _repositoryPost;
        private readonly IRepository<Follower> _repositoryFollower;
        private readonly IRepository<Following> _repositoryFollowing;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IRepository<AppUser> repositoryAppUser, IRepository<Post> repositoryPost, IRepository<Follower> repositoryFollower, IRepository<Following> repositoryFollowing, IRepository<Comment> repositoryComment, IMapper mapper)
        {
            _repositoryAppUser = repositoryAppUser;
            _repositoryPost = repositoryPost;
            _repositoryFollower = repositoryFollower;
            _repositoryFollowing = repositoryFollowing;
            _mapper = mapper;
        }
        public async Task<UserListDto> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            var userListDto = new UserListDto();
            var user = await _repositoryAppUser.GetByFilterAsync(x => x.Id == request.Id);

            var posts = _repositoryPost.GetQueryable().Include(x => x.Comments).Where(x => x.AppUserId == request.Id).ToList();
            var postMapping = _mapper.Map<List<PostListDto>>(posts);

            var followers = _repositoryFollower.GetQueryable().Where(x => x.AppUserId == request.Id);
            var followerMapping = _mapper.Map<List<FollowerListDto>>(followers);

            var followings = _repositoryFollowing.GetQueryable().Where(x => x.AppUserId == request.Id);
            var followingMapping = _mapper.Map<List<FollowingListDto>>(followings);

            if (user != null)
            {
                userListDto.Id = user.Id;
                userListDto.Email = user.Email;
                userListDto.Name = user.Name;
                userListDto.Surname = user.Surname;
                userListDto.Part = user.Part;
                userListDto.ProfileImagUrl = user.ProfileImagUrl;
                userListDto.Posts = posts;
                userListDto.Followers = followerMapping;
                userListDto.Followings = followingMapping;
            }

            return userListDto;
        }
    }
}
