using Training.Application.Extensions;
using Training.Application.Requests;
using Training.Application.Sales.Requests.Customers;
using Training.Common;
using Training.Domain.Common;

namespace Training.WebApi;

[ApiController]
[Route("api/[controller]")]
public class CustomersController(ICustomerService CustomerService) :  ControllerBase
{
    // TODO: Work with the Caché of this
    [HttpGet(Name = "GetCustomers")]
    [ProducesResponseType(typeof(IResponse<PagedResponse<CustomerInfo>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResponse<ErrorResponse>), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PagedResponse<CustomerInfo>>> FetchCustomersAsync([FromQuery] CustomerFilter Filter)
    {
        return await CustomerService.SearchCustomers(Filter);
    }

    [HttpPost]
    [ProducesResponseType(typeof(IResponse<EntityId>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(IResponse<ErrorResponse>), StatusCodes.Status500InternalServerError)]
    [ProducesErrorResponseType(typeof(IResponse<ErrorResponse>))]
    public async Task<ActionResult<IResponse<EntityId>>> CreateCustomer([FromBody] CreateCurstomerRequest request)
    {
        var ServiceResult = await CustomerService.CreateCustomer(request);
        return StatusCode(StatusCodes.Status201Created, await ServiceResult.ToResponseAsync());
    }
}
