using MediatR;

namespace SocialMediaSoln.Application.Features.CQRS.Commands
{
    public class UpdatePostCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? PublishedDate { get; set; }
        public int LikeCount { get; set; }
    }
}
