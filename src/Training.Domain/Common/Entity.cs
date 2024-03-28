namespace Training.Domain.Common;

public abstract class Entity
{
    public Guid Id { get; init; } = Guid.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdateAt { get; set; } = null;

    public DateTime? DeletedAt { get; set; } = null;
    
    public bool IsDeleted { get; set; } = false;

    protected readonly List<IDomainEvent> _domainEvents = [];

    protected Entity(Guid Id) => this.Id = Id;

    public List<IDomainEvent> PopDomainEvents()
    {
        var copy = _domainEvents.ToList();

        _domainEvents.Clear();

        return copy;
    }

    protected Entity() { }
}