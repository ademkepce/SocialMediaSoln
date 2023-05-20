using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SocialMediaSoln.Application.Mappings;
using System.Reflection;

namespace SocialMediaSoln.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(opt =>
            {
                opt.AddProfiles(new List<Profile>
                {
                    new PostMapping(),
                    new UserMapping(),
                    new FollowerMapping(),
                    new FollowingMapping(),
                    new CommentMapping()
                });
            });
        }
    }
}
