using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaSoln.Application.Features.CQRS.Commands
{
    public class RemovePostCommandRequest : IRequest
    {
        public int Id { get; set; }
        public RemovePostCommandRequest(int id)
        {
            Id = id;
        }
    }
}
