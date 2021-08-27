using System.Collections.Generic;

namespace Condominio.Domain.Models
{
    public class Apartamento
    {
        public int Numero { get; set; }
        public StatusOcupacao Status { get; set; }
        public IEnumerable<Garagem> Garagens { get; set; }
    }
}
