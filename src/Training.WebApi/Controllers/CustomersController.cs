namespace Training.WebApi;

[ApiController]
[Route("api/[controller]")]
public class CustomersController(ICustomerService customerService) :  ControllerBase
{
    private readonly ICustomerService _customerService = customerService;

    [HttpGet(Name = "GetCustomers")]
    public async Task<PagedResponse<CustomerInfo>> FetchCustomersAsync()
    {
        BaseFilter baseFilter = new();
        return await _customerService.FetchCustomersAsync(baseFilter);
    }
}
