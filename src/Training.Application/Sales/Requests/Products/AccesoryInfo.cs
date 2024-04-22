namespace Training.Application.Sales.Requests.Products;

public class AccesoryInfo
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public bool IsActive { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public decimal? PurchasePrice { get; set; }
}