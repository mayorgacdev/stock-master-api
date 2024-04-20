namespace Training.Application.Requests.Products;

public class CreateProductPriceRequest
{
    public decimal Price { get; set; }
    public DateTime ValidFrom { get; set; }
    public string Currency { get; set; } = string.Empty;
}