using Condominio.Domain.Adapters;
using Condominio.Domain.Models;
using Condominio.Domain.Services;
using Newtonsoft.Json;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Condominio.Application
{
    public class LogCondominioService : ILogCondominioService
    {
        private readonly ILogCondominioWriteAdapter logCondominioAdapter;
        public LogCondominioService(ILogCondominioWriteAdapter logCondominioAdapter)
        {
            this.logCondominioAdapter = logCondominioAdapter ??
                throw new ArgumentNullException(nameof(logCondominioAdapter));

        }
        public async Task GerarLogPorMetodoAsync(Exception exception, string nomeMetodo)
        {
            if(exception is null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            if (nomeMetodo is null)
            {
                throw new ArgumentNullException(nameof(nomeMetodo));
            }

            var logCondominio = new CondominioLog()
            {
                Erros = JsonConvert.SerializeObject(exception.Message),
                 Excecao =  JsonConvert.SerializeObject(exception),
                 Metodo = nomeMetodo,
                 TipoObjeto = exception.GetType().Name,
                 DataHorario = DateTimeOffset.Now

            };


            await logCondominioAdapter.InserirLogCondominioAsync(logCondominio);
            
        }
    }
}
