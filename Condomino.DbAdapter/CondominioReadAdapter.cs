using Condominio.Domain.Adapters;
using Condominio.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condomino.DbAdapter
{
    public class CondominioReadAdapter : ICondominioReadAdapter
    {
        public Task<MoradiaCondominio> BuscarMoradiaCondominioAsync(CondominioParametro condominioParametro)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<MoradiaCondominio>> BuscarMoradiaCondominiosAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
