using MediatR;
using Microsoft.AspNetCore.Http;
using SocialMediaSoln.Application.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaSoln.Application.Features.CQRS.Commands
{
    public class CreateUserCommandRequest : IRequest<CreatedUserDto?>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Part { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }
        public bool IsGroup { get; set; }
    }
}
