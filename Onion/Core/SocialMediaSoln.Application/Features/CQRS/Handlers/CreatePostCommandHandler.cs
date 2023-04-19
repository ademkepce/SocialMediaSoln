using AutoMapper;
using MediatR;
using SocialMediaSoln.Application.Dto;
using SocialMediaSoln.Application.Features.CQRS.Commands;
using SocialMediaSoln.Application.Interfaces;
using SocialMediaSoln.Domain.Entities;

namespace SocialMediaSoln.Application.Features.CQRS.Handlers
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommandRequest, CreatedPostDto?>
    {
        private readonly IRepository<Post> _repository;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler(IRepository<Post> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreatedPostDto?> Handle(CreatePostCommandRequest request, CancellationToken cancellationToken)
        {
            var post = new Post
            {
                Title = request.Title,
                Content = request.Content,
                PublishedDate = request.PublishedDate,
                Comments = request.Comments,
                AppUserId = request.AppUserId,
                CommunityId = request.CommunityId
            };
            var result = await _repository.CreateAsync(post);

            return _mapper.Map<CreatedPostDto>(result);
        }
    }
}
