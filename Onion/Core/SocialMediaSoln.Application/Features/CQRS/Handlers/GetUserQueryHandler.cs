using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialMediaSoln.Application.Dto;
using SocialMediaSoln.Application.Features.CQRS.Queries;
using SocialMediaSoln.Application.Interfaces;
using SocialMediaSoln.Domain.Entities;

namespace SocialMediaSoln.Application.Features.CQRS.Handlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQueryRequest, UserListDto>
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IRepository<AppUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UserListDto> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetQueryable().Where(x => x.Id == request.Id).Include(x => x.Posts).ThenInclude(x => x.Comments).ThenInclude(x=>x.AppUser).Include(x=>x.Followers).Include(x=>x.Followings).Include(x => x.Likes).FirstOrDefaultAsync();
            return _mapper.Map<UserListDto>(data);
        }
    }
}
