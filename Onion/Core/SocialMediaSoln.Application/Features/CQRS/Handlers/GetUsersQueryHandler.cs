using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialMediaSoln.Application.Dto;
using SocialMediaSoln.Application.Features.CQRS.Queries;
using SocialMediaSoln.Application.Interfaces;
using SocialMediaSoln.Domain.Entities;

namespace SocialMediaSoln.Application.Features.CQRS.Handlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQueryRequest, List<UserListDto>>
    {
        private readonly IRepository<AppUser> _repository;
        //private readonly IRepository<Post> _repository;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IRepository<AppUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<UserListDto>> Handle(GetUsersQueryRequest request, CancellationToken cancellationToken)
        {
            var users = _repository.GetQueryable().Include(x => x.Followers).Include(x => x.Followings).Include(x => x.Posts);
            return _mapper.Map<List<UserListDto>>(users);
        }
    }
}
