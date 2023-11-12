using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnica.Application.Contracts.Persistence;
using PruebaTecnica.Infrastructure.Persistence;
using PruebaTecnica.Infrastructure.Repositories;

namespace PruebaTecnica.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddDbContext<CandidateDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlServer"))
                );

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<ICandidateExperienceRepository, CandidateExperienceRepository>();


            return services;
        }
    }
}
