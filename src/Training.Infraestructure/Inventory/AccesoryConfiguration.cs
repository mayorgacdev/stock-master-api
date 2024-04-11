
namespace Training.Infraestructure.Inventory;

public class AccesoryConfiguration : IEntityTypeConfiguration<Accesory>
{
    public void Configure(EntityTypeBuilder<Accesory> Builder)
    {
        Builder.Property(Prop => Prop.Id).ValueGeneratedOnAdd();
        Builder.Property(Prop => Prop.Description).HasMaxLength(100);
        Builder.Property(Prop => Prop.Notes).HasMaxLength(100);
        Builder.Property(Prop => Prop.IsActive);

        Builder.HasMany(Prop => Prop.AccesoryDetails).WithOne(e => e.Accesory)
            .HasForeignKey(Prop => Prop.AccesoryId).OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("XI_AccesoryDetails_Accesory_AccesoryId");

        Builder.HasMany(Prop => Prop.PartDetails)
            .WithOne(e => e.Accesory)
            .HasForeignKey(Prop => Prop.AccesoryId)
            .OnDelete(DeleteBehavior.Cascade).HasConstraintName("XI_PartDetails_Accesory_AccesoryId");

        Builder.Ignore(Prop => Prop.Price);
        Builder.Property<decimal>("Amount").HasColumnName("Amount").IsRequired().HasColumnType("decimal(18, 2)");
        Builder.Property<Currency>("Currency").HasColumnName("Currency").HasConversion(currency => currency.Symbol, symbol => new Currency(symbol)).IsRequired();

        Builder.HasQueryFilter(e => e.IsActive == true);

        Builder.Ignore(Prop => Prop.Price);
        Builder.ToTable(nameof(Accesory));
    }
}
