namespace Training.Infraestructure.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Customer> CustomerRepository { get; }
    IReadRepository<Customer> CustomerReadRepository { get; }
    IReadRepository<Product> ProductReadRepository { get; }
    IRepository<Product> ProductRepository { get; }
    IRepository<ProductPicture> ProductPictureRepository { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}