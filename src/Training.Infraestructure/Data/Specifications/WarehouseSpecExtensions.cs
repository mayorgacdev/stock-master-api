namespace Training.Infraestructure.Data.Specifications;

using Training.Common;

public static class WarehouseSpecExtensions
{
    public static ISpecificationBuilder<Warehouse> ApplyOrdering(this ISpecificationBuilder<Warehouse> Builder, BaseFilter? Filter = null)
    {
        if (Filter is null) return Builder.OrderBy(Prop => Prop.Id);

        var IsAscending = !(Filter.OrderBy?.Equals("desc", StringComparison.OrdinalIgnoreCase) ?? false);

        return Filter.SortBy switch
        {
            nameof(Warehouse.Name) => IsAscending ? Builder.OrderBy(Prop => Prop.Name) : Builder.OrderByDescending(Prop => Prop.State),
            nameof(Warehouse.City) => IsAscending ? Builder.OrderBy(Prop => Prop.City) : Builder.OrderByDescending(Prop => Prop.Max),
            _ => Builder.OrderBy(Prop => Prop.Id)
        };
    }

    public static ISpecificationBuilder<Warehouse> TagWith(this ISpecificationBuilder<Warehouse> Builder, string Tag)
    {
        Builder.Specification.Items.TryAdd("TagWith", Tag);
        return Builder;
    }

    public static ISpecificationBuilder<Warehouse> ByName(this ISpecificationBuilder<Warehouse> Builder, string? Name)
        => (Name is not null) ? Builder.Where(Prop => Prop.Name.Contains(Name)) : Builder;

    public static ISpecificationBuilder<Warehouse> ByCity(this ISpecificationBuilder<Warehouse> Builder, string? City)
        => (City is not null) ? Builder.Where(Prop => Prop.City.Contains(City)) : Builder;

    public static ISpecificationBuilder<Warehouse> IncludeAll(this ISpecificationBuilder<Warehouse> Builder)
        => Builder.Include(Prop => Prop.Products);
}
