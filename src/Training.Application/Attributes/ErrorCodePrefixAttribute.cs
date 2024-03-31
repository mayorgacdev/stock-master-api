namespace Training.Application.Attributes;

/// <summary>
///     Prefijos usados para los códigos de errores: <see cref="Training.Application.Constants.ErrorCodes" />.
/// </summary>
/// <param name="Prefix">
///     Prefijo que será usado para los campos de <see cref="Training.Application.Constants.ErrorCodes" />.
/// </param>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ErrorCodePrefixAttribute(string Prefix) : Attribute
{
    /// <summary>
    ///     Nombre del prefijo usado para la lista de errores en <see cref="Training.Application.Constants.ErrorCodes" />.
    /// </summary>
    public readonly string Prefix = Prefix;
}