namespace Training.WebApi;

[ApiController]
[Route("api/[controller]")]
public class CustomersController(ICustomerService CustomerService) :  ControllerBase
{
    [HttpGet(Name = "GetCustomers")]
    public Task<PagedResponse<CustomerInfo>> FetchCustomersAsync([FromBody] CustomerFilter Filter)
    {
       return CustomerService.FetchCustomers(Filter);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCurstomerRequest request)
    {
        await CustomerService.CreateCustomer(request);
        return Ok();
    }
}
