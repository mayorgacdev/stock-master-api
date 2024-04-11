namespace Training.Domain.Inventory;

public class AccesoryDetail
{
    public Guid ProductId { get; private set; } = Guid.Empty;
    public Guid AccesoryId { get; private set; } = Guid.Empty;
    public string Notes { get; private set; } = string.Empty;
    public Accesory Accesory { get; set; } = null!;
    public Product Product { get; set; } = null!;

    public static AccesoryDetail Create(Guid productId, Guid accesoryId, string notes)
        => new()
        {
            ProductId = productId,
            AccesoryId = accesoryId,
            Notes = notes
        };
}
