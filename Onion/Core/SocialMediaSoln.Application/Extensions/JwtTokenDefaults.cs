﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaSoln.Application.Extensions
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "http://localhost";
        public const string ValidIssuer = "http://localhost";
        public const string Key = "ademademademademadem1.";
        public const int Expire = 5;
    }
}
