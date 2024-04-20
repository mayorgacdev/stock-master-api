namespace Training.Application.Requests.Products;

using Training.Application.Attributes;

[Validator<CreateProductValidator>]
public class CreateProductRequest : IRequest
{
    public required string Name { get; set; } = string.Empty;
    public required string Description { get; set; } = string.Empty;
    public required int Stock { get; set; }
    public required int ReorderLevel { get; set; }
    public required decimal TaxRate { get; set; }
    public required string BrandId { get; set; }
    public required string TypeId { get; set; }
    public required string SupplierId { get; set; }
    public required string WarehouseId { get; set; }
    public required decimal Profit { get; set; }
    public required CreateProductPriceRequest CreateProductPriceRequest { get; set; } 
    public required CreateProductPictureRequest[] ProductPictureRequest { get; set; } = Array.Empty<CreateProductPictureRequest>();
}