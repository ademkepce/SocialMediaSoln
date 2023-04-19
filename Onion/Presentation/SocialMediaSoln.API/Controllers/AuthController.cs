using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialMediaSoln.Application.Extensions;
using SocialMediaSoln.Application.Features.CQRS.Queries;

namespace SocialMediaSoln.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(CheckUserQueryRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsExist)
                return Created("",JwtTokenGenerator.GenerateToken(result));
            else
                return BadRequest("Kullanıcı adı veya şifre hatalı");
        }
    }
}
