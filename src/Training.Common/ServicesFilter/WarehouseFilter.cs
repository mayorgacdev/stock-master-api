namespace Training.Common;

public record WarehouseFilter : BaseFilter
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? State { get; set; }
    public string? City { get; set; }
}
