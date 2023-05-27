﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaSoln.Domain.Entities
{
    public class Following//Takip ettiklerim
    {
        public int Id { get; set; }
        public int? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}