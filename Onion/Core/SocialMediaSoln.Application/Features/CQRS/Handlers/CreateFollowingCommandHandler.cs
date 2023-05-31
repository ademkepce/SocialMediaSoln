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
    public class CreateFollowingCommandHandler : IRequestHandler<CreateFollowingCommandRequest, CreatedFollowingDto?>
    {
        private readonly IRepository<Following> _repository;
        private readonly IMapper _mapper;

        public CreateFollowingCommandHandler(IRepository<Following> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreatedFollowingDto?> Handle(CreateFollowingCommandRequest request, CancellationToken cancellationToken)
        {
            var following = new Following
            {
                AppUserId = request.AppUserId
            };
            var result = await _repository.CreateAsync(following);

            return _mapper.Map<CreatedFollowingDto>(result);
        }
    }
}
