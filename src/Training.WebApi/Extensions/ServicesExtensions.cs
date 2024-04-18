using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Training.Application.Attributes;
using Training.Application.Extensions;
using Training.Application.Proxies;
using Training.Infraestructure.Data.Specifications;

namespace Training.WebApi;

public static class ServicesExtensions
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection Services, IConfiguration Configuration)
    {
        Services.AddAutoMapper(typeof(MappingProfile).Assembly);

        Services.AddDbContext<TrainingDbContext>(Options =>
        {
            Options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);
        });
        Services.AddScoped(typeof(ISingleResultSpecification<>), typeof(SingleResultSpecification<>));

        Services.AddScoped<IUnitOfWork, TrainingDbContext>();
        Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        Services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        Services.AddScoped<ISpecificationGroup, SpecificationGroup>();

        return Services;
    }

    public static IServiceCollection AddServicesFromAttribute(this IServiceCollection Services)
    {
        var Types = from Type in typeof(ServiceAttribute<>).Assembly.GetTypes()
                    let ServiceAttribute = Type.LookupGenericAttribute(typeof(ServiceAttribute<>))
                    where ServiceAttribute is not null
                    let InterfaceType = ServiceAttribute.GetType().GetProperty(nameof(ServiceAttribute<IServiceCollection>.InterfaceType))!.GetValue(ServiceAttribute).As<Type>()
                    select (InterfaceType, Type);

        foreach (var (Interface, Type) in Types)
        {
            Services.AddScoped(Interface, Provider => LoggingAdviceServiceInterceptor.Create(Interface, Type, Provider));
        }

        Services.TryAddSingleton<ProxyGenerator>();
        return Services;
    }

    public static IServiceCollection AddTrainingSwaggerGen(this IServiceCollection Services)
    {
        Services.AddSwaggerGen(static SwaggerGenOptions =>
        {
        });

        return Services;
    }
}