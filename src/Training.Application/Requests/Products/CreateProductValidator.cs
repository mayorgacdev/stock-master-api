namespace Training.Application.Requests.Products;

using FluentValidation;

public class CreateProductValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(Prop => Prop.ProductPictureRequest).UniqueProductUrl();
        
        RuleFor(Prop => Prop.TypeId).ProductTypeExistAsync();
        
        RuleFor(Prop => Prop.BrandId).ProductBrandExistAsync();
        RuleFor(Prop => Prop.SupplierId).SupplierExistAsync();
        RuleFor(Prop => Prop.WarehouseId).WarehouseExistAsync();

        RuleFor(Prop => Prop.Name).NotEmpty().MaximumLength(50);
        RuleFor(Prop => Prop.Description).NotEmpty().MaximumLength(100);
    }
}
