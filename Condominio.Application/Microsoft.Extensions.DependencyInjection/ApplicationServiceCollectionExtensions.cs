using Condominio.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Condominio.Application.Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<ICondominioService, CondominioService>();
            services.AddScoped<ILogCondominioService, LogCondominioService>();
            services.AddScoped<IValidacaoBaseService, ValidacaoBaseService>();
            services.AddScoped<IValidacaoCondominioParametroService, ValidacaoCondominioParametroService>();
            services.AddScoped<IValidacaoCondominioService, ValidacaoCondominioService>();

            return services;

        }
    }
}
