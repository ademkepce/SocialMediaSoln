using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaSoln.Domain.Entities
{
    public class Follower//Takipçilerim
    {
        public int Id { get; set; }
        public int FollowerId { get; set; }
    }
}
