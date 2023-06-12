using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialMediaSoln.Application.Dto;
using SocialMediaSoln.Application.Features.CQRS.Queries;
using SocialMediaSoln.Application.Interfaces;
using SocialMediaSoln.Domain.Entities;

namespace SocialMediaSoln.Application.Features.CQRS.Handlers
{
    public class GetPostsQueryHandler : IRequestHandler<GetPostsQueryRequest, List<PostsListDto>>
    {
        private readonly IRepository<Post> _repository;
        private readonly IMapper _mapper;

        public GetPostsQueryHandler(IRepository<Post> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<PostsListDto>> Handle(GetPostsQueryRequest request, CancellationToken cancellationToken)
        {
            var posts = await _repository.GetQueryable().Include(x => x.AppUser).Include(x => x.Comments).ThenInclude(x=>x.AppUser).Include(x=>x.Likes).ToListAsync();
            return _mapper.Map<List<PostsListDto>>(posts);
        }
    }
}
