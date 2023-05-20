using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialMediaSoln.Application.Dto;
using SocialMediaSoln.Application.Features.CQRS.Queries;
using SocialMediaSoln.Application.Interfaces;
using SocialMediaSoln.Domain.Entities;

namespace SocialMediaSoln.Application.Features.CQRS.Handlers
{
    public class GetPostsQueryHandler : IRequestHandler<GetPostsQueryRequest, List<PostListDto>>
    {
        private readonly IRepository<Post> _repository;
        private readonly IMapper _mapper;

        public GetPostsQueryHandler(IRepository<Post> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<PostListDto>> Handle(GetPostsQueryRequest request, CancellationToken cancellationToken)
        {
            var posts = _repository.GetQueryable().Include(x => x.AppUser).Include(x => x.Comments);
            return _mapper.Map<List<PostListDto>>(posts);
        }
    }
}
