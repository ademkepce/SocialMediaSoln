﻿using SocialMediaSoln.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaSoln.Application.Dto
{
    public class PostUsersDto
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Part { get; set; }
        public string? ProfileImageUrl { get; set; }
        public bool? IsGroup { get; set; }
    }
}
