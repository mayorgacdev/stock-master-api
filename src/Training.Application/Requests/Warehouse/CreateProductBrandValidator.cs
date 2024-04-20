namespace Training.Application.Requests.Warehouse;

using FluentValidation;

public class CreateProductBrandValidator : AbstractValidator<CreateProductBrandRequest>
{
    public CreateProductBrandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100)
            .BrandNotExistAsync();
    }
}
