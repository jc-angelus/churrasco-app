using Churrasco.Infrastructure.Context;
using Churrasco.Infrastructure.Repositories.Entities;
using Churrasco.Infrastructure.Repositories.Generic;
using Churrasco.Infrastructure.Repositories.Interfaces.Entities;
using Churrasco.Infrastructure.Repositories.Interfaces.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Churrasco.Infrastructure.Extensions
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 13/09/2024
    /// Class: InfrastructureExtensions
    /// </summary>
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();            
            services.AddScoped<IUnitOfWork, UnitOfWork>();                        
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductsRepository, ProductsRepository>();            
            services.AddDbContext<ChallengeContext>(options => options.UseMySql(configuration["ConnectionStrings:ChallengeDb"], ServerVersion.AutoDetect(configuration["ConnectionStrings:ChallengeDb"])));

            return services;
        }

    }
}
