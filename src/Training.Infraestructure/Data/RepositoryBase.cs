using Training.Common;
using Training.Infraestructure.Interfaces;

namespace Training.Infraestructure;

public abstract class RepositoryBase<TEntity> : IReadRepository<TEntity> where TEntity : class
{
    private readonly DbContext DbContext;
    private readonly AutoMapper.IConfigurationProvider ConfigurationProvider;
    protected ISpecificationEvaluator Evaluator { get; }

    // We have a custom evaluator for QueryTag, therefore we're passing our custom specification evaluator
    protected RepositoryBase(DbContext dbContext, IMapper Mapper)
        : this(dbContext, AppSpecificationEvaluator.Instance, Mapper)
    {
    }

    protected RepositoryBase(DbContext DbContext, ISpecificationEvaluator SpecificationEvaluator, IMapper Mapper)
    {
        this.DbContext = DbContext;
        Evaluator = SpecificationEvaluator;
        ConfigurationProvider = Mapper.ConfigurationProvider;
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        DbContext.Set<TEntity>().Add(entity);

        await SaveChangesAsync(cancellationToken);

        return entity;
    }
    public virtual async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        DbContext.Set<TEntity>().AddRange(entities);

        await SaveChangesAsync(cancellationToken);

        return entities;
    }
    public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        DbContext.Set<TEntity>().Update(entity);

        await SaveChangesAsync(cancellationToken);
    }
    public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        DbContext.Set<TEntity>().Remove(entity);

        await SaveChangesAsync(cancellationToken);
    }
    public virtual async Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        DbContext.Set<TEntity>().RemoveRange(entities);

        await SaveChangesAsync(cancellationToken);
    }
    public virtual async Task DeleteRangeAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        var query = ApplySpecification(specification);
        DbContext.Set<TEntity>().RemoveRange(query);

        await SaveChangesAsync(cancellationToken);
    }
    public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task<TEntity?> FindAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
    {
        return await DbContext.Set<TEntity>().FindAsync([id], cancellationToken: cancellationToken);
    }
    public async Task<TEntity?> FirstOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
    }
    public async Task<TResult?> FirstOrDefaultAsync<TResult>(ISpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
    }
    public async Task<TEntity?> SingleOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification).SingleOrDefaultAsync(cancellationToken);
    }
    public async Task<TResult?> SingleOrDefaultAsync<TResult>(ISpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification).SingleOrDefaultAsync(cancellationToken);
    }
    public virtual async Task<List<TEntity>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<TEntity>().ToListAsync(cancellationToken);
    }
    public virtual async Task<List<TEntity>> ListAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        var queryResult = await ApplySpecification(specification).ToListAsync(cancellationToken);

        return specification.PostProcessingAction == null ? queryResult : specification.PostProcessingAction(queryResult).ToList();
    }
    public virtual async Task<List<TResult>> ListAsync<TResult>(ISpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default)
    {
        var queryResult = await ApplySpecification(specification).ToListAsync(cancellationToken);

        return specification.PostProcessingAction == null ? queryResult : specification.PostProcessingAction(queryResult).ToList();
    }
    public virtual async Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification, true).CountAsync(cancellationToken);
    }
    public virtual async Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<TEntity>().CountAsync(cancellationToken);
    }
    public virtual async Task<bool> AnyAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification, true).AnyAsync(cancellationToken);
    }
    public virtual async Task<bool> AnyAsync(CancellationToken cancellationToken = default)
    {
        return await DbContext.Set<TEntity>().AnyAsync(cancellationToken);
    }

    public async Task<TResult?> ProjectToFirstOrDefaultAsync<TResult>(ISpecification<TEntity> specification, CancellationToken cancellationToken)
    {
        return await ApplySpecification(specification)
            .ProjectTo<TResult>(ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<TResult>> ProjectToListAsync<TResult>(ISpecification<TEntity> specification, CancellationToken cancellationToken)
    {
        return await ApplySpecification(specification)
            .ProjectTo<TResult>(ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    public async Task<PagedResponse<TResult>> ProjectToListAsync<TResult>(ISpecification<TEntity> specification, BaseFilter filter, CancellationToken cancellationToken)
    {
        var count = await ApplySpecification(specification).CountAsync(cancellationToken);
        var pagination = new Pagination(count, filter);

        var data = await ApplySpecification(specification)
            .Skip(pagination.Skip)
            .Take(pagination.Take)
            .ProjectTo<TResult>(ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new PagedResponse<TResult>(data, pagination);
    }

    protected virtual IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification, bool evaluateCriteriaOnly = false)
    {
        return Evaluator.GetQuery(DbContext.Set<TEntity>(), specification, evaluateCriteriaOnly);
    }
    protected virtual IQueryable<TResult> ApplySpecification<TResult>(ISpecification<TEntity, TResult> specification)
    {
        return Evaluator.GetQuery(DbContext.Set<TEntity>(), specification);
    }
}

public class Repository<T> : RepositoryBase<T>, IRepository<T> where T : class
{
    public Repository(TrainingDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
}

public class ReadRepository<T> : RepositoryBase<T>, IReadRepository<T> where T : class
{
    public ReadRepository(TrainingDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
}
