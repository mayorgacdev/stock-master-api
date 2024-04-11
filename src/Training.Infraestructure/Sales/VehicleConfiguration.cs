namespace Training.Infraestructure;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> Builder)
    {
        Builder.Property(Prop => Prop.Id).ValueGeneratedOnAdd();
        Builder.HasMany(Prop => Prop.Invoices).WithOne(Prop => Prop.Vehicle).HasForeignKey(Prop => Prop.VehicleId)
            .HasConstraintName("IX_Vehicle_Invoices_Vehicle_Id");
        Builder.ToTable(nameof(Vehicle));        
    }
}
