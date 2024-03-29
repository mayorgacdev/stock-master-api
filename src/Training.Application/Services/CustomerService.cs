namespace Training.Application;

[GenerateAutomaticInterface]
public class CustomerService(TrainingDbContext dbContext) : ICustomerService
{
    private readonly TrainingDbContext _dbContext = dbContext;

    public IAsyncEnumerable<CustomerInfo> FetchCustomersAsync()
    {
        return _dbContext.Customers.Select(c => c.ToCustomerInfo()).ToAsyncEnumerable();
    }
}
