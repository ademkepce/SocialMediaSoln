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
    public class CreatePostCommandRequest : IRequest<CreatedPostDto?>
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? PublishedDate { get; set; }
        public int LikeCount { get; set; }
        public int? AppUserId { get; set; }
    }
}
