using MediatR;

namespace SocialMediaSoln.Application.Features.CQRS.Commands
{
    public class RemoveFollowingCommandRequest : IRequest
    {
        public int Id { get; set; }
        public RemoveFollowingCommandRequest(int id)
        {
            Id = id;
        }
    }
}
