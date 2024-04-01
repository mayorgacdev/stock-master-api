using Training.Common;
using Training.Infraestructure.Interfaces;

namespace Training.Infraestructure;

public abstract class RepositoryBase<TEntity> : IReadRepository<TEntity>
    where TEntity : class
{
    private readonly AutoMapper.IConfigurationProvider ConfigurationProvider;
    private readonly DbContext DbContext;
    protected ISpecificationEvaluator Evaluator { get; }


    protected RepositoryBase(DbContext Context, IMapper Mapper)
        : this(Context, AppSpecificationEvaluator.Instance, Mapper)
    {
        
    }

    protected RepositoryBase(DbContext DbContext, ISpecificationEvaluator Evaluator, IMapper Mapper)
    {
        this.DbContext = DbContext;
        this.Evaluator = Evaluator;
        ConfigurationProvider = Mapper.ConfigurationProvider;
    }

    public async Task<TEntity> AddAsync(TEntity Entity, CancellationToken CancellationToken = default)
    {
        await DbContext.Set<TEntity>().AddAsync(Entity, CancellationToken);
        await DbContext.SaveChangesAsync();
        return Entity;
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> Entities, CancellationToken CancellationToken = default)
        => await DbContext.Set<TEntity>().AddRangeAsync(Entities, CancellationToken);

    public void Update(TEntity Entity)
        => DbContext.Set<TEntity>().Update(Entity);

    public async Task<int> CountAsync(ISpecification<TEntity> Specification, CancellationToken CancellationToken = default)
        => await Evaluator.ApplySpecification(DbContext, Specification, true).CountAsync(CancellationToken);

    public async Task<List<TResult>> ListAsync<TResult>(ISpecification<TEntity, TResult> Specification, CancellationToken CancellationToken)
        => await Evaluator.ApplySpecification(DbContext, Specification).ToListAsync();

    public async Task<List<TResult>> ProjectToListAsync<TResult>(ISpecification<TEntity> Specification, CancellationToken CancellationToken)
        => await Evaluator.ApplySpecification(DbContext, Specification).ProjectTo<TResult>(ConfigurationProvider).ToListAsync();

    public Task<bool> AnyAsync(ISpecification<TEntity> Specification, CancellationToken CancellationToken = default)
        => Evaluator.ApplySpecification(DbContext, Specification, true).AnyAsync(CancellationToken);

    public async Task<PagedResponse<TResult>> ProjectToListAsync<TResult>(ISpecification<TEntity> Specification, BaseFilter Filter, CancellationToken CancellationToken)
        => await new Counter(await CountAsync(Specification, CancellationToken)).GetPagination(Filter).GetPagedResponse<TEntity, TResult>(Evaluator, Specification, DbContext, ConfigurationProvider);
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
