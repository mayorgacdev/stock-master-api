namespace Training.Domain;

public class DeliveryPrice : Entity
{
    private decimal Amount { get; set; }
    private Currency Currency { get; set; }         
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public Money Price
    {
        get => this.Currency.Amount(this.Amount);
        private set => (this.Amount, this.Currency) = (value.Amount, value.Currency);
    }

    public static DeliveryPrice CreateNew(string name, string description, Money price)
        => new DeliveryPrice
        {
            Id = Guid.NewGuid(),
            Name = name,
            Price = price,
            Description = description
        };
}