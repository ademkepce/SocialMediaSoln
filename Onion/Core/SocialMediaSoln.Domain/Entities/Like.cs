
namespace SocialMediaSoln.Domain.Entities
{
    public class Like
    {
        public int Id { get; set; }
        public int? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public int? PostId { get; set; }
        public Post? Post { get; set; }
    }
}
