namespace Training.Infraestructure.Data.Specifications;

using Training.Infraestructure.Attributes;

[GenerateAutomaticInterface]
public partial class SpecificationGroup(
    ISingleResultSpecification<Product> product,
    ISingleResultSpecification<Warehouse> warehouse,
    ISingleResultSpecification<ProductBrand> productBrand,
    ISingleResultSpecification<ProductType> productType,
    ISingleResultSpecification<Supplier> supplier,
    ISingleResultSpecification<Accesory> accesory,
    ISingleResultSpecification<Part> part) : ISpecificationGroup
{ 
    public ISingleResultSpecification<Product> ProductSpecification => product; 
    public ISingleResultSpecification<Warehouse> WarehouseSpecification => warehouse;
    public ISingleResultSpecification<ProductBrand> BrandSpecification => productBrand;
    public ISingleResultSpecification<ProductType> ProductTypeSpecification => productType;
    public ISingleResultSpecification<Supplier> SupplierSpecification => supplier; 
    public ISingleResultSpecification<Accesory> AccesorySpecification => accesory;
    public ISingleResultSpecification<Part> PartSpecification => part;
}
