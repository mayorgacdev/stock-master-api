using Training.Infraestructure.Interfaces;

namespace Training.Infraestructure.Data;

public class TrainingDbContext(DbContextOptions<TrainingDbContext> Options, IMapper Mapper) : DbContext(Options), IUnitOfWork
{
    public DbSet<Customer> Customers => base.Set<Customer>();
    public DbSet<DeliveryPrice> DeliveryPrices => base.Set<DeliveryPrice>();
    public DbSet<Vehicle> Vehicles => base.Set<Vehicle>();
    public DbSet<InvoiceRecord> InvoiceRecords => base.Set<InvoiceRecord>();
    public DbSet<InvoiceLine> InvoiceLines => base.Set<InvoiceLine>();
    public DbSet<Product> Products => base.Set<Product>();
    public DbSet<ProductBrand> ProductBrands => base.Set<ProductBrand>();
    public DbSet<ProductReturn> ProductReturns => base.Set<ProductReturn>();
    public DbSet<ProductType> ProductTypes => base.Set<ProductType>();
    public DbSet<ProductPrice> ProductPrices => base.Set<ProductPrice>();
    public DbSet<ProductPicture> ProductPictures => base.Set<ProductPicture>();
    public DbSet<Warehouse> Warehouses => base.Set<Warehouse>();
    public DbSet<Supplier> Suppliers => base.Set<Supplier>();
    public DbSet<ProductReturn> Deliveries => base.Set<ProductReturn>();
    public DbSet<Part> Parts => base.Set<Part>();
    public DbSet<Accesory> Accesories => base.Set<Accesory>();
    public DbSet<AccesoryDetail> AccesoryDetails => base.Set<AccesoryDetail>();
    public DbSet<PartDetail> PartDetails => base.Set<PartDetail>();

    public IReadRepository<Customer> CustomerReadRepository => new ReadRepository<Customer>(this, Mapper);
    public IReadRepository<Product> ProductReadRepository => new ReadRepository<Product>(this, Mapper);
    public IRepository<Customer> CustomerRepository => new Repository<Customer>(this, Mapper);
    public IRepository<Product> ProductRepository => new Repository<Product>(this, Mapper);
    public IRepository<ProductPicture> ProductPictureRepository => new Repository<ProductPicture>(this, Mapper);

    protected override void OnModelCreating(ModelBuilder ModelBuilder)
    {
        ModelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(ModelBuilder);
    }
}
