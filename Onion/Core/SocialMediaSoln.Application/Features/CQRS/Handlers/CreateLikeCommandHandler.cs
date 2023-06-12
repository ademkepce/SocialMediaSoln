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
    public class CreateLikeCommandHandler : IRequestHandler<CreateLikeCommandRequest, CreatedLikeDto?>
    {
        private readonly IRepository<Like> _repository;
        private readonly IMapper _mapper;

        public CreateLikeCommandHandler(IRepository<Like> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreatedLikeDto?> Handle(CreateLikeCommandRequest request, CancellationToken cancellationToken)
        {
            var follower = new Like
            {
                AppUserId = request.AppUserId,
                PostId = request.PostId
            };
            var result = await _repository.CreateAsync(follower);

            return _mapper.Map<CreatedLikeDto>(result);
        }
    }
}
