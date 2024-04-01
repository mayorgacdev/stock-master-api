using Training.Application.Responses;

namespace Training.Application.Exceptions;

public class TrainingException(string? Message = null, ErrorStatus? ErrorStatus = null, Exception? InnerException = null) : Exception(Message, InnerException)
{
    /// <summary>
    ///     Información detallada de los errores de SysCredit.Api.
    /// </summary>
    public ErrorStatus? ErrorStatus { get; } = ErrorStatus ?? new() { HasError = true };
}
