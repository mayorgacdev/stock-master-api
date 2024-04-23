namespace Training.Domain.Inventory;

/// <summary>
/// Represents a price for a product in the SellNet domain.
/// </summary>
public class ProductPrice : Entity
{
    /// <summary>
    /// Private constructor to prevent direct instantiation. Use the Create method instead.
    /// </summary>
    private ProductPrice() { }

    /// <summary>
    /// Gets the valid from date of the product price.
    /// </summary>
    public DateTime ValidFrom { get; private set; } = DateTime.MinValue;

    /// <summary>
    /// Gets the unique identifier of the associated product.
    /// </summary>
    public Guid ProductId { get; private set; } = Guid.Empty;

    public Product Product { get; private set; } = default!;

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

    /// <summary>
    /// Creates a new instance of the ProductPrice class associated with a product.
    /// </summary>
    /// <param name="Product">The product associated with the price.</param>
    /// <param name="Price">The total price of the product.</param>
    /// <param name="ValidFrom">The valid from date of the product price.</param>
    /// <returns>A new ProductPrice instance.</returns>
    public static ProductPrice For(Product Product, Money Price, DateTime ValidFrom) => For(Product.Id, Price, ValidFrom);

    /// <summary>
    /// Creates a new instance of the ProductPrice class.
    /// </summary>
    /// <param name="ProductId">The unique identifier of the associated product.</param>
    /// <param name="Price">The total price of the product.</param>
    /// <param name="ValidFrom">The valid from date of the product price.</param>
    /// <returns>A new ProductPrice instance.</returns>
    public static ProductPrice For(Guid ProductId, Money Price, DateTime ValidFrom) =>
        new()
        {
            Id = Guid.NewGuid(),
            ProductId = ProductId,
            Price = Price,
            ValidFrom = ValidFrom
        };

    public static ProductPrice ForNew(Money Price, DateTime ValidFrom) 
        => new()
        {
            Id = Guid.NewGuid(),
            Price = Price,
            ValidFrom = ValidFrom
        };


}