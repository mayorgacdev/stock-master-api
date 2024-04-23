namespace Training.Application.Requests.Products;

using FluentValidation;

public class CreateAccesoryWithPartsValidator : AbstractValidator<CreateAccesoryWithPartsRequest>
{
    public CreateAccesoryWithPartsValidator()
    {
        RuleFor(x => x.Id).ProductExistAsync().NotEmpty();
        RuleFor(x => x.Parts).PartsNotExistAsync().NotEmpty();
    }
}
