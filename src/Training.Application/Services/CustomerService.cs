namespace Training.Application;

[GenerateAutomaticInterface]
[ServiceAttribute<ICustomerService>]
[ErrorCategory(nameof(CustomerService))]
[ErrorCodePrefix(CustomerServicePrefix)]
public class CustomerService(IUnitOfWork UnitOfWork, ISingleResultSpecification<Customer> Specification) : ICustomerService
{
    [MethodId("DA73FB1A-07F1-4A6B-B5D8-F82C9F181479")]
    public async Task<PagedResponse<CustomerInfo>> SearchCustomers(CustomerFilter Filter)
    {
        Specification.Query.ApplySearching(Filter);
        return await UnitOfWork.CustomerReadRepository.ProjectToListAsync<CustomerInfo>(Specification, Filter, default);
    }

    [MethodId("02CAD161-104E-4750-B17E-C0AC8A1C404C")]
    public async Task<EntityId> CreateCustomer(CreateCurstomerRequest Request)
    {
        await UnitOfWork.CustomerRepository.AddAsync(Request.ToCustomer());
        await UnitOfWork.SaveChangesAsync();
        return new();
    }
}
// Console.WriteLine(Guid.NewGuid().ToString().ToUpper());