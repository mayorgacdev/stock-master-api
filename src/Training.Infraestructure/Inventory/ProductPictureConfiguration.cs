
namespace Training.Infraestructure;

public class ProductPictureConfiguration : IEntityTypeConfiguration<ProductPicture>
{
    public void Configure(EntityTypeBuilder<ProductPicture> builder)
    {
        builder.Property(Prop => Prop.Id).ValueGeneratedOnAdd();
        builder.Property(Prop => Prop.PictureUrl).HasMaxLength(256).IsRequired();
        builder.ToTable(nameof(ProductPicture));
    }
}
