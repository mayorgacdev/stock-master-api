
namespace Training.Infraestructure;

public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
{
    public void Configure(EntityTypeBuilder<ProductType> builder)
    {
        builder.Property(Prop => Prop.Id).ValueGeneratedOnAdd();
        builder.Property(Prop => Prop.Name).HasMaxLength(50).IsRequired();
        builder.ToTable(nameof(ProductType));
    }
}
