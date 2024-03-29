namespace Training.Infraestructure;

public class DbSetRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    private readonly DbSet<TEntity> _dbSet;
    private readonly IQueryable<TEntity> _baseQuery;
    private readonly IConfigurationProvider _configurationProvider;

    public DbSetRepository(DbSet<TEntity> dbSet, IQueryable<TEntity> baseQuery, IConfigurationProvider configurationProvider) =>
        (_dbSet, _baseQuery, _configurationProvider) = (dbSet, baseQuery, configurationProvider);

    public void Add(TEntity entity) => _dbSet.Add(entity);
    public void Remove(TEntity entity) => _dbSet.Remove(entity);

    public async Task<PagedResponse<TResult>> ProjectToListAsync<TResult>(
        ISpecification<TEntity> specification,
        BaseFilter filter,
        CancellationToken cancellationToken)
    {
        var count = await Apply(specification).CountAsync();

        var pagination = new Pagination(count, filter);

        var result = Apply(specification)
            .Skip(pagination.Skip)
            .Take(pagination.Take)
            .ProjectTo<TResult>(_configurationProvider)
            .ToAsyncEnumerable();

        return new PagedResponse<TResult>(result, pagination);
    }

    private IQueryable<TEntity> Apply(ISpecification<TEntity> specification) =>
        specification is QueryableSpecification<TEntity> queryableSpecification ? Apply(queryableSpecification)
        : throw new ArgumentException("Specification is not of expected implementation type", nameof(specification));

    private IQueryable<TEntity> Apply(QueryableSpecification<TEntity> specification)
    {
        IQueryable<TEntity> filteredQuery = specification.Conditions
            .Aggregate(_baseQuery, (query, condition) => query.Where(condition));

        using IEnumerator<(Expression<Func<TEntity, object>> keySelector, bool isAscending)> orderByEnumerator =
            specification.OrderByExpressions.GetEnumerator();

        if (!orderByEnumerator.MoveNext()) return filteredQuery;

        IOrderedQueryable<TEntity> orderedQuery = orderByEnumerator.Current.isAscending
            ? filteredQuery.OrderBy(orderByEnumerator.Current.keySelector)
            : filteredQuery.OrderByDescending(orderByEnumerator.Current.keySelector);

        while (orderByEnumerator.MoveNext())
        {
            orderedQuery = orderByEnumerator.Current.isAscending
                ? orderedQuery.ThenBy(orderByEnumerator.Current.keySelector)
                : orderedQuery.ThenByDescending(orderByEnumerator.Current.keySelector);
        }

        return orderedQuery;
    }

    public async Task<Option<TEntity>> SingleOrNoneAsync(ISpecification<TEntity> specification)
        => (await Apply(specification).SingleOrDefaultAsync()).AsOption();




}
