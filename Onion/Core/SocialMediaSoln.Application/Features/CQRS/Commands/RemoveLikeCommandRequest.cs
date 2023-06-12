using MediatR;

namespace SocialMediaSoln.Application.Features.CQRS.Commands
{
    public class RemoveLikeCommandRequest : IRequest
    {
        public int? AppUserId { get; set; }
        public int? PostId { get; set; }
        public RemoveLikeCommandRequest(int? appUserId, int? postId)
        {
            AppUserId = appUserId;
            PostId = postId;
        }
    }
}
