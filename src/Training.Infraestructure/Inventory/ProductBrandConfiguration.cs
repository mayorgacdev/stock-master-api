namespace Training.Infraestructure;

public class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrand>
{
    public void Configure(EntityTypeBuilder<ProductBrand> Builder)
    {
        Builder.Property(Prop => Prop.Id).ValueGeneratedOnAdd();
        Builder.Property(Prop => Prop.Name).HasMaxLength(50).IsRequired();
        Builder.HasIndex(Prop => Prop.Name).IsUnique();

        Builder.HasMany(Prop => Prop.Products).WithOne(Prop => Prop.ProductBrand)
            .HasForeignKey(Prop => Prop.ProductBrandId)
            .OnDelete(DeleteBehavior.Cascade).HasConstraintName("IX_Products_ProductBrand_ProductBrandId");

        Builder.HasQueryFilter(Prop => Prop.DeletedAt == null);

        Builder.ToTable(nameof(ProductBrand));
    }
}
