namespace Training.Domain.Sales;

public class InvoiceRecord : Entity
{
    private InvoiceRecord() { }
    public Guid CustomerId { get; internal set; }
    public Customer Customer { get; internal set; } = default!;

    public Guid DeliveryPriceId { get; private set; }
    public DeliveryPrice DeliveryPrice { get; private set; } = default!;

    public Guid VehicleId { get; private set; }
    public Vehicle Vehicle { get; private set; } = default!;

    public string Status { get; set; } = string.Empty;
    public DateTime IssueTime { get; internal set; }
    public DateOnly DueDate { get; internal set; }
    public DateTime? PaymentTime { get; internal set; }

    public ICollection<InvoiceLine> Invoices { get; } = new HashSet<InvoiceLine>();

    public Money TotalAmount =>
        this.Invoices.Aggregate(Money.Zero, (total, line) => total + line.Price);

    public static InvoiceRecord CreateNew(
        Guid customerId,
        Guid DeliveryPriceId,
        Guid vehicleId,
        string status,
        DateTime issueTime,
        DateOnly dueDate,
        DateTime? paymentTime)
        => new InvoiceRecord
        {
            Id = Guid.NewGuid(),
            CustomerId = customerId,
            DeliveryPriceId = DeliveryPriceId,
            VehicleId = vehicleId,
            Status = status,
            IssueTime = issueTime,
            DueDate = dueDate,
            PaymentTime = paymentTime
        };


}
