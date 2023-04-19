using AutoMapper;
using MediatR;
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
    internal class RemovePostCommandHandler : IRequestHandler<RemovePostCommandRequest>
    {
        private readonly IRepository<Post> _repository;

        public RemovePostCommandHandler(IRepository<Post> repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(RemovePostCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await _repository.GetByIdAsync(request.Id);
            if (deletedEntity != null)
            {
                deletedEntity.Id = request.Id;
                await this._repository.Remove(deletedEntity);
            }

            return Unit.Value;
        }
    }
}
