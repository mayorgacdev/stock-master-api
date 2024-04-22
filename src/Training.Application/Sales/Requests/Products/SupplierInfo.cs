namespace Training.Application.Sales.Requests.Products;

public class SupplierInfo
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
