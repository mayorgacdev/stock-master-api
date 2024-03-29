namespace Training.Infraestructure;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> Builder)
    {
        Builder.Property(Prop => Prop.Id).ValueGeneratedOnAdd();
        Builder.Property(Prop => Prop.Name).HasMaxLength(50).IsRequired();
        Builder.Property(Prop => Prop.Email).HasMaxLength(50).IsRequired();
        Builder.Property(Prop => Prop.Phone).HasMaxLength(50).IsRequired();
        Builder.Property(Prop => Prop.Address).HasMaxLength(50).IsRequired();
        Builder.ToTable(nameof(Supplier));
    }
}
