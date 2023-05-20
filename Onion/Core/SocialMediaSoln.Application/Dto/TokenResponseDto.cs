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
        public TokenResponseDto(string? token, DateTime expireDate, int id)
        {
            Token = token;
            ExpireDate = expireDate;
            Id = id;
        }
    }
}
