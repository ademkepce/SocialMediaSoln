using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

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
        [NotMapped]
        public IFormFile? File { get; set; }
        public string? ProfileImageUrl { get; set; }
        public bool IsGroup { get; set; }
        public List<Post>? Posts { get; set; }
        public List<Like>? Likes { get; set; }
        public List<Follower>? Followers { get; set; }
        public List<Following>? Followings { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}