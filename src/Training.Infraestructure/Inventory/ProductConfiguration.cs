namespace Training.Infraestructure;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> Builder)
    {
        Builder.Property(Prop => Prop.Id).ValueGeneratedOnAdd();

        Builder.Property(Prop => Prop.Description)
            .HasMaxLength(255)
            .IsRequired();

        Builder.HasOne(Prop => Prop.Warehouse)
            .WithMany(Collection => Collection.Products)
            .HasForeignKey(Prop => Prop.WarehouseId);

        Builder.HasQueryFilter(Prop => Prop.DeletedAt != null);
        Builder.HasIndex(Prop => Prop.Name).IsUnique();

        Builder.Property(Prop => Prop.Tax)
            .HasColumnType("decimal(18, 2)");

        Builder.Property<decimal>("PurchasePriceAmount")
            .HasColumnName("PurchasePrice")
            .IsRequired()
            .HasColumnType("decimal(18, 2)");

        Builder.Property<Currency>("Currency")
            .HasColumnName("Currency")
            .HasConversion(currency => currency.Symbol, symbol => new Currency(symbol))
            .IsRequired();

        Builder.HasOne<ProductBrand>().WithMany().HasForeignKey(Prop => Prop.ProductBrandId);
        Builder.HasMany<ProductPicture>().WithOne().HasForeignKey(Prop => Prop.ProductId);
        Builder.HasOne<ProductType>().WithMany().HasForeignKey(Prop => Prop.ProductTypeId);
        Builder.HasOne<Supplier>().WithMany().HasForeignKey(Prop => Prop.SupplierId);

        Builder.Ignore(Prop => Prop.PurchasePrice);
    }
}
