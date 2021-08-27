using Condominio.Domain.Adapters;
using Condomino.DbAdapter;
using Condomino.DbAdapter.DbAdapterConfiguration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Condominio.Application.Microsoft.Extensions.DependencyInjection
{
    public static class DbRepositoryServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication( this IServiceCollection services,
            DbAdapterConfiguration dbAdapterConfiguration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (dbAdapterConfiguration == null)
            {
                throw new ArgumentNullException(nameof(dbAdapterConfiguration));
            }

            services.AddSingleton(dbAdapterConfiguration);

            services.AddScoped<IDbConnection>( d => {
                return new SqlConnection(dbAdapterConfiguration.ConnectionString);
            });

            services.AddScoped<ICondominioReadAdapter, CondominioReadAdapter>();

            return services;

        }
    }
}
