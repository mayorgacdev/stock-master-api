namespace Training.Domain.Inventory;

public class PartDetail
{
    private PartDetail() { }

    public Guid AccesoryId { get; private set; } = Guid.Empty;
    public Guid PartId { get; private set; } = Guid.Empty;
    public Part Part { get; set; } = null!;
    public Accesory Accesory { get; set; } = null!;

    public static PartDetail Create(Guid accesoryId, Guid accesoryPartId)
        => new()
        {
            AccesoryId = accesoryId,
            PartId = accesoryPartId
        };
}

