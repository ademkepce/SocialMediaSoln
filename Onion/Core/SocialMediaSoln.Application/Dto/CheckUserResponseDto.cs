﻿using SocialMediaSoln.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaSoln.Application.Dto
{
    public class CheckUserResponseDto
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool IsExist { get; set; }
        public bool? IsGroup { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? ImageUrl { get; set; }
    }
}
