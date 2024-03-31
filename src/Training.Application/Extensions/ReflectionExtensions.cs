namespace Training.Application.Extensions;

/// <summary>
///     Extensión de utilería para obtener información de los metadatos del método de forma sencilla.
/// </summary>
public static class ReflectionExtensions
{
    /// <summary>
    ///     Verifica si <paramref name="MethodInfo"/> tiene configurado <see cref="MethodIdAttribute.MethodId"/>.
    /// </summary>
    /// <param name="MethodInfo">
    ///     Método que se buscara su MethodId.
    /// </param>
    /// <returns>
    ///     Regresa <see langword="true"/> si existe <see cref="MethodIdAttribute.MethodId"/> en <paramref name="MethodInfo"/> sino <see langword="false"/>.
    /// </returns>
    public static bool HasMethodId(this MethodBase? MethodInfo)
    {
        return MethodInfo.GetMethodId() is not null;
    }

    /// <summary>
    ///     Método del que se obtendrá el metadato: <see cref="MethodIdAttribute" />.
    /// </summary>
    /// <param name="MethodInfo">
    ///     Información del método con los metadatos de errores.
    /// </param>
    /// <returns>
    ///     Regresa el MethodId de <paramref name="MethodInfo" />.
    /// </returns>
    public static string? GetMethodId(this MethodBase? MethodInfo)
    {
        return MethodInfo?.GetCustomAttribute<MethodIdAttribute>()?.MethodId;
    }

    /// <summary>
    ///     Método del que se obtendrá el metadato: <see cref="ErrorCategoryAttribute" /> desde la clase que lo declara.
    /// </summary>
    /// <param name="MethodInfo">
    ///     Información del método con los metadatos de errores.
    /// </param>
    /// <returns>
    ///     Regresa el ErrorCategory de <paramref name="MethodInfo" />.
    /// </returns>
    public static string? GetErrorCategory(this MethodBase? MethodInfo)
    {
        return MethodInfo?.DeclaringType.GetErrorCategory();
    }

    /// <summary>
    ///     Método del que se obtendrá el metadato: <see cref="ErrorCodePrefixAttribute" /> desde la clase que lo declara.
    /// </summary>
    /// <param name="MethodInfo">
    ///     Información del método con los metadatos de errores.
    /// </param>
    /// <returns>
    ///     Regresa el ErrorCodePrefix de <paramref name="MethodInfo" />.
    /// </returns>
    public static string? GetErrorCodePrefix(this MethodBase? MethodInfo)
    {
        return MethodInfo?.DeclaringType.GetErrorCodePrefix();
    }

    /// <summary>
    ///     Obtiene el código de error correspondiente a un error de SysCredit.
    /// </summary>
    /// <param name="MethodInfo">
    ///     Método que declara el tipo que tiene el prefijo correspondiente de código de error.
    /// </param>
    /// <param name="PredefinedErrorCodeNumber">
    ///     Código de error predefinido.
    /// </param>
    /// <seealso cref="PredefinedErrorCodeNumbers" />
    /// <returns>
    ///     Regresa el código de error con el prefijo correspondiente al tipo donde es declarado el método <paramref name="MethodInfo" />.
    /// </returns>
    private static string? GetPredefinedErrorCode(this MethodBase? MethodInfo, string PredefinedErrorCodeNumber)
    {
        string? Prefix = MethodInfo?.GetErrorCodePrefix();

        if (Prefix is not null)
        {
            return $"{Prefix}{PredefinedErrorCodeNumber}";
        }

        return null;
    }
}
