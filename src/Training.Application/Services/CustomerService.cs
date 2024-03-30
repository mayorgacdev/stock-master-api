namespace Training.Application;

[GenerateAutomaticInterface]
public class CustomerService(IUnitOfWork UnitOfWork, ISingleResultSpecification<Customer> Specification) : ICustomerService
{
    public async Task<PagedResponse<CustomerInfo>> FetchCustomers(CustomerFilter Filter)
    {
        Specification.Query.ApplySearching(Filter);
        return await UnitOfWork.CustomerReadRepository.ProjectToListAsync<CustomerInfo>(Specification, Filter, default);
    }

    public async Task CreateCustomer(CreateCurstomerRequest Request)
    {
        await UnitOfWork.CustomerRepository.AddAsync(Request.ToCustomer());
        await UnitOfWork.SaveChangesAsync();
    }
}
