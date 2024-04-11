using Training.Domain.Inventory;

namespace Training.Domain.Sales;
public class ProductLine : InvoiceLine
{
    private ProductLine() { }

    public ProductLine(Guid invoiceRecordId, Guid productId, string description, int quantity, Money price)
        : base(invoiceRecordId, productId, description, quantity, price) { }

    public static ProductLine CreateNew(
        Guid invoiceRecordId,
        Guid productId,
        string description,
        int quantity,
        Money price) 
        => new(invoiceRecordId, productId, description, quantity, price);

}