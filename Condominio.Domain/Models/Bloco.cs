using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Condominio.Domain.Models
{
    public class Bloco
    {
        [Required(ErrorMessage = "O nome do bloco é obrigatório")]
        public string NomeBloco { get; set; }
        public Guid IdentificadorCondominio { get; set; }
        [Required(ErrorMessage = "É necessario informar os apartamentos")]
        public IEnumerable<Apartamento> Apartamentos { get; set; }

    }
}
