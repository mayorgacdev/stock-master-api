﻿namespace Training.Domain.Inventory;

/// <summary>
/// Represents a warehouse in the SellNet domain.
/// </summary>
public class Warehouse : Entity
{
    private Warehouse() { }

    /// <summary>
    /// Gets or sets the state where the warehouse is located.
    /// </summary>
    public string State { get; set; } = string.Empty;

    /// <summary>
    /// Gets the city where the warehouse is located.
    /// </summary>
    public string City { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the capacity of the warehouse.
    /// </summary>
    public int Capacity { get; private set; } = 0;

    /// <summary>
    /// Products stored in the warehouse.
    /// </summary>
    public ICollection<Product> Products { get; private set; } = new List<Product>();

    /// <summary>
    /// Creates a new instance of the Warehouse class.
    /// </summary>
    /// <param name="state"></param>
    /// <param name="city"></param>
    /// <returns></returns>
    public static Warehouse Create(string state, string city, int capacity)
        => new()
        {
            Id = Guid.NewGuid(),
            State = state,
            City = city,
            Capacity = capacity
        };

    public static Warehouse CreateWithId(Guid WarehouseId, string state, string city, int capacity)
        => new()
        {
            Id = WarehouseId,
            State = state,
            City = city,
            Capacity = capacity
        };
}
