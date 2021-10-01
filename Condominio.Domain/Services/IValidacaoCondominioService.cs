using Condominio.Domain.Models;

namespace Condominio.Domain.Services
{
    public interface IValidacaoCondominioService
    {
        /// <summary>
        /// Valida Um modelo de Moradia condominio
        /// </summary>
        /// <param name="moradiaCondominio"></param>
        void ValidarCondominio(MoradiaCondominio moradiaCondominio);
    }
}
