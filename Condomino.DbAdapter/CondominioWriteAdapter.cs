using AutoMapper;
using Condominio.Domain.Adapters;
using Condominio.Domain.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condomino.DbAdapter
{
    public class CondominioWriteAdapter : ICondominioWriteAdapter
    {
        private readonly IDbConnection dbConnection;
        private readonly IMapper mapper;

        static CondominioWriteAdapter() => SqlMapper.AddTypeMap(typeof(string), DbType.AnsiString);

        public CondominioWriteAdapter(IDbConnection dbConnection, IMapper mapper)
        {
            this.dbConnection = dbConnection ??
                throw new ArgumentNullException(nameof(dbConnection));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<MoradiaCondominio> AtualizarCondominioAsync(MoradiaCondominio moradiaCondominio)
        {
            var retorno = await dbConnection.QueryAsync<MoradiaCondominio>(
                @"UPDATE [dbo].[CondominioDados]
                       SET 
                          [Nome] = @Nome
                          ,[Telefone] = @Telefone
                          ,[Rua] = @Rua
                          ,[Cep] = @Cep
                          ,[Numero] = @Numero
                          ,[Bairro] = @Bairro
                          ,[Cidade] = @Cidade
                          ,[Pais] = @Pais
                          ,[IdentificadorEstado] = (select Identificador from Estado where Sigla = @Sigla)        
                     WHERE CpfCnpj = @CpfCnpj

                    SELECT
                            c.Nome
                            ,c.CpfCnpj
                            ,c.Telefone
                            ,c.Rua
                            ,c.Cep
                            ,c.Numero
                            ,c.Bairro
                            ,c.Cidade
                            ,c.Pais
                            ,e.Sigla
                            ,e.Nome
                    FROM condominio..CondominioDados as c
                    INNER JOIN Estado as e
                    ON c.IdentificadorEstado = e.Identificador
                    WHERE c.CpfCnpj = @CpfCnpj",
                new [] {
                    typeof(MoradiaCondominio),
                    typeof(Estado)
                },
                objeto => {
                    var moradiaCondominio = objeto[0] as MoradiaCondominio;
                    var estado = objeto[1] as Estado;

                    moradiaCondominio.Estado = estado;
                    return moradiaCondominio;
                },
                param: new
                {
                    Nome = moradiaCondominio.Nome,
                    CpfCnpj = moradiaCondominio.CpfCnpj,
                    Telefone = moradiaCondominio.Telefone,
                    Rua = moradiaCondominio.Rua,
                    Cep = moradiaCondominio.Cep,
                    Numero = moradiaCondominio.Numero,
                    Bairro = moradiaCondominio.Bairro,
                    Cidade = moradiaCondominio.Cidade,
                    Sigla = moradiaCondominio.Estado.Sigla,
                    pais = moradiaCondominio.Pais,
                    Identificador = moradiaCondominio.Identificador
                },
                splitOn: "Sigla") ;

            return retorno.FirstOrDefault<MoradiaCondominio>(); ;
        }

        public async Task SalvarCondominioAsync(MoradiaCondominio moradiaCondominio)
        {
            await dbConnection.QueryAsync<MoradiaCondominio>(
              @"INSERT INTO [dbo].[CondominioDados](
                                [Nome]
                               ,[CpfCnpj]
                               ,[Telefone]
                               ,[Rua]
                               ,[Cep]
                               ,[Numero]
                               ,[Bairro]
                               ,[Cidade]
                               ,[IdentificadorEstado]
                               ,[Pais])
                         VALUES
                        (
                                @Nome,
                                @CpcCnpj,
                                @Telefone,
                                @Rua,
                                @Cep,
                                @Numero,
                                @Bairro,
                                @Cidade,
                                (select Identificador from Estado where Sigla = @Sigla),
                                @pais
                        )",
              param: new
              {
                  Nome = moradiaCondominio.Nome,
                  CpcCnpj = moradiaCondominio.CpfCnpj,
                  Telefone = moradiaCondominio.Telefone,
                  Rua = moradiaCondominio.Rua,
                  Cep = moradiaCondominio.Cep,
                  Numero = moradiaCondominio.Numero,
                  Bairro = moradiaCondominio.Bairro,
                  Cidade = moradiaCondominio.Cidade,
                  Sigla = moradiaCondominio.Estado.Sigla,
                  pais = moradiaCondominio.Pais
              });
        }
    }
}
