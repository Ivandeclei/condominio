using System.Data;

namespace Condomino.DbAdapter.DbAdapterConfiguration
{
    public class CondominioContexto
    {
        public CondominioContexto(IDbConnection dbConnection)
        {
            Connection = dbConnection;
        }

        public IDbConnection Connection { get; set; }
    }
}
