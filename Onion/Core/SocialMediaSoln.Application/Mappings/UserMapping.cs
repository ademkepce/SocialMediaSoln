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
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            this.CreateMap<AppUser, UserListDto>().ReverseMap();
            this.CreateMap<AppUser, UsersListDto>().ReverseMap();
            this.CreateMap<AppUser, PostUsersDto>().ReverseMap();
            this.CreateMap<AppUser, CommentUsersDto>().ReverseMap();
            this.CreateMap<AppUser, CreatedUserDto>().ReverseMap();
        }
    }
}
