﻿namespace Training.Infraestructure.Data;

public class TrainingDbContext(DbContextOptions<TrainingDbContext> options, IMapper mapper) : DbContext(options), IUnitOfWork
{
    private readonly IMapper _mapper = mapper;

    public DbSet<Customer> Customers => base.Set<Customer>();
    public DbSet<DeliveryPrice> DeliveryPrices => base.Set<DeliveryPrice>();
    public DbSet<Vehicle> Vehicles => base.Set<Vehicle>();
    public DbSet<InvoiceRecord> InvoiceRecords => base.Set<InvoiceRecord>();
    public DbSet<InvoiceLine> InvoiceLines => base.Set<InvoiceLine>();
    public DbSet<Product> Products => base.Set<Product>();
    public DbSet<ProductBrand> ProductBrands => base.Set<ProductBrand>();
    public DbSet<ProductType> ProductTypes => base.Set<ProductType>();
    public DbSet<ProductPrice> ProductPrices => base.Set<ProductPrice>();
    public DbSet<ProductPicture> ProductPictures => base.Set<ProductPicture>();
    public DbSet<Warehouse> Warehouses => base.Set<Warehouse>();

    public IRepository<Product> ProductRepository => new DbSetRepository<Product>(Products, Products, _mapper.ConfigurationProvider);
    public IRepository<Customer> CustomerRepository => new DbSetRepository<Customer>(Customers, Customers, _mapper.ConfigurationProvider);

    public Task<int> Commit() => base.SaveChangesAsync();

    protected override void OnModelCreating(ModelBuilder ModelBuilder)
    {
        ModelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(ModelBuilder);
    }
}