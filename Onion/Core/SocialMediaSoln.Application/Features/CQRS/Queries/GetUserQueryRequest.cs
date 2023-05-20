using MediatR;
using SocialMediaSoln.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaSoln.Application.Features.CQRS.Queries
{
    public class GetUserQueryRequest : IRequest<UserListDto>
    {
        public int Id { get; set; }

        public GetUserQueryRequest(int id)
        {
            Id = id;
        }
    }
}
