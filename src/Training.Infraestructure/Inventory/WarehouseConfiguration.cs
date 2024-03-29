namespace Training.Infraestructure;

public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        builder.Property(prop => prop.Id).ValueGeneratedOnAdd();
        builder.Property(prop => prop.Name).HasMaxLength(50).IsRequired();
        // TODO Triggers
        builder.ToTable(nameof(Warehouse));
    }
}
