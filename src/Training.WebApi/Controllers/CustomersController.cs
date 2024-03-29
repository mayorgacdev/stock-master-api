namespace Training.WebApi;

[ApiController]
[Route("api/[controller]")]
public class CustomersController(ICustomerService customerService) :  ControllerBase
{
    private readonly ICustomerService _customerService = customerService;

    [HttpGet(Name = "GetCustomers")]
    public IAsyncEnumerable<CustomerInfo> FetchCustomersAsync()
    {
        return _customerService.FetchCustomersAsync();
    }
}
