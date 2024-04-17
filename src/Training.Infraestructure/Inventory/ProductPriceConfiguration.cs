namespace Training.Infraestructure;

public class ProductPriceConfiguration : IEntityTypeConfiguration<ProductPrice>
{
    public void Configure(EntityTypeBuilder<ProductPrice> Builder)
    {
        Builder.ToTable(nameof(ProductPrice));

        Builder.HasQueryFilter(Prop => Prop.ValidFrom <= DateTime.Now);
        Builder.Property<decimal>("Amount").HasColumnName("Amount").IsRequired().HasColumnType("decimal(18, 2)");

        Builder.Ignore(Prop => Prop.Price);
        Builder.Property<Currency>("Currency").HasColumnName("Currency").HasConversion(currency => currency.Symbol, symbol => new Currency(symbol)).IsRequired();

        Builder.HasQueryFilter(Prop => Prop.DeletedAt == null);
    }
}
