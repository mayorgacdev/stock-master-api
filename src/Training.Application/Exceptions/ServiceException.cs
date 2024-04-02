namespace Training.Application.Exceptions;

/// <summary>
///     Representa los errores ocurridos en un Servicio.
/// </summary>
/// <param name="Message">
///     Mensaje de error que describe porque se dio el error.
/// </param>
/// <param name="ErrorStatus">
///     Información detallada de los errores de SysCredit.Api.
/// </param>
/// <param name="InnerException">
///     Excepción que se va ha encolar al <see cref="SysCreditException"/>.
/// </param>
public class ServiceException(string? Message = null, ErrorStatus? ErrorStatus = null, Exception? InnerException = null)
        : TrainingException(Message, ErrorStatus, InnerException);
