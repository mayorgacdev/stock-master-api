namespace Training.Infraestructure;

public class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrand>
{
    public void Configure(EntityTypeBuilder<ProductBrand> Builder)
    {
        Builder.Property(Prop => Prop.Id).ValueGeneratedOnAdd();
        Builder.Property(Prop => Prop.Name).HasMaxLength(50).IsRequired();
        Builder.ToTable(nameof(ProductBrand));
    }
}
