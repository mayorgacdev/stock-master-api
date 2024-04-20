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
[ErrorCategory(nameof(CustomerService))]
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
                ProductPrice.For(new Money(ProductPriceRequest.Price, new Currency(ProductPriceRequest.Currency)), ProductPriceRequest.ValidFrom),
                ProductPictures))).Id;
    }

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

    public async Task<EntityId> CreateProductTypeAsync(CreateProductTypeRequest Request)
    {
        await Request.ValidateAndThrowOnFailuresAsync(
                Key(nameof(IUnitOfWork)).Value(UnitOfWork).
                Key(nameof(ISingleResultSpecification<ProductType>)).Value(SpecificationGroup.ProductTypeSpecification));

        return (await UnitOfWork.ProductTypeRepository.AddAsync(
                       ProductType.Create(Request.Name))).Id;
    }

    public async Task<EntityId> CreateProductBrandAsync(CreateProductBrandRequest Request)
    {
        await Request.ValidateAndThrowOnFailuresAsync(
                Key(nameof(IUnitOfWork)).Value(UnitOfWork).
                Key(nameof(ISingleResultSpecification<ProductBrand>)).Value(SpecificationGroup.BrandSpecification));

        return (await UnitOfWork.ProductBrandRepository.AddAsync(
                                  ProductBrand.Create(Request.Name))).Id;
    }

    public async Task<IEnumerable<AccesoryDetailInfo>> CreateAccesoryDetail(CreateAccessoryDetailRequest Request)
    {
        await Request.ValidateAndThrowOnFailuresAsync(
            Key(nameof(IUnitOfWork)).Value(UnitOfWork).
            Key(nameof(ISingleResultSpecification<Accesory>)).Value(SpecificationGroup.AccesorySpecification));
        IEnumerable<Accesory> accesories = Request.CreateAccesoriesRequest.Select(Req => Req.AsAccesory());

        return (await UnitOfWork.AccesoryDetailRepository.AddRangeAsync(
            AccesoryDetail.CreateMany(
                Guid.Parse(Request.ProductId),
                accesories))).AsAccesoryDetailInfo();
    }
}
