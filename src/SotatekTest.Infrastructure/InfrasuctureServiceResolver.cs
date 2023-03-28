using SotatekTest.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SotatekTest.Domain.Common;
using SotatekTest.Infrastructure.Repositories;
using SotatekTest.Infrastructure.Services;
using SotatekTest.Application.Interfaces.Services;

namespace SotatekTest.Infrastructure
{
    public static class InfrasuctureServiceResolver
    {
        public static IServiceCollection InfrastructureServiceRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped(typeof(ICacheService<>), typeof(CacheService<>));
            services.AddMemoryCache();
            return services;
        }
    }
}
