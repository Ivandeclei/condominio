using System.ComponentModel.DataAnnotations;

namespace Condominio.WebApi.Dtos
{
    public class CondominioParametroGet
    {
        /// <summary>
        /// CPF ou CNPJ  do condominio a ser pesquisado
        /// </summary>
        /// 

        public string? CpfCnpj { get; set; }
    }
}
