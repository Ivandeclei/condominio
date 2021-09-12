using System;
using System.ComponentModel.DataAnnotations;

namespace Condominio.Domain.Models
{
    public class MoradiaCondominio : EnderecoBase
    {
        public Guid Identificador { get; set; }

        [Required(ErrorMessage = "O nome do condominio é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = " O CNPJ ou CPF é obrigatório")]
        [MaxLength(14, ErrorMessage = "O valor informado excedeu o maxímo permitido {1}")]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "O Telefone é Obrigatório")]
        public string Telefone { get; set; }
        
    }
}
