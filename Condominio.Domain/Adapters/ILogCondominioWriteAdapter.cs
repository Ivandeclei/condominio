using Condominio.Domain.Models;
using System.Threading.Tasks;

namespace Condominio.Domain.Adapters
{
    public interface ILogCondominioWriteAdapter
    {
        /// <summary>
        /// Insere log de erros da aplicação
        /// </summary>
        /// <param name="condominioLog">
        /// objeto com dados para gerar os log da aplicação</param>

        Task InserirLogCondominioAsync(CondominioLog condominioLog);
    }
}
