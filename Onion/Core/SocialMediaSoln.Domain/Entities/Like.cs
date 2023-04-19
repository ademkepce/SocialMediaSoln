
namespace SocialMediaSoln.Domain.Entities
{
    public class Like
    {
        public int Id { get; set; }
        public int Likes { get; set; }
        public int PostId { get; set; }
        public Post? Post { get; set; }
    }
}