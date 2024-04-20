namespace Training.Infraestructure.Inventory;

public class AccesoryDetailConfiguration : IEntityTypeConfiguration<AccesoryDetail>
{
    public void Configure(EntityTypeBuilder<AccesoryDetail> Builder)
    {
        Builder.HasKey(Prop => new { Prop.AccesoryId, Prop.ProductId });
        Builder.ToTable(nameof(AccesoryDetail));
    }
}
