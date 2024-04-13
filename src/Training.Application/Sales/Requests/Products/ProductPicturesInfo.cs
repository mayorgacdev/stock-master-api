namespace Training.Application.Sales.Requests.Products;

public class ProductPicturesInfo
{
    public Guid Id { get; set; } = Guid.Empty;
    public string PictureUrl { get; set; } = string.Empty;
}

public class ProductPriceInfo
{
    public Guid Id { get; set; } = Guid.Empty;
    public decimal Price { get; set; }
    public DateTime ValidFrom { get; set; }
    public Guid ProductId { get; set; } = Guid.Empty;
}

public class WarehouseInfo
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Name { get; private set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public int Capacity { get; set; } = 0;
    public int Max { get; set; } = 0;
}

public class BrandInfo
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Name { get; set; } = string.Empty;
}

public class SupplierInfo
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class ProductTypeInfo
{
    public Guid Id { get; set; } = Guid.Empty;
    public string Name { get; set; } = string.Empty;
}
