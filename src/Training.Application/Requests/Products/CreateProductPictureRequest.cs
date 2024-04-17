namespace Training.Application.Requests.Products;

public class CreateProductPictureRequest : IRequest
{
    public required string PictureUrl { get; set; } = string.Empty;
}