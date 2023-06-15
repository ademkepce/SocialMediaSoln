
namespace SocialMediaSoln.Application.Dto
{
    public class CreatedUserDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Part { get; set; }
        public string? ProfileImageUrl { get; set; }
        public bool IsGroup { get; set; }
    }
}
