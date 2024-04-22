namespace Training.Application.Requests.Products;

using Training.Application.Attributes;

[Validator<CreateAccessoryDetailValidator>]
public class CreateAccessoryDetailRequest : IRequest
{
    public required CreateAccesoryRequest[] CreateAccesoriesRequest { get; set; }
    public required string ProductId { get; set; }
}
