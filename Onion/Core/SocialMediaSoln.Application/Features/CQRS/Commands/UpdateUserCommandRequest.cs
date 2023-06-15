using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaSoln.Application.Features.CQRS.Commands
{
    public class UpdateUserCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Part { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }
        public bool? IsGroup { get; set; }
    }
}
