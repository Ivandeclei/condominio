using AutoMapper;
using Condominio.Domain.Adapters;
using Condominio.Domain.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Condomino.DbAdapter
{
    public class CondominioReadAdapter : ICondominioReadAdapter
    {
        private readonly IDbConnection dbConnection;
        private readonly IMapper mapper;
        static CondominioReadAdapter() => SqlMapper.AddTypeMap(typeof(string), DbType.AnsiString);
        public CondominioReadAdapter(IDbConnection dbConnection,
            IMapper mapper)
        {
            this.dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<MoradiaCondominio> BuscarMoradiaCondominioAsync(CondominioParametro condominioParametro)
        {
            var retorno = await dbConnection.QueryAsync<MoradiaCondominio>(@"SELECT
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
                                                        WHERE c.CpfCnpj = @CpfCnpj
                                                        ",
                                                        new[]
                                                        {
                                                            typeof(MoradiaCondominio),
                                                            typeof(Estado)


                                                        },
                                                        objeto =>
                                                        {
                                                            var moradiaCondominio = objeto[0] as MoradiaCondominio;
                                                            var estado = objeto[1] as Estado;

                                                            moradiaCondominio.Estado = estado;
                                                            
                                                            return moradiaCondominio;
                                                        },
                                                        param: new
                                                        {
                                                            CpfCnpj = condominioParametro.CpfCnpj
                                                        },
                                                        splitOn: "Sigla");

            return retorno.FirstOrDefault<MoradiaCondominio>();

        
        }


        public async Task<IEnumerable<MoradiaCondominio>> BuscarMoradiaCondominiosAsync()
        {
            var retorno = await dbConnection.QueryAsync<MoradiaCondominio>(@"SELECT
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
                                                    ",
                                                        new[]
                                                        {
                                                            typeof(MoradiaCondominio),
                                                            typeof(Estado)


                                                        },
                                                        objeto =>
                                                        {
                                                            var moradiaCondominio = objeto[0] as MoradiaCondominio;
                                                            var estado = objeto[1] as Estado;

                                                            moradiaCondominio.Estado = estado;

                                                            return moradiaCondominio;
                                                        },
                                                        
                                                        splitOn: "Sigla");

            return retorno;
        }
    }
}
