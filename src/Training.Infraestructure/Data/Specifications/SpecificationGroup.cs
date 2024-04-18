namespace Training.Infraestructure.Data.Specifications;

using Training.Infraestructure.Attributes;

[GenerateAutomaticInterface]
public partial class SpecificationGroup : ISpecificationGroup
{
    public ISingleResultSpecification<Product> ProductSpecification { get; } = new SingleResultSpecification<Product>();
    public ISingleResultSpecification<Warehouse> WarehouseSpecification { get; } = new SingleResultSpecification<Warehouse>();
    public ISingleResultSpecification<ProductBrand> BrandSpecification { get; } = new SingleResultSpecification<ProductBrand>();
    public ISingleResultSpecification<ProductType> ProductTypeSpecification { get; } = new SingleResultSpecification<ProductType>();
    public ISingleResultSpecification<Supplier> SupplierSpecification { get;} = new SingleResultSpecification<Supplier>();
}
