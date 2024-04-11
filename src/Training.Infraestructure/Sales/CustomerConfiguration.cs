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
        Builder.HasMany(Prop => Prop.InvoiceRecords).WithOne(Prop => Prop.Customer).HasForeignKey(Prop => Prop.CustomerId)
            .HasConstraintName("IX_Customer_InvoiceRecord_Customer_Id");
    }
}
