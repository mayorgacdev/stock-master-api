namespace Training.Domain.Common;

/// <summary>
///     Objeto usado para retornar el Id de la entidad que se está creando.
/// </summary>
public record struct EntityId
{
    /// <summary>
    ///     Id único de la entidad creada desde base de datos.
    /// </summary>
    public Guid? Id { get; set; }

    /// <summary>
    ///     Convierte un <see cref="EntityId" /> en un <see cref="Guid" />?.
    /// </summary>
    /// <param name="EntityId">
    ///     <see cref="EntityId" /> que se va ha convertir en <see cref="Guid" />?.
    /// </param>
    public static implicit operator Guid?(EntityId EntityId) => EntityId.Id;

    /// <summary>
    ///     Convierte un <see cref="Guid" />? en un <see cref="EntityId" />.
    /// </summary>
    /// <param name="Id">
    ///     <see cref="Guid" />? que se va ha convertir en un <see cref="EntityId" />.
    /// </param>
    public static implicit operator EntityId(Guid? Id) => new() { Id = Id };
}
