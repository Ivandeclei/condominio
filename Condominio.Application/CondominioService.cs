using Condominio.Domain.Adapters;
using Condominio.Domain.Models;
using Condominio.Domain.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominio.Application
{
    public class CondominioService : ICondominioService
    {
        private readonly ICondominioReadAdapter dbCondominioReadAdapter;
        private readonly ILogCondominioService logCondominioService;
        private readonly ILogger logger;

        public CondominioService(ICondominioReadAdapter dbCondominioReadAdapter,
            ILogCondominioService logCondominioService,
            ILoggerFactory loggerFactory)
        {
            this.dbCondominioReadAdapter = dbCondominioReadAdapter ??
                throw new ArgumentNullException(nameof(dbCondominioReadAdapter));
            this.logCondominioService = logCondominioService ??
                throw new ArgumentNullException(nameof(logCondominioService));
            this.logger = loggerFactory.CreateLogger<CondominioService>() ??
                throw new ArgumentNullException(nameof(loggerFactory));
        }
        public async Task<MoradiaCondominio> BuscarMoradiaCondominioAsync(CondominioParametro condominioParametro)
        {
            logger.LogInformation("Realizando chamada ao metodo" + 
                nameof(BuscarMoradiaCondominioAsync));
            if(condominioParametro is null)
            {
                throw new ArgumentNullException(nameof(condominioParametro));
            }

            try
            {
               var condominio =  await dbCondominioReadAdapter
                    .BuscarMoradiaCondominioAsync(condominioParametro);

                return condominio;
            }
            catch (Exception e)
            {
                await logCondominioService.GerarLogPorMetodoAsync(e, 
                    nameof(ICondominioReadAdapter.BuscarMoradiaCondominioAsync));

                logger.LogInformation("Falha na chamada do metodo" + nameof(BuscarMoradiaCondominioAsync));

                throw;
            }

        }

        public async Task<IEnumerable<MoradiaCondominio>> BuscarMoradiaCondominiosAsync()
        {
            try
            {
                logger.LogInformation("Realiza chamada ao metodo" 
                    + nameof(BuscarMoradiaCondominiosAsync));

                var condominios = await dbCondominioReadAdapter.BuscarMoradiaCondominiosAsync();
                return condominios;
            }
            catch (Exception e)
            {
                await logCondominioService.GerarLogPorMetodoAsync(e, "FInalizando chamada ao metodo" 
                    + nameof(ICondominioReadAdapter.BuscarMoradiaCondominiosAsync));

                throw;
            }
        }
    }
}
