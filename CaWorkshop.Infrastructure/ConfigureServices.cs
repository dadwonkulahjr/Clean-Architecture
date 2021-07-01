using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CaWorkshop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using CaWorkshop.Application.Common.Interfaces;
using MediatR;
using CaWorkshop.Application.Common.Behaviours;
using CaWorkshop.Infrastructure.Identity;

namespace CaWorkshop.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(
                 configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddAuthentication()
                    .AddIdentityServerJwt();

            services.AddScoped<IApplicationDbContext>(p =>
            {
                return p.GetRequiredService<ApplicationDbContext>();
            });
            services.AddTransient(typeof(IPipelineBehavior<,>),
                            typeof(UnhandledExceptionBehaviour<,>));
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddTransient(typeof(IPipelineBehavior<,>),
                 typeof(ValidationBehaviour<,>));
            return services;
        }
    }
}
