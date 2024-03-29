namespace Training.Infraestructure;

public interface ISpecification<TEntity> where TEntity : class
{
    ISpecification<TEntity> And(Expression<Func<TEntity, bool>> Criteria);
    ISpecification<TEntity> OrderBy(Expression<Func<TEntity, object>> Criteria);
    ISpecification<TEntity> OrderByDescending(Expression<Func<TEntity, object>> Criteria);
}
