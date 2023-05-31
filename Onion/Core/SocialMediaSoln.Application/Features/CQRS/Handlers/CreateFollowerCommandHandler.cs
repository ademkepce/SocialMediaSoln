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
    public class CreateFollowerCommandHandler : IRequestHandler<CreateFollowerCommandRequest, CreatedFollowerDto?>
    {
        private readonly IRepository<Follower> _repository;
        private readonly IMapper _mapper;

        public CreateFollowerCommandHandler(IRepository<Follower> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreatedFollowerDto?> Handle(CreateFollowerCommandRequest request, CancellationToken cancellationToken)
        {
            var follower = new Follower
            {
                AppUserId = request.AppUserId
            };
            var result = await _repository.CreateAsync(follower);

            return _mapper.Map<CreatedFollowerDto>(result);
        }
    }
}
