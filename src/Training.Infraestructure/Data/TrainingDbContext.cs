﻿using Training.Infraestructure.Interfaces;

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
    public DbSet<ProductType> ProductTypes => base.Set<ProductType>();
    public DbSet<ProductPrice> ProductPrices => base.Set<ProductPrice>();
    public DbSet<ProductPicture> ProductPictures => base.Set<ProductPicture>();
    public DbSet<Warehouse> Warehouses => base.Set<Warehouse>();
    public DbSet<Supplier> Suppliers => base.Set<Supplier>();
    public DbSet<ProductReturn> ProductReturns => base.Set<ProductReturn>();
    public DbSet<Part> Parts => base.Set<Part>();
    public DbSet<Accesory> Accesories => base.Set<Accesory>();
    public DbSet<AccesoryDetail> AccesoryDetails => base.Set<AccesoryDetail>();
    public DbSet<PartDetail> PartDetails => base.Set<PartDetail>();

    public IReadRepository<Customer> CustomerReadRepository => new ReadRepository<Customer>(this, Mapper);
    public IReadRepository<Product> ProductReadRepository => new ReadRepository<Product>(this, Mapper);
    public IRepository<Customer> CustomerRepository => new Repository<Customer>(this, Mapper);
    public IRepository<Product> ProductRepository => new Repository<Product>(this, Mapper);
    public IRepository<ProductPicture> ProductPictureRepository => new Repository<ProductPicture>(this, Mapper);
    public IRepository<Supplier> SupplierRepository => new Repository<Supplier>(this, Mapper);
    public IRepository<Warehouse> WarehouseRepository => new Repository<Warehouse>(this, Mapper);
    public IRepository<ProductBrand> ProductBrandRepository => new Repository<ProductBrand>(this, Mapper);
    public IRepository<ProductType> ProductTypeRepository => new Repository<ProductType>(this, Mapper);
    public IRepository<Accesory> AccesoryRepository => new Repository<Accesory>(this, Mapper);
    public IRepository<AccesoryDetail> AccesoryDetailRepository => new Repository<AccesoryDetail>(this, Mapper);
    public IReadRepository<ProductPicture> ProductPictureReadRepository => new ReadRepository<ProductPicture>(this, Mapper);
    public IReadRepository<Supplier> SupplierReadRepository => new ReadRepository<Supplier>(this, Mapper);
    public IReadRepository<Warehouse> WarehouseReadRepository => new ReadRepository<Warehouse>(this, Mapper);
    public IReadRepository<ProductBrand> ProductBrandReadRepository => new ReadRepository<ProductBrand>(this, Mapper);
    public IReadRepository<ProductType> ProductTypeReadRepository => new ReadRepository<ProductType>(this, Mapper);
    public IReadRepository<Accesory> AccesoryReadRepository => new ReadRepository<Accesory>(this, Mapper);
    public IReadRepository<AccesoryDetail> AccesoryDetailReadRepository => new ReadRepository<AccesoryDetail>(this, Mapper);
    public IRepository<Part> PartRepository => new Repository<Part>(this, Mapper);
    public IReadRepository<Part> PartReadRepository => new ReadRepository<Part>(this, Mapper);
    public IRepository<PartDetail> PartDetailRepository => new Repository<PartDetail>(this, Mapper);
    public IReadRepository<PartDetail> PartDetailReadRepository => new ReadRepository<PartDetail>(this, Mapper);

    protected override void OnModelCreating(ModelBuilder ModelBuilder)
    {
        ModelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(ModelBuilder);
    }
}
