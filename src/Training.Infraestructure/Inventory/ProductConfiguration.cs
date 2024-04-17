namespace Training.Infraestructure;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> Builder)
    {
        Builder.Property(Prop => Prop.Id).ValueGeneratedOnAdd();

        Builder.Property(Prop => Prop.Name).HasMaxLength(100).IsRequired();
        Builder.HasIndex(Prop => Prop.Name).IsUnique();

        Builder.Property(Prop => Prop.Description)
            .HasMaxLength(255)
            .IsRequired();

        Builder.HasMany(Prop => Prop.ProductPictures)
            .WithOne(Prop => Prop.Product).HasForeignKey(Prop => Prop.ProductId)
            .HasConstraintName("IX_ProductPictures_Product_ProductId");

        Builder.HasMany(Prop => Prop.AccesoryDetails).WithOne(Prop => Prop.Product)
            .HasForeignKey(Prop => Prop.ProductId)
            .HasConstraintName("IX_AccesoryDetails_Product_ProductId");

        Builder.HasMany(Prop => Prop.ProductPrices).WithOne(Prop => Prop.Product)
            .HasForeignKey(Prop => Prop.ProductId)
            .HasConstraintName("IX_ProductPrices_Product_ProductId");

        Builder.Property(Prop => Prop.Stock).IsRequired();

        Builder.Property(Prop => Prop.ReorderLevel).IsRequired();

        Builder.Property(Prop => Prop.Tax)
            .HasColumnType("decimal(18, 2)");

        Builder.HasQueryFilter(Prop => Prop.DeletedAt == null);
    }
}
