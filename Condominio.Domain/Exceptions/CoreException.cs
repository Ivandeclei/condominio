using System;
using System.Collections.Generic;

namespace Condominio.Domain.Exceptions
{
    /// <summary>
    /// Classe anonima responsavel por instanciar uma coreexception
    /// </summary>
    /// <typeparam name="T"> QUalquer tipo que pode ser usado por coreException</typeparam>
    [Serializable]
    public class CoreException<T> : CoreException
    {
        public CoreException()
        {

        }

        public CoreException(List<CoreError> errors) : base(errors)
        {

        }
    }

    /// <summary>
    /// Cria base para tratamento de exceção de erros 
    /// </summary>
    [Serializable]
    public  class CoreException : ApplicationException
    {
        public CoreException()
        {
            Errors = new List<CoreError>();
        }

        public CoreException(List<CoreError> errors)
        {
            Errors = errors;
        }

        public CoreException(CoreError errors) : this (new List<CoreError>() { errors })
        {
   
        }

        public List<CoreError> Errors { get; }

        public static CoreException Exception(List<CoreError> errors) => 
            new CoreException(errors);
        public static CoreException Exception(CoreError error) =>
            new CoreException(error);
        
    }

    /// <summary>
    /// Classe coreError responsavel por estruturar mensagem de erro personalizada
    /// </summary>
    [Serializable]
    public  class CoreError
    {
        public CoreError() : base() { }
      
        public CoreError(string message) { }

        public string Key { get; set; }
        public string Message { get; set; }
    }
}
