using Condominio.Domain.Adapters;
using Condominio.Domain.Models;
using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Condomino.DbAdapter
{
    public class LogCondominioWriteAdapter : ILogCondominioWriteAdapter
    {
        private readonly IDbConnection dbConnection;

        static LogCondominioWriteAdapter() => SqlMapper.AddTypeMap(typeof(string), DbType.AnsiString);
        public LogCondominioWriteAdapter(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection ??
                throw new ArgumentNullException(nameof(dbConnection));
        }

        public async Task InserirLogCondominioAsync(CondominioLog condominioLog)
        {
            await dbConnection.ExecuteAsync(@"INSERT INTO CondominioLog(
                                                    Metodo, 
                                                    Excecao, 
                                                    Erros, 
                                                    DataHorario)
                                             VALUES(
                                                    @Metodo, 
                                                    @Excecao, 
                                                    @Erros, 
                                                    @DataHorario)", param: new
            {
                Metodo = condominioLog.Metodo,
                Excecao = condominioLog.Excecao,
                Erros = condominioLog.Erros,
                DataHorario = condominioLog.DataHorario
            });
        }
    }
}
