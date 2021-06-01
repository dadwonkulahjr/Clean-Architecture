using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CaWorkshop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;

namespace CaWorkshop.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,  IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(
                 configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication()
                    .AddIdentityServerJwt();

            return services;
        }
    }
}
