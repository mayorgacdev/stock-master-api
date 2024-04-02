namespace Training.Infraestructure;

public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> Builder)
    {
        Builder.Property(prop => prop.Id).ValueGeneratedOnAdd();
        Builder.Property(prop => prop.State).HasMaxLength(50).IsRequired();
        Builder.Property(prop => prop.City).HasMaxLength(50).IsRequired();
        Builder.Property(prop => prop.Capacity).IsRequired();
        Builder.Property(prop => prop.Max).IsRequired();
        Builder.ToTable(nameof(Warehouse));
    }
}