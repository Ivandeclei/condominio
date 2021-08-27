using System.ComponentModel.DataAnnotations;

namespace Condominio.Domain.Models
{
    public class CondominioParametro
    {
        [Required(ErrorMessage = "CNPJ obrigatório")]
        public long CpfCnpj { get; set; }
    }
}
