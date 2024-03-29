namespace Training.Domain.Common;

public abstract class Entity
{
    public Guid Id { get; init; } = Guid.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdateAt { get; set; } = null;

    public DateTime? DeletedAt { get; set; } = null;

    protected Entity() { }
}