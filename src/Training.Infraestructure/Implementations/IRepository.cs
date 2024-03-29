namespace Training.Infraestructure;

public interface IRepository<TEntity> where TEntity : class
{
    void Add(TEntity entity);
    void Remove(TEntity entity);
    Task<PagedResponse<TResult>> ProjectToListAsync<TResult>(ISpecification<TEntity> specification, BaseFilter filter, CancellationToken cancellationToken);
    Task<Option<TEntity>> SingleOrNoneAsync(ISpecification<TEntity> specification);
}