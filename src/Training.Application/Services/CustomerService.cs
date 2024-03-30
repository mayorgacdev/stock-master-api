namespace Training.Application;

[GenerateAutomaticInterface]
public class CustomerService(IUnitOfWork unitOfWork, ISpecification<Customer> specification) : ICustomerService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ISpecification<Customer> _specification = specification;

    public Task<PagedResponse<CustomerInfo>> FetchCustomersAsync(BaseFilter baseFilter)
    {
        return _unitOfWork.CustomerRepository.ProjectToListAsync<CustomerInfo>(_specification.OrderBy(e => e.FirtsName), baseFilter, default);
    }
}
