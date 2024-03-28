namespace Training.Domain;

/// <summary>
/// Represents a picture associated with a product in the SellNet domain.
/// </summary>
public class ProductPicture : Entity
{
    /// <summary>
    /// Private constructor to prevent direct instantiation. Use the Create method instead.
    /// </summary>
    private ProductPicture() { }

    /// <summary>
    /// Gets or sets the URL of the picture.
    /// </summary>
    public string PictureUrl { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the unique identifier of the associated product.
    /// </summary>
    public Guid ProductId { get; set; } = Guid.Empty;

    /// <summary>
    /// Creates a new instance of the productPicture class.
    /// </summary>
    /// <param name="pictureUrl">The name of the product brand.</param>
    /// <returns>A new productPicture instance.</returns>
    public static ProductPicture Create(Guid producId, string pictureUrl)
        => new()
        {
            Id = Guid.NewGuid(),
            ProductId = producId,
            PictureUrl = pictureUrl
        };
}
