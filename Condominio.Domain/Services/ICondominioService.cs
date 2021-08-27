﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Condominio.Domain.Models;

namespace Condominio.Domain.Services
{
    public interface ICondominioService
    {
        /// <summary>
        /// Busca condominios cadastrados no sistema
        /// </summary>
        /// <returns>
        /// Retorna uma lista de condominios cadastrados
        /// </returns>
        Task<IEnumerable<MoradiaCondominio>> BuscarMoradiaCondominiosAsync();

        /// <summary>
        /// Busca condominio cadastrado no sistema
        /// </summary>
        /// <Param name="condominioParametro">
        /// Parametro de busca de um condominio
        /// </Param>
        /// <returns>
        /// Retorna condominio cadastrado
        /// </returns>
        Task<MoradiaCondominio> BuscarMoradiaCondominioAsync(
            CondominioParametro condominioParametro);
    }
}
