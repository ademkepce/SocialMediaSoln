using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using SocialMediaSoln.Application.Dto;
using SocialMediaSoln.Application.Features.CQRS.Commands;
using SocialMediaSoln.Application.Interfaces;
using SocialMediaSoln.Domain.Entities;

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
            string path = await UploadImage(request.File);
            var post = new AppUser
            {
                Email = request.Email,
                Password = request.Password,
                Name = request.Name,
                Surname = request.Surname,
                Part = request.Part,
                IsGroup = request.IsGroup,
                ProfileImageUrl = path
            };
            var result = await _repository.CreateAsync(post);

            return _mapper.Map<CreatedUserDto>(result);
        }

        public async Task<string> UploadImage(IFormFile file)
        {
            var special = Guid.NewGuid().ToString();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Utility\Image", special + file.FileName);
            using (FileStream ms = new FileStream(filePath,FileMode.Create)) {
                await file.CopyToAsync(ms);
            }
            var filename = special + "-" + file.FileName;
            return filePath;
        }
    }
}
