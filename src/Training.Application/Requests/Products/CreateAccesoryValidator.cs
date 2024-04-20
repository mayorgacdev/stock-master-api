namespace Training.Application.Requests.Products;

using FluentValidation;

public class CreateAccesoryValidator : AbstractValidator<CreateAccesoryRequest>
{
    public CreateAccesoryValidator()
    {
        // TODO: Check database for existing name
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Notes).NotEmpty();
        RuleFor(x => x.IsActive).NotEmpty();
        RuleFor(x => x.PurchaseAmount).NotEmpty();
        RuleFor(x => x.Price).NotEmpty();
    }
}