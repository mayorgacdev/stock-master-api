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
        Builder.HasMany(Prop => Prop.Products).WithOne(Prop => Prop.Warehouse)
            .HasForeignKey(prop => prop.WarehouseId).OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("IX_Warehouse_Products_ProductId");
        Builder.ToTable(nameof(Warehouse));
    }
}