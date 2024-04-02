using FluentValidation;
using Training.Application.Requests;

namespace Training.Application.Validations.Customers;

public class CreateCustomerValidator : AbstractValidator<CreateCurstomerRequest>
{
    public CreateCustomerValidator()
    {
        RuleFor(Prop => Prop.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(Prop => Prop.LastName).NotEmpty().MaximumLength(50);
        RuleFor(Prop => Prop.Email).CustomerUniqueEmailAsync().NotEmpty().MaximumLength(100).EmailAddress();
        RuleFor(Prop => Prop.Phone).NotEmpty().MaximumLength(20);
    }
}
