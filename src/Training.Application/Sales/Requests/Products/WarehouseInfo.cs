namespace Training.Application.Sales.Requests.Products;

public class WarehouseInfo
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Name { get; private set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public int Capacity { get; set; } = 0;
    public int Max { get; set; } = 0;
}
