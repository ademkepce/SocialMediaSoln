using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialMediaSoln.Application.Dto;
using SocialMediaSoln.Application.Features.CQRS.Queries;
using SocialMediaSoln.Application.Interfaces;
using SocialMediaSoln.Domain.Entities;

namespace SocialMediaSoln.Application.Features.CQRS.Handlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQueryRequest, List<UsersListDto>>
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IRepository<Post> _repositoryPost;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IRepository<AppUser> repository, IMapper mapper, IRepository<Post> repositoryPost)
        {
            _repository = repository;
            _repositoryPost = repositoryPost;
            _mapper = mapper;
        }

        public async Task<List<UsersListDto>> Handle(GetUsersQueryRequest request, CancellationToken cancellationToken)
        {
            var userListDto = new UsersListDto();
            var users = _repository.GetQueryable().Include(x => x.Followers).Include(x => x.Followings).Include(x => x.Likes);

            var posts = _repositoryPost.GetQueryable().Include(x => x.Comments).ToList();
            var postMapping = _mapper.Map<List<UsersPostDto>>(posts);

            userListDto.Posts = postMapping;

            return _mapper.Map<List<UsersListDto>>(users);
        }
    }
}
