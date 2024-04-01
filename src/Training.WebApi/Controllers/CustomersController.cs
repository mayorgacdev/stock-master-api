using Training.Application.Requests;
using Training.Application.Sales.Requests.Customers;
using Training.Common;

namespace Training.WebApi;

[ApiController]
[Route("api/[controller]")]
public class CustomersController(ICustomerService CustomerService) :  ControllerBase
{
    [HttpGet(Name = "GetCustomers")]
    public Task<PagedResponse<CustomerInfo>> FetchCustomersAsync([FromQuery] CustomerFilter Filter)
    {
       return CustomerService.SearchCustomers(Filter);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCurstomerRequest request)
    {
        await CustomerService.CreateCustomer(request);
        return Ok();
    }
}
