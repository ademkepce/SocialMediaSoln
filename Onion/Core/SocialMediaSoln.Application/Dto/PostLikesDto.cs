using SocialMediaSoln.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaSoln.Application.Dto
{
    public class PostLikesDto
    {
        public int? AppUserId { get; set; }
        //public PostUsersDto? AppUser { get; set; }
        public int? PostId { get; set; }
    }
}
