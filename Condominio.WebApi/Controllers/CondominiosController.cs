using AutoMapper;
using Condominio.Application;
using Condominio.Domain.Exceptions;
using Condominio.Domain.Models;
using Condominio.Domain.Services;
using Condominio.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Condominio.WebApi.Controllers
{
    
    //[ApiVersion("1.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class CondominiosController : ControllerBase
    {
        private readonly ICondominioService condominioService;
 
        private readonly IMapper mapper;

        public CondominiosController(ICondominioService condominioService, IMapper mapper)
        {
            this.condominioService = condominioService ?? 
                throw new ArgumentNullException(nameof(condominioService));
       
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Busca determinado condominio 
        /// </summary>
        /// <param name="condominioParametroGet"> Busca um condominio pelo CPF ou CNPJ</param>
        /// <returns>
        /// Retorna Condominio pesquisado
        /// </returns>
        [HttpGet("BuscarCondominioPorCNPJ")]

        [ProducesResponseType(typeof(MoradiaCondominioDto), 200)]
        //[ProducesResponseType(typeof(CoreException), 400)]
        //[ProducesResponseType(typeof(InternalError), 500)]
        public async Task<IActionResult> BuscarCondominioAsync(
            [FromQuery] CondominioParametroGet condominioParametroGet)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var condominioParametro = mapper.Map<CondominioParametro>(condominioParametroGet);

                var condominio = await condominioService.BuscarMoradiaCondominioAsync(condominioParametro);

                var resultado = mapper.Map<MoradiaCondominioDto>(condominio);

                return Ok(resultado);
            }
            catch (CoreException e )
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Errors);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Busca determinado condominio 
        /// </summary>
        /// <returns>
        /// Retorna todos os condominios 
        /// </returns>
        [HttpGet]
        [ProducesResponseType(typeof(MoradiaCondominioDto), 200)]
        //[ProducesResponseType(typeof(CoreException<CoreError>), 400)]
        //[ProducesResponseType(typeof(InternalError), 500)]
        public async Task<IActionResult> BuscarCondominiosAsync()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var condominio = await condominioService.BuscarMoradiaCondominiosAsync();

                var resultado = mapper.Map<IEnumerable<MoradiaCondominioDto>>(condominio);

                return Ok(resultado);
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
