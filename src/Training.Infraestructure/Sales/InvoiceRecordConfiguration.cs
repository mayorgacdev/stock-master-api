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

        Builder.HasMany(Prop => Prop.Invoices).WithOne(Prop => Prop.InvoiceRecord)
            .HasForeignKey(Prop => Prop.InvoiceRecordId).HasConstraintName("IX_InvoiceRecord_Invoices_InvoiceRecord_Id");
        
        Builder.Ignore(Prop => Prop.TotalAmount);

        Builder.HasQueryFilter(Prop => Prop.DeletedAt == null);
        Builder.ToTable(nameof(InvoiceRecord));
    }
}
