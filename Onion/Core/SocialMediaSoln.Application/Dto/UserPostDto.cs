using SocialMediaSoln.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaSoln.Application.Dto
{
    public class UsersPostDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? PublishedDate { get; set; }
        public int LikeCount { get; set; }
        public List<PostCommentDto>? Comments { get; set; }
    }
}
