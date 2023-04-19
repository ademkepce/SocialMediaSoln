using AutoMapper;
using MediatR;
using SocialMediaSoln.Application.Dto;
using SocialMediaSoln.Application.Features.CQRS.Queries;
using SocialMediaSoln.Application.Interfaces;
using SocialMediaSoln.Domain.Entities;

namespace SocialMediaSoln.Application.Features.CQRS.Handlers
{
    public class GetPostQueryHandler : IRequestHandler<GetPostQueryRequest, PostListDto>
    {
        private readonly IRepository<Post> _repository;
        private readonly IMapper _mapper;

        public GetPostQueryHandler(IRepository<Post> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PostListDto> Handle(GetPostQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<PostListDto>(data);
        }
    }
}
