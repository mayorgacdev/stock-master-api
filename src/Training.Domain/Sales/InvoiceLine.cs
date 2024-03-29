using Training.Domain.Inventory;

namespace Training.Domain.Sales;

public abstract class InvoiceLine
{
    public Guid ProductId { get; set; } = Guid.Empty;
    public Guid InvoiceRecordId { get; private set; } = Guid.Empty;
    public string Description { get; private set; } = string.Empty;
    public int Quantity { get; private set; } = 1;
    public Money Price
    { 
        get => this.Currency.Amount(this.Amount);
        private set => (this.Amount, this.Currency) = (value.Amount, value.Currency);
    }

    private decimal Amount { get; set; } = 0;       // Used by EF Core
    private Currency Currency { get; set; }         // Used by EF Core

    protected InvoiceLine() { }      // Used by EF Core

    protected InvoiceLine(Guid invoiceRecordId, Guid productId, string description, int quantity, Money price)
    {
        InvoiceRecordId = invoiceRecordId;
        ProductId = productId;
        Description = description;
        Quantity = quantity;
        Price = price;
    }

    public void Increment(int quantity, Money price)
    {
        Quantity += quantity;
        Price += price;
    }
}
