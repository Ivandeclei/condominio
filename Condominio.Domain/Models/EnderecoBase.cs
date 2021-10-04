using System.ComponentModel.DataAnnotations;

namespace Condominio.Domain.Models
{
    public class EnderecoBase
    {
        [Required(ErrorMessage = "O nome da Rua é obrigatório")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório")]
        [Range(1, 99999999)]
        public int Cep { get; set; }

        public string Numero { get; set; }

        [Required(ErrorMessage = "O Bairro é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O Cidade é obrigatório")]
        public string Cidade { get; set; }

        public Estado Estado { get; set; }
        public string? Pais { get; set; }
    }
}
