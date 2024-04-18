namespace Training.Infraestructure.Data.Specifications;

public static class ProductTypeSpecExtensions
{
    // Make the extension for productType ISpecificationBuilder but in one line
    public static ISpecificationBuilder<ProductType> ByName(this ISpecificationBuilder<ProductType> builder, string? name) 
        => (name is not null) ? builder.Where(x => x.Name == name) : builder;
}
