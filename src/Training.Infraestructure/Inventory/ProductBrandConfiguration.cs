
namespace Training.Infraestructure;

public class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrand>
{
    public void Configure(EntityTypeBuilder<ProductBrand> builder)
    {
        builder.Property(Prop => Prop.Id).ValueGeneratedOnAdd();
        builder.Property(Prop => Prop.Name).HasMaxLength(50).IsRequired();
        builder.ToTable(nameof(ProductBrand));
    }
}
