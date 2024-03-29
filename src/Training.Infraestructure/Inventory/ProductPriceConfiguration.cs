namespace Training.Infraestructure;

public class ProductPriceConfiguration : IEntityTypeConfiguration<ProductPrice>
{
    public void Configure(EntityTypeBuilder<ProductPrice> builder)
    {
        builder.ToTable(nameof(ProductPrice));
        builder.HasOne<Product>().WithMany().HasForeignKey(Prop => Prop.ProductId).OnDelete(DeleteBehavior.Cascade);
        builder.Ignore(Prop => Prop.Price);
        builder.Property<decimal>("Amount").HasColumnName("Amount").IsRequired().HasColumnType("decimal(18, 2)");
        builder.Property<Currency>("Currency").HasColumnName("Currency").HasConversion(currency => currency.Symbol, symbol => new Currency(symbol)).IsRequired();
    }
}
