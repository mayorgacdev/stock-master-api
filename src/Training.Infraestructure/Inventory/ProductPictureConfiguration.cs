namespace Training.Infraestructure;

public class ProductPictureConfiguration : IEntityTypeConfiguration<ProductPicture>
{
    public void Configure(EntityTypeBuilder<ProductPicture> Builder)
    {
        Builder.Property(Prop => Prop.Id).ValueGeneratedOnAdd();
        Builder.Property(Prop => Prop.PictureUrl).IsRequired();

        Builder.ToTable(nameof(ProductPicture));
    }
}
