using MediatR;

namespace SocialMediaSoln.Application.Features.CQRS.Commands
{
    public class UpdatePostCommandRequest : IRequest
    {
        public int Id { get; set; }
        public int LikeCount { get; set; }
    }
}
