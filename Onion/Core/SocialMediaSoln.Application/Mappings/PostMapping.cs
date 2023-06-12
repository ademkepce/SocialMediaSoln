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
    public class PostMapping : Profile
    {
        public PostMapping()
        {
            this.CreateMap<Post, PostsListDto>().ReverseMap();
            this.CreateMap<Post, PostListDto>().ReverseMap();
            this.CreateMap<Post, CreatedPostDto>().ReverseMap();
            this.CreateMap<Post, UsersPostDto>().ReverseMap();
        }
    }
}
