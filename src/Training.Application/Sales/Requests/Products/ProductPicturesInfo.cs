namespace Training.Application.Sales.Requests.Products;

using Training.Application.Requests;

public class ProductPicturesRequest : IRequest
{
    public Guid Id { get; set; } = Guid.Empty;
    public string PictureUrl { get; set; } = string.Empty;
}
