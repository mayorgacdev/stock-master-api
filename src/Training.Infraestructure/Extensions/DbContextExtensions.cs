namespace Training.Infraestructure;

public static class DbContextExtensions
{
    public static IQueryable<TResult> ApplySpecification<TResult, TEntity>(this ISpecificationEvaluator Evaluator, DbContext Context, ISpecification<TEntity, TResult> Specification)
        where TEntity : class
        => Evaluator.GetQuery(Context.Set<TEntity>(), Specification);

    public static IQueryable<TEntity> ApplySpecification<TEntity>(this ISpecificationEvaluator Evaluator, DbContext Context, ISpecification<TEntity> Specification, bool EvaluateCriteriaOnly = false)
        where TEntity : class
        => Evaluator.GetQuery(Context.Set<TEntity>(), Specification, EvaluateCriteriaOnly);

    public static Pagination GetPagination(this Counter Counter, BaseFilter Filter)
        => new(Counter.Value, Filter);

    public static async Task<PagedResponse<TResult>> GetPagedResponse<TEntity, TResult>(
        this Pagination Pagination, 
        ISpecificationEvaluator Evaluator, 
        ISpecification<TEntity> Specification, 
        DbContext Context, 
        IConfigurationProvider ConfigurationProvider)
        where TEntity : class
        => new PagedResponse<TResult>(await Evaluator.ApplySpecification(Context, Specification).Skip(Pagination.Skip).Take(Pagination.Take).ProjectTo<TResult>(ConfigurationProvider).ToListAsync(), Pagination);
}

public record struct Counter(int Value);