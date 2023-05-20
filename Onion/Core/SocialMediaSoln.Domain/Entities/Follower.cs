
namespace SocialMediaSoln.Domain.Entities
{
    public class Follower//Takipçilerim
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
