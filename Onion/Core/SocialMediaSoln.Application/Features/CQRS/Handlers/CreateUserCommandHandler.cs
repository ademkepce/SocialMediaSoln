using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using SocialMediaSoln.Application.Dto;
using SocialMediaSoln.Application.Features.CQRS.Commands;
using SocialMediaSoln.Application.Interfaces;
using SocialMediaSoln.Domain.Entities;
using System.Net;
using System.Net.Security;

namespace SocialMediaSoln.Application.Features.CQRS.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreatedUserDto?>
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IRepository<AppUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreatedUserDto?> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            string path = "";
            if (request.File != null)
                path = await UploadImage(request.File);
            var post = new AppUser
            {
                Email = request.Email,
                Password = request.Password,
                Name = request.Name,
                Surname = request.Surname,
                Part = request.Part,
                IsGroup = request.IsGroup.Value,
                ProfileImageUrl = path
            };
            var result = await _repository.CreateAsync(post);

            return _mapper.Map<CreatedUserDto>(result);
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

        //public string GetImageUrl(string relativePath)
        //{
        //    var baseUrl = "https://sausocialmedia.com.tr";
        //    var imageUrl = $"{baseUrl}{relativePath}";

        //    return imageUrl;
        //}

    }
}
