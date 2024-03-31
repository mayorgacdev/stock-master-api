namespace Training.Contracts.Sales.Requests.Customers;

public record CustomerFilter : BaseFilter
{
    public string? Name { get; set; }
}
