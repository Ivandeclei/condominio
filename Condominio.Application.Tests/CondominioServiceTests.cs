using Condominio.Domain.Adapters;
using Condominio.Domain.Models;
using Condominio.Domain.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Condominio.Application.Tests
{

    public class CondominioServiceTests
    {
        private readonly ICondominioService condominioService;
        private readonly Mock<IValidacaoCondominioParametroService> validacaoCondominioParametroServiceMock;
        private readonly Mock<ILogCondominioService> logCondominioServiceMock;
        private readonly Mock<ICondominioReadAdapter> condominioReadAdapterMock;
        public CondominioServiceTests()
        {
            logCondominioServiceMock = new Mock<ILogCondominioService>();
            condominioReadAdapterMock = new Mock<ICondominioReadAdapter>();
            validacaoCondominioParametroServiceMock = new Mock<IValidacaoCondominioParametroService>();

            condominioService = new CondominioService(
                condominioReadAdapterMock.Object,
                logCondominioServiceMock.Object,
                validacaoCondominioParametroServiceMock.Object,
                new LoggerFactory()
            );
        }

        [Fact]
        [Trait(nameof(ICondominioService.BuscarMoradiaCondominioAsync), "Sucesso")]
        public async Task BuscarCondominioAsync_Sucesso()
        {
            //Arange = inicializacao de variaveis 
            var cpfCnpj = "99999999999999";
            var parametroCondominioMock = new CondominioParametro()
            {
                CpfCnpj = cpfCnpj
            };
            var parametroCondominioEsperado = new CondominioParametro()
            {
                CpfCnpj = cpfCnpj
            };

            var identificador = Guid.NewGuid();

            var condominioResultadoMock = new MoradiaCondominio()
            {
                Nome = "Condominio A",
                Identificador = identificador,
                CpfCnpj = cpfCnpj,
                Telefone = "31993584778",
                Cep = 31111111,
                Rua = "barao verde",
                Numero = "121A",
                Bairro = "Citrolandia",
                Cidade = "Betim",
                Estado = new Estado
                {
                    Identificador = identificador,
                    Nome = "Minas Gerais",
                    Sigla = "MG"
                },
                Pais = "Brasil"
            };

            var condominioResultadoEsperado = new MoradiaCondominio()
            {
                Nome = "Condominio A",
                Identificador = identificador,
                CpfCnpj = cpfCnpj,
                Telefone = "31993584778",
                Cep = 31111111,
                Rua = "barao verde",
                Numero = "121A",
                Bairro = "Citrolandia",
                Cidade = "Betim",
                Estado = new Estado
                {
                    Identificador = identificador,
                    Nome = "Minas Gerais",
                    Sigla = "MG"
                },
                Pais = "Brasil"
            };
            //Act = invocar os metodos 
            validacaoCondominioParametroServiceMock.Setup(v => v.ValidacaoCondominioParametro(It.IsAny<CondominioParametro>()))
                .Callback<CondominioParametro>((condominioParametroCallback) =>
                {
                    Assert.Equal(condominioParametroCallback.CpfCnpj, parametroCondominioEsperado.CpfCnpj);
                });
                

            condominioReadAdapterMock.Setup(c => c.BuscarMoradiaCondominioAsync(It.IsAny<CondominioParametro>()))
                .Callback<CondominioParametro>((condominioParametroCallback) =>
                {
                    Assert.Equal(condominioParametroCallback.CpfCnpj, parametroCondominioEsperado.CpfCnpj);
                });

            condominioReadAdapterMock.Setup(c => c.BuscarMoradiaCondominioAsync(It.IsAny<CondominioParametro>()))
            .ReturnsAsync(condominioResultadoMock);

            //Realiza chamada ao metodo

            var condominioResultado = await condominioService
                .BuscarMoradiaCondominioAsync(parametroCondominioMock);
            //Assertes = verifica a ação


            Assert.Equal(condominioResultadoEsperado.Identificador, condominioResultado.Identificador);
            Assert.Equal(condominioResultadoEsperado.Nome, condominioResultado.Nome);
            Assert.Equal(condominioResultadoEsperado.CpfCnpj, condominioResultado.CpfCnpj);
            Assert.Equal(condominioResultadoEsperado.Telefone, condominioResultado.Telefone);
            Assert.Equal(condominioResultadoEsperado.Cep, condominioResultado.Cep);
            Assert.Equal(condominioResultadoEsperado.Rua, condominioResultado.Rua);
            Assert.Equal(condominioResultadoEsperado.Numero, condominioResultado.Numero);
            Assert.Equal(condominioResultadoEsperado.Bairro, condominioResultado.Bairro);
            Assert.Equal(condominioResultadoEsperado.Cidade, condominioResultado.Cidade);
            Assert.Equal(condominioResultadoEsperado.Estado.Identificador, condominioResultado.Estado.Identificador);
            Assert.Equal(condominioResultadoEsperado.Estado.Nome, condominioResultado.Estado.Nome);
            Assert.Equal(condominioResultadoEsperado.Estado.Sigla, condominioResultado.Estado.Sigla);
            Assert.Equal(condominioResultadoEsperado.Pais, condominioResultado.Pais);
        }

        [Fact]
        [Trait(nameof(ICondominioService.BuscarMoradiaCondominioAsync), "ArgumentException")]
        public async Task BuscarCondominioAsync_ArgumentException()
        {
            //Arange = inicializacao de variaveis 

            CondominioParametro parametroCondominioMock = null;
            var parametroCondominioEsperado = "condominioParametro";
            var mensagemEsperada = "Value cannot be null.";


            //Act = invocar os metodos 

            var ex = await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await condominioService.BuscarMoradiaCondominioAsync(parametroCondominioMock);
            });

            //Assertes = verifica a ação

            Assert.Equal(parametroCondominioEsperado, ex.ParamName);
            Assert.Contains(mensagemEsperada, ex.Message);

        }

        [Fact]
        [Trait(nameof(ICondominioService.BuscarMoradiaCondominioAsync), "Exception")]
        public async Task BuscarCondominioAsync_Exception()
        {
            //Arange = inicializacao de variaveis 
            var cpfCnpj = "99999999999999";
            var parametroCondominioMock = new CondominioParametro()
            {
                CpfCnpj = cpfCnpj
            };
            var parametroCondominioEsperado = new CondominioParametro()
            {
                CpfCnpj = cpfCnpj
            };

            var identificador = Guid.NewGuid();

            var condominioResultadoMock = new MoradiaCondominio()
            {
                Nome = "Condominio A",
                Identificador = identificador,
                CpfCnpj = cpfCnpj,
                Telefone = "31993584778",
                Cep = 31111111,
                Rua = "barao verde",
                Numero = "121A",
                Bairro = "Citrolandia",
                Cidade = "Betim",
                Estado = new Estado
                {
                    Identificador = identificador,
                    Nome = "Minas Gerais",
                    Sigla = "MG"
                },
                Pais = "Brasil"
            };

            var condominioResultadoEsperado = new MoradiaCondominio()
            {
                Nome = "Condominio A",
                Identificador = identificador,
                CpfCnpj = cpfCnpj,
                Telefone = "31993584778",
                Cep = 31111111,
                Rua = "barao verde",
                Numero = "121A",
                Bairro = "Citrolandia",
                Cidade = "Betim",
                Estado = new Estado
                {
                    Identificador = identificador,
                    Nome = "Minas Gerais",
                    Sigla = "MG"
                },
                Pais = "Brasil"
            };

            var exceptionMock = new Exception("Erro ao recuperar dados");
            var exceptionEsperado = new Exception("Erro ao recuperar dados");

            var nomeMetodo = nameof(ICondominioService.BuscarMoradiaCondominioAsync);

            //Act = invocar os metodos 
            condominioReadAdapterMock.Setup(c => c.BuscarMoradiaCondominioAsync(It.IsAny<CondominioParametro>()))
                .Callback<CondominioParametro>((condominioParametroCallback) =>
                {
                    Assert.Equal(condominioParametroCallback.CpfCnpj, parametroCondominioEsperado.CpfCnpj);
                });

            condominioReadAdapterMock.Setup(c => c.BuscarMoradiaCondominioAsync(It.IsAny<CondominioParametro>()))
            .ThrowsAsync(exceptionMock);

            //Realiza chamada ao metodo

            var ex = await Assert.ThrowsAnyAsync<Exception>(async () =>
            {
                await condominioService
               .BuscarMoradiaCondominioAsync(parametroCondominioMock);
            });

            //Assertes = verifica a ação

            Assert.Equal(exceptionEsperado.Message, ex.Message);

            logCondominioServiceMock.Setup(a => a.GerarLogPorMetodoAsync(It.IsAny<Exception>(), It.IsAny<string>()))
                .Returns(Task.CompletedTask)
                .Callback<Exception, string>((exceptionCallback, metodoCallback) =>
                {
                    Assert.Equal(exceptionEsperado.Message, exceptionCallback.Message);
                    Assert.Equal(nomeMetodo, metodoCallback);
                });

        }


        [Fact]
        [Trait(nameof(ICondominioService.BuscarMoradiaCondominiosAsync), "Sucesso")]
        public async Task BuscarMoradiaCondominiosAsync_Sucesso()
        {
            //Arange = inicializacao de variaveis 
            var cpfCnpj = "99999999999999";

            var identificador = Guid.NewGuid();

            var condominioResultadoMock = new List<MoradiaCondominio>()
            {
                new MoradiaCondominio()
                {
                    Nome = "Condominio A",
                    Identificador = identificador,
                    CpfCnpj = cpfCnpj,
                    Telefone = "31993584778",
                    Cep = 31111111,
                    Rua = "barao verde",
                    Numero = "121A",
                    Bairro = "Citrolandia",
                    Cidade = "Betim",
                    Estado = new Estado
                {
                    Identificador = identificador,
                    Nome = "Minas Gerais",
                    Sigla = "MG"
                },
                    Pais = "Brasil"
                }
            };

            var condominioResultadoEsperado = new MoradiaCondominio()
            {
                Nome = "Condominio A",
                Identificador = identificador,
                CpfCnpj = cpfCnpj,
                Telefone = "31993584778",
                Cep = 31111111,
                Rua = "barao verde",
                Numero = "121A",
                Bairro = "Citrolandia",
                Cidade = "Betim",
                Estado = new Estado
                {
                    Identificador = identificador,
                    Nome = "Minas Gerais",
                    Sigla = "MG"
                },
                Pais = "Brasil"
            };
            //Act = invocar os metodos 

            condominioReadAdapterMock.Setup(c => c.BuscarMoradiaCondominiosAsync())
            .ReturnsAsync(condominioResultadoMock);

            //Realiza chamada ao metodo

            var condominioResultado = await condominioService
                .BuscarMoradiaCondominiosAsync();
            //Assertes = verifica a ação

            Assert.Collection(condominioResultado,
                item1 =>
                {
                    Assert.Equal(condominioResultadoEsperado.Identificador, item1.Identificador);
                    Assert.Equal(condominioResultadoEsperado.Nome, item1.Nome);
                    Assert.Equal(condominioResultadoEsperado.CpfCnpj, item1.CpfCnpj);
                    Assert.Equal(condominioResultadoEsperado.Telefone, item1.Telefone);
                    Assert.Equal(condominioResultadoEsperado.Cep, item1.Cep);
                    Assert.Equal(condominioResultadoEsperado.Rua, item1.Rua);
                    Assert.Equal(condominioResultadoEsperado.Numero, item1.Numero);
                    Assert.Equal(condominioResultadoEsperado.Bairro, item1.Bairro);
                    Assert.Equal(condominioResultadoEsperado.Cidade, item1.Cidade);
                    Assert.Equal(condominioResultadoEsperado.Estado.Identificador, item1.Estado.Identificador);
                    Assert.Equal(condominioResultadoEsperado.Estado.Nome, item1.Estado.Nome);
                    Assert.Equal(condominioResultadoEsperado.Estado.Sigla, item1.Estado.Sigla);
                    Assert.Equal(condominioResultadoEsperado.Pais, item1.Pais);
                });

        }


        [Fact]
        [Trait(nameof(ICondominioService.BuscarMoradiaCondominiosAsync), "Exception")]
        public async Task BuscarMoradiaCondominiosAsync_Exception()
        {
            //Arange = inicializacao de variaveis 
            var cpfCnpj = 99999999999999;

            var exceptionMock = new Exception("Erro ao recuperar dados");
            var exceptionEsperado = new Exception("Erro ao recuperar dados");

            var nomeMetodo = nameof(ICondominioService.BuscarMoradiaCondominiosAsync);

            //Act = invocar os metodos 

            condominioReadAdapterMock.Setup(c => c.BuscarMoradiaCondominiosAsync())
            .ThrowsAsync(exceptionMock);

            //Realiza chamada ao metodo

            var ex = await Assert.ThrowsAnyAsync<Exception>(async () =>
            {
                await condominioService
               .BuscarMoradiaCondominiosAsync();
            });

            //Assertes = verifica a ação

            Assert.Equal(exceptionEsperado.Message, ex.Message);

            logCondominioServiceMock.Setup(a => a.GerarLogPorMetodoAsync(It.IsAny<Exception>(), It.IsAny<string>()))
                .Returns(Task.CompletedTask)
                .Callback<Exception, string>((exceptionCallback, metodoCallback) =>
                {
                    Assert.Equal(exceptionEsperado.Message, exceptionCallback.Message);
                    Assert.Equal(nomeMetodo, metodoCallback);
                });

        }
    }


}
