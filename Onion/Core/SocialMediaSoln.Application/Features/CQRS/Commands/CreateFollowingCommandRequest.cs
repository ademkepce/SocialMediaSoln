using MediatR;
using SocialMediaSoln.Application.Dto;

namespace SocialMediaSoln.Application.Features.CQRS.Commands
{
    public class CreateFollowingCommandRequest : IRequest<CreatedFollowingDto?>
    {
        public int? AppUserId { get; set; }
    }
}
