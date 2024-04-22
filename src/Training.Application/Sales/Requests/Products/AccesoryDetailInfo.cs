namespace Training.Application.Sales.Requests.Products;

public class AccesoryDetailInfo
{
    public Guid ProductId { get; set; } = Guid.Empty;
    public IEnumerable<Guid> AccesoryId { get; set; } = Array.Empty<Guid>();

    public static AccesoryDetailInfo Create(Guid productId, IEnumerable<Guid> accesoriesId)
        => new()
        {
            ProductId = productId,
            AccesoryId = accesoriesId,
        };
}
