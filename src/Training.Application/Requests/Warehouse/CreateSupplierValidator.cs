namespace Training.Application.Requests.Warehouse;

using FluentValidation;

public class CreateSupplierValidator : AbstractValidator<CreateSupplierRequest>
{
    public CreateSupplierValidator()
    {
        RuleFor(Prop => Prop.Name).SupplierNotExistAsync();
        RuleFor(Prop => Prop.Address).NotEmpty();
        RuleFor(Prop => Prop.Phone).NotEmpty();
        RuleFor(Prop => Prop.Email).NotEmpty().EmailAddress();
    }
}
