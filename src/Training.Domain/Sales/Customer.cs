namespace Training.Domain.Sales;

public class Customer : Entity
{
    private Customer() { }
    public string FirtsName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    public static Customer Create(string firstName, string lastName, string email, string phone)
        => new Customer
        {
            Id = Guid.NewGuid(),
            FirtsName = firstName,
            LastName = lastName,
            Email = email,
            Phone = phone
        };
}