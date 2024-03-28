namespace Training.Domain;

public class InvoiceRecord : Entity
{
    private InvoiceRecord() { }
    public Customer Customer { get; internal set; } = null!;
    public Guid DeliveryPriceId { get; private set; }
    public Guid VehicleId { get; private set; }
    public string PaymentIntentId { get; private set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime IssueTime { get; internal set; }
    public DateOnly DueDate { get; internal set; }
    public DateTime? PaymentTime { get; internal set; }
    internal List<InvoiceLine> Lines { get; } = new List<InvoiceLine>();

    public Money TotalAmount =>
        this.Lines.Aggregate(Money.Zero, (total, line) => total + line.Price);

    public static InvoiceRecord CreateNew(
        Customer customer,
        Guid DeliveryPriceId,
        Guid vehicleId,
        string paymentIntentId,
        string status,
        DateTime issueTime,
        DateOnly dueDate,
        DateTime? paymentTime)
        => new InvoiceRecord
        {
            Id = Guid.NewGuid(),
            Customer = customer,
            DeliveryPriceId = DeliveryPriceId,
            VehicleId = vehicleId,
            PaymentIntentId = paymentIntentId,
            Status = status,
            IssueTime = issueTime,
            DueDate = dueDate,
            PaymentTime = paymentTime
        };


}
