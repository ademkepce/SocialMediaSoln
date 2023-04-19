﻿using Microsoft.EntityFrameworkCore;
using SocialMediaSoln.Domain.Entities;
using SocialMediaSoln.Persistence.Configuraitons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaSoln.Persistence.Context
{
    public class JwtContext : DbContext
    {
        public JwtContext(DbContextOptions<JwtContext> options) : base(options)
        {
            
        }

        public DbSet<AppUser>? AppUsers { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<Community>? Communities { get; set; }
        public DbSet<Follower>? Followers { get; set; }
        public DbSet<Following>? Followings { get; set; }
        public DbSet<Like>? Likes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new LikeConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
