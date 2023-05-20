using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaSoln.Application.Dto
{
    public class PostCommentDto
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        public string? PublishedDate { get; set; }
    }
}
