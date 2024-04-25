namespace Training.WebApi.Controllers;

public class WarehouseController(IWarehouseService WarehouseService) : TrainingControllerBase
{
    [HttpGet("FetchProducts")]
    [ProducesResponseType(typeof(PagedResponse<ProductInfo>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    [OutputCache(Duration = 30)]
    public async Task<ActionResult<PagedResponse<ProductInfo>>> FetchProductsAsync([FromQuery] ProductFilter Filter)
    {
        return await WarehouseService.FetchProductsByFilter(Filter);
    }

    [HttpGet("FetchProductBrands")]
    [ProducesResponseType(typeof(PagedResponse<ProductBrandInfo>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    [OutputCache(Duration = 30)]
    public async Task<ActionResult<PagedResponse<ProductBrandInfo>>> FetchProductBrandsAsync([FromQuery] ProductBrandFilter Filter)
    {
        return await WarehouseService.FetchProductBrandsAsync(Filter);
    }

    [HttpGet( "FetchProductTypes")]
    [ProducesResponseType(typeof(PagedResponse<ProductTypeInfo>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    [OutputCache(Duration = 30)]
    public async Task<ActionResult<PagedResponse<ProductTypeInfo>>> FetchProductTypesAsync([FromQuery] ProductTypeFilter Filter)
    {
        return await WarehouseService.FetchProductTypesAsync(Filter);
    }

    [HttpGet( "FetchWarehouses")]
    [ProducesResponseType(typeof(PagedResponse<WarehouseInfo>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    [OutputCache(Duration = 30)]
    public async Task<ActionResult<PagedResponse<WarehouseInfo>>> FetchWarehousesAsync([FromQuery] WarehouseFilter Filter)
    {
        return await WarehouseService.FetchWarehousesAsync(Filter);
    }

    [HttpGet( "FetchSuppliers")]
    [ProducesResponseType(typeof(PagedResponse<SupplierInfo>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    [OutputCache(Duration = 30)]
    public async Task<ActionResult<PagedResponse<SupplierInfo>>> FetchSuppliersAsync([FromQuery] SupplierFilter Filter)
    {
        return await WarehouseService.FetchSuppliersAsync(Filter);
    }

    [HttpGet("FetchAccesories")]
    [ProducesResponseType(typeof(PagedResponse<AccesoryInfo>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
    [OutputCache(Duration = 30)]
    public async Task<ActionResult<PagedResponse<AccesoryInfo>>> FetchAccesories([FromQuery] AccesoryFilter Filter)
    {
        return await WarehouseService.FetchAccesoriesAsync(Filter);
    }

    [HttpPost("CreateProduct")]
    [ProducesResponseType(typeof(IResponse<EntityId>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(IResponse<ErrorResponse>), StatusCodes.Status500InternalServerError)]
    [ProducesErrorResponseType(typeof(IResponse<ErrorResponse>))]
    public async Task<ActionResult<IResponse<EntityId>>> CreateProductAsync([FromBody] CreateProductRequest Request)
    {
        var ServiceResult = await WarehouseService.CreateProductAsync(Request);
        return StatusCode(StatusCodes.Status201Created, await ServiceResult.ToResponseAsync());
    }

    [HttpPost("CreateSupplier")]
    [ProducesResponseType(typeof(IResponse<EntityId>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(IResponse<ErrorResponse>), StatusCodes.Status500InternalServerError)]
    [ProducesErrorResponseType(typeof(IResponse<ErrorResponse>))]
    public async Task<ActionResult<IResponse<EntityId>>> CreateSupplierAsync([FromBody] CreateSupplierRequest Request)
    {
        var ServiceResult = await WarehouseService.CreateSupplierAsync(Request);
        return StatusCode(StatusCodes.Status201Created, await ServiceResult.ToResponseAsync());
    }


    [HttpPost("CreateProductType")]
    [ProducesResponseType(typeof(IResponse<EntityId>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(IResponse<ErrorResponse>), StatusCodes.Status500InternalServerError)]
    [ProducesErrorResponseType(typeof(IResponse<ErrorResponse>))]
    public async Task<ActionResult<IResponse<EntityId>>> CreateProductTypeAsync([FromBody] CreateProductTypeRequest Request)
    {
        var ServiceResult = await WarehouseService.CreateProductTypeAsync(Request);
        return StatusCode(StatusCodes.Status201Created, await ServiceResult.ToResponseAsync());
    }

    [HttpPost("CreateWarehouse")]
    [ProducesResponseType(typeof(IResponse<EntityId>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(IResponse<ErrorResponse>), StatusCodes.Status500InternalServerError)]
    [ProducesErrorResponseType(typeof(IResponse<ErrorResponse>))]
    public async Task<ActionResult<IResponse<EntityId>>> CreateWarehouseAsync([FromBody] CreateWarehouseRequest Request)
    {
        var ServiceResult = await WarehouseService.CreateWarehouseAsync(Request);
        return StatusCode(StatusCodes.Status201Created, await ServiceResult.ToResponseAsync());
    }

    [HttpPost("CreateProductBrand")]
    [ProducesResponseType(typeof(IResponse<EntityId>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(IResponse<ErrorResponse>), StatusCodes.Status500InternalServerError)]
    [ProducesErrorResponseType(typeof(IResponse<ErrorResponse>))]
    public async Task<ActionResult<IResponse<EntityId>>> CreateProductBrandAsync([FromBody] CreateProductBrandRequest Request)
    {
        var ServiceResult = await WarehouseService.CreateProductBrandAsync(Request);
        return StatusCode(StatusCodes.Status201Created, await ServiceResult.ToResponseAsync());
    }

    [HttpPost("CreateAccesoriesForProduct")]
    [ProducesResponseType(typeof(IResponse<EntityId>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(IResponse<ErrorResponse>), StatusCodes.Status500InternalServerError)]
    [ProducesErrorResponseType(typeof(IResponse<ErrorResponse>))]
    public async Task<ActionResult<IResponse<EntityId>>> CreateAccesoriesForProduct([FromBody] CreateAccessoryDetailRequest Request)
    {
        var ServiceResult = await WarehouseService.CreateAccesoriesForProductAsync(Request);
        return StatusCode(StatusCodes.Status201Created, await ServiceResult.ToResponseAsync());
    }

    [HttpPost("CreateAccesory")]
    [ProducesResponseType(typeof(IResponse<EntityId>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(IResponse<ErrorResponse>), StatusCodes.Status500InternalServerError)]
    [ProducesErrorResponseType(typeof(IResponse<ErrorResponse>))]
    public async Task<ActionResult<IResponse<EntityId>>> CreateAccesoryAsync([FromBody] CreateAccesoryRequest Request)
    {
        var ServiceResult = await WarehouseService.CreateAccesoryAsync(Request);
        return StatusCode(StatusCodes.Status201Created, await ServiceResult.ToResponseAsync());
    }

    [HttpPost("CreatePartsForAccesory")]
    [ProducesResponseType(typeof(IResponse<IEnumerable<Guid>>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(IResponse<ErrorResponse>), StatusCodes.Status500InternalServerError)]
    [ProducesErrorResponseType(typeof(IResponse<ErrorResponse>))]
    public async Task<ActionResult<IResponse<EntityId>>> CreatePartsForAccesoryAsync([FromBody] CreatePartsForAccesoryRequest Request)
    {
        var ServiceResult = await WarehouseService.CreatePartsForAccesoryAsync(Request);
        return StatusCode(StatusCodes.Status201Created, await ServiceResult.ToResponseAsync());
    }
}