using Condominio.Domain.Exceptions;

namespace Condominio.Domain.Services
{
    public  interface IValidacaoBaseService
    {
        /// <summary>
        /// Valida campos obrigatorios do modelo
        /// </summary>
        /// <typeparam name="T">Modelo a ser validado</typeparam>
        CoreException VerificarCamposObrigatorios<T>(CoreException erros, T classe);

    }
}
