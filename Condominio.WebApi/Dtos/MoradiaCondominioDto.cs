namespace Condominio.WebApi.Dtos
{
    public class MoradiaCondominioDto : EnderecoBaseDto
    {
        /// <summary>
        /// Nome do condominio
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// CPF ou CNPJ do Condominio
        /// </summary>
        public string CpfCnpj { get; set; }

        /// <summary>
        /// Telefone
        /// </summary>
        public string Telefone { get; set; }
    }
}
