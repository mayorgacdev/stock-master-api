namespace Training.WebApi.Middlewares;

using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;
using Training.Application.Attributes;
using Training.Application.Constants;
using Training.Application.Exceptions;
using Training.Application.Extensions;
using Training.Common;
using static Training.Application.Constants.TrainingConstants;
using static Training.Application.Constants.ErrorCodes;
using Training.Application.Proxies;

/// <summary>
///     Middleware que captura todas las excepciones no controladas de algún Request.
/// </summary>
/// <param name="Next">
///     Ejecuta el request actual.
/// </param>
/// <param name="Logger">
///     Objeto de Logs para informar sobre el error que se está capturando.
/// </param>
[ErrorCategory(nameof(TrainingMiddleware))]
[ErrorCodePrefix(InternalServerErrorPrefix)]
public class TrainingMiddleware(RequestDelegate Next, ILogger<TrainingMiddleware> Logger)
{
    /// <summary>
    ///     Código único del método que captura el error.
    /// </summary>
    public const string TrainingMiddlewareMethodId = "73E66405-D1D0-44D0-8EAB-9AC7D08742A9";

    /// <summary>
    ///     Método que tiene información del Request actual en ejecución.
    /// </summary>
    /// <param name="Context">
    ///     Información completa del Request que se está ejecutando.
    /// </param>
    /// <returns>
    ///     Task que represanta ha <see cref="InvokeAsync(HttpContext)" /> como una operación asincrona.
    /// </returns>
    [MethodId(TrainingMiddlewareMethodId)]
    public async Task InvokeAsync(HttpContext Context)
    {
        try
        {
            Context.Request.EnableBuffering();
            await Next(Context);
        }
        catch (ServiceException Exception)
        {
            int StatusCode = Exception.Data[IsFromValidationExceptionKey].As<bool>()
                ? StatusCodes.Status400BadRequest
                : StatusCodes.Status500InternalServerError;

            IResponse Response = await CreateHttpContextResponseDataAsync(Context, StatusCode).ToResponseAsync(Exception.ErrorStatus);
            await Context.Response.WriteAsync(WriteLogErrorResponse(Response));
        }

        catch (TrainingException Exception)
        {
            IResponse Response = await CreateHttpContextResponseDataAsync(Context).ToResponseAsync(Exception.ErrorStatus);
            await Context.Response.WriteAsync(WriteLogErrorResponse(Response));
        }
        catch (Exception Exception)
        {
            IResponse Response = await CreateHttpContextResponseDataAsync(Context).ToResponseAsync(CreateErrorStatusFromException(Exception));
            await Context.Response.WriteAsync(WriteLogErrorResponse(Response));
        }
    }

    /// <summary>
    ///     Establece las configuraciones del Response como una respuesta Json.
    /// </summary>
    /// <param name="Context">
    ///     Información detallada del Request que se está ejecutando.
    /// </param>
    /// <param name="StatusCode">
    ///     Código de error del Response del Request.
    /// </param>
    private static void ConfigureHttpContextResponse(HttpContext Context, int StatusCode)
    {
        Context.Response.ContentType = "application/json";
        Context.Response.StatusCode = StatusCode;
    }

    /// <summary>
    ///     Crea un <see cref="ErrorResponse" /> que será usado por <see cref="IResponse{T}.Data" />.
    /// </summary>
    /// <param name="Context">
    ///     Información detallada del Request que se está ejecutando.
    /// </param>
    /// <param name="StatusCode">
    ///     Código de error del Response del Request. Por defecto tiene un valor de 500.
    /// </param>
    /// <returns>
    ///     Regresa un <see cref="ErrorResponse" /> con información detallada del error del Request.
    /// </returns>
    private static async ValueTask<ErrorResponse> CreateHttpContextResponseDataAsync(HttpContext Context, int StatusCode = StatusCodes.Status500InternalServerError)
    {
        ConfigureHttpContextResponse(Context, StatusCode);

        Context.Request.Body.Seek(0, SeekOrigin.Begin);
        using var Reader = new StreamReader(Context.Request.Body, Encoding.UTF8);
        string RequestBody = await Reader.ReadToEndAsync().ConfigureAwait(false);
        Context.Request.Body.Seek(0, SeekOrigin.Begin);

        return new ErrorResponse
        (
            HttpMethod: Context.Request.Method,
            ServerHost: Context.Request.Host.ToString(),
            EndpointPath: Context.Request.Path.ToString(),
            QueryString: Context.Request.QueryString.ToString(),
            RequestBody: RequestBody.DeserializeIfNotNullOrEmpty<Dictionary<string, object>>()
        );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Exception"></param>
    /// <returns></returns>
    private static ErrorStatus CreateErrorStatusFromException(Exception Exception)
    {
        return new()
        {
            HasError = true,
            MethodId = TrainingMiddlewareMethodId,
            ErrorCode = InternalServerErrorCode,
            ErrorMessage = Exception.Message,
            ErrorCategory = typeof(TrainingMiddleware).GetErrorCategory(),
            Extensions =
            {
                [ExceptionTypeKey]       = Exception.GetType().ToString(),
                [ExceptionMessagesKey]   = Exception.GetMessages().ToArray(),
                [ExceptionSourceKey]     = Exception.Source,
                [ExceptionStackTraceKey] = Exception.StackTrace
            }
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Response"></param>
    /// <returns></returns>
    private static string SerializeResponse(IResponse Response)
    {
        var Options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonDefaultNamingPolicy.DefaultNamingPolicy,
            WriteIndented = true
        };

        return JsonSerializer.Serialize(Response, Options);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Response"></param>
    /// <returns></returns>
    private string WriteLogErrorResponse(IResponse Response)
    {
        string JsonText = SerializeResponse(Response);
        Logger.LogError(JsonText);
        return JsonText;
    }
}
