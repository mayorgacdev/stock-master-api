namespace Training.Application.Requests.Products;

using FluentValidation;

public class CreateProductValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(Prop => Prop.BrandName).ProductBrandExistAsync();
        RuleFor(Prop => Prop.TypeName).ProductTypeExistAsync();
        RuleFor(Prop => Prop.SupplierName).SupplierExistAsync();
        RuleFor(Prop => Prop.WarehouseName).WarehouseExistAsync();

        RuleFor(Prop => Prop.Name).NotEmpty().MaximumLength(50);
        RuleFor(Prop => Prop.Description).NotEmpty().MaximumLength(100);
    }
}
