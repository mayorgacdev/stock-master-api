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

    public Supplier Supplier { get; private set; } = default!;

    /// <summary>
    /// Gets the unique identifier of the warehouse where the product is stored.
    /// </summary>
    public Guid WarehouseId { get; private set; }

    public Warehouse Warehouse { get; private set; } = default!;

    /// <summary>
    /// Gets the unique identifier of the brand of the product.
    /// </summary>
    public Guid ProductBrandId { get; private set; }
    
    public ProductBrand ProductBrand { get; private set; } = default!;
    /// <summary>
    /// Gets the unique identifier of the type of the product.
    /// </summary>
    public Guid ProductTypeId { get; private set; }

    public ProductType ProductType { get; private set; } = default!;

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
    /// Gets the total cost of the product.
    /// </summary>
    public decimal Profit { get; private set; }

    public ProductPrice ProductHistoric { get; private set; } = default!;

    public ICollection<ProductPrice> ProductPrices { get; set; } = [];
    public ICollection<ProductPicture> ProductPictures { get; set; } = [];
    public ICollection<AccesoryDetail> AccesoryDetails { get; set; } = [];


    public static Product Create(
        Guid supplierId,
        Guid wareHouseId,
        Guid productBrandId,
        Guid productTypeId,
        string name,
        string description,
        int stock,
        int reorderLevel,
        decimal tax)
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
                Tax = tax
            };
}