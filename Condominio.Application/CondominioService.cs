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
        private readonly IValidacaoCondominioParametroService validacaoCondominioParametroService;
        private readonly IValidacaoCondominioService validacaoCondominioService;
        private readonly ICondominioWriteAdapter dbCondominioWriteAdapter;

        public CondominioService(ICondominioReadAdapter dbCondominioReadAdapter,
            ICondominioWriteAdapter dbCondominioWriteAdapter,
            ILogCondominioService logCondominioService,
            IValidacaoCondominioParametroService validacaoCondominioParametroService,
            IValidacaoCondominioService validacaoCondominioService,
        ILoggerFactory loggerFactory)
        {
            this.dbCondominioReadAdapter = dbCondominioReadAdapter ??
                throw new ArgumentNullException(nameof(dbCondominioReadAdapter));
            this.logCondominioService = logCondominioService ??
                throw new ArgumentNullException(nameof(logCondominioService));
            this.validacaoCondominioParametroService = validacaoCondominioParametroService ??
                throw new ArgumentNullException(nameof(validacaoCondominioParametroService));
            this.logger = loggerFactory.CreateLogger<CondominioService>() ??
                throw new ArgumentNullException(nameof(loggerFactory));
            this.dbCondominioWriteAdapter = dbCondominioWriteAdapter ??
                throw new ArgumentNullException(nameof(dbCondominioWriteAdapter));
            this.validacaoCondominioService = validacaoCondominioService ??
                throw new ArgumentNullException(nameof(validacaoCondominioService));
        }

        public async Task<MoradiaCondominio> BuscarMoradiaCondominioAsync(
            CondominioParametro condominioParametro)
        {
            logger.LogInformation("Realizando chamada ao metodo" + 
                nameof(BuscarMoradiaCondominioAsync));
            if(condominioParametro is null)
            {
                throw new ArgumentNullException(nameof(condominioParametro));
            }

            validacaoCondominioParametroService.ValidacaoCondominioParametro(condominioParametro);

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

                logger.LogInformation("Falha na chamada do metodo" + nameof(
                    BuscarMoradiaCondominioAsync));

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

        public async Task SalvarCondominioAsync(MoradiaCondominio moradiaCondominio)
        {
            logger.LogInformation("Realiza chamada ao metodo" + nameof(SalvarCondominioAsync));

            if(moradiaCondominio is null)
            {
                throw new ArgumentNullException(nameof(moradiaCondominio));
            }

            validacaoCondominioService.ValidarCondominio(moradiaCondominio);

            try
            {
                await dbCondominioWriteAdapter.SalvarCondominioAsync(moradiaCondominio);

            }
            catch (Exception e)
            {

                await logCondominioService.GerarLogPorMetodoAsync(e , 
                    nameof(ICondominioWriteAdapter.SalvarCondominioAsync));

                logger.LogInformation("Falha na chamada do metodo" + nameof(
                    SalvarCondominioAsync));

                throw;
            }
        }

        public async Task<MoradiaCondominio> AtualizarCondominioAsync(MoradiaCondominio moradiaCondominio)
        {
            logger.LogInformation("Realiza chamada ao metodo" + nameof(AtualizarCondominioAsync));

            if(moradiaCondominio is null)
            {
                throw new ArgumentNullException(nameof(moradiaCondominio));
            }

            validacaoCondominioService.ValidarCondominio(moradiaCondominio);

            try
            {
                var resultado = await dbCondominioWriteAdapter.AtualizarCondominioAsync(moradiaCondominio);
                return resultado;
            }
            catch (Exception e)
            {

                await logCondominioService.GerarLogPorMetodoAsync(e,
                    nameof(ICondominioWriteAdapter.AtualizarCondominioAsync));

                logger.LogInformation("Falha na chamada do metodo" + nameof(
                    AtualizarCondominioAsync));

                throw;
            }
        }

    }
}
