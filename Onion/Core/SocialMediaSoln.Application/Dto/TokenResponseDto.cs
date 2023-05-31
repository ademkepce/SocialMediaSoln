using SocialMediaSoln.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaSoln.Application.Dto
{
    public class TokenResponseDto
    {
        public string? Token { get; set; }
        public DateTime ExpireDate { get; set; }
        public int Id { get; set; }
        public bool? IsGroup { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? ImageUrl { get; set; }
        public TokenResponseDto(string? token, DateTime expireDate, int id, bool? isGroup, string? name, string? surname, string? imageUrl)
        {
            Token = token;
            ExpireDate = expireDate;
            Id = id;
            IsGroup = isGroup;
            Name = name;
            Surname = surname;
            ImageUrl = imageUrl;
        }
    }
}
