using MediatR;
using SocialMediaSoln.Application.Dto;
using SocialMediaSoln.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaSoln.Application.Features.CQRS.Commands
{
    public class CreateLikeCommandRequest : IRequest<CreatedLikeDto?>
    {
        public int? AppUserId { get; set; }
        public int? PostId { get; set; }
    }
}
