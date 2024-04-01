using Training.Application.Attributes;

namespace Training.Application.Extensions;

/// <summary>
///     Métodos de utilería para obtener información desde un Type.
/// </summary>
public static class TypeExtensions
{
    /// <summary>
    /// 
    /// REMOVE THIS
    /// </summary>
    /// <param name="Type"></param>
    /// <returns></returns>

    public static Type GetUnderlyingType(this Type Type)
    {
        static Type NullableGetUnderlyingType(Type Type) => Nullable.GetUnderlyingType(Type) ?? Type;

        if (Type.IsEnum)
        {
            return Enum.GetUnderlyingType(NullableGetUnderlyingType(Type));
        }

        return NullableGetUnderlyingType(Type);
    }

    /// <summary>
    ///     Obtiene el métadato <see cref="ErrorCategoryAttribute" /> desde la información de tipo <paramref name="Type" />.
    /// </summary>
    /// <param name="Type">
    ///     Información el tipo que tiene los metadatos de errores.
    /// </param>
    /// <returns>
    ///     Regresa el <see cref="ErrorCategoryAttribute" /> correspondiente al tipo.
    /// </returns>
    public static string? GetErrorCategory(this Type? Type)
    {
        return Type?.GetCustomAttribute<ErrorCategoryAttribute>()?.Category;
    }

    /// <summary>
    ///     Obtiene el métadato <see cref="ErrorCodePrefixAttribute" /> desde la información de tipo <paramref name="Type" />.
    /// </summary>
    /// <param name="Type">
    ///     Información el tipo que tiene los metadatos de errores.
    /// </param>
    /// <returns>
    ///     Regresa el <see cref="ErrorCodePrefixAttribute" /> correspondiente al tipo.
    /// </returns>
    public static string? GetErrorCodePrefix(this Type? Type)
    {
        return Type?.GetCustomAttribute<ErrorCodePrefixAttribute>()?.Prefix;
    }
}
