﻿
namespace SocialMediaSoln.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? PublishedDate { get; set; }
        public int LikeCount { get; set; }
        public int AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
