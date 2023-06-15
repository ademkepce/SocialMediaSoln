using MediatR;
using SocialMediaSoln.Application.Features.CQRS.Commands;
using SocialMediaSoln.Application.Interfaces;
using SocialMediaSoln.Domain.Entities;

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
            if (updatedEntity != null)
            {
                // Güncellenecek alanları kontrol ederek güncelleme yapın
                if (request.Content != null)
                    updatedEntity.Content = request.Content;

                if (request.PublishedDate != null)
                    updatedEntity.PublishedDate = request.PublishedDate;

                if (request.AppUserId != null)
                    updatedEntity.AppUserId = request.AppUserId;

                await this._repository.SaveChangesAsync();
            }

            return Unit.Value;
        }
    }
}
