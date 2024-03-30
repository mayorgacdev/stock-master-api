using AutoMapper;
using Training.Domain.Sales;

namespace Training.WebApi;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection Services, IConfiguration Configuration)
    {
        Services.AddAutoMapper(Assembly.GetExecutingAssembly());

        Services.AddDbContext<TrainingDbContext>(Options =>
        {
            Options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);
        });

        Services.AddScoped<IUnitOfWork, TrainingDbContext>();
        Services.AddScoped<ICustomerService, CustomerService>();
        Services.AddScoped(typeof(ISpecification<>), typeof(QueryableSpecification<>));


        return Services;
    }
}

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Customer, CustomerInfo>();
        CreateMap<CustomerInfo, Customer>();
    }
}

/*

public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Startup));

        // Otros servicios y configuraciones
        services.AddDbContext<TrainingDbContext>(options =>
        {
            // Configura tu base de datos
        });

        services.AddScoped<IUnitOfWork, TrainingDbContext>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped(typeof(ISpecification<>), typeof(QueryableSpecification<>));

        return services;
    }
*/