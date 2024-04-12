namespace Training.Application.Sales.Requests.Products;

public class ProductInfo
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string SupplierName { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public string WarehouseName { get; set; } = string.Empty;
    public string BrandName { get; set; } = string.Empty;
    public string TypeName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Stock { get; set; }
    public int ReorderLevel { get; set; }
    public decimal TaxRate { get; set; }
    public decimal Price { get; set; }
    public ProductPicturesInfo[] ProductPictureInfos { get; set; } = Array.Empty<ProductPicturesInfo>();

}
