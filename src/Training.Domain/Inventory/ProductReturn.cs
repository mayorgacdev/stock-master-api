namespace Training.Domain.Inventory;

public class ProductReturn : Entity
{
    public DateTime ReturnDate { get; private set; }
    public Guid InvoiceLineId { get; private set; }
    public int QuantityReturned { get; private set; }
    public string Reason { get; private set; } = string.Empty;

    public static ProductReturn Create(Guid invoiceLineId, int quantityReturned, string reason)
        => new()
        {
            Id = Guid.NewGuid(),
            ReturnDate = DateTime.Now,
            InvoiceLineId = invoiceLineId,
            QuantityReturned = quantityReturned,
            Reason = reason
        };
    
}
