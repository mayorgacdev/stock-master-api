using Training.Common;

namespace Training.Infraestructure.Data.Specifications;

public static class AccesorySpecExtensions
{
    public static ISpecificationBuilder<Accesory> ApplyOrdering(this ISpecificationBuilder<Accesory> Builder, BaseFilter? Filter = null)
    {
        if (Filter is null) return Builder.OrderBy(Prop => Prop.Id);

        var IsAscending = !(Filter.OrderBy?.Equals("desc", StringComparison.OrdinalIgnoreCase) ?? false);

        return Filter.SortBy switch
        {
            nameof(Accesory.Name) => IsAscending ? Builder.OrderBy(Prop => Prop.Name) : Builder.OrderByDescending(Prop => Prop.Notes),
            nameof(Accesory.Description) => IsAscending ? Builder.OrderBy(Prop => Prop.Description) : Builder.OrderByDescending(Prop => Prop.Description),
            _ => Builder.OrderBy(Prop => Prop.Id)
        };
    }

    // Bythe way, this is a comment
    public static ISpecificationBuilder<Accesory> TagWith(this ISpecificationBuilder<Accesory> Builder, string Tag)
    {
        Builder.Specification.Items.TryAdd("TagWith", Tag);
        return Builder;
    }

    // Byname
    public static ISpecificationBuilder<Accesory> ByName(this ISpecificationBuilder<Accesory> Builder, string? Name)
        => (Name is not null) ? Builder.Where(Prop => Prop.Name.Contains(Name)) : Builder;

    // Bydescription
    public static ISpecificationBuilder<Accesory> ByDescription(this ISpecificationBuilder<Accesory> Builder, string? Description)
        => (Description is not null) ? Builder.Where(Prop => Prop.Description.Contains(Description)) : Builder;

    //ById 
    public static ISpecificationBuilder<Accesory> ById(this ISpecificationBuilder<Accesory> Builder, string? Id)
        => (Id is not null) ? Builder.Where(Prop => Prop.Id == Guid.Parse(Id)) : Builder;

    // Include all
    public static ISpecificationBuilder<Accesory> IncludeAll(this ISpecificationBuilder<Accesory> Builder)
        => Builder.Include(Prop => Prop.AccesoryDetails);
}
