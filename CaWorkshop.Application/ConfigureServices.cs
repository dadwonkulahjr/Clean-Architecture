using CaWorkshop.Application.TodoLists.Queries.GetTodoLists;
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
    }
}
