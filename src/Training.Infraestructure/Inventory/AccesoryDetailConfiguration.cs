namespace Training.Infraestructure.Inventory;

public class AccesoryDetailConfiguration : IEntityTypeConfiguration<AccesoryDetail>
{
    public void Configure(EntityTypeBuilder<AccesoryDetail> Builder)
    {
        Builder.HasKey(Prop => new { Prop.AccesoryId, Prop.ProductId });
        Builder.Property(Prop => Prop.Notes).HasMaxLength(100);

        Builder.ToTable(nameof(AccesoryDetail));
    }
}
