using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaSoln.Application.Dto
{
    public class PostListDto
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public string? PublishedDate { get; set; }
        public PostUserDto? AppUser { get; set; }
        public List<PostCommentDto>? Comments { get; set; }
        public List<PostLikesDto>? Likes { get; set; }
    }
}
