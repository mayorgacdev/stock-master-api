namespace Training.Application.Requests.Warehouse;

using Training.Application.Attributes;

[Validator<CreateProductTypeValidator>]
public class CreateProductTypeRequest : IRequest
{
    public string Name { get; set; } = string.Empty;
}
