namespace Training.Domain.Inventory;

public class PartDetail
{
    private PartDetail() { }

    public string Notes { get; private set; } = string.Empty;
    public Guid AccesoryId { get; private set; } = Guid.Empty;
    public Guid PartId { get; private set; } = Guid.Empty;
    public Part Part { get; set; } = null!;
    public Accesory Accesory { get; set; } = null!;

    public static PartDetail Create(string notes, Guid accesoryId, Guid accesoryPartId)
        => new()
        {
            Notes = notes,
            AccesoryId = accesoryId,
            PartId = accesoryPartId
        };
}

