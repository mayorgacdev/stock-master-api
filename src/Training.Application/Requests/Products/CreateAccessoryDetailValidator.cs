namespace Training.Application.Requests.Products;

using FluentValidation;

public class CreateAccessoryDetailValidator : AbstractValidator<CreateAccessoryDetailRequest>
{
    public CreateAccessoryDetailValidator()
    {
        RuleFor(x => x.CreateAccesoriesRequest)
            .AccesoriesNotExistAsync().NotNull();

        RuleFor(x => x.ProductId).NotEmpty();
    }
}