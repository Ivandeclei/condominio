using Condominio.Domain.Exceptions;
using Condominio.Domain.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Condominio.Application
{
    public  class ValidacaoBaseService : IValidacaoBaseService
    {
     
        public CoreException VerificarCamposObrigatorios<T>(CoreException erros, T classe)
        {
            if (classe == null)
            {
                throw new System.ArgumentNullException(nameof(classe));
            }

            var coreException = new CoreException();

            if (!ModelValidator.TryValidate(classe, out IEnumerable<ValidationResult> errors))
            {
                foreach (var item in errors)
                {
                    coreException.Errors.Add(new CoreError()
                    {
                        Key = item.MemberNames.FirstOrDefault(),
                        Message = item.ErrorMessage
                    });
                }

                return coreException;
            }

            return coreException;
        }

    }
}
