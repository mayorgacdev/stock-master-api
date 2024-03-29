namespace Training.Infraestructure;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> Builder)
    {
        Builder.Property(Prop => Prop.Id).ValueGeneratedOnAdd();
        Builder.Property(Prop => Prop.FirtsName).HasMaxLength(50).IsRequired();
        Builder.Property(Prop => Prop.LastName).HasMaxLength(50).IsRequired();
        Builder.Property(Prop => Prop.Email).HasMaxLength(60).IsRequired();
        Builder.Property(Prop => Prop.Phone).HasMaxLength(15).IsRequired();
    }
}
