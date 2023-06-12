using AutoMapper;
using SocialMediaSoln.Application.Dto;
using SocialMediaSoln.Domain.Entities;

namespace SocialMediaSoln.Application.Mappings
{
    public class LikeMapping : Profile
    {
        public LikeMapping()
        {
            this.CreateMap<Like, CreatedLikeDto>().ReverseMap();
            this.CreateMap<Like, PostLikesDto>().ReverseMap();
        }
    }
}
