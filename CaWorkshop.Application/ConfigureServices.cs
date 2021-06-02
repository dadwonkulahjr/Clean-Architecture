using CaWorkshop.Application.TodoLists.Queries.GetTodoLists;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CaWorkshop.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
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
