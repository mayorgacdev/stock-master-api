namespace Training.WebApi;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection Services, IConfiguration Configuration)
    {
        Services.AddDbContext<TrainingDbContext>(Options => 
        {
            Options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);
        });

        Services.AddScoped<ICustomerService, CustomerService>();
        
        return Services;
    }
}
