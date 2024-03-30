namespace Training.WebApi;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection Services, IConfiguration Configuration)
    {
        Services.AddAutoMapper(typeof(MappingProfile).Assembly);

        Services.AddDbContext<TrainingDbContext>(Options =>
        {
            Options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);
        });
        Services.AddScoped(typeof(ISingleResultSpecification<>), typeof(SingleResultSpecification<>));

        Services.AddScoped<IUnitOfWork, TrainingDbContext>();
        Services.AddScoped<ICustomerService, CustomerService>();

        Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        Services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));

        return Services;
    }
}