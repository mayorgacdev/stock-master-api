namespace Training.Application.Sales.Requests.Products;

public class ProductInfo
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public SupplierInfo SupplierInfo { get; set; } = default!;
    public WarehouseInfo WarehouseInfo { get; set; } = default!;
    public ProductBrandInfo BrandInfo { get; set; } = default!;
    public ProductTypeInfo ProductTypeInfo { get; set; } = default!;
    public ProductPriceInfo[] PriceInfo { get; set; } = Array.Empty<ProductPriceInfo>();
    public PictureInfo[] Pictures { get; set; } = Array.Empty<PictureInfo>();
    public string Description { get; set; } = string.Empty;
    public int Stock { get; set; }
    public int ReorderLevel { get; set; }
    public decimal Tax { get; set; }
    public decimal Profit { get; set; }
}

public class PictureInfo
{
    public Guid Id { get; set; }
    public string PictureUrl { get; set; } = string.Empty;
}