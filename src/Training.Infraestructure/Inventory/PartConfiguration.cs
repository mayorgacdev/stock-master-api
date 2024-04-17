
namespace Training.Infraestructure.Inventory;

public class PartConfiguration : IEntityTypeConfiguration<Part>
{
    public void Configure(EntityTypeBuilder<Part> Builder)
    {
        Builder.Property(prop => prop.Id).ValueGeneratedOnAdd();
        Builder.Property(prop => prop.Name).HasMaxLength(256).IsRequired();
        Builder.HasIndex(prop => prop.Name).IsUnique();

        Builder.Property(prop => prop.Description).HasMaxLength(500).IsRequired();
        Builder.Property(prop => prop.IsActive);

        Builder.HasMany(Prop => Prop.PartDetails)
            .WithOne(Prop => Prop.Part).HasForeignKey(Prop => Prop.PartId)
            .HasForeignKey("IX_PartDetails_Part_PartId");

        Builder.Property<decimal>("PurchaseAmount").HasColumnName("PurchaseAmount").IsRequired().HasColumnType("decimal(18, 2)");
        Builder.Property<decimal>("Amount").HasColumnName("Amount").IsRequired().HasColumnType("decimal(18, 2)");
        Builder.Property<Currency>("Currency").HasColumnName("Currency").HasConversion(currency => currency.Symbol, symbol => new Currency(symbol)).IsRequired();

        Builder.Ignore(Prop => Prop.Price);
        Builder.Ignore(Prop => Prop.PurchasePrice);

        Builder.HasQueryFilter(Prop => Prop.DeletedAt == null);
        Builder.ToTable(nameof(Part));
    }
}
