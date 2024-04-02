namespace Training.Infraestructure.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Customer> CustomerRepository { get; }
    IReadRepository<Customer> CustomerReadRepository { get; }
    IReadRepository<Product> ProductReadRepository { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}