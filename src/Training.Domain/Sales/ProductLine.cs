namespace Training.Domain.Sales;
public class ProductLine : InvoiceLine
{
    private ProductLine() { }

    public ProductLine(Guid invoiceId, Guid productId, string description, int quantity, Money price)
        : base(invoiceId, productId, description, quantity, price) { }

    public static ProductLine CreateNew(
        Guid invoiceId,
        Guid productId,
        string description,
        int quantity,
        Money price) 
        => new(invoiceId, productId, description, quantity, price);
}