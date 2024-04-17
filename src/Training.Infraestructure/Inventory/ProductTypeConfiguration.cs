namespace Training.Infraestructure;

public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
{
    public void Configure(EntityTypeBuilder<ProductType> Builder)
    {
        Builder.Property(Prop => Prop.Id).ValueGeneratedOnAdd();
        Builder.Property(Prop => Prop.Name).HasMaxLength(50).IsRequired();
        Builder.HasIndex(Prop => Prop.Name).IsUnique();

        Builder.HasMany(Prop => Prop.Products).WithOne(Prop => Prop.ProductType).HasForeignKey(Prop => Prop.ProductTypeId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("IX_ProductType_Product_ProductId");

        Builder.HasQueryFilter(Prop => Prop.DeletedAt == null);
        Builder.ToTable(nameof(ProductType));
    }
}
