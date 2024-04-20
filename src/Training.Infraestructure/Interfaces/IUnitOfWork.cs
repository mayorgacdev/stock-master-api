namespace Training.Infraestructure.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Customer> CustomerRepository { get; }
    IReadRepository<Customer> CustomerReadRepository { get; }
    IReadRepository<Product> ProductReadRepository { get; }
    IRepository<Product> ProductRepository { get; }
    IRepository<ProductPicture> ProductPictureRepository { get; }
    IRepository<Supplier> SupplierRepository { get; }
    IRepository<Warehouse> WarehouseRepository { get; }
    IRepository<ProductBrand> ProductBrandRepository { get; }
    IRepository<ProductType> ProductTypeRepository { get; }
    IRepository<Accesory> AccesoryRepository { get; }
    IRepository<AccesoryDetail> AccesoryDetailRepository { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}