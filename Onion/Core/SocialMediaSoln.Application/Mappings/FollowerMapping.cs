using AutoMapper;
using SocialMediaSoln.Application.Dto;
using SocialMediaSoln.Domain.Entities;

namespace SocialMediaSoln.Application.Mappings
{
    public class FollowerMapping : Profile
    {
        public FollowerMapping()
        {
            this.CreateMap<Follower, FollowerListDto>().ReverseMap();
        }
    }
}
