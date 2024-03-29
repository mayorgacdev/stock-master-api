namespace Training.Infraestructure;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> Builder)
    {
        Builder.Property(Prop => Prop.Id).ValueGeneratedOnAdd();
        Builder.ToTable(nameof(Vehicle));        
    }
}
