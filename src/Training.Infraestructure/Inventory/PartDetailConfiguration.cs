namespace Training.Infraestructure.Inventory;

public class PartDetailConfiguration : IEntityTypeConfiguration<PartDetail>
{
    public void Configure(EntityTypeBuilder<PartDetail> Builder)
    {
        Builder.HasKey(Prop => new { Prop.PartId, Prop.AccesoryId });
        Builder.Property(Prop => Prop.Notes).HasMaxLength(100);
        Builder.ToTable(nameof(PartDetail));
    }
}
