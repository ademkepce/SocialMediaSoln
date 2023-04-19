using AutoMapper;
using MediatR;
using SocialMediaSoln.Application.Dto;
using SocialMediaSoln.Application.Features.CQRS.Queries;
using SocialMediaSoln.Application.Interfaces;
using SocialMediaSoln.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaSoln.Application.Features.CQRS.Handlers
{
    public class CheckUserQueryHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto?>
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IMapper _mapper;

        public CheckUserQueryHandler(IRepository<AppUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CheckUserResponseDto?> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var checkUserDto = new CheckUserResponseDto();
            var user = await _repository.GetByFilterAsync(x => x.Email == request.Username && x.Password == request.Password);

            if(user == null)
            {
                checkUserDto.IsExist = false;
            }
            else
            {
                checkUserDto.IsExist = true;
                checkUserDto.Email = user.Email;
                checkUserDto.Password = user.Password;
                checkUserDto.Id = user.Id;
            }
            return checkUserDto;
        }
    }
}
