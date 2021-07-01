using CaWorkshop.Application.Common.Behaviours;
using CaWorkshop.Application.TodoLists.Queries.GetTodoLists;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CaWorkshop.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>),
            typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>),
 typeof(PerformanceBehaviour<,>));
            //services.AddTransient<IGetTodoListsQuery, GetTodoListsQuery>();
            return services;
        }
        //public static IServiceCollection AddMediatorServices(this IServiceCollection services)
        //{
        //    services.AddSingleton<IMediator>();
        //    return services;
        //}
    }
}
