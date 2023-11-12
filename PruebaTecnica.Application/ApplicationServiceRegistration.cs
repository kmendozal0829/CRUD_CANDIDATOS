using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnica.Application.Behaviours;
using System.Reflection;

namespace PruebaTecnica.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());//Se injecta AutoMApper
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());//Se Injecta FluentValidation
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionsBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
