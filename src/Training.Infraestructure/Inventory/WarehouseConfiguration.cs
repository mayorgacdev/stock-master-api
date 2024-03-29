namespace Training.Infraestructure;

public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        builder.Property(prop => prop.Id).ValueGeneratedOnAdd();
        builder.Property(prop => prop.State).HasMaxLength(50).IsRequired();
        builder.Property(prop => prop.City).HasMaxLength(50).IsRequired();
        builder.Property(prop => prop.Capacity).IsRequired();
        builder.Property(prop => prop.Max).IsRequired();
        builder.ToTable(nameof(Warehouse));
    }
}