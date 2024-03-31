namespace Training.Infraestructure.Data.Specifications;

// Examples how to extend specifications.
// These extensions are applied in Ardalis.Sample.Domain.Specs.CustomerSpec
public static class CustomerSpecExtensions
{
    // Let's assume we want to apply ordering for customers.
    // Conveniently, we can create add an extension method, and use it in any customer spec.
    public static ISpecificationBuilder<Customer> ApplyOrdering(this ISpecificationBuilder<Customer> Builder, BaseFilter? Filter = null)
    {
        // If there is no filter apply default ordering;
        if (Filter is null) return Builder.OrderBy(Prop => Prop.Id);

        // We want the "asc" to be the default, that's why the condition is reverted.
        var IsAscending = !(Filter.OrderBy?.Equals("desc", StringComparison.OrdinalIgnoreCase) ?? false);

        return Filter.SortBy switch
        {
            nameof(Customer.FirtsName) => IsAscending ? Builder.OrderBy(Prop => Prop.FirtsName) : Builder.OrderByDescending(Prop => Prop.FirtsName),
            nameof(Customer.LastName) => IsAscending ? Builder.OrderBy(Prop => Prop.LastName) : Builder.OrderByDescending(Prop => Prop.LastName),
            _ => Builder.OrderBy(Prop => Prop.Id)
        };
    }

    // More complex scenario would be if we want to add a new feature.
    // Let's say we want to add a capability for query tags. We can utilize the Items dictionary in the specification to store the tag.
    // Once we have this in place, we would also need to add an evaluator in SpecificationEvaluator (check the example in Sample.App2)
    public static ISpecificationBuilder<Customer> TagWith(this ISpecificationBuilder<Customer> Builder, string Tag)
    {
        Builder.Specification.Items.TryAdd("TagWith", Tag);
        return Builder;
    }

    public static ISpecificationBuilder<Customer> ByName(this ISpecificationBuilder<Customer> Builder, string? Name)
        => Name is not null ? Builder.Where(Prop => Prop.FirtsName.Contains(Name) || Prop.LastName.Contains(Name)) : Builder;    

    public static ISpecificationBuilder<Customer> ApplySearching(this ISpecificationBuilder<Customer> Builder, CustomerFilter Filter)
        => Filter is not null ? Builder.ByName(Filter.Name).ApplyOrdering() : Builder;
}