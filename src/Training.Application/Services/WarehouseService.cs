namespace Training.Application.Services;

using Ardalis.Specification;
using Training.Application.Attributes;
using Training.Application.Sales.Requests.Customers;
using Training.Domain.Common;
using Training.Domain.Sales;
using Training.Infraestructure.Interfaces;
using static Training.Application.Constants.ErrorCodePrefix;
using Training.Infraestructure.Data.Specifications;
using Training.Application.Requests;
using static Training.Common.ContextData;
using Training.Domain.Inventory;
using Training.Application.Sales.Requests.Products;
using Training.Application.Requests.Products;
using Training.Application.Mapping;
using Training.Application.Requests.Warehouse;

[GenerateAutomaticInterface]
[Service<IWarehouseService>]
[ErrorCategory(nameof(WarehouseService))]
[ErrorCodePrefix(WarehouseServicePrefix)]
public partial class WarehouseService(
    IUnitOfWork UnitOfWork, 
    ISpecificationGroup SpecificationGroup) : IWarehouseService
{
    [MethodId("0E05AE33-4204-40AE-A24E-6D3DE9E15FBE")]
    public async Task<PagedResponse<ProductInfo>> FetchProductsByFilter(ProductFilter Filter)
    {
        SpecificationGroup.ProductSpecification.Query
            .IncludeAll()
            .ByName(Filter.Name)
            .ByBrandName(Filter.BrandName)
            .ByTypeName(Filter.TypeName)
            .BySupplierName(Filter.SupplierName)
            .ByWarehouseName(Filter.WarehouseName)
            .ApplyOrdering(Filter);

        return await UnitOfWork.ProductReadRepository
            .ProjectToListAsync<ProductInfo>(SpecificationGroup.ProductSpecification, Filter, default);
    }

    [MethodId("AAF3F35D-3BEA-4263-8891-167A90A528C0")]
    public async Task<EntityId> CreateProductAsync(CreateProductRequest Request)
    {
        await Request.ValidateAndThrowOnFailuresAsync(
            Key(nameof(IUnitOfWork)).Value(UnitOfWork).
            Key(nameof(ISingleResultSpecification<Product>)).Value(SpecificationGroup.ProductSpecification));

        IEnumerable<ProductPicture> ProductPictures = Request.ProductPictureRequest.Select(Req => Req.AsProductPicture());
        CreateProductPriceRequest ProductPriceRequest = Request.CreateProductPriceRequest;

        return (await UnitOfWork.ProductRepository.AddAsync(
            Product.Create(
                Guid.Parse(Request.SupplierId),
                Guid.Parse(Request.WarehouseId),
                Guid.Parse(Request.BrandId),
                Guid.Parse(Request.TypeId),
                Request.Name,
                Request.Description,
                Request.Stock,
                Request.ReorderLevel,
                Request.TaxRate,
                Request.Profit,
                ProductPrice.For(
                    new Money(ProductPriceRequest.Price,
                    new Currency(ProductPriceRequest.Currency)), ProductPriceRequest.ValidFrom),
                ProductPictures))).Id;
    }

    [MethodId("B5C4247F-D984-46C4-B6DD-FA2E9F5C25BC")]
    public async Task<EntityId> CreateSupplierAsync(CreateSupplierRequest Request)
    {
        await Request.ValidateAndThrowOnFailuresAsync(
            Key(nameof(IUnitOfWork)).Value(UnitOfWork).
            Key(nameof(ISingleResultSpecification<Supplier>)).Value(SpecificationGroup.SupplierSpecification));

        return (await UnitOfWork.SupplierRepository.AddAsync(
            Supplier.Create(
                Request.Name, 
                Request.Address, 
                Request.Email,
                Request.Phone))).Id;
    }

    [MethodId("381B1260-3CE2-443D-B801-B9741199C51C")]
    public async Task<EntityId> CreateWarehouseAsync(CreateWarehouseRequest Request)
    {
        await Request.ValidateAndThrowOnFailuresAsync(
            Key(nameof(IUnitOfWork)).Value(UnitOfWork).
            Key(nameof(ISingleResultSpecification<Warehouse>)).Value(SpecificationGroup.WarehouseSpecification));

        return (await UnitOfWork.WarehouseRepository.AddAsync(
            Warehouse.Create(
                Request.Name, 
                Request.Max, 
                Request.State,
                Request.City, 
                Request.Capacity))).Id;
    }

    [MethodId("4C8C2991-FB9C-461A-ABAD-3B30A53989D8")]
    public async Task<EntityId> CreateProductTypeAsync(CreateProductTypeRequest Request)
    {
        await Request.ValidateAndThrowOnFailuresAsync(
            Key(nameof(IUnitOfWork)).Value(UnitOfWork).
            Key(nameof(ISingleResultSpecification<ProductType>)).Value(SpecificationGroup.ProductTypeSpecification));

        return (await UnitOfWork.ProductTypeRepository.AddAsync(ProductType.Create(Request.Name))).Id;
    }

    [MethodId("7D26DAF8-DC31-4452-9DA9-88C2DB25A1E1")]
    public async Task<EntityId> CreateProductBrandAsync(CreateProductBrandRequest Request)
    {
        await Request.ValidateAndThrowOnFailuresAsync(
            Key(nameof(IUnitOfWork)).Value(UnitOfWork).
            Key(nameof(ISingleResultSpecification<ProductBrand>)).Value(SpecificationGroup.BrandSpecification));

        return (await UnitOfWork.ProductBrandRepository.AddAsync(ProductBrand.Create(Request.Name))).Id;
    }

    [MethodId("779E6415-6DD9-430D-A7FE-433CF2D850E6")]
    public async Task<IEnumerable<AccesoryDetailInfo>> CreateAccesoryDetailAsync(CreateAccessoryDetailRequest Request)
    {
        await Request.ValidateAndThrowOnFailuresAsync(
            Key(nameof(IUnitOfWork)).Value(UnitOfWork).
            Key(nameof(ISingleResultSpecification<Accesory>)).Value(SpecificationGroup.AccesorySpecification));
        
        IEnumerable<Accesory> Accesories = Request.CreateAccesoriesRequest.Select(Req => Req.AsAccesory());

        return (await UnitOfWork.AccesoryDetailRepository.AddRangeAsync
            (AccesoryDetail.CreateMany(
                Guid.Parse(Request.ProductId), Accesories))).
                AsAccesoryDetailInfo();
    }
    
    [MethodId("997A0D1C-EA7E-4EA1-8D63-9E6D502088D0")]
    public Task<PagedResponse<ProductBrandInfo>> FetchProductBrandsAsync(ProductBrandFilter ProductBrandFilter)
    {
        SpecificationGroup.BrandSpecification.Query
            .ByName(ProductBrandFilter.Name)
            .ApplyOrdering(ProductBrandFilter);

        return UnitOfWork.ProductBrandReadRepository
            .ProjectToListAsync<ProductBrandInfo>(SpecificationGroup.BrandSpecification, ProductBrandFilter, default);
    }

    [MethodId("B7A172E0-C4C9-40A5-9736-67DA9EBC9119")]
    public Task<PagedResponse<ProductTypeInfo>> FetchProductTypesAsync(ProductTypeFilter Filter)
    {
        SpecificationGroup.ProductTypeSpecification.Query.Where(e => e.Name.Contains(Filter.Name ?? string.Empty));

        return UnitOfWork.ProductTypeReadRepository
            .ProjectToListAsync<ProductTypeInfo>(SpecificationGroup.ProductTypeSpecification, Filter, default);
    }

    [MethodId("24862812-4D54-4B79-9B26-751B38764ECC")]
    public Task<PagedResponse<SupplierInfo>> FetchSuppliersAsync(SupplierFilter Filter)
    {
        SpecificationGroup.SupplierSpecification.Query
            .ApplyOrdering(Filter);

        return UnitOfWork.SupplierReadRepository
            .ProjectToListAsync<SupplierInfo>(SpecificationGroup.SupplierSpecification, Filter, default);
    }

    [MethodId("3A6BF993-EEA5-471C-9822-75EAA505AE10")]
    public Task<PagedResponse<WarehouseInfo>> FetchWarehousesAsync(WarehouseFilter Filter)
    {
        SpecificationGroup.WarehouseSpecification.Query
            .ApplyOrdering(Filter);

        return UnitOfWork.WarehouseReadRepository
            .ProjectToListAsync<WarehouseInfo>(SpecificationGroup.WarehouseSpecification, Filter, default);
    }

    [MethodId("764811A5-EDE1-44BF-97CF-E315687005F3")]
    public Task<PagedResponse<AccesoryInfo>> FetchAccesoriesAsync(AccesoryFilter Filter)
    {
        SpecificationGroup.AccesorySpecification.Query
            .ByName(Filter.Name)
            .ById(Filter.Id)
            .ApplyOrdering(Filter);

        return UnitOfWork.AccesoryReadRepository
            .ProjectToListAsync<AccesoryInfo>(SpecificationGroup.AccesorySpecification, Filter, default);
    }

}
