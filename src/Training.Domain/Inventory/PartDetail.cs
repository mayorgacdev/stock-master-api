namespace Training.Domain.Inventory;

public class PartDetail
{
    private PartDetail() { }

    public string Description { get; private set; } = string.Empty;
    public string Notes { get; private set; } = string.Empty;
    public bool IsActive { get; private set; } 
    public Guid AccesoryId { get; private set; } = Guid.Empty;
    public Guid PartId { get; private set; } = Guid.Empty;
    public Part Part { get; set; } = null!;
    public Accesory Accesory { get; set; } = null!;
    public static PartDetail Create(string description, string notes, bool isActive, Guid accesoryId, Guid accesoryPartId)
        => new()
        {
            Description = description,
            Notes = notes,
            IsActive = isActive,
            AccesoryId = accesoryId,
            PartId = accesoryPartId
        };
}

