
namespace SocialMediaSoln.Domain.Entities
{
    public class Community
    {
        public int Id { get; set; }
        public string? CommunityName { get; set; }
        public int Members { get; set; }
        public string? ImageUrl { get; set; }
        public List<Post>? Posts { get; set; }
    }
}