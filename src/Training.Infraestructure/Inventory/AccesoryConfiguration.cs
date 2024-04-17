
namespace Training.Infraestructure.Inventory;

public class AccesoryConfiguration : IEntityTypeConfiguration<Accesory>
{
    public void Configure(EntityTypeBuilder<Accesory> Builder)
    {
        Builder.Property(Prop => Prop.Id).ValueGeneratedOnAdd();
        Builder.Property(Prop => Prop.Description).HasMaxLength(100);
        Builder.Property(Prop => Prop.Notes).HasMaxLength(100);
        Builder.HasIndex(Prop => Prop.Name);
        Builder.Property(Prop => Prop.Name).HasMaxLength(100).IsRequired();

        Builder.Property(Prop => Prop.IsActive);

        Builder.HasMany(Prop => Prop.AccesoryDetails).WithOne(e => e.Accesory)
            .HasForeignKey(Prop => Prop.AccesoryId).OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("XI_AccesoryDetails_Accesory_AccesoryId");

        Builder.HasMany(Prop => Prop.PartDetails)
            .WithOne(e => e.Accesory)
            .HasForeignKey(Prop => Prop.AccesoryId)
            .OnDelete(DeleteBehavior.Cascade).HasConstraintName("XI_PartDetails_Accesory_AccesoryId");

        Builder.Property<decimal>("Amount").HasColumnName("Amount").IsRequired().HasColumnType("decimal(18, 2)");
        Builder.Property<Currency>("Currency").HasColumnName("Currency").HasConversion(currency => currency.Symbol, symbol => new Currency(symbol)).IsRequired();
        Builder.Property<decimal>("PurchaseAmount").HasColumnName("PurchaseAmount").IsRequired().HasColumnType("decimal(18, 2)");

        Builder.HasQueryFilter(Prop => Prop.DeletedAt == null);
        Builder.HasQueryFilter(e => e.IsActive == true);

        Builder.Ignore(Prop => Prop.Price);
        Builder.Ignore(Prop => Prop.PurchasePrice);
        Builder.ToTable(nameof(Accesory));
    }
}
