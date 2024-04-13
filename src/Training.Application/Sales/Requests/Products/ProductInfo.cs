namespace Training.Application.Sales.Requests.Products;

public class ProductInfo
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public SupplierInfo SupplierInfo { get; set; } = default!;
    public WarehouseInfo WarehouseInfo { get; set; } = default!;
    public BrandInfo BrandInfo { get; set; } = default!;
    public ProductTypeInfo ProductTypeInfo { get; set; } = default!;
    public string Description { get; set; } = string.Empty;
    public int Stock { get; set; }
    public int ReorderLevel { get; set; }
    public decimal TaxRate { get; set; }
    public ProductPriceInfo[] ProductPricesInfo { get; set; } = Array.Empty<ProductPriceInfo>();
    public ProductPicturesInfo[] ProductPicturesInfo { get; set; } = Array.Empty<ProductPicturesInfo>();
}
