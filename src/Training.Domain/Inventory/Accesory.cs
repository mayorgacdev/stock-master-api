namespace Training.Domain.Inventory;

public class Accesory : Entity
{ 
    private Accesory() 
    {
        this.AccesoryDetails = new HashSet<AccesoryDetail>();
        this.PartDetails= new HashSet<PartDetail>();
    }

    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string Notes { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }

    /// <summary>
    /// Gets the total price of the product.
    /// </summary>
    public Money PurchasePrice
    {
        get => this.Currency.Amount(this.PurchaseAmount);
        private set => (this.PurchaseAmount, this.Currency) = (value.Amount, value.Currency);
    }

    /// <summary>
    /// Private field representing the amount of the product price.
    /// </summary>
    private decimal PurchaseAmount { get; set; } = 0;

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

    public static Accesory Create(Money price, Money purchasePrice, string name, string description, string notes, bool isActive)
        => new()
           {
               Id = Guid.NewGuid(),
               PurchasePrice = purchasePrice,
               Price = price,
               Name = name,
               Description = description,
               Notes = notes,
               IsActive = isActive
           };

    public ICollection<AccesoryDetail> AccesoryDetails { get; private set; }
    public ICollection<PartDetail> PartDetails { get; private set; } 
}
