namespace Condomino.DbAdapter.Clients
{
    public class EnderecoBaseDto
    {
        public string Rua { get; set; }

        public int? Cep { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public EstadoDto Estado { get; set; }

        public string? Pais { get; set; }
    }
}
