using System;

namespace Condominio.Domain.Models
{
    public class Estado
    {
        public Guid Identificador { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
    }
}
