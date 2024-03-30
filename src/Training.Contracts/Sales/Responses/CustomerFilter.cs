namespace Training.Contracts.Sales.Responses;

public record CustomerFilter : BaseFilter
{
    public string? Name { get; set; }
}
