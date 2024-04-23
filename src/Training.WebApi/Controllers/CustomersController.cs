namespace Training.WebApi.Controllers;

public class CustomersController(ICustomerService CustomerService) : TrainingControllerBase
{
    [HttpGet(Name = "FetchCustomers")]
    [ProducesResponseType(typeof(PagedResponse<CustomerInfo>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    [OutputCache(Duration = 30)]
    public async Task<ActionResult<PagedResponse<CustomerInfo>>> FetchCustomersAsync([FromQuery] CustomerFilter Filter)
    {
        return await CustomerService.FetchCustomersByFilter(Filter);
    }

    [HttpPost(Name = "CreateCustomer")]
    [ProducesResponseType(typeof(IResponse<EntityId>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(IResponse<ErrorResponse>), StatusCodes.Status500InternalServerError)]
    [ProducesErrorResponseType(typeof(IResponse<ErrorResponse>))]
    public async Task<ActionResult<IResponse<EntityId>>> CreateCustomer([FromBody] CreateCurstomerRequest request)
    {
        var ServiceResult = await CustomerService.CreateCustomer(request);
        return StatusCode(StatusCodes.Status201Created, await ServiceResult.ToResponseAsync());
    }
}

// Path: src/Training.WebApi/Controllers/CustomersController.cs