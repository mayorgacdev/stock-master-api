namespace Training.Application.Sales.Requests.Products;

public class ProductPriceInfo
{
    public Guid Id { get; set; } = Guid.Empty;
    public decimal Price { get; set; }
    public DateTime ValidFrom { get; set; }
    public Guid ProductId { get; set; } = Guid.Empty;
}
