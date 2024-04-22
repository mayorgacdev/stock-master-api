namespace Training.Common;

public record ProductTypeFilter : BaseFilter
{
    public string? Name { get; set; }
}

public record SupplierFilter : BaseFilter
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
}

public record WarehouseFilter : BaseFilter
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
}

public record AccesoryFilter : BaseFilter
{
    public string? Id { get; set; }
    public string? Name { get; set; } 
}