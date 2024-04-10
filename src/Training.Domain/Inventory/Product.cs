using Training.Domain.Sales;

namespace Training.Domain.Inventory;

/// <summary>
/// Represents a product in the SellNet domain.
/// </summary>
public class Product : Entity
{
    private Product() { }
    
    /// <summary>
    /// Gets the name of the product.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the unique identifier of the supplier of the product.
    /// </summary>
    public Guid SupplierId { get; private set; }

    /// <summary>
    /// Gets the unique identifier of the warehouse where the product is stored.
    /// </summary>
    public Guid WarehouseId { get; private set; }

    public Warehouse Warehouse { get; private set; } = default!;

    /// <summary>
    /// Gets the unique identifier of the brand of the product.
    /// </summary>
    public Guid ProductBrandId { get; private set; }
    
    /// <summary>
    /// Gets the unique identifier of the type of the product.
    /// </summary>
    public Guid ProductTypeId { get; private set; }

    /// <summary>
    /// Description of the product.
    /// </summary>
    public string Description { get; private set; } = string.Empty;

    /// <summary>
    /// Stock of the product.
    /// </summary>
    public int Stock { get; private set; }

    /// <summary>
    /// Reorder level represents the minimum stock level at which the product should be reordered.
    /// </summary>
    public int ReorderLevel { get; private set; }

    /// <summary>
    /// Tax rate applied to the product.
    /// </summary>
    public decimal Tax { get; private set; }

    /// <summary>
    /// Purchase Price very util for analysis.
    /// </summary>
    public Money PurchasePrice
    {
        get => this.Currency.Amount(this.PurchasePriceAmount);
        private set => (this.PurchasePriceAmount, this.Currency) = (value.Amount, value.Currency);
    }

    private decimal PurchasePriceAmount { get; set; } // Used by EF Core

    private Currency Currency { get; set; } // Used by EF Core

    public ICollection<ProductPicture> ProductPictures { get; set; } = [];

    public static Product Create(
        Guid supplierId,
        Guid wareHouseId,
        Guid productBrandId,
        Guid productTypeId,
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
            ProductBrandId = productBrandId,
            ProductTypeId = productTypeId,
            Name = name,
            Description = description,
            Stock = stock,
            ReorderLevel = reorderLevel,
            Tax = tax,
            PurchasePrice = purchasePrice,
        };
}