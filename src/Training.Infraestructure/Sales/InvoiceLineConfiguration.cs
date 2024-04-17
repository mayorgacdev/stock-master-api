namespace Training.Infraestructure;

public class InvoiceLineConfiguration : IEntityTypeConfiguration<InvoiceLine>
{
    public void Configure(EntityTypeBuilder<InvoiceLine> Builder)
    {
        Builder.HasKey(Prop => new { Prop.ProductId, Prop.InvoiceRecordId });
        
        Builder.Property(Prop => Prop.Description).HasMaxLength(200).IsRequired();
        Builder.Property(Prop => Prop.Quantity).IsRequired();

        Builder.Property<decimal>("Amount").HasColumnName("Amount").HasColumnType("decimal(18, 2)").IsRequired();
        Builder.Property<Currency>("Currency").HasColumnName("Currency").HasConversion(currency => currency.Symbol, symbol => new Currency(symbol)).IsRequired();
        
        Builder.Ignore(Prop => Prop.Price);
    }
}
