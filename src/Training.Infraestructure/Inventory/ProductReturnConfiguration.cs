
namespace Training.Infraestructure.Inventory;

public class ProductReturnConfiguration : IEntityTypeConfiguration<ProductReturn>
{
    public void Configure(EntityTypeBuilder<ProductReturn> Builder)
    {
        Builder.Property(Prop => Prop.Id).ValueGeneratedOnAdd();
        Builder.Property(Prop => Prop.QuantityReturned).IsRequired();
        Builder.Property(Prop => Prop.Reason).HasMaxLength(300).IsRequired();
    }
}
