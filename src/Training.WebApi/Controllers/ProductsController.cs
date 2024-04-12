namespace Training.WebApi.Controllers;

public class ProductsController(IWarehouseService WarehouseService) : TrainingControllerBase
{
    [HttpGet(Name = "FetchProducts")]
    [ProducesResponseType(typeof(PagedResponse<ProductInfo>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    [OutputCache(Duration = 30)]
    public async Task<ActionResult<PagedResponse<ProductInfo>>> FetchProductsAsync([FromQuery] ProductFilter Filter)
    {
        return await WarehouseService.FetchProductsByFilter(Filter);
    }
}
