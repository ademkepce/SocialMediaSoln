using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaSoln.Application.Features.CQRS.Commands
{
    public class RemoveFollowerCommandRequest : IRequest
    {
        public int? FollowerId { get; set; }
        public int? AppUserId { get; set; }
        public RemoveFollowerCommandRequest(int followerId, int appUserId)
        {
            FollowerId = followerId;
            AppUserId = appUserId;
        }
    }
}
