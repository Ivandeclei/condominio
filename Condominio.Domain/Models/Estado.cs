using System;
using System.ComponentModel.DataAnnotations;

namespace Condominio.Domain.Models
{
    public class Estado
    {
        public Guid Identificador { get; set; }
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Estado é obrigatório")]
        [StringLength(2, ErrorMessage = "O tamanho maximo da sigla do estado é 2 caracteres")]
        public string Sigla { get; set; }
    }
}
