using Condominio.Domain.Models;

namespace Condominio.Domain.Services
{
    public interface IValidacaoCondominioParametroService
    {
        /// <summary>
        /// Valida condominio Parametro de entrada
        /// </summary>
        /// <param name="condominioParametro">
        /// Parametro reposnavel por identificar um condominio 
        /// neste caso o CNPJ
        /// </param>
        void ValidacaoCondominioParametro(CondominioParametro condominioParametro);
    }
}
