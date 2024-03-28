namespace Training.Domain.Products;

/// <summary>
/// Represents a type of product in the SellNet domain.
/// </summary>
public class ProductType : Entity
{
    /// <summary>
    /// Private constructor to prevent direct instantiation. Use the Create method instead.
    /// </summary>
    private ProductType() { }

    /// <summary>
    /// Gets the name of the product type.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the collection of products associated with the product type.
    /// </summary>
    public ICollection<Product> Products { get; private set; } = new List<Product>();

    /// <summary>
    /// Creates a new instance of the ProductType class.
    /// </summary>
    /// <param name="Name">The name of the product type.</param>
    /// <returns>A new ProductType instance.</returns>
    public static ProductType Create(string Name)
        => new()
        {
            Id = Guid.NewGuid(),
            Name = Name
        };
}

