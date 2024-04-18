namespace Training.Infraestructure.Data.Specifications;

using Training.Common;

public static class ProductBrandSpecExtensions
{
    public static ISpecificationBuilder<ProductBrand> ByName(this ISpecificationBuilder<ProductBrand> Builder, string? Name)
        => (Name is not null) ? Builder.Where(Prop => Prop.Name.Contains(Name)) : Builder;
}
