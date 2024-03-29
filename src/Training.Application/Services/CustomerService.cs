namespace Training.Application;

[GenerateAutomaticInterface]
public class CustomerService(ISpecification<Customer> specification) : ICustomerService
{
    private readonly ISpecification<Customer> _specification = specification;

    public void FetchCustomersAsync(BaseFilter filter)
    {
    }
}
