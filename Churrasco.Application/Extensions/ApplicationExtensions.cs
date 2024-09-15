using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Churrasco.Domain.Mappers;
using Churrasco.Infrastructure.Extensions;
using Churrasco.Application.Interfaces;
using Churrasco.Application.Services;

namespace Churrasco.Application.Extensions
{

    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 13/09/2024
    /// Class: ApplicationExtensions
    /// </summary>
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();            
            services.AddAutoMapper(typeof(DomainMappingProfile));
            services.AddMediatR(Assembly.GetExecutingAssembly());            
            services.AddScoped<ILoginServices, LoginServices>();
            services.AddScoped<IProductsServices, ProductsServices>();
            InfrastructureExtensions.AddInfrastructure(services, configuration);            
            return services;
        }

    }
}
