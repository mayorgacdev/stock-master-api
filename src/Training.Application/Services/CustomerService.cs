namespace Training.Application;

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

[GenerateAutomaticInterface]
[Service<ICustomerService>]
[ErrorCategory(nameof(CustomerService))]
[ErrorCodePrefix(CustomerServicePrefix)]
public class CustomerService(IUnitOfWork UnitOfWork, 
    ISingleResultSpecification<Customer> Specification)
{
    [MethodId("DA73FB1A-07F1-4A6B-B5D8-F82C9F181479")]
    public async Task<PagedResponse<CustomerInfo>> FetchCustomersByFilter(CustomerFilter Filter)
    {
        Specification.Query.ApplySearching(Filter);
        return await UnitOfWork.CustomerReadRepository
            .ProjectToListAsync<CustomerInfo>(Specification, Filter, default);
    }

    [MethodId("02CAD161-104E-4750-B17E-C0AC8A1C404C")]
    public async Task<EntityId> CreateCustomer(CreateCurstomerRequest Request)
    {
        await Request.ValidateAndThrowOnFailuresAsync(Key(nameof(IUnitOfWork)).Value(UnitOfWork)
            .Key(nameof(ISingleResultSpecification<Customer>)).Value(Specification));

        return (await UnitOfWork.CustomerRepository
            .AddAsync(Customer.Create(Request.FirstName, Request.LastName, Request.Email, Request.Phone))).Id;
    }
}
// Console.WriteLine(Guid.NewGuid().ToString().ToUpper());