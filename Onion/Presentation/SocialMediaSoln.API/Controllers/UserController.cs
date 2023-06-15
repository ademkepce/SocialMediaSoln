using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMediaSoln.Application.Features.CQRS.Commands;
using SocialMediaSoln.Application.Features.CQRS.Queries;

namespace SocialMediaSoln.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _mediator.Send(new GetUsersQueryRequest());

            // Kullanıcının profil resmi URL'sini güncelle
            foreach (var user in result)
            {
                if (user.ProfileImageUrl != null)
                    user.ProfileImageUrl = GenerateImageUrl(user.ProfileImageUrl);
            }

            return Ok(result);
        }

        private string GenerateImageUrl(string fileName)
        {
            // Doğrudan dosya adını URL olarak kullan
            return $"https://sausocialmedia.com.tr/api/User/Images/{fileName}";
        }

        [HttpGet("images/{fileName}")]
        public IActionResult GetImage(string fileName)
        {
            var wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var imagePath = Path.Combine(wwwrootPath, "Images", fileName);

            if (!System.IO.File.Exists(imagePath))
            {
                return NotFound();
            }

            var imageBytes = System.IO.File.ReadAllBytes(imagePath);

            return File(imageBytes, "image/png"); // ya da resmin uygun medya türüne göre belirleyin
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetUserQueryRequest(id));
            // Kullanıcının profil resmi URL'sini güncelle
            if (result.ProfileImageUrl != null)
                result.ProfileImageUrl = GenerateImageUrl(result.ProfileImageUrl);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateUserCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateUserCommandRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }
    }
}
