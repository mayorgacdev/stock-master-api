
namespace Training.Infraestructure;

public class ProductLineConfiguration : IEntityTypeConfiguration<ProductLine>
{
    public void Configure(EntityTypeBuilder<ProductLine> Builder)
    {
        Builder.HasBaseType<InvoiceLine>().ToTable("InvoiceLines");
    }
}
