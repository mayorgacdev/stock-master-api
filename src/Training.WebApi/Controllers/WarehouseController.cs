namespace Training.WebApi.Controllers;

public class WarehouseController(IWarehouseService WarehouseService) : TrainingControllerBase
{
    [HttpGet(Name = "FetchProducts")]
    [ProducesResponseType(typeof(PagedResponse<ProductInfo>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    [OutputCache(Duration = 30)]
    public async Task<ActionResult<PagedResponse<ProductInfo>>> FetchProductsAsync([FromQuery] ProductFilter Filter)
    {
        return await WarehouseService.FetchProductsByFilter(Filter);
    }

    [HttpPost]
    [ProducesResponseType(typeof(IResponse<EntityId>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(IResponse<ErrorResponse>), StatusCodes.Status500InternalServerError)]
    [ProducesErrorResponseType(typeof(IResponse<ErrorResponse>))]
    public async Task<ActionResult<IResponse<EntityId>>> CreateCustomer([FromBody] CreateProductRequest request)
    {
        var ServiceResult = await WarehouseService.CreateProductAsync(request);
        return StatusCode(StatusCodes.Status201Created, await ServiceResult.ToResponseAsync());
    }
}
