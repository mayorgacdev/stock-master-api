namespace Training.Infraestructure;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> Builder)
    {
        Builder.Property(Prop => Prop.Id).ValueGeneratedOnAdd();
        Builder.Property(Prop => Prop.Name).HasMaxLength(50).IsRequired();
        Builder.Property(Prop => Prop.Email).HasMaxLength(50).IsRequired();
        Builder.HasIndex(Prop => Prop.Email).IsUnique();

        Builder.Property(Prop => Prop.Phone).HasMaxLength(50).IsRequired();
        Builder.Property(Prop => Prop.Address).HasMaxLength(50).IsRequired();
        Builder.HasMany(Prop => Prop.Products).WithOne(Prop => Prop.Supplier).HasForeignKey(Prop => Prop.SupplierId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("IX_Supplier_Products_ProductId");
        
        Builder.HasQueryFilter(Prop => Prop.DeletedAt == null);
        Builder.ToTable(nameof(Supplier));
    }
}
