namespace Training.Infraestructure.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Customer> CustomerRepository { get; }
    IReadRepository<Customer> CustomerReadRepository { get; }
    
    IReadRepository<Product> ProductReadRepository { get; }
    IRepository<Product> ProductRepository { get; }

    IRepository<ProductPicture> ProductPictureRepository { get; }
    IReadRepository<ProductPicture> ProductPictureReadRepository { get; }

    IRepository<Supplier> SupplierRepository { get; }
    IReadRepository<Supplier> SupplierReadRepository { get; }

    IRepository<Warehouse> WarehouseRepository { get; }
    IReadRepository<Warehouse> WarehouseReadRepository { get; }
    
    IRepository<ProductBrand> ProductBrandRepository { get; }
    IReadRepository<ProductBrand> ProductBrandReadRepository { get; }

    IRepository<ProductType> ProductTypeRepository { get; }
    IReadRepository<ProductType> ProductTypeReadRepository { get; }

    IRepository<Accesory> AccesoryRepository { get; }
    IReadRepository<Accesory> AccesoryReadRepository { get; }


    IRepository<AccesoryDetail> AccesoryDetailRepository { get; }
    IReadRepository<AccesoryDetail> AccesoryDetailReadRepository { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}