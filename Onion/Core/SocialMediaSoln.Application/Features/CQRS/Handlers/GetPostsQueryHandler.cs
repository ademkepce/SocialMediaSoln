﻿using AutoMapper;
using MediatR;
using SocialMediaSoln.Application.Dto;
using SocialMediaSoln.Application.Features.CQRS.Queries;
using SocialMediaSoln.Application.Interfaces;
using SocialMediaSoln.Domain.Entities;

namespace SocialMediaSoln.Application.Features.CQRS.Handlers
{
    public class GetPostsQueryHandler : IRequestHandler<GetPostsQueryRequest, List<PostListDto>>
    {
        private readonly IRepository<Post> _repository;
        private readonly IMapper _mapper;

        public GetPostsQueryHandler(IRepository<Post> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<PostListDto>> Handle(GetPostsQueryRequest request, CancellationToken cancellationToken)
        {
            var posts = await _repository.GetAllAsync();
            return _mapper.Map<List<PostListDto>>(posts);

        }
    }
}