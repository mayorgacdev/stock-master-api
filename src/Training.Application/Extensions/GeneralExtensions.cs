using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Training.Application.Extensions;

/// <summary>
///     Métodos de utilería de propósito general.
/// </summary>
public static class GeneralExtensions
{
    /// <summary>
    ///     Realiza un casting de tipo <typeparamref name="TObject" /> sobre el objeto <paramref name="object" />.
    /// </summary>
    /// <typeparam name="TObject">
    ///     Tipo del casting ha realizar.
    /// </typeparam>
    /// <param name="object">
    ///     Objeto que se le aplicará el casting de tipo <typeparamref name="TObject" />.
    /// </param>
    /// <returns>
    ///     Regresa el objeto <paramref name="object" /> convertido al tipo <typeparamref name="TObject" />.
    /// </returns>
    /// <exception cref="InvalidCastException">
    ///     Excepción que es lanzada cuando <paramref name="object" /> no se puede convertir al tipo <typeparamref name="TObject" />.
    /// </exception>
    public static TObject? As<TObject>(this object? @object) => (TObject?)@object;

    /// <summary>
    ///     Transforma una cadena Json en un objeto de tipo <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">
    ///     Tipo del objeto usado en la deserialización.
    /// </typeparam>
    /// <param name="Json">
    ///     Cadena en formato Json que se va ha deserializar.
    /// </param>
    /// <returns>
    ///     Regresa la cadena <paramref name="Json"/> deserializada a un objeto de tipo <typeparamref name="T"/>
    ///     si <paramref name="Json"/> no es nulo.
    /// </returns>
    public static T? DeserializeIfNotNullOrEmpty<T>(this string? Json)
    {
        if (String.IsNullOrEmpty(Json))
        {
            return default;
        }

        return JsonSerializer.Deserialize<T?>(Json);
    }

    /// <summary>
    ///     Crea un código Hash del texto usado como argumento.
    /// </summary>
    /// <param name="Text">
    ///     Texto del que se obtendrá su código Hash.
    /// </param>
    /// <returns>
    ///     Regresa un array de bytes como resulto de convertir <paramref name="Text" /> en código Hash.
    /// </returns>
    public static byte[] ComputeHashSha512(this string Text)
    {
        return SHA512.HashData(Encoding.UTF8.GetBytes(Text));
    }
}
