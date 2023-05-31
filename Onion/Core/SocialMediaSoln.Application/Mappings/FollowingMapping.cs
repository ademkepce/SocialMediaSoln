using AutoMapper;
using SocialMediaSoln.Application.Dto;
using SocialMediaSoln.Domain.Entities;

namespace SocialMediaSoln.Application.Mappings
{
    public class FollowingMapping : Profile
    {
        public FollowingMapping()
        {
            this.CreateMap<Following, FollowingListDto>().ReverseMap();
            this.CreateMap<Following, CreatedFollowingDto>().ReverseMap();
        }
    }
}
