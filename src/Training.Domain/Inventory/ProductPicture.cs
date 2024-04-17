using System;

namespace Training.Domain.Inventory;

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

    public Product Product { get; set; } = default!;

    /// <summary>
    /// Creates a new instance of the productPicture class.
    /// </summary>
    /// <param name="pictureUrl">The name of the product brand.</param>
    /// <returns>A new productPicture instance.</returns>
    public static IEnumerable<ProductPicture> CreateMany(Product product, IEnumerable<ProductPicture> productPictures)
        => productPictures.Select((productPicture, index) => new ProductPicture()
        {
            Id = Guid.NewGuid(),
            Product = product,
            PictureUrl = productPicture.PictureUrl
        });

    public static ProductPicture Create(string PictureUrl)
        => new()
        {
            PictureUrl = PictureUrl
        };
}
