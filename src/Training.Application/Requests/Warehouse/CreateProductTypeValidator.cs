namespace Training.Application.Requests.Warehouse;

using FluentValidation;

public class CreateProductTypeValidator : AbstractValidator<CreateProductTypeRequest>
{
    public CreateProductTypeValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100).ProductTypeNotExistAsync();
    }
}
