using SocialMediaSoln.Domain.Entities;

namespace SocialMediaSoln.Application.Dto
{
    public class UserListDto
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Part { get; set; }
        public string? ProfileImagUrl { get; set; }
        public bool? IsGroup { get; set; }
        public List<PostListDto>? Posts { get; set; }
        public List<FollowerListDto>? Followers { get; set; }
        public List<FollowingListDto>? Followings { get; set; }
    }
}
