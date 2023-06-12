using MediatR;
using SocialMediaSoln.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaSoln.Application.Features.CQRS.Commands
{
    public class CreateFollowerCommandRequest : IRequest
    {
        public int? FollowerId { get; set; }
        public int? AppUserId { get; set; }
    }
}
