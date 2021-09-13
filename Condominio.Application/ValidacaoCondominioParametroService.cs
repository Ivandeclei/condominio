using Condominio.Domain.Exceptions;
using Condominio.Domain.Models;
using Condominio.Domain.Services;
using System;
using System.Linq;

namespace Condominio.Application
{
    public class ValidacaoCondominioParametroService : IValidacaoCondominioParametroService
    {
        private readonly IValidacaoBaseService validacaoBaseService;

       public ValidacaoCondominioParametroService(IValidacaoBaseService validacaoBaseService)
        {
            this.validacaoBaseService = validacaoBaseService ??
                throw new ArgumentNullException(nameof(validacaoBaseService));
        }
        public void ValidacaoCondominioParametro(CondominioParametro condominioParametro)
        {
            var erros = new CoreException();
            
            erros = validacaoBaseService.VerificarCamposObrigatorios<CondominioParametro>(
                erros, condominioParametro);

            if (erros.Errors.Any())
            {
                throw CoreException.Exception( erros.Errors.ToList());
            }

        }
    }
}
