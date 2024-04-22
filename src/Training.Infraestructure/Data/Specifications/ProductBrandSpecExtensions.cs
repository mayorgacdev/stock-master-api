namespace Training.Infraestructure.Data.Specifications;

using Training.Common;

public static class ProductBrandSpecExtensions
{
    // Apply Ordering like other extensions
    public static ISpecificationBuilder<ProductBrand> ApplyOrdering(this ISpecificationBuilder<ProductBrand> Builder, BaseFilter? Filter = null)
    {
        if (Filter is null) return Builder.OrderBy(Prop => Prop.Id);

        var IsAscending = !(Filter.OrderBy?.Equals("desc", StringComparison.OrdinalIgnoreCase) ?? false);

        return Filter.SortBy switch
        {
            nameof(Product.Name) => IsAscending ? Builder.OrderBy(Prop => Prop.Name) : Builder.OrderByDescending(Prop => Prop.Id),
            _ => Builder.OrderBy(Prop => Prop.Id)
        };
    }

    public static ISpecificationBuilder<ProductBrand> ByName(this ISpecificationBuilder<ProductBrand> Builder, string? Name)
        => (Name is not null) ? Builder.Where(Prop => Prop.Name.Contains(Name)) : Builder;
}
