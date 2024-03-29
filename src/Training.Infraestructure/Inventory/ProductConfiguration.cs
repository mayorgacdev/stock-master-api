namespace Training.Infraestructure;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> Builder)
    {
        Builder.Property(Prop => Prop.Id).ValueGeneratedOnAdd();

        Builder.Property(Prop => Prop.Description)
            .HasMaxLength(255)
            .IsRequired();
        
        Builder.HasOne(Prop => Prop.Warehouse)
            .WithMany(Collection => Collection.Products)
            .HasForeignKey(Prop => Prop.WarehouseId);
        
        Builder.Property(Prop => Prop.Tax)
            .HasColumnType("decimal(18, 2)");

        Builder.Property<decimal>("PurchasePriceAmount")
            .HasColumnName("PurchasePrice")
            .IsRequired()
            .HasColumnType("decimal(18, 2)");
        
        Builder.Property<Currency>("Currency")
            .HasColumnName("Currency")
            .HasConversion(currency => currency.Symbol, symbol => new Currency(symbol))
            .IsRequired();

        
       /* Builder.AfterInsert(Trigger => Trigger
            .Action(Action => Action
                .Condition(Product => IsValidStock(Product))
                .Condition(Product => IsValidExistenceOnWarehouse(Product))
                .Update<Warehouse>(
                    (Product, Warehouse) => Warehouse.Id == Product.New.WarehouseId,
                    (NewProduct, OldWarehouse) => Warehouse.CreateWithId(
                        OldWarehouse.Id,
                        OldWarehouse.Max,
                        OldWarehouse.State,
                        OldWarehouse.City,
                        OldWarehouse.Capacity + NewProduct.New.Stock)
                )));*/

        Builder.Ignore(Prop => Prop.PurchasePrice);
    }

    
    private static bool IsValidStock(NewTableRef<Product> Product)
    {
        return Product.New.Stock > 0;
    }

    private static bool IsValidExistenceOnWarehouse(NewTableRef<Product> Product)
    {
        return Product.New.Warehouse.Max >= Product.New.Warehouse.Capacity + Product.New.Stock;
    }
}
