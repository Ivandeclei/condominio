using System.ComponentModel.DataAnnotations;

namespace Condominio.Domain.Models
{
    public class CondominioParametro
    {
        [Required(ErrorMessage = "CNPJ obrigatório")]
        [StringLength(14, ErrorMessage = "O valor informado excedeu o maxímo de {1} caracteres permitido")]
        public string? CpfCnpj { get; set; }

    }
}
