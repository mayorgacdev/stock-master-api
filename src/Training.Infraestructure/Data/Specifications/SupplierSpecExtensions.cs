namespace Training.Infraestructure.Data.Specifications;

using Training.Common;

public static class SupplierSpecExtensions
{ 
    public static ISpecificationBuilder<Supplier> ApplyOrdering(this ISpecificationBuilder<Supplier> Builder, BaseFilter? Filter = null)
    {
        if (Filter is null) return Builder.OrderBy(Prop => Prop.Id);

        var IsAscending = !(Filter.OrderBy?.Equals("desc", StringComparison.OrdinalIgnoreCase) ?? false);

        return Filter.SortBy switch
        {
            nameof(Supplier.Name) => IsAscending ? Builder.OrderBy(Prop => Prop.Name) : Builder.OrderByDescending(Prop => Prop.Id),
            nameof(Supplier.Email) => IsAscending ? Builder.OrderBy(Prop => Prop.Email) : Builder.OrderByDescending(Prop => Prop.Address),
            _ => Builder.OrderBy(Prop => Prop.Id)
        };
    }

    public static ISpecificationBuilder<Supplier> TagWith(this ISpecificationBuilder<Supplier> Builder, string Tag)
    {
        Builder.Specification.Items.TryAdd("TagWith", Tag);
        return Builder;
    }

    public static ISpecificationBuilder<Supplier> ByName(this ISpecificationBuilder<Supplier> Builder, string? Name)
        => (Name is not null) ? Builder.Where(Prop => Prop.Name.Contains(Name)) : Builder;

    public static ISpecificationBuilder<Supplier> ByEmail(this ISpecificationBuilder<Supplier> Builder, string? City)
        => (City is not null) ? Builder.Where(Prop => Prop.Email.Contains(City)) : Builder;

    public static ISpecificationBuilder<Supplier> IncludeAll(this ISpecificationBuilder<Supplier> Builder)
        => Builder.Include(Prop => Prop.Products);  
}
