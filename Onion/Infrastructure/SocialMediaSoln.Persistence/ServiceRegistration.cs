using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialMediaSoln.Application.Interfaces;
using SocialMediaSoln.Persistence.Context;
using SocialMediaSoln.Persistence.Repositories;

namespace SocialMediaSoln.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JwtContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));//Persistance'deki Repositorylerin kaydını yapıyoruz.
        }
    }
}
