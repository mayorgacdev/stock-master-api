namespace Training.Application.Requests.Warehouse;

using Training.Application.Attributes;

[Validator<CreateProductBrandValidator>]
public class CreateProductBrandRequest : IRequest
{
    public required string Name { get; set; }
}