namespace Condomino.DbAdapter.Clients
{
    public class MoradiaCondominioDto : EnderecoBaseDto
    {
        public string Nome { get; set; }

        public long CpfCnpj { get; set; }

        public string Telefone { get; set; }
    }
}
