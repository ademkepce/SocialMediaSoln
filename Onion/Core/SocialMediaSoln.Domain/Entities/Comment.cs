
namespace SocialMediaSoln.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public string? PublishedDate { get; set; }
        public int AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}