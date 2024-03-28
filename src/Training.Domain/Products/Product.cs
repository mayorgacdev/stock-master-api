namespace Training.Domain;

public class Product : Entity
{
    public string Name { get; private set; } = string.Empty;

    public Guid SupplierId { get; private set; }

    public Guid WarehouseId { get; private set; }

    public Guid ProductBrand { get; private set; }
    
    public Guid ProductTypeId { get; private set; }

    public string Description { get; private set; } = string.Empty;

    public int Stock { get; private set; }

    public int ReorderLevel { get; private set; }

    public decimal Tax { get; private set; }

    public Money PurchasePrice
    {
        get => this.Currency.Amount(this.PurchasePriceAmount);
        private set => (this.PurchasePriceAmount, this.Currency) = (value.Amount, value.Currency);
    }

    private decimal PurchasePriceAmount { get; set; } // Used by EF Core

    private Currency Currency { get; set; } // Used by EF Core

    public static Product Create(
        Guid supplierId,
        Guid wareHouseId,
        string name,
        string description,
        int stock,
        int reorderLevel,
        decimal tax,
        Money purchasePrice)
        => new Product()
        {
            Id = Guid.NewGuid(),
            SupplierId = supplierId,
            WarehouseId = wareHouseId,
            Name = name,
            Description = description,
            Stock = stock,
            ReorderLevel = reorderLevel,
            Tax = tax,
            PurchasePrice = purchasePrice,
        };
}