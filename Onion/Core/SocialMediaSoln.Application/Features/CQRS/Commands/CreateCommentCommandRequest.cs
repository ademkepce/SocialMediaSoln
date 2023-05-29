
using MediatR;
using SocialMediaSoln.Application.Dto;
using SocialMediaSoln.Domain.Entities;

namespace SocialMediaSoln.Application.Features.CQRS.Commands
{
    public class CreateCommentCommandRequest :IRequest<CreatedCommentDto?>
    {
        public string? Message { get; set; }
        public string? PublishedDate { get; set; }
        public int? PostId { get; set; }
        public int? AppUserId { get; set; }
    }
}
