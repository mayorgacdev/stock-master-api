namespace Training.Application.Extensions;

/// <summary>
///     Métodos de utilería para operaciones sobre colecciones.
/// </summary>
public static class CollectionExtensions
{
    /// <summary>
    ///     Agrega un rango de elementos para <paramref name="Source" />.
    /// </summary>
    /// <typeparam name="TSource">
    ///     Tipo de la coleccion.
    /// </typeparam>
    /// <param name="Source">
    ///     Colección que se le agregarán los nuevos elementos.
    /// </param>
    /// <param name="Values">
    ///     Lista de valores que serán añadidos.
    /// </param>
    public static void AddRange<TSource>(this ICollection<TSource> Source, params TSource[] Values)
    {
        AddRange(Source, (IEnumerable<TSource>)Values);
    }

    /// <inheritdoc cref="AddRange{TSource}(ICollection{TSource}, TSource[])" />
    public static void AddRange<TSource>(this ICollection<TSource> Source, IEnumerable<TSource> Values)
    {
        foreach (TSource Value in Values)
        {
            Source.Add(Value);
        }
    }

    /// <summary>
    ///     Checks whether enumerable is null or empty.
    /// </summary>
    /// <typeparam name="TSource">
    ///     The type of the enumerable.
    /// </typeparam>
    /// <param name="Source">
    ///     The System.Collections.Generic.IEnumerable`1 to be checked.
    /// </param>
    /// <returns>
    ///     True if enumerable is null or empty, false otherwise.
    /// </returns>
    public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> Source)
    {
        return Source == null || !Source.Any();
    }

    /// <summary>
    ///     Regresa un <see cref="IEnumerable{T}" /> vacío si <paramref name="Source" /> es null sino un valor por defecto.
    /// </summary>
    /// <typeparam name="TSource">
    ///     Tipo de la colección.
    /// </typeparam>
    /// <param name="Source">
    ///     La colección ha chequear.
    /// </param>
    /// <param name="DefaultValue">
    ///     Valor por defecto en caso de que la coleccion sea nula o este vacía.
    /// </param>
    /// <returns>
    ///     Regresa un <see cref="Enumerable.Empty{TResult}" /> si <paramref name="Source" /> es null
    ///     sino un <see cref="Enumerable.DefaultIfEmpty{TSource}(IEnumerable{TSource}, TSource)" />.
    /// </returns>
    public static IEnumerable<TSource> DefaultIfNullOrEmpty<TSource>(this IEnumerable<TSource>? Source)
    {
        return Source ?? Enumerable.Empty<TSource>();
    }
}
