namespace Training.Infraestructure;

public interface IRepository<TEntity>
{
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    void Update(TEntity entity);
    Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);
    Task<List<TResult>> ListAsync<TResult>(ISpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default);
}


public interface IReadRepository<TEntity> where TEntity : class
{
    Task<PagedResponse<TResult>> ProjectToListAsync<TResult>(ISpecification<TEntity> specification, BaseFilter filter, CancellationToken cancellationToken);
    Task<List<TResult>> ProjectToListAsync<TResult>(ISpecification<TEntity> specification, CancellationToken cancellationToken);
}