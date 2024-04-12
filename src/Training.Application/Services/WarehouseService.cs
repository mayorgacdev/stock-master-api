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

[GenerateAutomaticInterface]
[Service<IWarehouseService>]
[ErrorCategory(nameof(CustomerService))]
[ErrorCodePrefix(WarehouseServicePrefix)]
public partial class WarehouseService(IUnitOfWork UnitOfWork, ISingleResultSpecification<Product> Specification)
{
    [MethodId("0E05AE33-4204-40AE-A24E-6D3DE9E15FBE")]
    public async Task<PagedResponse<ProductInfo>> FetchProductsByFilter(ProductFilter Filter)
    {
        Specification.Query.IncludeAll()
            .ByName(Filter.Name)
            .ByBrandName(Filter.BrandName)
            .ByTypeName(Filter.TypeName)
            .BySupplierName(Filter.SupplierName)
            .ByWarehouseName(Filter.WarehouseName)
            .ApplyOrdering(Filter); 

        return await UnitOfWork.ProductReadRepository
            .ProjectToListAsync<ProductInfo>(Specification, Filter, default);
    }
}
