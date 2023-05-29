using AutoMapper;
using SocialMediaSoln.Application.Dto;
using SocialMediaSoln.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaSoln.Application.Mappings
{
    public class CommentMapping : Profile
    {
        public CommentMapping()
        {
            this.CreateMap<Comment, PostCommentDto>().ReverseMap();
            this.CreateMap<Comment, CreatedCommentDto>().ReverseMap();
        }
    }
}
