using Condominio.Domain.Models;
using System.Threading.Tasks;

namespace Condominio.Domain.Adapters
{
    public interface ICondominioWriteAdapter
    {
        /// <summary>
        /// Salva um cadastro de um novo condominio
        /// </summary>
        /// <param name="moradiaCondominio"></param>
        /// <returns></returns>
        Task SalvarCondominioAsync(MoradiaCondominio moradiaCondominio);

        /// <summary>
        /// Atualiza dados cadastrais de um condominio
        /// </summary>
        /// <param name="moradiaCondominio"></param>
        /// <returns>
        /// Retorna dados atualizados
        /// </returns>
        Task<MoradiaCondominio> AtualizarCondominioAsync(MoradiaCondominio moradiaCondominio);
    }
}
