
namespace SocialMediaSoln.Domain.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Part { get; set; }
        public List<Post>? Posts { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}