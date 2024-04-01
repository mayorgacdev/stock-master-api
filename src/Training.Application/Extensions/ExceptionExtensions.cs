using Training.Application.Exceptions;
using Training.Application.Responses;

namespace Training.Application.Extensions;

/// <summary>
///     Métodos de utilería para mejor manejo de las excepciones.
/// </summary>
public static class ExceptionExtensions
{
    /// <summary>
    ///     Obtiene la lista enlazada de excepciones como un array.
    /// </summary>
    /// <param name="Ex">
    ///     Excepción que sirve como puntero inicial de la lista de excepciones.
    /// </param>
    /// <returns>
    ///     Regresa la lista enlazada de excepciones como un array.
    /// </returns>
    public static IEnumerable<Exception> GetExceptions(this Exception? Ex)
    {
        while (Ex is not null)
        {
            yield return Ex;
            Ex = Ex.InnerException;
        }
    }

    /// <summary>
    ///     Obtiene la lista enlazada de excepciones como un array de cadena de mensajes.
    /// </summary>
    /// <param name="Ex">
    ///     Excepción que sirve como puntero inicial de la lista de excepciones.
    /// </param>
    /// <returns>
    ///     Regresa la lista enlazada de excepciones como un array de cadena de mensajes.
    /// </returns>
    public static IEnumerable<string> GetMessages(this Exception? Ex)
    {
        return Ex.GetExceptions().Select(Ex => Ex.Message);
    }

    /// <summary>
    ///     Transforma la lista ligada de excepciones en un dicionario.
    /// </summary>
    /// <param name="Ex">
    ///     Excepción que sirve como puntero inicial de la lista de excepciones.
    /// </param>
    /// <returns>
    ///     Regresa la lista ligada de excepciones como un diccionario de errores.
    /// </returns>
    public static IDictionary<string, object?> ExceptionsToDictionary(this Exception? Ex)
    {
        return Ex.GetExceptions().ToDictionary<Exception, string, object?>(Ex => Ex.GetType().ToString(), Ex => Ex.Message);
    }

    public const string ExceptionTypeKey = "ExceptionType";

    public const string ExceptionMessagesKey = "ExceptionMessages";

    public const string ExceptionSourceKey = "ExceptionSource";

    public const string ExceptionStackTraceKey = "ExceptionStackTrace";

    /// <summary>
    ///     Convierte una Excepción general ha una posible representación de <typeparamref name="TException"/>.
    /// </summary>
    /// <param name="Exception">
    ///     Excepción con la información del error.
    /// </param>
    /// <param name="MethodInfo">
    ///     Método que tiene los metadatos relacionado a error de <paramref name="Ex" />.
    /// </param>
    /// <returns>
    ///     Regresa un <typeparamref name="TException"/> como una posible representación más detallada de <see cref="Exception" />.
    /// </returns>
    public static TException CreateExceptionUsingMethodInfo<TException>(this Exception Exception, MethodBase MethodInfo, Action<ErrorStatus> ErrorStatusOptions) where TException : TrainingException
    {
        var Status = new ErrorStatus
        {
            HasError = true,
            MethodId = MethodInfo.GetMethodId(),
            ErrorCode = string.Empty,
            ErrorMessage = string.Empty,
            ErrorCategory = MethodInfo.GetErrorCategory()
        };

        ErrorStatusOptions.Invoke(Status);

        Status.Extensions.Add(ExceptionTypeKey, Exception.GetType().ToString());
        Status.Extensions.Add(ExceptionMessagesKey, Exception.GetMessages().ToArray());
        Status.Extensions.Add(ExceptionSourceKey, Exception.Source);
        Status.Extensions.Add(ExceptionStackTraceKey, Exception.StackTrace);

        return Activator.CreateInstance(typeof(TException), [Status.ErrorMessage, Status, Exception]).As<TException>()!;
    }
}
