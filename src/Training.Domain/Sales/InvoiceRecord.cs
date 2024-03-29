namespace Training.Domain.Sales;

public class InvoiceRecord : Entity
{
    private InvoiceRecord() { }
    public Guid CustomerId { get; internal set; }
    public Guid DeliveryPriceId { get; private set; }
    public Guid VehicleId { get; private set; }
    public string Status { get; set; } = string.Empty;
    public DateTime IssueTime { get; internal set; }
    public DateOnly DueDate { get; internal set; }
    public DateTime? PaymentTime { get; internal set; }
    public List<InvoiceLine> Lines { get; } = new List<InvoiceLine>();

    public Money TotalAmount =>
        this.Lines.Aggregate(Money.Zero, (total, line) => total + line.Price);

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
