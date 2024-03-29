namespace Training.Domain.Inventory;

public class Supplier : Entity
{
    private Supplier() { }

    public string Name { get; private set; } = string.Empty;
    public string Address { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;
    public string Email { get; set; } = string.Empty;   
    public static Supplier Create(string name, string address, string email, string phone)
        => new()
        {
            Id = Guid.NewGuid(),
            Name = name,
            Email = email,
            Address = address,
            Phone = phone
        };
}
