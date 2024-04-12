namespace Training.Common;

public record ProductFilter : BaseFilter
{
    public string? Name { get; set; }
    public string? BrandName { get; set; }
    public string? TypeName { get; set; }
    public string? SupplierName { get; set; }

    public required string WarehouseName { get; set; }
}
