namespace Training.Infraestructure;

public class InvoiceRecordConfiguration : IEntityTypeConfiguration<InvoiceRecord>
{
    public void Configure(EntityTypeBuilder<InvoiceRecord> Builder)
    {
        Builder.Property(Prop => Prop.Id).ValueGeneratedOnAdd();
        Builder.Property(Prop => Prop.Status).HasMaxLength(50).IsRequired();
        Builder.Property(Prop => Prop.IssueTime).IsRequired();
        Builder.Property(Prop => Prop.DueDate).IsRequired();
        Builder.Property(Prop => Prop.PaymentTime).IsRequired();
        Builder.ToTable(nameof(InvoiceRecord));
    }
}
