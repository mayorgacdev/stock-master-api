namespace Training.Infraestructure.Interfaces;

public interface IUnitOfWork : IDisposable
{
    public IRepository<Product> ProductRepository { get; }
    public IRepository<Customer> CustomerRepository { get; }
    Task<int> Commit();
}