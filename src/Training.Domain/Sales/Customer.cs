namespace Training.Domain.Sales;

public class Customer : Entity
{
    private Customer()
    {
        InvoiceRecords = new HashSet<InvoiceRecord>();
    }
    public string FirtsName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;

    public static Customer Create(string firstName, string lastName, string email, string phone)
        => new Customer
        {
            Id = Guid.NewGuid(),
            FirtsName = firstName,
            LastName = lastName,
            Email = email,
            Phone = phone
        };

    public ICollection<InvoiceRecord> InvoiceRecords { get; private set; }
}