namespace Training.Domain.Inventory;

/// <summary>
/// Represents a brand of a product in the SellNet domain.
/// </summary>
public class ProductBrand : Entity
{
    /// <summary>
    /// Private constructor to prevent direct instantiation. Use the Create method instead.
    /// </summary>
    private ProductBrand() 
    {
        Products = new HashSet<Product>();
    }

    /// <summary>
    /// Gets the name of the product brand.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the collection of products associated with the product brand.
    /// </summary>
    public ICollection<Product> Products { get; private set; }
    
    /// <summary>
    /// Creates a new instance of the ProductBrand class.
    /// </summary>
    /// <param name="Name">The name of the product brand.</param>
    /// <returns>A new ProductBrand instance.</returns>
    public static ProductBrand Create(string Name)
        => new()
        {
            Id = Guid.NewGuid(),
            Name = Name
        };
}
