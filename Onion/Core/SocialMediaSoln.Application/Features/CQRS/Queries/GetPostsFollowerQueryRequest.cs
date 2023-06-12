using MediatR;
using SocialMediaSoln.Application.Dto;

namespace SocialMediaSoln.Application.Features.CQRS.Queries
{
    public class GetPostsFollowerQueryRequest : IRequest<List<PostsListDto>>
    {
        public int AppUserId { get; set; }
        public GetPostsFollowerQueryRequest(int id)
        {
            AppUserId = id;
        }
    }
}
