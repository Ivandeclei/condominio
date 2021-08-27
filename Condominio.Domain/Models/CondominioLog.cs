using System;

namespace Condominio.Domain.Models
{
    public class CondominioLog
    {
        public string Metodo { get; set; }
        public string TipoObjeto { get; set; }
        public string Excecao { get; set; }
        public string Erros { get; set; }
        public DateTimeOffset DataHorario { get; set; }
       
    }
}
