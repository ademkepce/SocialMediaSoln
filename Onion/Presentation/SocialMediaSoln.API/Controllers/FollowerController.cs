﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMediaSoln.Application.Features.CQRS.Commands;

namespace SocialMediaSoln.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FollowerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFollowerCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Created("", result);
        }

        [HttpDelete("{followerId}/{appUserId}")]
        public async Task<IActionResult> Remove(int followerId, int appUserId)
        {
            await _mediator.Send(new RemoveFollowerCommandRequest(followerId, appUserId));
            return Ok();
        }
    }
}
