namespace Training.Domain.Inventory;

public class Part : Entity
{
    private Part() { }

    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }

    /// <summary>
    /// Gets the total price of the product.
    /// </summary>
    public Money Price
    {
        get => this.Currency.Amount(this.Amount);
        private set => (this.Amount, this.Currency) = (value.Amount, value.Currency);
    }

    /// <summary>
    /// Private field representing the amount of the product price.
    /// </summary>
    private decimal Amount { get; set; } = 0;

    /// <summary>
    /// Private field representing the currency of the product price.
    /// </summary>
    private Currency Currency { get; set; }

    public static Part Create(Money price, string name, string description, bool isActive)
        => new()
        {
               Id = Guid.NewGuid(),
               Price = price,
               Name = name,
               Description = description,
               IsActive = isActive
           };

    public ICollection<PartDetail> PartDetails { get; private set; } = new List<PartDetail>();
}
