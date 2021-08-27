using Condominio.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Condominio.Application.Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication( this IServiceCollection services,
            ApplicationConfiguration applicationConfiguration )
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (applicationConfiguration == null)
            {
                throw new ArgumentNullException(nameof(applicationConfiguration));
            }

            services.AddSingleton(applicationConfiguration);

            services.AddScoped<ICondominioService, CondominioService>();
            services.AddScoped<ILogCondominioService, LogCondominioService>();

            return services;

        }
    }
}
