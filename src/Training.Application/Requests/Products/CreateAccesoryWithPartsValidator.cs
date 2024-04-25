namespace Training.Application.Requests.Products;

using FluentValidation;

public class CreateAccesoryWithPartsValidator : AbstractValidator<CreatePartsForAccesoryRequest>
{
    public CreateAccesoryWithPartsValidator()
    {
        RuleFor(x => x.AccesoryId).NotEmpty();
        RuleFor(x => x.Parts).PartsNotExistAsync().NotEmpty();
    }
}
