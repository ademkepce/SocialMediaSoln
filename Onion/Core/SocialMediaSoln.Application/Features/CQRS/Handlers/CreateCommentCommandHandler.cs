using AutoMapper;
using MediatR;
using SocialMediaSoln.Application.Dto;
using SocialMediaSoln.Application.Features.CQRS.Commands;
using SocialMediaSoln.Application.Interfaces;
using SocialMediaSoln.Domain.Entities;

namespace SocialMediaSoln.Application.Features.CQRS.Handlers
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommandRequest, CreatedCommentDto?>
    {
        private readonly IRepository<Comment> _repository;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(IRepository<Comment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreatedCommentDto?> Handle(CreateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var comment = new Comment
            {
                Message = request.Message,
                PublishedDate = request.PublishedDate,
                PostId = request.PostId,
                AppUserId = request.AppUserId
            };
            var result = await _repository.CreateAsync(comment);

            return _mapper.Map<CreatedCommentDto>(result);
        }
    }
}
