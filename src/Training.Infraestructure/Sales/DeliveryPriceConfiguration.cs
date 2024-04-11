namespace Training.Infraestructure;

public class DeliveryPriceConfiguration : IEntityTypeConfiguration<DeliveryPrice>
{
    public void Configure(EntityTypeBuilder<DeliveryPrice> Builder)
    {
        Builder.Property(Prop => Prop.Id).ValueGeneratedOnAdd();
        Builder.Property(Prop => Prop.Name).HasMaxLength(50).IsRequired();
        Builder.Property(Prop => Prop.Description).HasMaxLength(100).IsRequired();
        Builder.Property<decimal>("Amount").HasColumnName("Amount").IsRequired().HasColumnType("decimal(18, 2)");
        Builder.Property<Currency>("Currency").HasColumnName("Currency").HasConversion(currency => currency.Symbol, symbol => new Currency(symbol)).IsRequired();
        Builder.HasMany(Prop => Prop.InvoiceRecords).WithOne(Prop => Prop.DeliveryPrice).HasForeignKey(Prop => Prop.DeliveryPriceId)
            .HasConstraintName("IX_InvoiceRecords_DeliveryPrice_DeliveryPriceId");

        Builder.Ignore(Prop => Prop.Price);
    }
}
