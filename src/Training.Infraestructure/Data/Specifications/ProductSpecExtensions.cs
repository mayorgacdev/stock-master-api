namespace Training.Infraestructure.Data.Specifications;

using Training.Common;

public static class ProductSpecExtensions 
{
    public static ISpecificationBuilder<Product> ApplyOrdering(this ISpecificationBuilder<Product> Builder, BaseFilter? Filter = null)
    {
        if (Filter is null) return Builder.OrderBy(Prop => Prop.Id);

        var IsAscending = !(Filter.OrderBy?.Equals("desc", StringComparison.OrdinalIgnoreCase) ?? false);

        return Filter.SortBy switch
        {
            nameof(Product.Name) => IsAscending ? Builder.OrderBy(Prop => Prop.Name) : Builder.OrderByDescending(Prop => Prop.Description),
            nameof(Product.Stock) => IsAscending ? Builder.OrderBy(Prop => Prop.Stock) : Builder.OrderByDescending(Prop => Prop.Tax),
            _ => Builder.OrderBy(Prop => Prop.Id)
        };
    }

    public static ISpecificationBuilder<Product> TagWith(this ISpecificationBuilder<Product> Builder, string Tag)
    {
        Builder.Specification.Items.TryAdd("TagWith", Tag);
        return Builder;
    }

    public static ISpecificationBuilder<Product> ByName(this ISpecificationBuilder<Product> Builder, string? Name)
        => (Name is not null) ? Builder.Where(Prop => Prop.Name.Contains(Name)) : Builder;

    public static ISpecificationBuilder<Product> ByBrandName(this ISpecificationBuilder<Product> Builder, string? BrandName)
        => (BrandName is not null) ? Builder.Where(Prop => Prop.ProductBrand.Name.Contains(BrandName)) : Builder;

    public static ISpecificationBuilder<Product> ByTypeName(this ISpecificationBuilder<Product> Builder, string? TypeName)
        => (TypeName is not null) ? Builder.Where(Prop => Prop.ProductType.Name.Contains(TypeName)) : Builder;

    public static ISpecificationBuilder<Product> BySupplierName(this ISpecificationBuilder<Product> Builder, string? SupplierName)  
        => (SupplierName is not null) ? Builder.Where(Prop => Prop.Supplier.Name.Contains(SupplierName)) : Builder;

    public static ISpecificationBuilder<Product> ByWarehouseName(this ISpecificationBuilder<Product> Builder, string? WarehouseName)
        => (WarehouseName is not null) ? Builder.Where(Prop => Prop.Warehouse.Name.Contains(WarehouseName)) : Builder;

    public static ISpecificationBuilder<Product> ByBrandId(this ISpecificationBuilder<Product> Builder, Guid? BrandId)
        => (BrandId is not null) ? Builder.Where(Prop => Prop.ProductBrand.Id == BrandId) : Builder;

    public static ISpecificationBuilder<Product> ByProductTypeId(this ISpecificationBuilder<Product> Builder, Guid? TypeId)
         => (TypeId is not null) ? Builder.Where(Prop => Prop.ProductType.Id == TypeId) : Builder;

    public static ISpecificationBuilder<Product> ByWarehouseId(this ISpecificationBuilder<Product> Builder, Guid? WarehouseId)
         => (WarehouseId is not null) ? Builder.Where(Prop => Prop.Warehouse.Id == WarehouseId) : Builder;

    public static ISpecificationBuilder<Product> BySupplierId(this ISpecificationBuilder<Product> Builder, Guid? SupplierId)
         => (SupplierId is not null) ? Builder.Where(Prop => Prop.Supplier.Id == SupplierId) : Builder;

    public static ISpecificationBuilder<Product> IncludeAll(this ISpecificationBuilder<Product> Builder)
        => Builder.Include(Prop => Prop.Supplier)
            .Include(Prop => Prop.Warehouse)
            .Include(Prop => Prop.ProductBrand)
            .Include(Prop => Prop.ProductType)
            .Include(Prop => Prop.ProductPictures);
}
