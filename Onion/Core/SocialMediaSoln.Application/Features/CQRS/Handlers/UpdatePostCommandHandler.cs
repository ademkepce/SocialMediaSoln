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
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommandRequest>
    {
        private readonly IRepository<Post> _repository;

        public UpdatePostCommandHandler(IRepository<Post> repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(UpdatePostCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedEntity = await _repository.GetByIdAsync(request.Id);
            if(updatedEntity != null)
            {
                updatedEntity.LikeCount = request.LikeCount;
                await this._repository.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}
