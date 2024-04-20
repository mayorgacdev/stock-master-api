namespace Training.Domain.Inventory;

public class AccesoryDetail
{
    public Guid ProductId { get; private set; } = Guid.Empty;
    public Guid AccesoryId { get; private set; } = Guid.Empty;
    public Accesory Accesory { get; set; } = null!;
    public Product Product { get; set; } = null!;

    public static AccesoryDetail Create(Guid producId, Accesory accesory)
        => new()
        {
            ProductId = producId,
            Accesory = accesory,
        };

    public static IEnumerable<AccesoryDetail> CreateMany(Guid productId, IEnumerable<Accesory> accesories)
        => accesories.Select(accesory => Create(productId, accesory));
}
