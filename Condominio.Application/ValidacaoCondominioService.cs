using Condominio.Domain.Exceptions;
using Condominio.Domain.Models;
using Condominio.Domain.Services;
using System;
using System.Linq;

namespace Condominio.Application
{
    public class ValidacaoCondominioService : IValidacaoCondominioService
    {
        private readonly IValidacaoBaseService validacaoBaseService;
        public ValidacaoCondominioService(IValidacaoBaseService validacaoBaseService)
        {
            this.validacaoBaseService = validacaoBaseService ?? 
                throw new ArgumentNullException(nameof(validacaoBaseService));
        }

        public void ValidarCondominio(MoradiaCondominio moradiaCondominio)
        {
            var erros = new CoreException();


            validacaoBaseService.VerificarCamposObrigatorios<MoradiaCondominio>(erros, moradiaCondominio);
            validacaoBaseService.VerificarCamposObrigatorios<Estado>(erros, moradiaCondominio.Estado);

        }
    }
}
