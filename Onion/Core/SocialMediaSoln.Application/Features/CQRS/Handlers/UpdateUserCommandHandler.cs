using MediatR;
using Microsoft.AspNetCore.Http;
using SocialMediaSoln.Application.Features.CQRS.Commands;
using SocialMediaSoln.Application.Interfaces;
using SocialMediaSoln.Domain.Entities;

namespace SocialMediaSoln.Application.Features.CQRS.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest>
    {
        private readonly IRepository<AppUser> _repository;

        public UpdateUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedEntity = await _repository.GetByIdAsync(request.Id);

            if (updatedEntity != null)
            {
                // Güncellenecek alanları kontrol ederek güncelleme yapın
                if (request.Email != null)
                    updatedEntity.Email = request.Email;

                if (request.Password != null)
                    updatedEntity.Password = request.Password;

                if (request.Name != null)
                    updatedEntity.Name = request.Name;

                if (request.Surname != null)
                    updatedEntity.Surname = request.Surname;

                if (request.Part != null)
                    updatedEntity.Part = request.Part;

                if (request.File != null)
                    updatedEntity.ProfileImageUrl = await UploadImage(request.File);

                if (request.IsGroup.HasValue)
                    updatedEntity.IsGroup = request.IsGroup.Value;

                await this._repository.SaveChangesAsync();
            }

            return Unit.Value;
        }


        public async Task<string> UploadImage(IFormFile file)
        {
            var special = Guid.NewGuid().ToString();
            var wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var imagesPath = Path.Combine(wwwrootPath, "Images");
            var fileName = special + "_" + file.FileName;
            var filePath = Path.Combine(imagesPath, fileName).Replace("\\", "/");

            Directory.CreateDirectory(imagesPath);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var relativePath = $"{fileName}";

            return relativePath;
        }
    }
}
