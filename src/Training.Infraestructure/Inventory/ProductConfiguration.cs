﻿namespace Training.Infraestructure;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> Builder)
    {
        Builder.Property(Prop => Prop.Id).ValueGeneratedOnAdd();
        Builder.Property(Prop => Prop.Description).HasMaxLength(255).IsRequired();
        Builder.HasOne(Prop => Prop.Warehouse).WithMany(Collection => Collection.Products).HasForeignKey(Prop => Prop.WarehouseId);

        Builder.AfterInsert(Trigger => Trigger
            .Action(Action => Action
            .Condition(Products => Products.New.Stock > 0 && Products.New.Warehouse.Capacity  >= Products.New.Warehouse.Capacity + Products.New.Stock)
                .Update<Warehouse>(
                (Product, Warehouse) => Warehouse.Id == Product.New.WarehouseId,
                (NewProduct, Warehouse) => Warehouse.CreateWithId(Warehouse.Id, Warehouse.State, Warehouse.City, Warehouse.Capacity + NewProduct.New.Stock)
            )));
    }
}
