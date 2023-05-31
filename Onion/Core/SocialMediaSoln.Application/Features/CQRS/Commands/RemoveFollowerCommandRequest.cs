using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaSoln.Application.Features.CQRS.Commands
{
    public class RemoveFollowerCommandRequest : IRequest
    {
        public int Id { get; set; }
        public RemoveFollowerCommandRequest(int id)
        {
            Id = id;
        }
    }
}
