using Training.Domain;

namespace Training.Infraestructure;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> Builder)
    {
        Builder.Property(Prop => Prop.Id).ValueGeneratedOnAdd();
        Builder.Property(p => p.Description).HasMaxLength(255).IsRequired();
        Builder.Property(p => p.Stock).IsRequired();
        Builder.Property(p => p.ReorderLevel).IsRequired();
        Builder.Property(p => p.Tax).IsRequired();
        Builder.Property<decimal>("PurchasePriceAmount").HasColumnName("PurchasePrice").HasColumnType("decimal(18, 2)").IsRequired();
        Builder.HasOne<Supplier>().WithMany().HasForeignKey(p => p.SupplierId);
        Builder.HasOne<Warehouse>().WithMany().HasForeignKey(p => p.WarehouseId);
        Builder.HasOne<ProductBrand>().WithMany().HasForeignKey(p => p.ProductBrandId);
        Builder.HasOne<ProductType>().WithMany().HasForeignKey(p => p.ProductTypeId);
    }
}

