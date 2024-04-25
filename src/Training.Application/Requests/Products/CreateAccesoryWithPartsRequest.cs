using Training.Application.Attributes;

namespace Training.Application.Requests.Products;

[Validator<CreateAccesoryWithPartsValidator>]
public class CreatePartsForAccesoryRequest : IRequest
{
    public required string AccesoryId { get; set; }
    public required CreatePartRequest[] Parts { get; set; }
}
