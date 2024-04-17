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

[GenerateAutomaticInterface]
[Service<IWarehouseService>]
[ErrorCategory(nameof(CustomerService))]
[ErrorCodePrefix(WarehouseServicePrefix)]
public partial class WarehouseService(
    IUnitOfWork UnitOfWork, 
    ISingleResultSpecification<Product> Specification) : IWarehouseService
{
    [MethodId("0E05AE33-4204-40AE-A24E-6D3DE9E15FBE")]
    public async Task<PagedResponse<ProductInfo>> FetchProductsByFilter(ProductFilter Filter)
    {
        Specification.Query
            .IncludeAll()
            .ByName(Filter.Name)
            .ByBrandName(Filter.BrandName)
            .ByTypeName(Filter.TypeName)
            .BySupplierName(Filter.SupplierName)
            .ByWarehouseName(Filter.WarehouseName)
            .ApplyOrdering(Filter);

        return await UnitOfWork.ProductReadRepository
            .ProjectToListAsync<ProductInfo>(Specification, Filter, default);
    }

    public async Task<EntityId> CreateProductAsync(CreateProductRequest Request)
    {
        await Request.ValidateAndThrowOnFailuresAsync(Key(nameof(IUnitOfWork)).Value(UnitOfWork)
            .Key(nameof(ISingleResultSpecification<Product>)).Value(Specification));

        ProductPicture[] ProductPictures = Request.ProductPictureRequest.Select(Req => Req.AsProductPicture()).ToArray();
        
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
                ProductPictures
                ))).Id;
    }
}
