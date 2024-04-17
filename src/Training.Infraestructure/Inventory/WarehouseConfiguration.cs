namespace Training.Infraestructure;

public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> Builder)
    {
        Builder.Property(Prop => Prop.Id).ValueGeneratedOnAdd();
        
        Builder.Property(Prop => Prop.State).HasMaxLength(50).IsRequired();
        Builder.Property(Prop => Prop.City).HasMaxLength(50).IsRequired();
        
        Builder.Property(Prop => Prop.Capacity).IsRequired();
        Builder.Property(Prop => Prop.Max).IsRequired();
        
        Builder.Property(Prop => Prop.Name).HasMaxLength(100).IsRequired();
        Builder.HasIndex(Prop => Prop.Name).IsUnique();

        Builder.HasMany(Prop => Prop.Products).WithOne(Prop => Prop.Warehouse)
            .HasForeignKey(Prop => Prop.WarehouseId).OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("IX_Warehouse_Products_ProductId");

        Builder.HasQueryFilter(Prop => Prop.DeletedAt == null);
        Builder.ToTable(nameof(Warehouse));
    }
}