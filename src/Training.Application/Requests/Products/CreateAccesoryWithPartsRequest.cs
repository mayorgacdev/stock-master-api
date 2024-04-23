using Training.Application.Attributes;

namespace Training.Application.Requests.Products;

[Validator<CreateAccesoryWithPartsValidator>]
public class CreateAccesoryWithPartsRequest : IRequest
{
    public required string Id { get; set; }
    public required CreatePartRequest[] Parts { get; set; }
}
