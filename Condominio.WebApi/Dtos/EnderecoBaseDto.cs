namespace Condominio.WebApi.Dtos
{
    public class EnderecoBaseDto
    {
       /// <summary>
       /// Nome da Rua do condominio
       /// </summary>
        public string Rua { get; set; }

        /// <summary>
        /// CEP
        /// </summary>
        public int Cep { get; set; }

        /// <summary>
        /// Número 
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Bairro
        /// </summary>
        public string Bairro { get; set; }

        /// <summary>
        /// Cidade onde o condominio está localizado
        /// </summary>
        public string Cidade { get; set; }

       /// <summary>
       /// Estado onde o condominio esta localizado
       /// </summary>
        public EstadoDto Estado { get; set; }

        /// <summary>
        /// País 
        /// </summary>
        public string? Pais { get; set; }
    }
}
