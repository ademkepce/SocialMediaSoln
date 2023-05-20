
namespace SocialMediaSoln.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public string? PublishedDate { get; set; }
        public int PostId { get; set; }
        public Post? Post { get; set; }

    }
}