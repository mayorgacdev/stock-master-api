namespace Training.Domain.Sales;

public class Vehicle : Entity
{
    private Vehicle() 
    {
        Invoices = new HashSet<InvoiceRecord>();
    }

    public int SupportedStock { get; set; } = 0;
    public string Model { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Year { get; set; } = 0;
    public string Color { get; set; } = string.Empty;
    public ICollection<InvoiceRecord> Invoices { get; set; }

    public static Vehicle CreateNew(
        int supportedStock,
        string model,
        string description,
        int year,
        string color)
        => new Vehicle
        {
            Id = Guid.NewGuid(),
            SupportedStock = supportedStock,
            Model = model,
            Description = description,
            Year = year,
            Color = color
        };
}
